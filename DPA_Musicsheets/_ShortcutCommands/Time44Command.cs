using DPA_Musicsheets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._Shortcuts {
    class Time44Command : BaseCommand {

        public Time44Command() : base("LeftAltT") {
        }

        public Time44Command(string pattern) : base(pattern) {
        }


        public override BaseCommand Clone() {
            return new Time44Command();
        }

        protected override void Execute() {
            var timeSignature = new TimeSignature(new int[] { 4, 4 });
            var text = timeSignature.ToText() + " ";
            FileHandler.AddText(text);
        }
    }
}
