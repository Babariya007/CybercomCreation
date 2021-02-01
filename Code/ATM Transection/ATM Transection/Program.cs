using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ATM_Transection
{

    #region Get or Set User Details
    class UserDetails
    {
        private string _Name;
        private string _MobileNo;
        private string _Pin;
        private decimal _balance;

        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                _Name = value;
            }
        }

        public string MobileNo 
        {
            get 
            { 
                return _MobileNo; 
            }
            set
            {
                Regex regexMobileNo = new Regex("^[0-9]{10}$"); // Regex To Validate Mobile Number
                if (regexMobileNo.IsMatch(value))
                {
                    this._MobileNo = value;
                }
                else
                {
                    Console.WriteLine("You must enter 10 digit");
                }
            }
        }
        public string Pin
        {
            get
            {
                return _Pin;
            }
            set
            {
                Regex regexPinNo = new Regex("^[0-9]{4}$"); // Regex To Validate Pin Number
                if (regexPinNo.IsMatch(value))
                {
                    this._Pin = value;
                }
                else
                {
                    Console.WriteLine("You must enter 10 digit");
                }
            }
        }
        public decimal Balance { get => _balance; set => _balance = value; }
    }
    #endregion Get or Set User Details



    //----------------------------    Create New Account   --------------------------------
    #region Create Account Class
    class CreateAccount : Transection
    {
        public static void CreateNewAccount()
        {
            int Balance;

            try
            {
                UserDetails ud = new UserDetails();
                Console.WriteLine("\nEnter Your Name");
                ud.Name = Console.ReadLine();

                Console.WriteLine("Enter Your Mobile No");
                ud.MobileNo = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Enter Your Pin");
                ud.Pin = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Enter Deposit Balance");
                Balance = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\nCongretulaction Your Account is opened");

                Console.WriteLine("1. Widrowal Cash");
                Console.WriteLine("2. Cash Deposit");
                Console.WriteLine("3. Quait");

                int transoption = Convert.ToInt32(Console.ReadLine());

                switch (transoption)
                {
                    case 1: Console.WriteLine("Enter Widrowal Amount");
                        decimal widrowalAmount = Convert.ToDecimal(Console.ReadLine());
                        Amount(widrowalAmount, Balance, ud.MobileNo);
                        break;

                    case 2: Console.WriteLine("Deposit Case Amount");
                        decimal deposit = Convert.ToDecimal(Console.ReadLine());
                        dipositAmount(deposit, Balance, ud.MobileNo);
                        break;

                    case 3: Console.WriteLine("Enter any Key for Exit");
                        Environment.Exit(0);
                        break;
                }
            }
            catch (FormatException fex)
            {
                Console.WriteLine("Please Enter {0} valid Formet", fex.Message);
            }
        }

    }
    #endregion Create Account Class




    //--------------------------------   Existing Account   ----------------------------------------
    #region Existing Account Class
    class ExstingAccount : Transection
    {
        public static void ExistingAccount()
        {
            string[] Name = { "Elon", "Ratan", "Mike" };
            string[] MobileNo = { "1234567890", "1254639078", "123654897" };
            string[] Pin = { "1234", "4321", "1122"};
            decimal[] Balance = { 5000, 3500, 2000};

            string ATMPin;
            decimal WithdrawalAmount, DipositAmount;

            Console.WriteLine("Enter Pin Number");
            ATMPin = Convert.ToString(Console.ReadLine());

            bool flag = false;
            try
            {
                for (int i = 0; i < Pin.Length; i++)
                {
                    try
                    {

                        if (Pin[i] == ATMPin)
                        {
                            flag = true;

                            Console.WriteLine("\nWelcome {0}\n",Name[i]);

                            Console.WriteLine("----------------  Please Select Choice  --------------------");
                            Console.WriteLine("1. Balance Enquiry");
                            Console.WriteLine("2. Cash Withdrawal");
                            Console.WriteLine("3. Cash Deposit");
                            Console.WriteLine("4. Cancle Transetion");


                            int transoption = Convert.ToInt32(Console.ReadLine());
                            switch (transoption)
                            {
                                case 1:
                                    Console.WriteLine("Your Balance is {0}.", Balance[i]);
                                    break;

                                case 2: Console.WriteLine("Please Enter Withdrawal Amount");
                                    WithdrawalAmount = Convert.ToDecimal((Console.ReadLine()));
                                    Amount(WithdrawalAmount, Balance[i], MobileNo[i]);
                                    break;

                                case 3: Console.WriteLine("Enter Ammount for Diposit");
                                    DipositAmount = Convert.ToDecimal(Console.ReadLine());
                                    dipositAmount(DipositAmount, Balance[i], MobileNo[i]);
                                    break;

                                case 4: Console.WriteLine("Enter any Key for Exit");
                                    Environment.Exit(0);
                                    break;
                            }
                        }
                    }
                    catch(Exception)
                    {
                        Console.WriteLine("Please Enter Valid Pin");
                    }
                }
                if (!flag)
                {
                    Console.WriteLine("Please enter valid Pin");
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Please Enter Valid Pin Number");
            }
        }
    }
    #endregion Existing Account Class




    //--------------------------------   Transection Operation   ----------------------------------------
    #region Transection Class
    class Transection
    {
        public static void Amount(decimal widrowalAmount, decimal TotalBalance, string MobileNo)
        {
            decimal MinimumBalance = 1000;
            if (MinimumBalance > widrowalAmount)
            {
                TotalBalance = TotalBalance - widrowalAmount;
                Console.WriteLine("\nPlease Collect your Cash");
                Console.WriteLine("\nYour remaining Balance is: " + TotalBalance);
                Console.WriteLine("\ntransaction message sent successfully {0} Number", MobileNo);

            }
            else
            {
                Console.WriteLine("Insufficeant Balance");
            }
        }

        public static void dipositAmount(decimal DipositAmount, decimal TotalBalance, string MobileNo)
        {
            TotalBalance += DipositAmount;
            Console.WriteLine("Your Amount: {0}", TotalBalance);
            Console.WriteLine("transaction message sent successfully {0} Number", MobileNo);
        }

    }
    #endregion Transection Class



    


    #region Main
    class Program
    {

        static void Main(string[] args)
        {
            int NewOrExit;
            Console.WriteLine("\n-----------------  Welcom TO ATM   ----------------------\n\n");
            do
            {
                Console.WriteLine("1. Create New Account");
                Console.WriteLine("2. Exsisting Account");

                NewOrExit = Convert.ToInt32(Console.ReadLine());

                do
                {
                    switch (NewOrExit)
                    {
                        case 1:
                            CreateAccount.CreateNewAccount();
                            break;

                        case 2:
                            ExstingAccount.ExistingAccount();
                            break;

                        default:
                            Console.WriteLine("Please Select 1 or 2");
                            break;
                    }
                } while (NewOrExit == 1 && NewOrExit == 2);
            } while (NewOrExit !=1 && NewOrExit != 2);
        }


        
    }
    #endregion Main

}
