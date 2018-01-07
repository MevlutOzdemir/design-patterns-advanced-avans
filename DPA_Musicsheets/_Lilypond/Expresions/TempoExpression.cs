using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.Models;

namespace DPA_Musicsheets._Lilypond.Expresions {
    class TempoExpression : IAbstractExpression {

        public void Solve(LilypondContext context, LilypondToken token) {
            // Tempo not supported
        }
    }
}
