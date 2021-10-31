using Project.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    partial class Pharmacy
    {
        public override string ToString()
        {
            return Name;
        }

        public bool AddDrug(Drug drug)
        {
            if (_drugs.Count == MaxCount)
            {
                return false;
            }

            _drugs.Add(drug);
            return true;
        }

        public static bool ShowDrugItems()
        {
            if (_drugs.Count == 0)
            {
                return false;
            }


            Help.Print("Dermanlarin siyahisi: ", ConsoleColor.Blue);
            foreach (var item in _drugs)
            {
                Help.Print(item.ToString(), ConsoleColor.Green);
            }
            return true;


        }

        public static void InfoDrug(string name)
        {
            var drugs = _drugs.FindAll(x => x.Name.ToLower().Contains(name.Trim().ToLower()));
            if (drugs.Count == 0)
            {
                Help.Print("Hech bir melumat tapilmadi!", ConsoleColor.Red);
                return;
            }

            Help.Print("Axtarish neticeleri:", ConsoleColor.Blue);
            foreach (var item in drugs)
            {
                Help.Print(item.ToString(), ConsoleColor.Green);
            }
        }

    }
}
