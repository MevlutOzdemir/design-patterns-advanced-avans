using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.Models;
using PSAMControlLibrary;

namespace DPA_Musicsheets._Lilypond.Expresions {
    class RestExpression : IAbstractExpression {

        public void Solve(LilypondContext context, LilypondToken token) {
            var restLength = Int32.Parse(token.Value[1].ToString());
            context.Symbols.Add(new Rest((MusicalSymbolDuration)restLength));
        }
    }
}
