using DPA_Musicsheets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Models {

    class TimeSignature : IMusicSymbol {

        private int[] _timeSignature;

        public TimeSignature(int[] timeSignature) {
            this._timeSignature = timeSignature;
        }


        /* Bron: https://www.youtube.com/watch?v=e0McxnRboLE */
        // in a 4/4 bar there are 4 quarters (eg. 4 times 1/4) in a bar
        public string ToText() {
            // 0 = no of beats in bar
            // 1 = type of note
            return $"\\time {_timeSignature[0]}/{_timeSignature[1]}";
        }
    }
}
