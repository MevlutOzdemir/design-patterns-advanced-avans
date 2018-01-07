using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._StaffSequnce.MusicalSymbolTypes {
    class MusicalSymbolTimeSignature : IMusicalSymbolType {

        public void handle(StaffContext staffContext) {
            byte[] timeSignature = new byte[4];
            timeSignature[0] = (byte)staffContext._beatsPerBar;
            timeSignature[1] = (byte)(Math.Log(staffContext._beatNote) / Math.Log(2));

            staffContext.MetaTrack.Insert(staffContext.absoluteTicks, new MetaMessage(MetaType.TimeSignature, timeSignature));
        }
    }
}
