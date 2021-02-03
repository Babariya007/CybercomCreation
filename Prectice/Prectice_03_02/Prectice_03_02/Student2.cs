using System;
using System.Collections.Generic;
using System.Text;

namespace Prectice_03_02
{
    public partial class Distributor
    {
        #region Using Partial Class
        //public string StudentDetails()
        //{
        //    return _studentName + _studentCity;
        //}
        #endregion Using Partial Class


        #region Using Partial Method
        partial void StudentDetails()
        {
            Console.WriteLine("Student Name: {0}  &&  City: {1}", StudentName, StudentCity);
        }
        #endregion Using Partial Method

    }
}
