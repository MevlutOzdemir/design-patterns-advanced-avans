using PSAMControlLibrary;
using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._StaffSequnce.MusicalSymbolTypes {
    class MusicalSymbolNote : IMusicalSymbolType {


        public void handle(StaffContext staffContext) {
            // Calculate duration
            var note = staffContext.MusicalSymbol as Note;

            double absoluteLength = 1.0 / (double)note.Duration;
            absoluteLength += (absoluteLength / 2.0) * note.NumberOfDots;

            double relationToQuartNote = staffContext._beatNote / 4.0;
            double percentageOfBeatNote = (1.0 / staffContext._beatNote) / absoluteLength;
            double deltaTicks = (staffContext.Sequence.Division / relationToQuartNote) / percentageOfBeatNote;

            // Calculate height
            int noteHeight = staffContext.notesOrderWithCrosses.IndexOf(note.Step.ToLower()) + ((note.Octave + 1) * 12);
            noteHeight += note.Alter;
            staffContext.NotesTrack.Insert(staffContext.absoluteTicks, new ChannelMessage(ChannelCommand.NoteOn, 1, noteHeight, 90)); // Data2 = volume

            staffContext.absoluteTicks += (int)deltaTicks;
            staffContext.NotesTrack.Insert(staffContext.absoluteTicks, new ChannelMessage(ChannelCommand.NoteOn, 1, noteHeight, 0)); // Data2 = volume
        }
    }
}
