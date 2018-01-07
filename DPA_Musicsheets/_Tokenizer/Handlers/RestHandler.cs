using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DPA_Musicsheets.Models;

namespace DPA_Musicsheets._Tokenizer.Handlers {

    class RestHandler : ITokenHandler {

        public bool canHandle(string s) {
            return new Regex(@"r.*?[0-9][.]*").IsMatch(s);
        }

        public LilypondTokenKind handle(string s) {
            return LilypondTokenKind.Rest;
        }

    }

}
