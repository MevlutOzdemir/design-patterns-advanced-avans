using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.Models;

namespace DPA_Musicsheets._Tokenizer.Handlers {

    class BaseHandler : ITokenHandler {

        private Dictionary<string, LilypondTokenKind> lookup;

        public BaseHandler() {
            lookup = new Dictionary<string, LilypondTokenKind> {
                { "\\relative", LilypondTokenKind.Staff },
                { "\\clef", LilypondTokenKind.Clef },
                { "\\time", LilypondTokenKind.Time },
                { "|", LilypondTokenKind.Bar }
            };
        }

        public bool canHandle(string s) {
            return lookup.ContainsKey(s);
        }

        public LilypondTokenKind handle(string s) {
            return lookup[s];
        }
    }
}
