using System;

namespace Prectice_2_or_3
{


    //----------------------------------------------   Class  ----------------------------------------------------------
    class Customer
    {
        string _firstName;
        string _lastName;

        public Customer() : this("No First Name", "No last Name")
        { }

        public Customer(string firstName, string lastName)
        {
            this._firstName = firstName;
            this._lastName = lastName;
        }

        public void printFullName()
        {
            Console.WriteLine("Full Name = " + _firstName + " &&  Last Name = " + _lastName);
        }
    }







    //--------------------------------------  Static Class  --------------------------------------------------------
    class Circle
    {
        static float Pi = 3.14F;
        int _Redious;

        public Circle(int Radious)
        {
            this._Redious = Radious;
        }

        public float CalArea()
        {
            return Circle.Pi * this._Redious * this._Redious;
        }
    }









    //------------------------------------  Mehod Hinding  -------------------------------------------------------------
    public class Employee
    {
        public string FirstName;
        public string LastName;

        public void PrintName()
        {
            Console.WriteLine(FirstName + " " + LastName);
        }
    }
    public class PartTimeEmployee : Employee
    {
        public new void PrintName()                     //Use New Keyword for method hidding
        {
            Console.WriteLine(FirstName + " " + LastName + " Using Method Hidding");
        }
    }







    //---------------------------------  Overloadding  -------------------------------------------------
    public class Sum
    {
        public static void Add(int FN, int SN)
        {
            Console.WriteLine("Sum = {0}", FN + SN + " int part");
        }
        public static void Add(float FN, float SN)
        {
            Console.WriteLine("Sum = {0}", FN + SN + " Float part");
        }
    }





    //-------------------------------------  get set  ------------------------------------------------------
    public class Student
    {
        private string _Name;
        private int _id;

        public string Email { get; set; }

        public string Name
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Name is not available");
                }
                this._Name = value;
            }
            get
            {
                return this._Name;
            }
        }

        public int ID
        {
            set
            {
                if (value < 0)
                {
                    throw new Exception("ID is must be Gretter then Zero");
                }
                this._id = value;
            }
            get
            {
                return this._id;
            }
        }
    }







    //-------------------------------------  Structure  ------------------------------------------------------
    public struct Client
    {
        private int _id;
        private string _name;

        public int ID
        {
            set { this._id = value; }
            get { return this._id; }
        }

        public string Name
        {
            get => _name; set => _name = value;
        }

        public Client(int ID, string Name)
        {
            this._id = ID;
            this._name = Name;
        }

        public void PrientDetail()
        {
            Console.WriteLine("ID = {0} && Name = {1}", this._id, this._name);
        }
    }





    //-------------------------------------  Interface/Explicit Interface  ------------------------------------------------------
    interface ICustomer
    {
        void print();
    }
    interface I2
    {
        void print2();
    }
    class interfaceCustomer : ICustomer,I2
    {
        public void print()
        {
            Console.WriteLine("Interface Method Print");
        }
        public void print2()
        {
            Console.WriteLine("Second Interface");
        }
    }








    class Program
    {
        static void Main(string[] args)
        {

            //------------------------------------  Prectice Class  ----------------------------------------------------
            #region Precties Class
            Customer c1 = new Customer();

            Customer c2 = new Customer("Abhay", "Babariya");
            c2.printFullName();
            #endregion Precties Class





            //------------------------------------  static and instance class member  ------------------------------------
            #region static and instance class member
            Circle cr1 = new Circle(5);
            float Area = cr1.CalArea();
            Console.WriteLine(Area);
            #endregion static and instance class member





            //------------------------------------  Method Hindding  -------------------------------------------------------
            #region Method Hindding
            PartTimeEmployee PE = new PartTimeEmployee();
            PE.FirstName = "Abhay";
            PE.LastName = "Babariya";
            PE.PrintName();
            #endregion Method Hindding






            //-------------------------------------  Method Overloading  -----------------------------------------------------
            #region Method Overloading
            Sum.Add(5, 6);
            Sum.Add(5.5F, 6.5F);
            #endregion Method Overloading




            //-------------------------------------  Get Set  -----------------------------------------------------
            #region GET SET
            Student s1 = new Student();
            s1.Name = "Abhay";
            s1.ID = 101;
            s1.Email = string.Empty;

            Console.WriteLine(s1.Name + " " + s1.ID + " " + s1.Email);
            #endregion GET SET




            //-------------------------------------  Structure  -----------------------------------------------------
            #region Structure
            Client cl1 = new Client(101, "Abhay");
            cl1.PrientDetail();
            #endregion Structure




            //-------------------------------------  Interface/Explicit Interface  ------------------------------------------------------
            #region Interface
            interfaceCustomer ic = new interfaceCustomer();
            
           
            //interface
            ic.print();                                             //This is First Interface Print
            ic.print2();                                            //This is Second Interface Print

            
            //Explicit Interface
            ICustomer i1 = new interfaceCustomer();
            I2 i2 = new interfaceCustomer();

            i1.print();
            i2.print2();
            #endregion Interface

        }
    }
}
