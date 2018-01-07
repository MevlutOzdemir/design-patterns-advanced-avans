using DPA_Musicsheets._Shortcuts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._States {

    public interface IState {

        void Execute(string pattern);

    }

}
