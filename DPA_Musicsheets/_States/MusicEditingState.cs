using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets._ShortcutCommands;
using DPA_Musicsheets._Shortcuts;
using DPA_Musicsheets.Managers;

namespace DPA_Musicsheets._States {

    class MusicEditingState : IState {

        private FileHandler _fileHandler;
        private BaseCommand _firstInChain;

        public MusicEditingState(FileHandler fileHandler) {
            this._fileHandler = fileHandler;

            /* commands in the chain that can be executed when music is in editing mode */
            BaseCommand command = null;
            _firstInChain = command = new ClefTrebleCommand();
            command.SetNextChain(command = new TempoCommand());
            command.SetNextChain(command = new Time34Command());
            command.SetNextChain(command = new Time44Command());
            command.SetNextChain(command = new Time44Command("LeftAltT4"));
            command.SetNextChain(command = new Time68Command());
            command.SetNextChain(command = new BarlineCommand());
            command.SetNextChain(command = new OpenFileCommand());
            command.SetNextChain(command = new SaveAsPDFCommand());
            command.SetNextChain(command = new SaveAsLilypondCommand());
        }

        public void Execute(string pattern) {
            _firstInChain.Handle(_fileHandler, pattern);
        }


    }
}
