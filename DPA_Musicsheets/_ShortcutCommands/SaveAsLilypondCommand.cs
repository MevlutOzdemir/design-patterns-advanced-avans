using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._Shortcuts {
    class SaveAsLilypondCommand : BaseCommand {

        public SaveAsLilypondCommand() : base("LeftCtrlS") {
        }

        public override BaseCommand Clone() {
            return new SaveAsLilypondCommand();
        }

        protected override void Execute() {
            FileHandler.Save(".ly", FileHandler.FilePath);
        }
    }
}
