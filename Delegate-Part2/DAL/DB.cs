using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delegate_Part2.MODEL;

namespace Delegate_Part2.DAL
{
    public class DB
    {

      public List<Trainer> GetTrainerDB() 
        {

            List<Trainer> List = new List<Trainer> { 
            
            new Trainer{Name="Ahmad Naser",CompanyName="HundW",NumberOfYearsOfExperience=10},
            new Trainer{Name="Ahmad Hammad",CompanyName="Dimensions",NumberOfYearsOfExperience=8},
            new Trainer{Name="Sami Awwad",CompanyName="SalamSoft",NumberOfYearsOfExperience=7},
            new Trainer{Name="Fadi Gab",CompanyName="Faz",NumberOfYearsOfExperience=6},
            new Trainer{Name="Israa Fiaz",CompanyName="Microsoft",NumberOfYearsOfExperience=3},
            new Trainer{Name="Demtrics Joze",CompanyName="Fedora",NumberOfYearsOfExperience=1},
            new Trainer{Name="Endress Kassem",CompanyName="Apple",NumberOfYearsOfExperience=2},
            new Trainer{Name="Emad Sayyed",CompanyName="Galaxy",NumberOfYearsOfExperience=7},
            new Trainer{Name="Mouyad jaber",CompanyName="Samsung",NumberOfYearsOfExperience=9},

            };




            return List;
        
        }

      public List<Trainee> GetTraineeDB()
      {
          List<Trainee> List = new List<Trainee> { 
            
            new Trainee{Name="Naser Ahmad ",CollegeMajorScore=84,CollegeName="Birzeit"},
            new Trainee{Name="Hammad Ahmad ",CollegeMajorScore=82,CollegeName="UNO"},
            new Trainee{Name="Awwad Sami ",CollegeMajorScore=81,CollegeName="Najah"},
            new Trainee{Name="Gab Fadi ",CollegeMajorScore=85,CollegeName="PT"},
            new Trainee{Name="Fiaz Israa ",CollegeMajorScore=78,CollegeName="Birzeit"},
            new Trainee{Name="Joze Demtrics ",CollegeMajorScore=97,CollegeName="Birzeit"},
            new Trainee{Name="Kassem Endress ",CollegeMajorScore=71,CollegeName="Ahleya"},
            new Trainee{Name="Sayyed Emad ",CollegeMajorScore=92,CollegeName="Jordan U"},
            new Trainee{Name="jaber Mouyad ",CollegeMajorScore=83,CollegeName="Birzeit"}
 };
          return List;

      }

      public List<Course> GetCourseDB()
      {

         Trainee te1=  new Trainee { Name="Naser Ahmad ",CollegeMajorScore=84,CollegeName="Birzeit"};
         Trainee te2 = new Trainee { Name = "Hammad Ahmad ", CollegeMajorScore = 82, CollegeName = "UNO" };
         Trainee te3 = new Trainee { Name = "Awwad Sami ", CollegeMajorScore = 81, CollegeName = "Najah" };
         Trainee te4 = new Trainee { Name = "Gab Fadi ", CollegeMajorScore = 85, CollegeName = "PT" };
         Trainee te5 = new Trainee { Name = "Fiaz Israa ", CollegeMajorScore = 78, CollegeName = "Birzeit" };
         Trainee te6 = new Trainee { Name = "Joze Demtrics ", CollegeMajorScore = 97, CollegeName = "Birzeit" };
         Trainee te7 = new Trainee { Name = "Kassem Endress ", CollegeMajorScore = 71, CollegeName = "Ahleya" };
         Trainee te8 = new Trainee { Name = "Sayyed Emad ", CollegeMajorScore = 92, CollegeName = "Jordan U" };
         Trainee te9 = new Trainee { Name = "jaber Mouyad ", CollegeMajorScore = 83, CollegeName = "Birzeit" };


         Trainer tr1 = new Trainer { Name = "Ahmad Naser", CompanyName = "HundW", NumberOfYearsOfExperience = 10 };
         Trainer tr2= new Trainer { Name = "Ahmad Hammad", CompanyName = "Dimensions", NumberOfYearsOfExperience = 8 };
         Trainer tr3 = new Trainer { Name = "Sami Awwad", CompanyName = "SalamSoft", NumberOfYearsOfExperience = 7 };
         Trainer tr4 = new Trainer { Name = "Fadi Gab", CompanyName = "Faz", NumberOfYearsOfExperience = 6 };



         List<Course> List = new List<Course>
         {
                         new Course{Name="JAVA",NumberOfHours=45,Trainer=tr1,Trainees=new List<Trainee>{
             te1,te3,te3,te7
             }},
                          new Course{Name="C#",NumberOfHours=65,Trainer=tr1,Trainees=new List<Trainee>{
             te1,te3,te6,te7,te8
             }},
                          new Course{Name="PHP",NumberOfHours=85,Trainer=tr1,Trainees=new List<Trainee>{
             te1,te3,te5,te7,te2
             }},
                          new Course{Name="JQuery",NumberOfHours=35,Trainer=tr1,Trainees=new List<Trainee>{
             te1,te3,te5,te7
             }},
                          new Course{Name="OOP",NumberOfHours=40,Trainer=tr1,Trainees=new List<Trainee>{
             te1,te3,te5,te7,te2,te6
             }},
         };
          return List;

      }
      

    }
}
