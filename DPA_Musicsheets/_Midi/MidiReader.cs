
using DPA_Musicsheets.FileReaders;
using DPA_Musicsheets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Midi {
    public class MidiReader : IFileReader {

        public MusicSheet ReadFile(string path) {
            var facade = new MidiFacade();

            var musicSheet = facade.LoadMidi(path);
      
            var builder = new StringBuilder();

            builder.AppendLine("\\relative c' {");
            builder.AppendLine("\\clef treble");

            foreach (var symbol in musicSheet.Items) {
                if (symbol.ToText().Contains("|") || symbol.ToText().Contains("\\")) {
                    builder.AppendLine(symbol.ToText());
                } else {
                    builder.Append(symbol.ToText()).Append(" ");
                }
            }

            builder.AppendLine("}");
            musicSheet.SymbolsContent = builder;

            return musicSheet;
        }

     
    }
}
