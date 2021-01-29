using System;
using System.Collections.Generic;

namespace Deleget
{
                //Deleget Prectice
    public delegate void HelloDelegate(string Message);
    public delegate bool IsPromotable(Employee empl);
    public delegate void MultipleDelegate();

    class Program
    {
        static void Main(string[] args)
        {
            Hello("Hello Friends");         /* Use Normal delegate */

            #region Delegate
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee() { ID = 101, Name = "Elon", Salary = 200000, Experience=18 });
            empList.Add(new Employee() { ID = 104, Name = "Ratan", Salary = 20000, Experience = 35 });
            empList.Add(new Employee() { ID = 102, Name = "Mark", Salary = 200, Experience = 10 });
            empList.Add(new Employee() { ID = 103, Name = "Bill", Salary = 200, Experience = 15 });

            Employee.PromoteEmployee(empList, emp => emp.Experience >= 20);                      // It is a Lambda Expression
            #endregion Delegate


            #region Multiple Delegate
            MultipleDelegate md = new MultipleDelegate(MethodOne);
            md += MethodTwo;                //Add Delegate
            md += MethodThree;              //Add Delegate
            md -= MethodOne;                //Remove Delegate

            md();
            #endregion Multiple Delegate


        }

        public static void Hello(string strMessage)
        {
            Console.WriteLine(strMessage);
        }



        #region Multiple Delegate Functions
        public static void MethodOne()
        {
            Console.WriteLine("Method One Invoke");
        }
        public static void MethodTwo()
        {
            Console.WriteLine("Method Two Invoke");
        }
        public static void MethodThree()
        {
            Console.WriteLine("Method Three Invoke");
        }
        #endregion Multiple Delegate Functions
    }

    
    
    #region Delegate
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int Experience { get; set; }

        public static void PromoteEmployee(List<Employee> empList, IsPromotable isEligible)
        {
            foreach(Employee employee in empList)
            {
                if (isEligible(employee))
                {
                    Console.WriteLine(employee.Name + " Promoted");
                }
            }
        }
    }
    #endregion Delegate




}
