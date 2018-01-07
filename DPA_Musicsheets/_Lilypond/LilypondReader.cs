using DPA_Musicsheets.FileReaders;
using DPA_Musicsheets.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets {
    public class LilypondReader : IFileReader {

        public MusicSheet ReadFile(string path) {
            var musicSheet = new MusicSheet();

            StringBuilder builder = new StringBuilder();

            foreach (var line in File.ReadAllLines(path)) {
                builder.AppendLine(line);
            }

            musicSheet.SymbolsContent = builder;

            return musicSheet;
        }

    }
}
