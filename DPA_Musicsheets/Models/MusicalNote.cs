using DPA_Musicsheets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Models {

    class MusicalNote : AbstractMusicalNote, IMusicSymbol {
    
        public MusicalNote(string name) {
            NoteName = name;
        }

        public string ToText() {       
            var punten = GenerateString(Dots, ".");
            var kommas = GenerateString(Commas, ",");
            var apostrof = GenerateString(Apostrophe, "'");

            return this.NoteName + kommas + apostrof + this.Duration + punten;
        }

        private string GenerateString(int total, string type) {
            String returnString = "";
            for (int i = 0; i < total; i++) {
                returnString += type;
            }

            return returnString;
        }


    }

}
