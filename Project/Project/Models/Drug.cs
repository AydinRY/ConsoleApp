using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    class Drug
    {
        public string Name { get; }

        public int Id { get; }

        public int Price { get; }

        public int Count { get; }

        private static int _counter;



        public Drug(string name, int price, int count)
        {
            Name = name;
            Price = price;
            Count = count; 

            _counter++;
            Id = _counter;
        }

        public override string ToString()
        {
            return $"{Id} - {Name}  {Price} azn {Count} eded ";
        }
    }
}
