using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._Memento {
    public class Memento {

        /* Bron: https://www.youtube.com/watch?v=jOnxYT8Iaoo */

        private string _text;

        public Memento(string text) {
            this._text = text;
        }

        public string GetSavedText() {
            return this._text;
        }
    }
}
