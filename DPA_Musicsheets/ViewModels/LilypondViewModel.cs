using DPA_Musicsheets._States;
using DPA_Musicsheets.Managers;
using DPA_Musicsheets.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace DPA_Musicsheets.ViewModels {
    public class LilypondViewModel : ViewModelBase {


        private bool _textChangedByLoad;

        private string _text;
        private string _textOnLoad;

        private int _cursorLocation;
        private int _saveFiles;
        private int _currentTexts;
        private readonly int MILLISECONDS_BEFORE_CHANGE_HANDLED = 1500;

        private DateTime _lastChange;
        private FileHandler _fileHandler;        
        public event EventHandler<LilypondEventArgs> LilypondTextChanged;
        

        public LilypondViewModel(FileHandler fileHandler) {
            _fileHandler = fileHandler;
            _textChangedByLoad = false;
            _saveFiles = 0;
            _currentTexts = 0;
            //_waitingForRender = false;
            ClickedUndoOrRedo = false;
    
            LilyPondTextChangedFunc();

            _text = "Your lilypond text will appear here.";
        }

        #region properties
        public bool ClickedUndoOrRedo { get; set; }

        /* binding with undo button to toggle state */
        public bool CanUndo { get { return CurrentTexts >= 1; } }
        
        /* binding with redo button to toggle state */
        public bool CanRedo { get { return (SavedFiles - 1) > CurrentTexts; } }

        public int SavedFiles {
            get { return _saveFiles; }
            set {
                _saveFiles = value;
                RaisePropertyChanged(() => CanRedo);
                RaisePropertyChanged(() => CanUndo);
            }
        }

        public int CurrentTexts {
            get { return _currentTexts; }
            set {
                _currentTexts = value;
                RaisePropertyChanged(() => CanRedo);
                RaisePropertyChanged(() => CanUndo);
            }
        }

        public string LilypondText {
            get { return _text; }
            set {
                _text = value;
                RaisePropertyChanged(() => LilypondText);
                LilypondTextChanged?.Invoke(this, new LilypondEventArgs { LilypondText = value });
            }
        }
        #endregion

        #region commands
        public ICommand TextChangedCommand => new RelayCommand<TextChangedEventArgs>((args) => {
            if (!_textChangedByLoad) {
                //_waitingForRender = true;
                _lastChange = DateTime.Now;
                MessengerInstance.Send<CurrentStateMessage>(new CurrentStateMessage() { State = "Rendering..." });

                Task.Delay(MILLISECONDS_BEFORE_CHANGE_HANDLED).ContinueWith((task) => {
                    if ((DateTime.Now - _lastChange).TotalMilliseconds >= MILLISECONDS_BEFORE_CHANGE_HANDLED) {

                        _fileHandler.LoadLilypond(LilypondText);

                        if (ClickedUndoOrRedo == false) {
                            _fileHandler.Originator.Set(LilypondText);
                            _fileHandler.CareTaker.AddMemento(_fileHandler.Originator.StoreInMemento());

                            SavedFiles++;
                            CurrentTexts++;
                        }
                        ClickedUndoOrRedo = false;
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext()); // Request from main thread.
            } else {
                // add's the currently loaded file/text into memento
                _fileHandler.Originator.Set(LilypondText);
                _fileHandler.CareTaker.AddMemento(_fileHandler.Originator.StoreInMemento());
                SavedFiles++;
                _textOnLoad = LilypondText;
            }
        });

        public RelayCommand UndoCommand => new RelayCommand(() => {
            if (CanUndo) {
                CurrentTexts--;
                ClickedUndoOrRedo = true;
                var text = _fileHandler.Originator.RestoreFromMemento(_fileHandler.CareTaker.GetMemento(CurrentTexts));
                LilypondText = text;
            }
        });

        public RelayCommand RedoCommand => new RelayCommand(() => {
            if (CanRedo) {
                CurrentTexts++;
                ClickedUndoOrRedo = true;
                var text = _fileHandler.Originator.RestoreFromMemento(_fileHandler.CareTaker.GetMemento(CurrentTexts));
                LilypondText = text;
            }
        });

        public ICommand SaveAsCommand => new RelayCommand(() => {
            SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Midi|*.mid|Lilypond|*.ly|PDF|*.pdf" };

            if (saveFileDialog.ShowDialog() == true) {
                string extension = Path.GetExtension(saveFileDialog.FileName);

                _fileHandler.Save(extension, saveFileDialog.FileName);
            }
        });

        public ICommand SelectionChangedCommand => new RelayCommand<RoutedEventArgs>((args) => {
            this._cursorLocation = (args.OriginalSource as System.Windows.Controls.TextBox).SelectionStart;
        });
        #endregion

        #region functions
        public void LilyPondTextChangedFunc() {
            _fileHandler.LilypondTextChanged += (src, e) => {
                _textChangedByLoad = true;
                LilypondText = e.LilypondText;
                //LilypondText = _previousText = e.LilypondText;
                _textChangedByLoad = false;
            };
        }

        public void InsertText(string text) {
            LilypondText = _text.Insert(_cursorLocation, text);
        }

        public void SetSaved() {
            _textOnLoad = LilypondText;
        }

        public bool IsFileChanged() {
            return _textOnLoad != LilypondText;
        }
        #endregion
    }
}
