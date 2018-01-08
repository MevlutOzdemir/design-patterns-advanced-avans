
using DPA_Musicsheets.Models;
using PSAMControlLibrary;
using PSAMWPFControlLibrary;
using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DPA_Musicsheets.Factories;
using DPA_Musicsheets.FileReaders;
using DPA_Musicsheets._Lilypond;
using DPA_Musicsheets._Shortcuts;
using GalaSoft.MvvmLight.Ioc;
using DPA_Musicsheets.ViewModels;
using DPA_Musicsheets._FileSaver;
using DPA_Musicsheets._Memento;
using DPA_Musicsheets._States;
using Microsoft.Win32;
using DPA_Musicsheets._StaffSequnce;

namespace DPA_Musicsheets.Managers {
    public class FileHandler {

        private string _lilypondText;
        private FileSaverFactory _fileSaverFactory;

        public IState State { get; set; }
        public string FilePath { get; set; }
        public Caretaker CareTaker { get; set; }    // memento
        public Originator Originator { get; set; }  // memento
        public Sequence MidiSequence { get; set; }
        public List<MusicalSymbol> WPFStaffs { get; set; }

        public event EventHandler<LilypondEventArgs> LilypondTextChanged;
        public event EventHandler<WPFStaffsEventArgs> WPFStaffsChanged;
        public event EventHandler<MidiSequenceEventArgs> MidiSequenceChanged;

        public string LilypondText {
            get { return _lilypondText; }
            set {
                _lilypondText = value;
                LilypondTextChanged?.Invoke(this, new LilypondEventArgs() { LilypondText = value });
            }
        }

        public FileHandler() {
            this._fileSaverFactory = new FileSaverFactory(this);
            this.State = new MusicEditingState(this);
            this.Originator = new Originator();
            this.CareTaker = new Caretaker();
            this.WPFStaffs = new List<MusicalSymbol>();
        }

        public void OpenFile(string path) {
            WPFStaffs.Clear();
            FilePath = path;

            String extension = Path.GetExtension(path);
            IFileReader reader = new FileReaderFactory().Get(extension);
           
            var musicSheet = reader.ReadFile(path);
            var content = musicSheet.SymbolsContent.ToString();
            LoadLilypond(content);

            this.State = new MusicEditingState(this);
        }

        public void LoadLilypond(string content) {
            WPFStaffs.Clear();
            LilypondText = content.Length > 0 ? content : "";

            var tokens = GetTokensFromLilypond(content);
            var staffCollection = new LilypondClient(tokens).Solve();

            WPFStaffs.AddRange(staffCollection);
            WPFStaffsChanged?.Invoke(this, new WPFStaffsEventArgs() { Symbols = WPFStaffs, Message = "" });

            MidiSequence = new StaffHandler().GetSequenceFromWPFStaffs(WPFStaffs);
            MidiSequenceChanged?.Invoke(this, new MidiSequenceEventArgs() { MidiSequence = MidiSequence });
        }

        private static LinkedList<LilypondToken> GetTokensFromLilypond(string content) {
            var tokens = new LinkedList<LilypondToken>();
            var tokenizer = new Tokenizer();

            content = content.Trim().ToLower().Replace("\r\n", " ").Replace("\n", " ").Replace("  ", " ");

            foreach (string s in content.Split(' ')) {
                LilypondToken token = tokenizer.Tokenize(s);

                if (tokens.Last != null) {
                    tokens.Last.Value.NextToken = token;
                    token.PreviousToken = tokens.Last.Value;
                }

                tokens.AddLast(token);
            }

            return tokens;
        }

        public void AddText(string text) {
            var lilypondVm = SimpleIoc.Default.GetInstance<LilypondViewModel>();
            lilypondVm.InsertText(text);
        }

        #region Saving to files (.ly|.pdf|.mid)
        public void Save(string type, string fileName) {
            var saver = _fileSaverFactory.Get(type);

            if (saver != null) {
                saver.Save(fileName, LilypondText);
            }
        }
        #endregion
    }
}
