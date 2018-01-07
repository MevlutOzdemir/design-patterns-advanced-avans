using DPA_Musicsheets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Models {


    class Bar : IMusicSymbol {

        public string ToText() {
            return "|";
        }

    }
}
