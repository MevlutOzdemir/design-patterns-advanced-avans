using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.Models;

namespace DPA_Musicsheets._Tokenizer.Handlers {
    class NullHandler : ITokenHandler {

        public bool canHandle(string s) {
            return true;
        }

        public LilypondTokenKind handle(string s) {
            return LilypondTokenKind.Unknown;
        }
    }
}
