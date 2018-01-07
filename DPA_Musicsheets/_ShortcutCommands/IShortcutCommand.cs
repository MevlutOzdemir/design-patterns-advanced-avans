using DPA_Musicsheets.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._Shortcuts {

    public interface IShortcutCommand {

        string Pattern { get; }

        void Execute(FileHandler handler);

    }

}
