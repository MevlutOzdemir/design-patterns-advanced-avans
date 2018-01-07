using PSAMControlLibrary;
using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._StaffSequnce {
    public class StaffContext {

        public int _beatNote = 4;    // De waarde van een beatnote.
        public int _bpm = 120;       // Aantal beatnotes per minute.
        public int _beatsPerBar = 0;     // Aantal beatnotes per maat.
        public int speed;
        public int absoluteTicks = 0;

        byte[] tempo;

        public Sequence Sequence { get; } = new Sequence();
        public Track MetaTrack { get; } = new Track();
        public Track NotesTrack { get; } = new Track();
        public MusicalSymbol MusicalSymbol { get; set; }

        public List<string> notesOrderWithCrosses = new List<string>() { "c", "cis", "d", "dis", "e", "f", "fis", "g", "gis", "a", "ais", "b" };


        public StaffContext() {
            // Calculate tempo
            speed = (60000000 / _bpm);
            tempo = new byte[3];
            tempo[0] = (byte)((speed >> 16) & 0xff);
            tempo[1] = (byte)((speed >> 8) & 0xff);
            tempo[2] = (byte)(speed & 0xff);

            Sequence.Add(MetaTrack);
            MetaTrack.Insert(0 /* Insert at 0 ticks*/, new MetaMessage(MetaType.Tempo, tempo));
            Sequence.Add(NotesTrack);
        }





    }
}
