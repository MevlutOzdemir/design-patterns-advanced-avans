using DPA_Musicsheets.Factories;
using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Midi.MessageHandler {
    class MessageHandlerFactory : IFactory<IMessageHandler> {

        private IFactory<IMessageHandler> _factory = new Factory<IMessageHandler>();

        public MessageHandlerFactory() {
            AddType(MessageType.Channel.ToString(), typeof(ChannelHandler));
            AddType(MessageType.Meta.ToString(), typeof(MetaHandler));
        }

        public void AddType(string classType, Type type) {
            _factory.AddType(classType, type);
        }

        public IMessageHandler Get(string type) {
            return _factory.Get(type);
        }

    
    }
}
