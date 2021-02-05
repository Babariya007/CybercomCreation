using System;
using System.Threading;

namespace Pratice_04_02
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Multi Theding
            Thread t1 = new Thread(fun1);
            Thread t2 = new Thread(fun2);
            Thread t3 = new Thread(fun3);

            t1.Start(); t2.Start(); t3.Start();
            #endregion Multi Theding

            #region Anonymouse & Lambda
            Program.MyMethod(delegate (int b) { b += 10; Console.WriteLine(b); }, 5);         //Anonymouse Function

            MyDelegate obj = (a) =>                                     //Use Lambda Expression 
            {
                a += 10;
                Console.WriteLine(a);
            };
            obj(5);
            #endregion Anonymouse & Lambda


        }

        #region Multi Theding
        public static void fun1()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("Fun 1: {0}", i);
            }
        }
        public static void fun2()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("Fun 2: {0}", i);
                if (i == 25)
                {
                    Console.WriteLine("Thread going to sleep for 5 Sec");
                    Thread.Sleep(5000);
                }
            }
        }
        public static void fun3()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("Fun 3: {0}", i);
            }
        }
        #endregion Multi Theding

        #region Anonymouse & Lambda
        public delegate void MyDelegate(int num);

        public static void MyMethod(MyDelegate del, int a)
        {
            a += 9;
            del.Invoke(a);
        }
        #endregion Anonymouse & Lambda

    }
}
