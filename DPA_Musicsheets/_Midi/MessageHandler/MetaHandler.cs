using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.Midi.MessageHandler.MetaTypeMessageHandler;
using Sanford.Multimedia.Midi;

namespace DPA_Musicsheets.Midi.MessageHandler {
    class MetaHandler : IMessageHandler {

        public void handle(MidiContext context, MidiEvent midiEvent) {
            var metaMessage = midiEvent.MidiMessage as MetaMessage;
            var type = metaMessage.MetaType;

            IMetaTypeHandler handler = new MetaTypeHandlerFactory().Get(type.ToString());

            if (handler != null) {
                handler.handle(context, midiEvent);
            }

        }
    }
}
