using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delegate_Part2.MODEL;
namespace Delegate_Part2.DAL
{
    class CourseDAO
    {
        DB db = DB.Instance;



        public Dictionary<Course, List<Trainee>> getAllTraineesByCourseName(string CourseName)
      {

          var AllTrainee = db.GetTraineeDB();
          var AllCourses = db.GetCourseDB();

          Dictionary<Course, List<Trainee>> TraineesByCourse = new Dictionary<Course, List<Trainee>>();

 foreach(Course c in AllCourses)
 {
     if(c.Name==CourseName)
     TraineesByCourse.Add(c, c.Trainees);
 }

 return TraineesByCourse;


      }


        public Trainer getTrainerByCourseName(string CourseName)
        {

            var TrainerByCourse = (from z in db.GetCourseDB() where z.Name == CourseName select z.Trainer).First();

            return TrainerByCourse;


        }

        internal Trainee getBestTraineeByCourseName(string CourseName)
        {
            var trs=db.GetCourseDB().Where(x => x.Name == CourseName).Select(t=>new{ Trs=t.Trainees}).First();


          return  trs.Trs.OrderByDescending(x => x.CollegeMajorScore).First();
          

        }

        internal Trainee getWorstTraineeByCourseName(string CourseName)
        {
            var trs = db.GetCourseDB().Where(x => x.Name == CourseName).Select(t => new { Trs = t.Trainees }).First();


            return trs.Trs.OrderBy(x => x.CollegeMajorScore).First();
          
        }

        public IOrderedEnumerable<IGrouping<int, Course>> GroupCoursesByNumberOfTrainees()
        {
            var CourseByTraneeNumber = from cr in db.GetCourseDB()
                                       group cr by cr.Trainees.Count into crGroups
                                       orderby crGroups.Key
                                       select crGroups;


            return CourseByTraneeNumber;
        }

        public IOrderedEnumerable<IGrouping<string, Course>> GroupTraineeByCourse()
        {

            var GroupTrByCo = db.GetCourseDB().GroupBy(y => y.Name).Select(group => group).OrderBy(x => x.Key);
            return GroupTrByCo;


        }

    }
}
