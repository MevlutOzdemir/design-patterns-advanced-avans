using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanford.Multimedia.Midi;

namespace DPA_Musicsheets.Midi.MessageHandler.MetaTypeMessageHandler {

    class TimeSignatureHandler : IMetaTypeHandler {

        public void handle(MidiContext context, MidiEvent midiEvent) {
            IMidiMessage midiMessage = midiEvent.MidiMessage;
            var metaMessage = midiMessage as MetaMessage;

            int[] timeSignature = new int[2];
            byte[] timeSignatureBytes = metaMessage.GetBytes();
            context._beatNote = timeSignatureBytes[0];
            context._beatsPerBar = (int)(1 / Math.Pow(timeSignatureBytes[1], -2));

            timeSignature[0] = timeSignatureBytes[0];
            timeSignature[1] = (int)(1 / Math.Pow(timeSignatureBytes[1], -2));

            context.CurrentTimeSignature = new Models.TimeSignature(timeSignature);
            context.MusicSheet.AddMusicSymbol(context.CurrentTimeSignature);
        }
    }
}
