using DPA_Musicsheets.Models;
using PSAMControlLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._Lilypond {

    class LilypondClient {

        private LinkedList<LilypondToken> tokens;
        private LilypondContext context;

        public LilypondClient(LinkedList<LilypondToken> tokens) {
            this.tokens = tokens;
            this.context = new LilypondContext();
        }

        public IEnumerable<MusicalSymbol> Solve() {

            LilypondToken currentToken = tokens.First?.Value;

            while (currentToken != null) {

                var handler = new ExpressionFactory().Get(currentToken.TokenKind.ToString());

                if (handler != null) {
                    handler.Solve(context, currentToken);
                }

                currentToken = currentToken.NextToken;
            }

            return context.Symbols;
        }

    }

}
