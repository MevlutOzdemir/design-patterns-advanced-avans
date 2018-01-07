using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Midi.MessageHandler.MetaTypeMessageHandler {

    interface IMetaTypeHandler {

        void handle(MidiContext context, MidiEvent midiEvent);

    }

}
