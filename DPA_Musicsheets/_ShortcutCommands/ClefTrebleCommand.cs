using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._Shortcuts {
    class ClefTrebleCommand : BaseCommand {

        public ClefTrebleCommand() : base("LeftAltC") {
        }

        public override BaseCommand Clone() {
            return new ClefTrebleCommand();
        }

        protected override void Execute() {
            FileHandler.AddText("\\clef treble");
        }
    }
}
