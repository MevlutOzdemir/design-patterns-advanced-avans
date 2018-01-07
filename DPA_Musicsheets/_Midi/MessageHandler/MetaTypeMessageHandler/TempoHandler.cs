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
            IMidiMessage midiMessage = midiEvent.MidiMessage;
            var metaMessage = midiMessage as MetaMessage;

            byte[] bytes = metaMessage.GetBytes();
            int tempo = (bytes[0] & 0xff) << 16 | (bytes[1] & 0xff) << 8 | (bytes[2] & 0xff);
            int _bpm = 60000000 / tempo;

            Tempo tempoObject = new Tempo(120);
            context.MusicSheet.AddMusicSymbol(tempoObject);
        }
    }
}
