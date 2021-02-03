using System;
using System.Collections.Generic;
using System.Linq;

namespace Prectice_03_02
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Partial
            //Student s = new Student();
            //s.StudentName = "Ratan";
            //s.StudentCity = "Mumbai";

            //Console.WriteLine("Student Name: {0}  &  City: {1}", s.StudentName, s.StudentCity);
            #endregion Partial

            #region Indexer
            //Employee emp = new Employee();
            //emp[0] = 5;
            //emp[1] = -5;            //It is false because enter negative value
            //emp[2] = 10;            //Create IndexoutOfRange error

            //Console.WriteLine("Age: " + emp[0]);
            #endregion Indexer

            #region Optional parameters
            //Add(10,20,30,52,65,12,39);
            #endregion Optional parameters

            #region Directory
            //Branch branch = new Branch()
            //{
            //    BranchID = 1,
            //    BranchName = "Krushnagar",
            //    ManagerName = "Elon"
            //};

            //Branch b2 = new Branch()
            //{
            //    BranchID = 2,
            //    BranchName = "Patel Colony",
            //    ManagerName = "Ratan"
            //};

            //Dictionary<int, Branch> directoryBranch = new Dictionary<int, Branch>();
            //directoryBranch.Add(branch.BranchID, branch);
            //directoryBranch.Add(b2.BranchID, b2);

            //foreach(KeyValuePair<int, Branch> branchkey in directoryBranch)
            //{
            //    Branch br = branchkey.Value;
            //    Console.WriteLine("Distributor ID: {0}  Name: {1}  Manager: {2}", br.BranchID, br.BranchName, br.ManagerName);
            //}
            #endregion Directory

            #region List Collection
            Branch b1 = new Branch()
            {
                BranchID = 1,
                BranchName = "Krushnagar",
                ManagerName = "Elon"
            };

            Branch b2 = new Branch()
            {
                BranchID = 2,
                BranchName = "Patel Colony",
                ManagerName = "Ratan"
            };

            List<Branch> branchs = new List<Branch>(2);
            branchs.Add(b1);
            branchs.Add(b2);

            foreach(Branch b in branchs)
            {
                Console.WriteLine("Branch Name: {0}   Manager: {1}", b.BranchName, b.ManagerName);
            }

            Branch bb = branchs.Find(br => br.BranchID > 1);
            Console.WriteLine("Branch Name: " + bb.BranchName);

            int index = branchs.FindIndex(1, br => br.BranchID > 1);
            Console.WriteLine("Index: "+index);
            #endregion List Collection

        }

        #region Optional parameters
        public static void Add(int FN, int SN, params int[] otherNumber)
        {
            int result = FN + SN;
            if(otherNumber != null)
            {
                foreach(int i in otherNumber)
                {
                    result += i;
                }
            }

            Console.WriteLine("Sum= " + result);
        }
        #endregion Optional parameters


        #region Employee Class
        class Employee
        {
            private int[] Age = new int[2];

            public int this[int index]
            {
                get
                {
                    return Age[index];
                }
                set
                {
                    if (index >= 0 && index < Age.Length)
                    {
                        if (value > 0)
                        {
                            Age[index] = value;
                        }
                        else
                        {
                            Console.WriteLine("Age Must be Greterthen 0");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Index !!");
                    }
                }
            }
        }
        #endregion Employee Class


        #region Branch Class
        class Branch
        {
            public int BranchID { get; set; }
            public string BranchName { get; set; }
            public string ManagerName { get; set; }
        }
        #endregion Branch Class


    }
}
