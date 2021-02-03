using System;
using System.Collections.Generic;
using System.Text;

namespace Prectice_03_02
{
    public partial class Distributor
    {
        private string _studentName;
        private string _studentCity;

        public string StudentName { get => _studentName; set => _studentName = value; }
        public string StudentCity { get => _studentCity; set => _studentCity = value; }

        public string studentName()
        {
            return _studentName;
        }

        partial void StudentDetails();

    }
}
