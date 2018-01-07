using DPA_Musicsheets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._Shortcuts {
    class Time34Command : BaseCommand {

        public Time34Command() : base("LeftAltT3") {
        }

        public override BaseCommand Clone() {
            return new Time34Command();
        }

        protected override void Execute() {
            var timeSignature = new TimeSignature(new int[] { 3, 4 });
            var text = timeSignature.ToText() + " ";
            FileHandler.AddText(text);
        }
    }
}
