using DPA_Musicsheets._Shortcuts;
using DPA_Musicsheets.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._ShortcutCommands {
    class BarlineCommand : BaseCommand {

        public BarlineCommand() : base("LeftAltB") {
        }

        public override BaseCommand Clone() {
            return new BarlineCommand();
        }

        protected override void Execute() {
            FileHandler.AddText("|");
        }
    }
}
