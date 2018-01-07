using DPA_Musicsheets.Factories;
using DPA_Musicsheets.FileReaders;
using DPA_Musicsheets.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets {

    public class FileReaderFactory : IFactory<IFileReader> {

        private IFactory<IFileReader> _factory = new Factory<IFileReader>();

        public FileReaderFactory() {
            AddType(".mid", typeof(MidiReader));
            AddType(".ly", typeof(LilypondReader));
        }

        public void AddType(string classType, Type type) {
            this._factory.AddType(classType, type);

        }

        public IFileReader Get(string type) {
            var reader = _factory.Get(type);

            if (reader == null) {
                throw new NotSupportedException($"File extension {type} is not supported.");
            }

            return reader;
        }

    }
}
