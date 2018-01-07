using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._Shortcuts {
    class SaveAsPDFCommand : BaseCommand {

        public SaveAsPDFCommand() : base("LeftCtrlSP") {
        }

        public override BaseCommand Clone() {
            return new SaveAsPDFCommand();
        }

        protected override void Execute() {
            SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "PDF|*.pdf" };

            if (saveFileDialog.ShowDialog() == true) {
                FileHandler.Save(".pdf", saveFileDialog.FileName);
            }
        }
    }
}
