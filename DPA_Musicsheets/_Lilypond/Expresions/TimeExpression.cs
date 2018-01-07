using DPA_Musicsheets.Models;
using PSAMControlLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._Lilypond.Expresions {
    class TimeExpression : IAbstractExpression {

        public void Solve(LilypondContext context, LilypondToken token) {

            token = token.NextToken;
            var times = token.Value.Split('/');
            var timeSignature = new PSAMControlLibrary.TimeSignature(TimeSignatureType.Numbers, UInt32.Parse(times[0]), UInt32.Parse(times[1]));

            context.Symbols.Add(timeSignature);

        }
    }
}
