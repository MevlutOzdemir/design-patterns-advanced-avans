using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._FileSaver {

    interface IFileSaver {

        void Save(string fileName, string text);

    }
}
