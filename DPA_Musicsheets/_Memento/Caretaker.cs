using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._Memento {
    public class Caretaker {

        private List<Memento> _savedTexts = new List<Memento>();

        public void AddMemento(Memento m) {
            _savedTexts.Add(m);
        }

        public Memento GetMemento(int index) {
            if (index < _savedTexts.Count) {
                return _savedTexts[index];
            }

            return new Memento(""); // should not be reached, breakpoint for testing
        }

    }
}
