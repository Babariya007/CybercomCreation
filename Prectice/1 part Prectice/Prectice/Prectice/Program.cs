using System;
using TA = Prectice.ProjectA;       //TA = namespace alias
using TB = Prectice.ProjectB;       //TB = namespace alias

namespace Prectice
{
    class Program
    {
        int Num;

        #region Main Method
        static void Main(string[] args)
        {
            //------------------------------  Simple Read/Write in Console  --------------------------------

            Console.WriteLine("Hello World!");          //Use for write in Console

            Console.Write("Enter Your Name: ");
            string UserName = Console.ReadLine();                //Use for input data from Console
            Console.WriteLine("Your Name: " + UserName + "  Using String Concatanation");
            Console.WriteLine("Your Name: {0}", UserName + "  Using Placeholder");      //We also write use Place Holder



            //-------------------------------  Call Static Method  --------------------------------------------
            Program.Nullable();



            //--------------------------------  Call Instant Method  --------------------------------------------
            Program program = new Program();
            program.EvenOdd();
            program.EvenOddSwitchCase();
            program.NumberWhile();
            program.NumberDoWhile();
            program.Numberfor();
            program.Numberforeach();



            //--------------------------------  UserName Namespace  ------------------------------------------------
            TA.TeamA.Print();
            TB.TeamB.Print();
        }
        #endregion Main Method





        //-------------------------------------  Static Method  --------------------------------------------------
        #region Nullable
        public static void Nullable()
        {
            Console.WriteLine();
            Console.WriteLine("\"Check Nullable\"");

            int? TicketOnSale = null;

            int AvalableTicket = TicketOnSale ?? 0;

            Console.WriteLine("The Available Tickets are: {0}", AvalableTicket);
        }
        #endregion Nullable




        //-------------------------------------  Instant Method/If_Else  -----------------------------------------
        #region Even Or Odd
        public void EvenOdd()
        {
            Console.WriteLine("\nCheck Number is Even Or Odd");

            Console.Write("Enter Number for Even Numbers: ");
            Num = Convert.ToInt32(Console.ReadLine());

            if (Num % 2 == 0)
            {
                Console.WriteLine("{0} Number is Even.", Num);
            }
            else
            {
                Console.WriteLine("{0} Nuber is Odd", Num);
            }
        }
        #endregion Even Or Odd




        //-------------------------------------  Switch Statement  -----------------------------------------
        #region Even Odd Using Switch_Case
        public void EvenOddSwitchCase()
        {
            Console.WriteLine("\nCheck Number is Even or Odd using Switch_Case");
            Num = Convert.ToInt32(Console.ReadLine());

            switch (Num % 2 == 0)
            {
                case true:
                    Console.WriteLine("{0} Number is Even Number.", Num);
                    break;
                case false:
                    Console.WriteLine("{0} Number is Odd Number.", Num);
                    break;
            }
        }
        #endregion Even Odd Using Switch_Case




        //-------------------------------------  While Loop  -----------------------------------------
        #region Natural Number Using While
        public void NumberWhile()
        {
            Console.WriteLine("\nPrint Number 1 to n by User using while Loop");

            int i = 1;
            Console.Write("Enter Number for Print 1 to N Number: ");
            Num = Convert.ToInt32(Console.ReadLine());

            while (i <= Num)
            {
                Console.WriteLine(i);
                i++;
            }
        }
        #endregion Natural Number Using While


        //-------------------------------------  do_While Loop  -----------------------------------------
        #region Print Natural Number using do_While
        public void NumberDoWhile()
        {
            Console.WriteLine("\nPrint Number 1 to n by User do_while Loop");

            string choice = string.Empty;

            do
            {
                int i = 1;
                Console.Write("Enter Number for Print 1 to N Number: ");
                Num = Convert.ToInt32(Console.ReadLine());

                while (i <= Num)
                {
                    Console.WriteLine(i);
                    i++;
                }

                do
                {
                    Console.WriteLine("Do you want to again print number ? YES or NO");
                    choice = Console.ReadLine().ToUpper();

                    if (choice != "YES" && choice != "NO")
                    {
                        Console.WriteLine("Invalid choise. Please Enter Yes or No ?");
                    }
                } while (choice != "YES" && choice != "NO");
            } while (choice == "YES");
        }
        #endregion Print Natural Number using do_While



        //-------------------------------------  for Loop  -----------------------------------------
        #region Print Natural Number using for loop
        public void Numberfor() 
        {
            Console.WriteLine("\nPrint Number 1 to n by User using for Loop");
            Console.Write("\nEnter Number 1 to n: ");
            Num = Convert.ToInt32(Console.ReadLine());
            
            for (int i = 1; i <= Num; i++)
            {
                Console.WriteLine(i);
            }
        }
        #endregion Print Natural Number using for loop



        //-------------------------------------  foreach Loop  -----------------------------------------
        #region Print Natural Number using foreach loop
        public void Numberforeach()
        {
            Console.WriteLine("\nPrint Number using foreach");

            int[] Number = new int[3];

            Number[0] = 1;
            Number[1] = 2;
            Number[2] = 3;
            
            foreach (int i in Number)
            {
                Console.WriteLine(i);
            }
        }
        #endregion Print Natural Number using foreach loop
    }
}
