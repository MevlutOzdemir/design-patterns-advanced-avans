using DPA_Musicsheets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Models {

    class TimeSignature : IMusicSymbol {

        public int[] timeSignature = new int[2];

        public TimeSignature(int[] timeSignature) {
            this.timeSignature = timeSignature;
        }

        public string ToText() {
            return $"\\time {timeSignature[0]}/{timeSignature[1]}";
        }
    }
}
