using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._Memento {
    public class Originator {

        private string _text;

        public void Set(string newText) {
            this._text = newText;
        }

        public Memento StoreInMemento() {
            Console.WriteLine("From Originator: saving to memento");
            return new Memento(_text);
        }

        public string RestoreFromMemento(Memento memento) {
            Console.WriteLine("From Originator: previous article saved in memento");
            _text = memento.GetSavedText();

            return _text;
        }

    }
}
