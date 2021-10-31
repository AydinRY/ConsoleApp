using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    partial class Pharmacy
    {
        public string Name { get; }

        public int MaxCount { get; }

        public int Id { get; }

        private static List<Drug> _drugs = new List<Drug>();

        private static int _counter = 0;

        public Pharmacy(string name, int maxcount)
        {
            Name = name;
            MaxCount = maxcount;
            _counter++;
            Id = _counter;
        }

    }
}
