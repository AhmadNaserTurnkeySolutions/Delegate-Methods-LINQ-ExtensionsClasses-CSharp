using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delegate_Part2.MODEL;
namespace Delegate_Part2.DAL
{
  public class TraineeDAO
    {
      DB db = DB.Instance;

      //CRUD
      //::Create
      //::Read      (select by id , select by trainee , select all trainee , ....)
      //::Update
      //::Delete

      public int InsertTrainee(Trainee Trainee) 
      {

          return 0;
          //return 1;

      }

      public int UpdateTrainee(Trainee Trainee)
      {

          return 0;
          //return 1;

      }

      public Trainee getTraineeByName(string Name) 
      {
          var tr = from t in db.GetTraineeDB() where t.Name == Name select t ;
          
          Trainee test = tr.First();
          
          return test;
      }

      public List<Trainee> GetTraineesBy(Trainee Trainee) 
      {

          var ts = from t in db.GetTraineeDB()
                   where t.Name.Contains(Trainee.Name) ||
                         t.CollegeName == Trainee.CollegeName ||
                         t.CollegeMajorScore == Trainee.CollegeMajorScore
                   select t;

          return ts.ToList<Trainee>();
      }

      public  dynamic GroupByCollegeName(string CName)
      {
          var groupByCollege = db.GetTraineeDB().GroupBy(x => x.CollegeName).Select(group => group).OrderBy(x => x.Key);
          return groupByCollege;
      }

      public Trainee GetBestTrainee(Trainee Trainee) 
      {

          return (Trainee)db.GetTraineeDB().Max(t => t);
      }

      public Trainee GetWorstTrainee(Trainee Trainee)
      {

          return (Trainee)db.GetTraineeDB().Min(t => t);
      }

    }
}
