using DPA_Musicsheets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._Tokenizer.Handlers {
    interface ITokenHandler {

        bool canHandle(string s);

        LilypondTokenKind handle(string s);

    }
}
