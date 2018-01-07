using DPA_Musicsheets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._Shortcuts {
    class TempoCommand : BaseCommand {

        public TempoCommand() : base("LeftAltS") {
        }

        public override BaseCommand Clone() {
            return new TempoCommand();
        }

        protected override void Execute() {
            var tempo = new Tempo(120);
            var text = tempo.ToText() + " ";
            FileHandler.AddText(text);
        }
    }
}
