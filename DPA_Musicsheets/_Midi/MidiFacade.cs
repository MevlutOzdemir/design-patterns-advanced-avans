using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DPA_Musicsheets.Midi;
using DPA_Musicsheets.Midi.MessageHandler;
using DPA_Musicsheets.Models;
using DPA_Musicsheets.Interfaces;
using Sanford.Multimedia.Midi;

namespace DPA_Musicsheets.Midi {


    public class MidiFacade : IMidiFacade {

        private MidiContext midiContext;

        public MidiFacade() {
            this.midiContext = new MidiContext();
        }

        private void LoadFile(string path) {
            midiContext.Sequence = new Sequence();

            try {
                midiContext.Sequence.Load(path);
                midiContext.division = midiContext.Sequence.Division;
            } catch (Exception e) {
                Console.WriteLine(e.GetType());
            }

        }

        public MusicSheet LoadMidi(string path) {

            this.LoadFile(path);

            for (int i = 0; i < midiContext.Sequence.Count; i++) {
                Track track = midiContext.Sequence[i];

                foreach (var midiEvent in track.Iterator()) {
                    var handlerType = midiEvent.MidiMessage.MessageType.ToString();
                    IMessageHandler handler = new MessageHandlerFactory().Get(handlerType);

                    if (handler != null) {
                        handler.handle(midiContext, midiEvent);
                    }

                }
            }

            return midiContext.MusicSheet;
        }


    }
}
