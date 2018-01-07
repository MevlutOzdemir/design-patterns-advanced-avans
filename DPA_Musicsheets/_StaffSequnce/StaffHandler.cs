using DPA_Musicsheets._StaffSequnce.MusicalSymbolTypes;
using PSAMControlLibrary;
using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._StaffSequnce {

    class StaffHandler {

        private StaffContext staffContext;

        public StaffHandler() {
            this.staffContext = new StaffContext();
        }

        public Sequence GetSequenceFromWPFStaffs(List<MusicalSymbol> WPFStaffs) {
            foreach (MusicalSymbol musicalSymbol in WPFStaffs) {
                staffContext.MusicalSymbol = musicalSymbol;
                //staffContext.note = musicalSymbol as Note;

                var handlerType = musicalSymbol?.Type.ToString();
                IMusicalSymbolType handler = new MusicalSymbolHandlerFactory().Get(handlerType);

                if (handler != null) {
                    handler.handle(staffContext);
                }
            }

            staffContext.NotesTrack.Insert(staffContext.absoluteTicks, MetaMessage.EndOfTrackMessage);
            staffContext.MetaTrack.Insert(staffContext.absoluteTicks, MetaMessage.EndOfTrackMessage);

            return staffContext.Sequence;
        }
    }
}
