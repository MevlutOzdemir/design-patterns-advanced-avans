using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.Models;
using PSAMControlLibrary;

namespace DPA_Musicsheets._Lilypond.Expresions {
    class ClefExpression : IAbstractExpression {

        public void Solve(LilypondContext context, LilypondToken token) {
            token = token.NextToken;

            if (token == null) return;

            if (token.Value == "treble")
                context.CurrentClef = new PSAMControlLibrary.Clef(ClefType.GClef, 2);
            else if (token.Value == "bass")
                context.CurrentClef = new PSAMControlLibrary.Clef(ClefType.FClef, 4);
            //else
            //    throw new NotSupportedException($"Clef {token.Value} is not supported.");

            context.Symbols.Add(context.CurrentClef);

        }

    }
}
