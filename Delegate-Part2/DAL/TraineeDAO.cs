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
         
        

          var LINQSingleQuery = from t in db.GetTraineeDB() where t.Name == Name select t ;
          Trainee ReturnTrainee = null;


          try
          {
              ReturnTrainee = LINQSingleQuery.First();

          }
          catch(Exception ex)
          {
           //
          }

          return ReturnTrainee;
      }

      public List<Trainee> GetTraineesBy(Trainee Trainee) 
      {

          var ts = from t in db.GetTraineeDB()
                   where t.Name.Contains(Trainee.Name) ||
                         t.CollegeName.Contains(Trainee.CollegeName) ||
                         t.CollegeMajorScore == Trainee.CollegeMajorScore
                   select t;

          return ts.ToList<Trainee>();
      }

      public IOrderedEnumerable<IGrouping<string, Trainee>> GroupByCollegeName(string CollegeName)
      {
        //  var groupByCollege = db.GetTraineeDB().GroupBy(x => x.CollegeName).Select(group => group).OrderBy(x => x.Key);

          var groupByCollege = from tr in db.GetTraineeDB()
                               group tr by tr.CollegeName into TraineeGroup
                               where TraineeGroup.Key == CollegeName
                               orderby TraineeGroup.Key
                               select TraineeGroup;

          return groupByCollege;
      }

      public Trainee GetBestTrainee() 
      {
          //double max = 0;
          //Trainee temp = null;

          //foreach( var x in db.GetTraineeDB() )
          //{
          //if(x.CollegeMajorScore>max)
          //{
          //    max = x.CollegeMajorScore;
          //    temp = x;
          //}
          //}
          //return temp;

          return db.GetTraineeDB().OrderByDescending(x=>x.CollegeMajorScore).First();
      }

      public Trainee GetWorstTrainee()
      {

          return db.GetTraineeDB().OrderBy(x => x.CollegeMajorScore).First();
      }

    }


}
