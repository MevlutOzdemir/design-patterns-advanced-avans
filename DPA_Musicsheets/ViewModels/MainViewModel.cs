using DPA_Musicsheets._States;
using DPA_Musicsheets.Managers;
using DPA_Musicsheets.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Win32;
using PSAMWPFControlLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DPA_Musicsheets.ViewModels {
    public class MainViewModel : ViewModelBase {
        private string _fileName;
        public string FileName {
            get {
                return _fileName;
            }
            set {
                _fileName = value;
                RaisePropertyChanged(() => FileName);
            }
        }

        private string _currentState;
        public string CurrentState {
            get { return _currentState; }
            set { _currentState = value; RaisePropertyChanged(() => CurrentState); }
        }



        private FileHandler _fileHandler;

        public MainViewModel(FileHandler fileHandler) {
            _fileHandler = fileHandler;

            FileName = @"Files/Alle-eendjes-zwemmen-in-het-water.mid";

            MessengerInstance.Register<CurrentStateMessage>(this, (message) => CurrentState = message.State);
        }

        public ICommand OpenFileCommand => new RelayCommand(() => {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Midi or LilyPond files (*.mid *.ly)|*.mid;*.ly" };
            if (openFileDialog.ShowDialog() == true) {
                FileName = openFileDialog.FileName;
            }
        });


        public ICommand ShortcutCommands => new RelayCommand<string>((command) => {
            _fileHandler.State.Execute(command);
        });

        public ICommand LoadCommand => new RelayCommand(() => {
            _fileHandler.OpenFile(FileName);
        });


        public ICommand OnLostFocusCommand => new RelayCommand(() => {
            //Console.WriteLine("Maingrid Lost focus");
        });

        public ICommand OnKeyDownCommand => new RelayCommand<KeyEventArgs>((e) => {
            //Console.WriteLine($"Key down: {e.Key}");

            var patternBuilder = new StringBuilder();
            if (Keyboard.Modifiers == ModifierKeys.Control) {

                if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) {
                    patternBuilder.Append(Key.LeftCtrl.ToString());
                }

                if (Keyboard.IsKeyDown(Key.S))
                    patternBuilder.Append(Key.S.ToString());

                if (Keyboard.IsKeyDown(Key.P))
                    patternBuilder.Append(Key.P.ToString());

                if (Keyboard.IsKeyDown(Key.O))
                    patternBuilder.Append(Key.O.ToString());
            }

            if (Keyboard.Modifiers == ModifierKeys.Alt) {
                if (Keyboard.IsKeyDown(Key.LeftAlt))
                    patternBuilder.Append(Key.LeftAlt.ToString());

                if (Keyboard.IsKeyDown(Key.C))
                    patternBuilder.Append(Key.C.ToString());

                if (Keyboard.IsKeyDown(Key.S))
                    patternBuilder.Append(Key.S.ToString());

                if (Keyboard.IsKeyDown(Key.T))
                    patternBuilder.Append(Key.T.ToString());

                if (Keyboard.IsKeyDown(Key.B))
                    patternBuilder.Append(Key.T.ToString());

                if (Keyboard.IsKeyDown(Key.D3))
                    patternBuilder.Append("3");

                if (Keyboard.IsKeyDown(Key.D4))
                    patternBuilder.Append("4");

                if (Keyboard.IsKeyDown(Key.D6))
                    patternBuilder.Append("6");
            }

            Console.WriteLine(patternBuilder.ToString());
            if (patternBuilder.Length > 0) {
                _fileHandler.State.Execute(patternBuilder.ToString());
            }
        });

        public ICommand OnKeyUpCommand => new RelayCommand(() => {
            //Console.WriteLine("Key Up");
        });

        public ICommand OnWindowClosingCommand => new RelayCommand<CancelEventArgs>(e => {
            var lilypondVm = SimpleIoc.Default.GetInstance<LilypondViewModel>();

            if (lilypondVm.IsFileChanged()) {
                MessageBoxResult result = MessageBox.Show("Je hebt wijzingen aangebracht, weet je zeker dat je wilt afsluiten?",
                    "Bevestiging", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes) {
                    ViewModelLocator.Cleanup();
                    Environment.Exit(0);
                } else {
                    e.Cancel = true;
                }
            } else {
                Environment.Exit(0);
            }
        });
    }
}
