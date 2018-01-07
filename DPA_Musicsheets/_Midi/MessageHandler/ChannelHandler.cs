using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.Models;
using Sanford.Multimedia.Midi;

namespace DPA_Musicsheets.Midi.MessageHandler {
    class ChannelHandler : IMessageHandler {

        private MusicSheet musicSheet;
        private MidiContext context;
        private String[] noteLookup = { "c", "cis", "d", "dis", "e", "f", "fis", "g", "gis", "a", "ais", "b" };

        public ChannelHandler() {
        }

        public void handle(MidiContext context, MidiEvent midiEvent) {
            this.context = context;
            this.musicSheet = context.MusicSheet;

            var channelMessage = midiEvent.MidiMessage as ChannelMessage;

            if (channelMessage.Command.ToString().Equals("NoteOn")) {
                ProcessNote(midiEvent);
            }
        }

        private void ProcessNote(MidiEvent midiEvent) {
            var channelMessage = midiEvent.MidiMessage as ChannelMessage;

            if (channelMessage.Data2 > 0) { // Data2 = loudness
                this.CreateNote(midiEvent);
                return;
            }

            if (!context.startedNoteIsClosed) { // Finish the previous note with the length.
                this.FinishPreviousNote(midiEvent);
                return;
            }

            var note = new RestNote();
            this.musicSheet.AddMusicSymbol(note);
            //lilypondContent.Append("r");
        }

        private void CreateNote(MidiEvent midiEvent) {
            var channelMessage = midiEvent.MidiMessage as ChannelMessage;
            string name = GetNoteName(channelMessage.Data1);
            context.Note = new MusicalNote(name);

            this.AddCommasAndApostrof(context.Note, context.previousMidiKey, channelMessage.Data1);

            context.previousMidiKey = channelMessage.Data1;
            context.startedNoteIsClosed = false;
        }

        private string GetNoteName(int midiKey) {
            return noteLookup[midiKey % 12];
        }


        private void AddCommasAndApostrof(AbstractMusicalNote note, int previousMidiKey, int midiKey) {
            int distance = midiKey - previousMidiKey;
            while (distance < -6) {
                note.Commas += 1;
                distance += 8;
            }

            while (distance > 6) {
                note.Apostrophes += 1;
                distance -= 8;
            }
        }

        private void FinishPreviousNote(MidiEvent midiEvent) {
            context.Note.Duration = NoteLength(midiEvent, out double percentageOfBar, out int dots);
            context.Note.Dots = dots;
            context.previousNoteAbsoluteTicks = midiEvent.AbsoluteTicks;
            context.AddLocalNote();

            this.UpdatePercentageOfBar(percentageOfBar);

            if (this.PercentageBarEndReached()) {
                this.AddMaatstreep();
                context.ResetBarPercentage();
            }

            context.startedNoteIsClosed = true;
        }

        private void UpdatePercentageOfBar(double percentage) {
            context.percentageOfBarReached += percentage;
        }

        private bool PercentageBarEndReached() {
            return context.percentageOfBarReached >= 1;
        }

        private void AddMaatstreep() {
            var note = new Bar();
            this.musicSheet.AddMusicSymbol(note);
        }


        private int NoteLength(MidiEvent midiEvent, out double percentageOfBar, out int noteDots) {
            int absoluteTicks = context.previousNoteAbsoluteTicks;
            int nextNoteAbsoluteTicks = midiEvent.AbsoluteTicks;
            int duration = 0;
            noteDots = 0;

            double deltaTicks = nextNoteAbsoluteTicks - absoluteTicks;

            if (deltaTicks <= 0) {
                percentageOfBar = 0;
                return 0;
            }

            double percentageOfBeatNote = deltaTicks / context.division;
            percentageOfBar = (1.0 / context._beatsPerBar) * percentageOfBeatNote;


            for (int noteLength = 32; noteLength >= 1; noteLength -= 1) {
                double absoluteNoteLength = (1.0 / noteLength);

                if (percentageOfBar <= absoluteNoteLength) {
                    if (noteLength < 2)
                        noteLength = 2;

                    int subtractDuration = CalculateSubstractDuration(noteLength);
                    duration = CalculateDuration(noteLength);
                    noteDots = this.CalculateNoteDots(duration, noteLength, subtractDuration);

                    break;
                }
            }

            return duration;
        }


        private int CalculateSubstractDuration(int noteLength) {
            int[] durations = { 32, 16, 8, 4, 2 };

            foreach (var duration in durations) {
                if (noteLength >= duration) {
                    return duration;
                }
            }

            return durations[durations.Length - 1];
        }

        private int CalculateDuration(int noteLength) {
            int[] durations = { 32, 16, 8, 4 };
            int[] noteLengthRange = { 16, 8, 4, 2 };

            for (int i = 0; i < noteLengthRange.Length; i++) {
                if (noteLength > noteLengthRange[i]) {
                    return durations[i];
                }
            }

            return 2;

            //if (noteLength > 16) return 32;
            //if (noteLength > 8) return 16;
            //if (noteLength > 4) return 8;
            //if (noteLength > 2) return 4;
            //return 2;
        }

        private int CalculateNoteDots(int duration, int noteLength, int subtractDuration) {
            double currentTime = 0;
            int dots = 0;

            while (currentTime < (noteLength - subtractDuration)) {
                var addTime = 1 / ((subtractDuration / context._beatNote) * Math.Pow(2, dots));

                if (addTime <= 0)
                    break;

                currentTime += addTime;

                if (currentTime <= (noteLength - subtractDuration))
                    dots++;

                if (dots >= 4)
                    break;
            }

            return dots;
        }



    }
}
