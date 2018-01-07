using DPA_Musicsheets._Shortcuts;
using DPA_Musicsheets.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._States {
    class MusicPlayingState : IState {

        private FileHandler _fileHandler;
        private BaseCommand _firstInChain;

        public MusicPlayingState(FileHandler fileHandler) {
            this._fileHandler = fileHandler;

            /* commands in the chain that can be executed when music is playing */
            BaseCommand command = null;
            _firstInChain = command = new OpenFileCommand();
            command.SetNextChain(command = new SaveAsPDFCommand());
            command.SetNextChain(command = new SaveAsLilypondCommand());
        }

        public void Execute(string pattern) {
            _firstInChain.Handle(_fileHandler, pattern);
        }
    }
}