using DPA_Musicsheets.Models;
using PSAMControlLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._Lilypond {

    class LilypondContext {

        public List<MusicalSymbol> Symbols { get; set; }

        public PSAMControlLibrary.Clef CurrentClef { get; set; }

        public int PreviousOctave { get; set; }
        public char PreviousNote { get; set; }

        public LilypondContext() {
            Symbols = new List<MusicalSymbol>();
            PreviousOctave = 4;
            PreviousNote = 'c';
            CurrentClef = null;
        }

    }

}
