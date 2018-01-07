using DPA_Musicsheets._Lilypond.Expresions;
using DPA_Musicsheets.Factories;
using DPA_Musicsheets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets._Lilypond {

    class ExpressionFactory : IFactory<IAbstractExpression> {

        private IFactory<IAbstractExpression> _factory;

        public ExpressionFactory() {
            this._factory = new Factory<IAbstractExpression>();

            this.AddType(LilypondTokenKind.Bar.ToString(), typeof(BarExpression));
            this.AddType(LilypondTokenKind.Clef.ToString(), typeof(ClefExpression));
            this.AddType(LilypondTokenKind.Note.ToString(), typeof(NoteExpression));
            this.AddType(LilypondTokenKind.Rest.ToString(), typeof(RestExpression));
            this.AddType(LilypondTokenKind.Tempo.ToString(), typeof(TempoExpression));
            this.AddType(LilypondTokenKind.Time.ToString(), typeof(TimeExpression));
        }

        public void AddType(string classType, Type type) {
            _factory.AddType(classType, type);
        }

        public IAbstractExpression Get(string type) {
            return _factory.Get(type);
        }
    }
}
