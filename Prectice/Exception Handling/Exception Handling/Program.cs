using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Exception_Handling
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Exception
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(@"D:\CybercomCreation\Prectice\Exception Handling\Exception Handling\program.txt");
                Console.WriteLine(streamReader.ReadToEnd());
            }
            catch (FileNotFoundException fex)
            {
                Console.WriteLine("File Not Found {0}\n", fex.FileName);
                //WeakReference can also write Message
                Console.WriteLine("File Not Found for message {0} Please try again", fex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }

            }
            #endregion Exception




            //----------------------  Inner Exception  ------------------------------
            #region Inner Exception
            try
            {
                try
                {
                    Console.WriteLine("Please Enter Divisior Number: ");
                    int divisior = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Please Enter Divider Number: ");
                    int divider = Convert.ToInt32(Console.ReadLine());

                    int division = divisior / divider;
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("You not divided by 0");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion Inner Exception







            //----------------------  Custom Exception  ------------------------------
            #region Custom Exception
            try
            {
                Student s1 = new Student();
                s1.StudentName = "CR";

                ValidStudent(s1);
                Console.WriteLine("Student Name : " + s1.StudentName);
            }
            catch (InvelidNameException nameex)
            {
                Console.WriteLine("Invelid name : " + nameex.Message);
            }
            #endregion Custom Exception







            //----------------------  Multipal Exception on one Catch Handling ------------------------------
            #region Multipal Exception Handling
            try
            {
                int n1, n2, sum;

                Console.WriteLine("Enter Two value For sum");
                n1 = Convert.ToInt32(Console.ReadLine());
                n2 = Convert.ToInt32(Console.ReadLine());

                sum = n1 + n2;

                Console.WriteLine("Sum : {0}", sum);
            }
            catch (Exception ex)
            {
                if (ex is FormatException || ex is OverflowException)
                {
                    Console.WriteLine("Please Enter Integer Value");
                }
            }
            #endregion Multipal Exception Handling







            //----------------------  Exception in array Handling ------------------------------
            #region Exception in array Handling
            try
            {
                int[] array = { 11, 6, 0, 5, 0, 54, 12, 0 };

                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine(array[i] / array[i + 1]);
                }
            }
            catch(IndexOutOfRangeException iorex)
            {
                Console.WriteLine(iorex.Message);
            }
            catch(DivideByZeroException dbzex)
            {
                Console.WriteLine(dbzex.Message);
            }
            #endregion Exception in array Handling

        }

        #region Custom Exception Method
        public static void ValidStudent(Student name)
        {
            Regex regx = new Regex("^[a-zA-Z]+$");

            if (!regx.IsMatch(name.StudentName))
            {
                throw new InvelidNameException(name.StudentName);
            }
        }
        #endregion Custom Exception Method

    }

    //----------------------  Custom Exception  ------------------------------
    #region Custom Ecxcepton
    public class InvelidNameException : Exception
    {
        public InvelidNameException() : base() { }

        public InvelidNameException(string Message) : base(Message)
        {

        }
    }
    #endregion Custom Ecxcepton


    //----------------------  Class Custom Exception  ------------------------------
    #region Constructor for Custom Exception
    class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
    }
    #endregion Constructor for Custom Exception

}
