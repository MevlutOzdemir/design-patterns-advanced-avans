using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.Models;
using PSAMControlLibrary;

namespace DPA_Musicsheets._Lilypond.Expresions {
    class BarExpression : IAbstractExpression {

        public void Solve(LilypondContext context, LilypondToken token) {
            context.Symbols.Add(new Barline());
        }

    }
}
