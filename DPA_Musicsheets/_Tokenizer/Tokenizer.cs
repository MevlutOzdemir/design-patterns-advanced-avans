using DPA_Musicsheets._Tokenizer.Handlers;
using DPA_Musicsheets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DPA_Musicsheets._Lilypond {
    class Tokenizer {

        private List<ITokenHandler> handlers;

        public Tokenizer() {
            handlers = new List<ITokenHandler> {
                new BaseHandler(),
                new NoteHandler(),
                new RestHandler(),
                new NullHandler() // !! should always be at the end of this list !!
            };
        }

        public LilypondToken Tokenize(string s) {
            var token = new LilypondToken() {
                Value = s
            };

            foreach (var handler in handlers) {
                if (handler.canHandle(s)) {
                    token.TokenKind = handler.handle(s);
                    return token;
                }
            }

            return token; // never reached, but it's needed for the compiler.
        }

    }
}
