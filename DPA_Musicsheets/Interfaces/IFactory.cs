using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA_Musicsheets.Factories {

    public interface IFactory<T> {
        void AddType(string classType, Type type);
        T Get(string type);
    }

}
