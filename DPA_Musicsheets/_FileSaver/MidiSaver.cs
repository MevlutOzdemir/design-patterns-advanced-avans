using DPA_Musicsheets._StaffSequnce;
using DPA_Musicsheets.Managers;
using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._FileSaver {
    class MidiSaver : IFileSaver {

        private FileHandler _fileHandler;

        public MidiSaver(FileHandler fileHandler) {
            this._fileHandler = fileHandler;
        }

        public void Save(string fileName, string text) {
            var WPFStaffs = _fileHandler.WPFStaffs;
            Sequence sequence = new StaffHandler().GetSequenceFromWPFStaffs(WPFStaffs);

            sequence.Save(fileName);
        }
    }
}
