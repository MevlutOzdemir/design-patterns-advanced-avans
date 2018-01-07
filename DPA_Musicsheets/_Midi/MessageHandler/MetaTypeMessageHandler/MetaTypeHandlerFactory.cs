
using DPA_Musicsheets.Factories;
using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Midi.MessageHandler.MetaTypeMessageHandler {
    class MetaTypeHandlerFactory : IFactory<IMetaTypeHandler> {

        private IFactory<IMetaTypeHandler> _factory = new Factory<IMetaTypeHandler>();

        public MetaTypeHandlerFactory() {
            this.AddType(MetaType.Tempo.ToString(), typeof(TempoHandler));
            this.AddType(MetaType.TimeSignature.ToString(), typeof(TimeSignatureHandler));
            this.AddType(MetaType.EndOfTrack.ToString(), typeof(EndOfTrackHandler));
        }

        public void AddType(string classType, Type type) {
            _factory.AddType(classType, type);
        }

        public IMetaTypeHandler Get(string type) {

            return _factory.Get(type);
        }
    }
}
