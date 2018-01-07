using DPA_Musicsheets._StaffSequnce.MusicalSymbolTypes;
using DPA_Musicsheets.Factories;
using PSAMControlLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._StaffSequnce {
    class MusicalSymbolHandlerFactory : IFactory<IMusicalSymbolType> {

        private IFactory<IMusicalSymbolType> _factory = new Factory<IMusicalSymbolType>();

        public MusicalSymbolHandlerFactory() {
            AddType(MusicalSymbolType.Note.ToString(), typeof(MusicalSymbolNote));
            AddType(MusicalSymbolType.TimeSignature.ToString(), typeof(MusicalSymbolTimeSignature));
        }

        public void AddType(string classType, Type type) {
            _factory.AddType(classType, type);
        }

        public IMusicalSymbolType Get(string type) {
            return _factory.Get(type);
        }


    }
}
