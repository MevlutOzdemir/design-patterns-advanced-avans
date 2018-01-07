using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.Models;
using Sanford.Multimedia.Midi;

namespace DPA_Musicsheets.Midi.MessageHandler.MetaTypeMessageHandler {
    class TempoHandler : IMetaTypeHandler {

        public void handle(MidiContext context, MidiEvent midiEvent) {
            //IMidiMessage midiMessage = midiEvent.MidiMessage;
            var metaMessage = midiEvent.MidiMessage as MetaMessage;

            var bpm = this.CalculateBPM(metaMessage);          
            context.MusicSheet.AddMusicSymbol(new Tempo(bpm));
        }

        public int CalculateBPM(MetaMessage metaMessage) {
            byte[] bytes = metaMessage.GetBytes();
            int tempo = (bytes[0] & 0xff) << 16 | (bytes[1] & 0xff) << 8 | (bytes[2] & 0xff);
            return 60000000 / tempo;
        }
    }
}
