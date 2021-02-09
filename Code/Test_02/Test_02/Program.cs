using System;
using System.Collections.Generic;

namespace Test_02
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region Select Option for Program Run
                Console.WriteLine("\n-------------------------------------------\n");
                Console.WriteLine("Select the option which program to run");
                Console.WriteLine("1.  String is Pelindrom or not");
                Console.WriteLine("2.  Show Input is string or Digit");
                Console.WriteLine("3.  Count 1's Enter number by User");
                Console.WriteLine("5.  Create Binary Triangle");
                Console.WriteLine("6.  Find Smallest Element in Metrix");
                Console.WriteLine("7.  Celsius to Fahrenheit Conversion");
                Console.WriteLine("8.  Reverse a String with Predefined Function");
                Console.WriteLine("9.  Multilevel Inheritance");
                Console.WriteLine("10. Multilevel Inheritance with Virtual Methods.");
                Console.WriteLine("11. Value for Static Number");
                Console.WriteLine("12. Convert 2D array into 1D array");
                Console.WriteLine("13. Lower Bound and Upper Bound of an Array");
                Console.WriteLine("14. DivideByZero Exception");
                Console.WriteLine("15. Bubble Sort.");
                Console.WriteLine("16. User-defined exception");
                Console.WriteLine("17. Calculate Percentage using goto statement");
                Console.WriteLine("18. Write Date and Time in txt file");
                Console.WriteLine("19. Constructor overloading");
                Console.WriteLine("20. Fibonacci Series");

                int choseProgram = Convert.ToInt32(Console.ReadLine());

                switch (choseProgram)
                {
                    case 1:
                        Palindrome.IsPalindrome();
                        break;

                    case 2:
                        StringOrDigit();
                        break;

                    case 3:
                        Numberof1.number();
                        break;

                    case 4:
                        Console.WriteLine("This Program is Not available right Now");
                        break;

                    case 5:
                        BinaryTriangle.binaryTraingle();
                        break;

                    case 6:
                        smallInMatrix();
                        break;

                    case 7:
                        CalToFah.Temprature();
                        break;

                    case 8:
                        ReverseString();
                        break;

                    case 9:
                        MultiLevelInheritance();
                        break;

                    case 10:
                        MultiLevelVirtualMethod();
                        break;

                    case 11:
                        StaticNumber();
                        break;

                    case 12:
                        break;

                    case 13: break;

                    case 14:
                        DivideZero.DivideZeroException();
                        break;

                    case 15: break;

                    case 16:
                        userDifineException();
                        break;

                    case 17: break;

                    case 18: break;

                    case 19: break;

                    case 20:
                        Fibonacci.FibonacciSeries();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Plese Chose Valid Number");
            }
            #endregion Select Option for Program Run

        }

        #region 2. Show Input is string or Digit Function
        public static void StringOrDigit()
        {
            TextInput input = new NumericInput();
            Console.WriteLine("Enter char or numbers: ");
            string inputstr = Console.ReadLine();
            foreach (char str in inputstr)
            {
                input.Add(str);
            }
            Console.WriteLine("Number is : {0}", input.GetValue());
        }
        #endregion 2. Show Input is string or Digit Function

        #region 6. Smallest Element in Metrix
        public static void smallInMatrix()
        {
            SmallElementInMetrix smallInMatrix = new SmallElementInMetrix();
            smallInMatrix.setMatrix();
            smallInMatrix.PrintMatrix();

            Console.WriteLine("Smallest Value in the Metrix : {0}", smallInMatrix.min());
        }
        #endregion 6. Smallest Element in Metrix

        #region 8. Reverse a String
        public static void ReverseString()
        {
            Console.WriteLine("Enter String: ");
            string str = Convert.ToString(Console.ReadLine());
            ReverseStr.RevStr(str);
        }
        #endregion 8. Reverse a String

        #region 9. Multilavel Inheritance
        public static void MultiLevelInheritance()
        {
            LandRover lr = new LandRover();
            lr.LandRoverCar();
            lr.Car();
            lr.tataGroup();
        }
        #endregion 9. Multilavel Inheritance

        #region 10. Multilevel Inheritance with Virtual Methods
        public static void MultiLevelVirtualMethod()
        {
            Student s = new Student();
            s.GetInfo();
            Stud stud = new Stud();
            stud.GetInfo();
        }
        #endregion 10. Multilevel Inheritance with Virtual Methods

        #region 11. Output of static Number
        public static void StaticNumber()
        {
            float i = 1.0f, j = 0.05f;
            do

            {

                Console.WriteLine(i++ - ++j);

            } while (i < 2.0f && j <= 2.0f);
        }
        #endregion 11. Output of static Number

        

        #region 16. User-defined exception
        public static void userDifineException()
        {
            try
            {
                Console.WriteLine("\n--- Check You give Vote or Not ---");
                Console.WriteLine("Enter your Age:");
                int age = Convert.ToInt32(Console.ReadLine());
                UserDifineFunction.validate(age);
            }
            catch (InvalidAgeException iae)
            {
                Console.WriteLine(iae);
            }
        }
        #endregion 16. User-defined exception

    }

    #region 1. Palindrom or not
    class Palindrome
    {
        public static void IsPalindrome()
        {
            try
            {
                string str, rev;
                Console.WriteLine("Enter String");
                str = Console.ReadLine();

                char[] ch = str.ToCharArray();          //It's Convert String to array

                Array.Reverse(ch);                      //Create Reverse array
                rev = new string(ch);                   //Stor array in to string

                bool checkrevstr = str.Equals(rev, StringComparison.OrdinalIgnoreCase);
                if (checkrevstr == true)
                {
                    Console.WriteLine("{0} is Palindrom", str);
                }
                else
                {
                    Console.WriteLine("{0} is not Palindrom", str);
                }
            }
            catch
            {
                Console.WriteLine("Plese Enter String");
            }
        }
    }
    #endregion 1. Palindrom or not

    #region 2. Show Input is string or Digit
    public class TextInput
    {
        public List<char> listChar = new List<char>();

        public virtual void Add(char ch)
        {
            listChar.Add(ch);
        }
        public string GetValue()
        {
            string str = "";
            foreach (char chstr in listChar)
            {
                str += chstr;
            }
            return str;
        }
    }
    public class NumericInput : TextInput
    {
        public override void Add(char ch)
        {
            if (ch < '0' || ch > '9') { }
            else
                listChar.Add(ch);
        }
    }
    #endregion 2. Show Input is string or Digit

    #region 3. Number of 1's in the entered number
    class Numberof1
    {
        public static void number()
        {
            int number, counter = 0;
            Console.WriteLine("How many Enter Number ?");
            number = Convert.ToInt32(Console.ReadLine());

            int[] numarray = new int[number];
            Console.WriteLine("Enter Numbers: ");
            for (int i = 0; i < number; i++)
            {
                numarray[i] = Convert.ToInt32(Console.ReadLine());
            }

            foreach (int numOne in numarray)
            {
                if (numOne == 1)
                {
                    counter++;
                }
            }
            Console.WriteLine("You have enter 1 Number: {0} times", counter);
        }
    }
    #endregion 3. Number of 1's in the entered number

    #region 5. Binary Triangle
    class BinaryTriangle
    {
        public static void binaryTraingle()
        {
            int row;
            Console.WriteLine("How many Number of Row: ");
            row = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= row; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (j % 2 == 0)
                    {
                        Console.Write("0");
                    }
                    else
                    {
                        Console.Write("1");
                    }
                }
                Console.WriteLine();
            }
        }
    }
    #endregion 5. Binary Triangle

    #region 6. Smallest Element in Metrix
    class SmallElementInMetrix
    {
        int row = 0, col = 0;
        int[,] matrix;
        public void setMatrix()
        {
            Console.WriteLine("Enter rows:");
            row = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Columns:");
            col = Convert.ToInt32(Console.ReadLine());
            matrix = new int[row, col];

            Console.WriteLine("enter the numbers");
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    Console.Write("Element - [{0},{1}] : ", r, c);
                    matrix[r, c] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        public void PrintMatrix()
        {
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    Console.Write("{0} ", matrix[r, c]);
                }
                Console.WriteLine();
            }
        }
        public int min()
        {
            int smallvalue = matrix[0, 0];
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    if (smallvalue > matrix[r, c])
                    {
                        smallvalue = matrix[r, c];
                    }
                }
            }
            return smallvalue;
        }
    }

    #endregion 6. Smallest Element in Metrix

    #region 7.  Celsius to Fahrenheit Conversion
    class CalToFah
    {
        public static void Temprature()
        {
            double cal, fah;
            Console.WriteLine("Enter Celsius Temprature: ");
            cal = Convert.ToDouble(Console.ReadLine());

            fah = ((cal * 9) / 5) + 32;

            Console.WriteLine("{0} Celsius = {1} Fahrenheit", cal, fah);
        }
    }
    #endregion 7.  Celsius to Fahrenheit Conversion

    #region 8. Reverse a String
    class ReverseStr
    {
        public static void RevStr(string s)
        {
            char[] chStr = s.ToCharArray();
            Array.Reverse(chStr);
            Console.WriteLine("Reverse String : " + new string(chStr));
        }
    }
    #endregion 8. Reverse a String

    #region 9. Multilavel Inheritance
    public class TATAGroup
    {
        public void tataGroup()
        {
            Console.WriteLine("Perent - TATA Group");
        }
    }
    public class TATAMoters : TATAGroup
    {
        public void Car()
        {
            Console.WriteLine("Child 1 Perent 2 - TATA Moters is higest shar valuation in 2020");
        }
    }
    public class LandRover : TATAMoters
    {
        public void LandRoverCar()
        {
            Console.WriteLine("Child 2 - Land Rover Car is part of TATA Moters");
        }
    }
    #endregion 9. Multilavel Inheritance

    #region 10. Multilevel Inheritance with Virtual Methods
    public class Person
    {
        protected string MobileNo = "1234567890";
        protected string Name = "Hanuman";
        public virtual void GetInfo()
        {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("Mobile No: {0}", MobileNo);
            Console.WriteLine();
        }
    }
    class Student : Person
    {
        public int RollNo = 101;
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine("Student RollNo: {0}", RollNo);
        }
    }
    class Stud : Student
    {
        private string StudentAddress = "Gujarat - India";
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine("Student Address: {0}", StudentAddress);
        }
    }
    #endregion 10. Multilevel Inheritance with Virtual Methods

    

    #region 13. Lower Bound and Upper Bound of an Array
    #endregion 13. Lower Bound and Upper Bound of an Array

    #region 14. DivideByZero Exception
    class DivideZero
    {
        public static void DivideZeroException()
        {
            try
            {
                int num1 = 7, div;

                div = num1 / 0;
            }
            catch (DivideByZeroException dbze)
            {
                Console.WriteLine("You Not Divided by 0");
                Console.WriteLine("Message: {0}", dbze.Message);
                Console.WriteLine("Stack Trace: " + dbze.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex);
            }
        }
    }
    #endregion 14. DivideByZero Exception

    #region 16. User-defined exception
    public class InvalidAgeException : Exception
    {
        public InvalidAgeException(string message) : base(message)
        {
        }
    }
    public class UserDifineFunction
    {
        public static void validate(int age)
        {
            if (age < 18)
            {
                throw new InvalidAgeException("Sorry, vote only greter then 18 Age\n");
            }
            else
            {
                Console.WriteLine("You have Aligible for Vote");
            }
        }
    }
    #endregion 16. User-defined exception

    #region 20. Fibonacci Series
    class Fibonacci
    {
        public static void FibonacciSeries()
        {
            int number, n1 = 0, n2 = 1, n3;
            Console.WriteLine("Enter Number: ");
            number = Convert.ToInt32(Console.ReadLine());

            for (int i = 2; i <= number; i++)
            {
                n3 = n1 + n2;
                Console.Write(n3 + " ");
                n1 = n2;
                n2 = n3;
            }
        }
    }
    #endregion 20. Fibonacci Series

}
