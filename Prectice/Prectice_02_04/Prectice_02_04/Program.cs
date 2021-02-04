using System;
using System.Collections.Generic;

namespace Prectice_02_04
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Generic
            Distributor distributor1 = new Distributor()
            {
                DistributorID = 1,
                DistributorName = "Elon",
                DistributorBranch = "Krushnagar",
                SupplyCity = "jamnagar"
            };
            Distributor distributor2 = new Distributor()
            {
                DistributorID = 2,
                DistributorName = "Ratan",
                DistributorBranch = "Oswal",
                SupplyCity = "jamnagar"
            };
            Distributor distributor3 = new Distributor()
            {
                DistributorID = 3,
                DistributorName = "Ritesh",
                DistributorBranch = "Noida",
                SupplyCity = "Delhi"
            };
            Distributor distributor4 = new Distributor()
            {
                DistributorID = 4,
                DistributorName = "Rakesh",
                DistributorBranch = "BSE Street",
                SupplyCity = "Mumbai"
            };

            List<Distributor> distributorList = new List<Distributor>();
            distributorList.Add(distributor1);
            distributorList.Add(distributor2);
            distributorList.Add(distributor3);
            distributorList.Add(distributor4);

            List<Distributor> distributorOtherCityList = new List<Distributor>();
            distributorOtherCityList.Add(distributor3);
            distributorOtherCityList.Add(distributor4);

            Foreach(distributorList);

            distributorList.AddRange(distributorOtherCityList);         //here we can add distributorothercitylist data add to distributorlist
            Foreach(distributorList);

            List<Distributor> disList = distributorList.GetRange(1, 2);     //GetRange(index number, count) this function is use to get data from in index to the range
            Foreach(distributorList);

            distributorList.Insert(1, distributor3);              //Here we add record in index position we diside
            Foreach(distributorList);

            distributorList.Remove(distributor2);                 //We can use remove record

            distributorList.RemoveAt(1);                            //We can remove record at particular index record
            Foreach(distributorList);

            distributorList.RemoveAll(x => x.SupplyCity == "jamnagar");      //Here we can remove all the items on condition
            Foreach(distributorList);

            distributorList.RemoveRange(1, 3);                     //Here we can remove data for given index range
            Foreach(distributorList);

            static void Foreach(List<Distributor> dis)
            {
                foreach (Distributor distributor in dis)
                {
                    Console.WriteLine("ID:{3} Name: {0}, Branch: {1}, City: {2}", distributor.DistributorName, distributor.DistributorBranch, distributor.SupplyCity, distributor.DistributorID);
                }
            }
            #endregion Generic

            #region Sort
            List<int> numbers = new List<int>() { 2, 4, 11, 336, 1, 58, 6, 54, 8 };

            numbers.Sort();                 //Here short in asending Order
            numbers.Reverse();                //Here print array in reverse order

            List<string> alfabet = new List<string>() { "Elon", "Ratan", "Junjunwala", "Shiv Nadar", "Ritesh" };
            alfabet.Sort();                 //Here we also short alfabet in asending Order

            foreach (string al in alfabet)
            {
                Console.WriteLine(al);
            }

            //---------------Complex Sorting Prectice
            SortByName sort = new SortByName();
            distributorList.Sort(sort);
            Foreach(distributorList);

            Comparison<Distributor> distributorCompare = new Comparison<Distributor>(CompareDistributor);
            distributorList.Sort(distributorCompare);

            distributorList.Sort((x, y) => x.DistributorName.CompareTo(y.DistributorName));     //We can also use direct using Lambda expression in delegets
            Foreach(distributorList);
            #endregion Sort

            #region Collection Class
            Console.WriteLine(distributorList.TrueForAll(a => a.SupplyCity == "jamnagar"));       //It's return true or false value

            IReadOnlyCollection<Distributor> readDistributor = distributorList.AsReadOnly();
            Console.WriteLine("Data Items: " + readDistributor.Count);

            distributorList.TrimExcess();           //It can use a Trim to anallocated memory
            #endregion Collection Class

            #region Dictionary on List
            BSE company1 = new BSE()
            {
                StockName = "RELINCE",
                TomorowPrice = 1952.23,
                TodayPrice = 1976.11
            };
            BSE company2 = new BSE()
            {
                StockName = "TATA MOTERS",
                TomorowPrice = 328.00,
                TodayPrice = 326.10
            };
            BSE company3 = new BSE()
            {
                StockName = "INDIGO PAINTS",
                TomorowPrice = 2498.52,
                TodayPrice = 2866.20
            };
            BSE company4 = new BSE()
            {
                StockName = "IRCTC",
                TomorowPrice = 1952.23,
                TodayPrice = 1539.20
            };
            BSE company5 = new BSE()
            {
                StockName = "KOTAK MAHINDRA BANK",
                TomorowPrice = 1821.12,
                TodayPrice = 1912.00
            };

            Dictionary<string, BSE> bseDir = new Dictionary<string, BSE>();
            bseDir.Add(company1.StockName, company1);
            bseDir.Add(company2.StockName, company2);
            bseDir.Add(company3.StockName, company3);
            bseDir.Add(company4.StockName, company4);
            bseDir.Add(company5.StockName, company5);

            string userChoise = string.Empty;

            do
            {
                Console.WriteLine("Enter Company Name: ");
                string strCompanyName = Console.ReadLine().ToUpper();

                BSE resultBSE = bseDir.ContainsKey(strCompanyName) ? bseDir[strCompanyName] : null;

                if (resultBSE == null)
                {
                    Console.WriteLine("Please enter velid Company Name");
                }
                else
                {
                    Console.WriteLine("\nCompany Name: {0}\nTomorrow Price: {1}\nToday Price: {2}\n", resultBSE.StockName, resultBSE.TomorowPrice, resultBSE.TodayPrice);
                }
                do
                {
                    Console.WriteLine("Do you continue ? YES or NO");
                    userChoise = Console.ReadLine().ToUpper();
                } while (userChoise != "YES" && userChoise != "NO");
            } while (userChoise == "YES");
            #endregion Dictionary on List

            #region Queue
            Queue<string> str = new Queue<string>();
            str.Enqueue("H");
            str.Enqueue("E");
            str.Enqueue("L");
            str.Enqueue("L");
            str.Enqueue("O");

            Console.WriteLine("Total Record: " + str.Count);
            Console.WriteLine(str.Peek());
            Console.WriteLine(str.Contains("L"));

            while (str.Count > 0)
            {
                Console.Write(str.Dequeue());
            }
            Console.WriteLine();
            #endregion Queue

            #region Stack
            Stack<Distributor> stackDistributor = new Stack<Distributor>();
            stackDistributor.Push(distributor1);
            stackDistributor.Push(distributor2);
            stackDistributor.Push(distributor3);
            stackDistributor.Push(distributor4);

            Console.WriteLine("Items in stack: {0}", stackDistributor.Count);
            Console.WriteLine("Peek Item from stack: {0}", stackDistributor.Peek());

            foreach(Distributor d in stackDistributor)
            {
                Console.WriteLine(d.DistributorName + " " + d.SupplyCity);
            }

            stackDistributor.Clear();
            #endregion stack

        }

        #region Sort using Delegets
        private static int CompareDistributor(Distributor x, Distributor y)
        {
            return x.DistributorName.CompareTo(y.DistributorName);
        }
        #endregion Sort using Delegets

    }

    #region Owan Sort Class
    public class SortByName : IComparer<Distributor>
    {
        public int Compare(Distributor x, Distributor y)
        {
            return x.DistributorName.CompareTo(y.DistributorName);
        }
    }
    #endregion Owan Sort Class

    #region Distributor
    public class Distributor
    {
        public int DistributorID { get; set; }
        public string DistributorName { get; set; }
        public string DistributorBranch { get; set; }
        public string SupplyCity { get; set; }
    }
    #endregion Distributor

    #region BSE Class
    public class BSE
    {
        public string StockName { get; set; }
        public double TomorowPrice { get; set; }
        public double TodayPrice { get; set; }
    }
    #endregion BSE Class

}
