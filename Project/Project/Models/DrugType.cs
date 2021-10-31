using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    class DrugType
    {
        public int Id { get; }

        public string TypeName { get; }

        private static int _counter;

        public DrugType(string typename)
        {
            TypeName = typename;

            _counter++;
            Id = _counter;
        }

        public override string ToString()
        {
            return TypeName;
        }
    }
}
