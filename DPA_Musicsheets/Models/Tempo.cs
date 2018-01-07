using DPA_Musicsheets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Models {
    class Tempo : IMusicSymbol {

        public int Temp { set; get; }
        public int NootLength { set; get; }

        public Tempo(int temp, int nootLength) {
            this.Temp = temp;
            this.NootLength = nootLength;
        }

        public string ToText() {
            return $"\\tempo {NootLength}={Temp}";
        }
    }
}
