using DPA_Musicsheets.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._FileSaver {
    class LilypondSaver : IFileSaver {

        public void Save(string fileName, string text) {
            if (fileName == null) {
                SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Lilypond|*.ly" };

                if (saveFileDialog.ShowDialog() == true) {
                    fileName = saveFileDialog.FileName;
                }
            }

            if (fileName == null) return;

            using (StreamWriter outputFile = new StreamWriter(fileName)) {
                outputFile.Write(text);
                outputFile.Close();
            }

            var lilypondVm = SimpleIoc.Default.GetInstance<LilypondViewModel>();
            lilypondVm.SetSaved();
        }
    }
}
