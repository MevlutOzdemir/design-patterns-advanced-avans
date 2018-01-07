using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DPA_Musicsheets.Models;
using PSAMControlLibrary;

namespace DPA_Musicsheets._Lilypond.Expresions {
    class NoteExpression : IAbstractExpression {

        private static List<Char> notesorder = new List<Char> { 'c', 'd', 'e', 'f', 'g', 'a', 'b' };

        public void Solve(LilypondContext context, LilypondToken token) {
            // Length
            int noteLength = Int32.Parse(Regex.Match(token.Value, @"\d+").Value);
            // Crosses and Moles
            int alter = 0;
            alter += Regex.Matches(token.Value, "is").Count;
            alter -= Regex.Matches(token.Value, "es|as").Count;
            // Octaves
            int distanceWithPreviousNote = notesorder.IndexOf(token.Value[0]) - notesorder.IndexOf(context.PreviousNote);
            if (distanceWithPreviousNote > 3) // Shorter path possible the other way around
            {
                distanceWithPreviousNote -= 7; // The number of notes in an octave
            } else if (distanceWithPreviousNote < -3) {
                distanceWithPreviousNote += 7; // The number of notes in an octave
            }

            if (distanceWithPreviousNote + notesorder.IndexOf(context.PreviousNote) >= 7) {
                context.PreviousOctave++;
            } else if (distanceWithPreviousNote + notesorder.IndexOf(context.PreviousNote) < 0) {
                context.PreviousOctave--;
            }

            // Force up or down.
            context.PreviousOctave += token.Value.Count(c => c == '\'');
            context.PreviousOctave -= token.Value.Count(c => c == ',');

            context.PreviousNote = token.Value[0];

            var note = new Note(token.Value[0].ToString().ToUpper(), alter, context.PreviousOctave, (MusicalSymbolDuration)noteLength, NoteStemDirection.Up, NoteTieType.None, new List<NoteBeamType>() { NoteBeamType.Single });
            note.NumberOfDots += token.Value.Count(c => c.Equals('.'));

            context.Symbols.Add(note);
        }

    }
}
