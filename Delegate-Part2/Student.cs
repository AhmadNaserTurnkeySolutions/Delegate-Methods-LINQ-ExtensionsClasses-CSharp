using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Part2
{
    class Student
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public DateTime Birthdate { set; get; }
        public int age { get { return DateTime.Now.Year - Birthdate.Year; } }
        public string address { set; get; } 



    }
}
