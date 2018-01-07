using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanford.Multimedia.Midi;

namespace DPA_Musicsheets.Midi.MessageHandler.MetaTypeMessageHandler {
    class EndOfTrackHandler : IMetaTypeHandler {

        public void handle(MidiContext context, MidiEvent midiEvent) {
            if(context.previousNoteAbsoluteTicks > 0) {

            }
        }

    }
}
