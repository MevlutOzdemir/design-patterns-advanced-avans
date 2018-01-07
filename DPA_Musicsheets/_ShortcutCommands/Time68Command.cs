using DPA_Musicsheets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._Shortcuts {
    class Time68Command : BaseCommand {

        public Time68Command() : base("LeftAltT6") {
        }

        public override BaseCommand Clone() {
            return new Time68Command();
        }

        protected override void Execute() {
            var timeSignature = new TimeSignature(new int[] { 6, 8 });
            var text = timeSignature.ToText() + " ";
            FileHandler.AddText(text);
        }
    }
}
