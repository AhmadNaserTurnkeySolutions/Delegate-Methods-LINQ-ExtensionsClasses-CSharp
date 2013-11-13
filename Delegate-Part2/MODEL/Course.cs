using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Part2.MODEL
{
    public class Course
    {
        public string Name { set; get; }
        public int NumberOfHours { set; get; }
        public Trainer Trainer { set; get; }
        public List<Trainee> Trainees { set; get; }


    }
}
