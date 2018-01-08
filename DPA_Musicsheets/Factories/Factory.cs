using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Factories {
    public class Factory<T> : IFactory<T>

        /* Bron: https://codereview.stackexchange.com/questions/8307/implementing-factory-design-pattern-with-generics */

        where T : class {
    
        protected readonly Dictionary<string, Type> table = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);

        public void AddType(string typenaming, Type type) {
            table[typenaming] = type;
        }

        public T Get(string type) {
            if(type == null) {
                return null;
            }

            if (table.TryGetValue(type, out var t)) {
                return (T)Activator.CreateInstance(t);
            }

            return null;
        }
    }
}
