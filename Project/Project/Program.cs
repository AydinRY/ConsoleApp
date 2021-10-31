using Project.Models;
using Project.Utils;
using System;
using System.Collections.Generic;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pharmacy> pharmacies = new List<Pharmacy>();

            while (true)
            {
                Help.Print("1-Aptek yaratmaq, 2-Derman elave etmek" +
                ", 3-Dermanlarin siyahisi, 4-Axtarish etmek" +
                ", 5-Derman almaq, 6-Cixish", ConsoleColor.Yellow);


                string result = Console.ReadLine();
                bool isInt = int.TryParse(result, out int menu);
                if (isInt && (menu >= 1 && menu <= 6))
                {
                    if (menu == 6)
                        break;

                    switch (menu)
                    {
                        case 1:
                            Help.Print("Aptekin adini qeyd edin:", ConsoleColor.Blue);
                            string pharmacyName = Console.ReadLine();

                            if (pharmacies.Exists(x => x.Name.ToLower() == pharmacyName.ToLower()))
                            {
                                Help.Print("Bu adda Aptek artiq var!", ConsoleColor.Red);
                                goto case 1;
                            }
                                
                        inputMaxCount:
                            Help.Print("Aptekin hecmini qeyd edin:", ConsoleColor.Blue);
                            string maxCountString = Console.ReadLine();
                            isInt = int.TryParse(maxCountString, out int maxCount);
                            if (!isInt)
                            {
                                Help.Print("Hecmi duzgun teyin edin!", ConsoleColor.Red);
                                goto inputMaxCount;
                            }

                            Pharmacy pharmacy = new Pharmacy(pharmacyName, maxCount);
                            pharmacies.Add(pharmacy);

                            Help.Print($"{pharmacyName} Yaradildi!", ConsoleColor.Green);
                            break;

                        case 2:
                            if (pharmacies.Count == 0)
                            {
                                Help.Print("Movcud Aptek yoxdur!", ConsoleColor.Red);
                                goto case 1;
                            }

                            Help.Print("Dermanin adini daxil edin:", ConsoleColor.Blue);
                            string name = Console.ReadLine();

                            //inputTypeName:
                            //Help.Print("Dermanin tipini secin:", ConsoleColor.Blue);
                            //Help.Print("1-a, 2-b, 3-c, 4-d", ConsoleColor.Cyan);
                            //string type = Console.ReadLine();
                            //if (type.ToLower()!="a" && type.ToLower()!= "b" && type.ToLower()!= "c" && type.ToLower()!= "d")
                            //{
                            //    Help.Print("Duzgun tipi secin!", ConsoleColor.Red);
                            //    goto inputTypeName;
                            //}
                            //DrugType drugType = new DrugType(type);

                            Help.Print("Qiymeti daxil edin:", ConsoleColor.Blue);
                            int price = Convert.ToInt32(Console.ReadLine());
                            Help.Print("Nece eded elave etmek isteyirsiniz?", ConsoleColor.Blue);
                            int count = Convert.ToInt32(Console.ReadLine());

                            inputPharmacyName:
                            Help.Print("Movcud olan Aptek-ler:", ConsoleColor.Blue);
                            foreach (var item in pharmacies)
                            {
                                Help.Print(item.ToString(), ConsoleColor.Yellow);
                            }

                            Help.Print("Aptekin adini daxil edin:", ConsoleColor.Blue);
                            pharmacyName = Console.ReadLine();
                            Pharmacy existPharmacy = pharmacies.Find(x => x.Name.ToLower() == pharmacyName.ToLower());
                            if (existPharmacy == null)
                            {
                                Help.Print("Movcud apteklerden sechin!", ConsoleColor.Red);
                                goto inputPharmacyName;
                            }

                            Drug drug = new Drug(name, price, count);
                            if (!existPharmacy.AddDrug(drug))
                            {
                                Help.Print("Limiti ashirsiz!", ConsoleColor.Red);
                                goto inputPharmacyName;
                            }

                            Help.Print($"{drug} {existPharmacy}-a elave olundu", ConsoleColor.Green);

                            break;
                        case 3:
                            if (pharmacies.Count == 0)
                            {
                                Help.Print("Movcud Aptek yoxdur!", ConsoleColor.Red);
                                goto case 1;
                            }

                        inputPharmacyName2:
                            Help.Print("Movcud olan Aptek-ler:", ConsoleColor.Blue);
                            foreach (var item in pharmacies)
                            {
                                Help.Print(item.ToString(), ConsoleColor.Yellow);
                            }

                            Help.Print("Aptekin adini daxil edin:", ConsoleColor.Blue);
                            pharmacyName = Console.ReadLine();
                            Pharmacy existPharmacy2 = pharmacies.Find(x => x.Name.ToLower() == pharmacyName.ToLower());
                            if (existPharmacy2 == null)
                            {
                                Help.Print("Movcud apteklerden sechin!", ConsoleColor.Red);
                                goto inputPharmacyName2;
                            }

                            if (!Pharmacy.ShowDrugItems())
                            {
                                Help.Print("Bu aptekde derman yoxdur!", ConsoleColor.Red);
                                     goto case 2;
                            }

                            break;
                        case 4:
                            if (pharmacies.Count == 0)
                            {
                                Help.Print("Movcud Aptek yoxdur!", ConsoleColor.Red);
                                goto case 1;
                            }

                        inputPharmacyName3:
                            Help.Print("Movcud olan Aptek-ler:", ConsoleColor.Blue);
                            foreach (var item in pharmacies)
                            {
                                Help.Print(item.ToString(), ConsoleColor.Yellow);
                            }

                            Help.Print("Aptekin adini daxil edin:", ConsoleColor.Blue);
                            pharmacyName = Console.ReadLine();
                            Pharmacy existPharmacy3 = pharmacies.Find(x => x.Name.ToLower() == pharmacyName.ToLower());
                            if (existPharmacy3 == null)
                            {
                                Help.Print("Movcud apteklerden sechin!", ConsoleColor.Red);
                                goto inputPharmacyName3;
                            }

                            if (!Pharmacy.ShowDrugItems())
                            {
                                Help.Print("Bu aptekde derman yoxdur!", ConsoleColor.Red);
                                goto case 2;
                            }

                            Help.Print("Axtardiginiz dermanin adini qeyd edin:", ConsoleColor.Blue);
                            name = Console.ReadLine();
                            Pharmacy.InfoDrug(name);


                            Help.Print("Axtardiginiz dermanin adini qeyd edin:", ConsoleColor.Blue);
                            name = Console.ReadLine();
                            Pharmacy.InfoDrug(name);


                            break;
                        case 5:
                            if (pharmacies.Count == 0)
                            {
                                Help.Print("Movcud Aptek yoxdur!", ConsoleColor.Red);
                                goto case 1;
                            }

                        inputPharmacyName4:
                            Help.Print("Movcud olan Aptek-ler:", ConsoleColor.Blue);
                            foreach (var item in pharmacies)
                            {
                                Help.Print(item.ToString(), ConsoleColor.Yellow);
                            }

                            Help.Print("Aptekin adini daxil edin:", ConsoleColor.Blue);
                            pharmacyName = Console.ReadLine();
                            Pharmacy existPharmacy4 = pharmacies.Find(x => x.Name.ToLower() == pharmacyName.ToLower());
                            if (existPharmacy4 == null)
                            {
                                Help.Print("Movcud apteklerden sechin!", ConsoleColor.Red);
                                goto inputPharmacyName4;
                            }

                            if (!Pharmacy.ShowDrugItems())
                            {
                                Help.Print("Bu aptekde derman yoxdur!", ConsoleColor.Red);
                                goto case 2;
                            }

                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Help.Print("Gosterilmish edelerden secin!", ConsoleColor.Red);
                }

            }
        }
    }
}
