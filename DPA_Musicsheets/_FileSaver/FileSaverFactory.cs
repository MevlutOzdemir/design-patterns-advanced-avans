using DPA_Musicsheets.Factories;
using DPA_Musicsheets.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._FileSaver {
    class FileSaverFactory {

        protected Dictionary<string, IFileSaver> table;

        public FileSaverFactory(FileHandler fileHandler) {
            this.table = new Dictionary<string, IFileSaver> {
                { ".pdf", new PDFSaver() },
                { ".ly", new LilypondSaver() },
                { ".mid", new MidiSaver(fileHandler) }
            };
        }

        public IFileSaver Get(string type) {
            if (table.TryGetValue(type, out var saver)) {
                return saver;
            }

            return null;
        }
    }
}
