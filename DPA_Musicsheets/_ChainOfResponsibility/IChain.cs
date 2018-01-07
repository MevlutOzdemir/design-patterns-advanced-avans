using DPA_Musicsheets.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._ChainOfResponsibility {

    public interface IChain {

        /* Bron: https://www.youtube.com/watch?v=jDX6x8qmjbA 
         * Currently implemented in: BaseCommand.cs.
         * & used by the 2 states, MusicEditing & MusicPlaying
         **/
        
        void SetNextChain(IChain nextChain);

        void Handle(FileHandler handler, string commandWanted);

    }

}
