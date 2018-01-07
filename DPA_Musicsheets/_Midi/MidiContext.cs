using DPA_Musicsheets.Models;
using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Midi {

    class MidiContext {

        public int _beatNote = 4;    // De waarde van een beatnote.
        public int _bpm = 120;       // Aantal beatnotes per minute.
        public int _beatsPerBar;     // Aantal beatnotes per maat.

        public int division;
        public int previousMidiKey = 60; // Central C;
        public int previousNoteAbsoluteTicks = 0;
        public double percentageOfBarReached = 0;
        public bool startedNoteIsClosed = true;

        public TimeSignature CurrentTimeSignature { get; set; }
        public MusicSheet MusicSheet { get; set; }
        public Sequence Sequence { get; set; }
        public MusicalNote Note { get; set; }

        public MidiContext() {
            MusicSheet = new MusicSheet();
        }

        public void ResetBarPercentage() {
            this.percentageOfBarReached -= 1;
        }

        public void AddLocalNote() {
            this.MusicSheet.AddMusicSymbol(this.Note);
            this.Note = null;
        }



    }
}
