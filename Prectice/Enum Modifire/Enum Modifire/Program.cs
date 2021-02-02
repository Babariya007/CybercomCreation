using System;
using System.Collections.Generic;
using System.Reflection;

namespace Enum_Modifire
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Enum
            Day day1 = (Day)6;               //here we can direct use position
            Console.WriteLine(day1 + "\n");


            string[] day = Enum.GetNames(typeof(Day));
            foreach (string days in day)
            {
                Console.WriteLine(days);
            }

            //Month month = (Month)Day.Wednesday;
            //Console.WriteLine(month);



            Customer c1 = new Customer();
            c1.CustomerID = 1;
            Console.WriteLine("\nCustomer ID: {0}", c1.CustomerID);

            RegularCustomer rc1 = new RegularCustomer();
            rc1.CustomerID = 2;
            rc1.CustomerName = "Elon";
            Console.WriteLine("\nCustomerID = {0} && Customer Name = {1}", rc1.CustomerID, rc1.CustomerName);
            #endregion Enum

            #region Obsolete Attribute
            //Calcuater.Sum(10, 20);
            //Calcuater.Sum1(20, 30);
            //Calcuater.Sum2(10, 30);               //Here use Obsolete(message, bool)
            #endregion Obsolete Attribute

            #region Reflection
            Console.WriteLine("\n\n");

            //RegularCustomer rc1 = new RegularCustomer();
            //Type T = rc1.GetType();

            Type T = Type.GetType("Enum_Modifire.RegularCustomer");         //We can also use this way
            
            Console.WriteLine("Namespace Name: {0}", T.Namespace);
            Console.WriteLine("Class Full Name: {0}", T.Name);

            Console.WriteLine("Propertis of Regular Customere");
            PropertyInfo[] properties = T.GetProperties();
            foreach(PropertyInfo property in properties)
            {
                Console.WriteLine(property.PropertyType.Name + " " + property.Name);
            }

            Console.WriteLine("Methods of Regular Customere");
            MethodInfo[] methods = T.GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.ReturnType.Name + " " + method.Name);
            }

            Console.WriteLine("Contructor of Regular Customere");
            ConstructorInfo[] constructors = T.GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                Console.WriteLine(constructor.Name);
            }

            #endregion Reflection

            #region Late biding

            Console.WriteLine();
            Assembly executAssembly = Assembly.GetExecutingAssembly();

            Type regularcustomerType = executAssembly.GetType("Enum_Modifire.RegularCustomer");

            object regularCustomerInstance = Activator.CreateInstance(regularcustomerType);

            MethodInfo getFullNameMethod = regularcustomerType.GetMethod("City");

            string[] parameters = new string[1];
            parameters[0] = "Jamnagar";

            string CityName = (string)getFullNameMethod.Invoke(regularCustomerInstance, parameters);
            Console.WriteLine("City Name: {0}", CityName);
            #endregion Late biding

            #region Generic
            bool Equal = Calculator<int>.AreEqual(10, 10);
            if (Equal)
                Console.WriteLine("value are Equal");
            else
                Console.WriteLine("Values are Not Equal");
            #endregion Generic
        }

        #region Enum

        #region Enum Day
        enum Day
        {
            Sunday = 2,
            Monday = 8,
            Tuesday = 6,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        }
        #endregion Enum Day

        #region Enum Month
        enum Month
        {
            Jan,
            Feb,
            Mar,
            Apr,
            May,
            Jun
        }
        #endregion Enum Month

        #endregion Enum

        #region class for Obsolete Attribute
        public class Calcuater
        {
            [Obsolete]                                     //This i show only Warning to use this type of method
            public static int Sum(int FN, int SN)
            {
                return FN + SN;
            }
            [Obsolete("Please use Addiction(List<int> Numbers)")]       //Here pass a message to suggest which function use you
            public static int Sum1(int FN, int SN)
            {
                return FN + SN;
            }
            [Obsolete("Please use Addiction(List<int> Numbers)",true)]       //Here pass two parameter with true then if you use this type of method then it's generate Error
            public static int Sum2(int FN, int SN)
            {
                return FN + SN;
            }

            public static int Addiction(List<int> Numbers)
            {
                int sum=0;
                foreach(int numbers in Numbers)
                {
                    sum = sum + numbers;
                }
                return sum;
            }
        }
        #endregion class for Obsolete Attribute
    }

    #region Class
    public class Calculator<T>
    {
        public static bool AreEqual(T value1, T value2)
        {
            return value1.Equals(value2);
        }
    }
    #endregion Class


    #region Customer Class
    public class Customer
    {
        private int _CustomerID;             //Private Keyword is allow to only this Container
        protected string _CustomerName;     //Protected keyword allow to container and also able to Dirived Container

        public int CustomerID               //Public Keyword is use able to anywhere show in main method to use
        {
            get 
            {
                return _CustomerID;
            }
            set
            {
                this._CustomerID = value;
            }
        }
    }
    #endregion Customer Class


    #region Regular Customer Class
    public class RegularCustomer : Customer
    {
        public string CustomerName
        {
            get
            {
                return base._CustomerName;
            }
            set
            {
                this._CustomerName = value;
            }
        }

        #region City for Late Binding
        public string City(string CityName)
        {
            return "City: " + CityName;
        }
        #endregion City for Late Binding

    }
    #endregion Regular Customer Class

}
