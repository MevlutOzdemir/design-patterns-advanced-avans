using DPA_Musicsheets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Models {
    class Tempo : IMusicSymbol {

        private int _bpm;

        public Tempo(int _bpm) {
            this._bpm = _bpm;
        }

        public string ToText() {
            return $"\\tempo 4={_bpm}";
        }
    }
}
