using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Models {



    abstract class AbstractMusicalNote {

        public String NoteName { get; set; }      
        public double Duration { get; set; }
        public int Dots { get; set; }
        public int Commas { get; set; }
        public int Apostrophe { get; set; }


    }
}
