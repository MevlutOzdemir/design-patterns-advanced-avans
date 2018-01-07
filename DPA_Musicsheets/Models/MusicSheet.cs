using DPA_Musicsheets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Models {

    public class MusicSheet {

        public LinkedList<IMusicSymbol> Items { get; set; }
        public StringBuilder SymbolsContent { get; set; }

        public MusicSheet() {
            Items = new LinkedList<IMusicSymbol>();
        }

        public void AddMusicSymbol(IMusicSymbol symbol) {
            Items.AddLast(symbol);
        }

    }

}
