using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delegate_Part2.MODEL;
using Delegate_Part2.DAL;
namespace Delegate_Part2
{
    class Program
    {
        #region Basic Delegate

      
        delegate List<Student> StudentsDel(List<Student> stu);
        // IOrderedEnumerable<IGrouping<string, Student>> 
        delegate dynamic GroupsDel(List<Student> stu);

        #endregion



       
        #region Advance Delegate with events in MainClass  
        delegate int PerformCalculation(int x, int y);
        #endregion


        static void Main(string[] args)
        {
            LinqGalaxy1Examples();
            LinqGalaxy2Examples();


            AdvanceLinqAndDelegateExamples();







     }


        #region LinqGalaxy1  
        //Using Delegate To Call Functions
        //1-Add functions to a delegate
        //2-Call all the functions using the delegate
        private static void LinqGalaxy1Examples()
        {
            /*
          delegate List<Student> StudentsDel(List<Student> stu);
       // IOrderedEnumerable<IGrouping<string, Student>>  instead of dynamic
          delegate dynamic GroupsDel(List<Student> stu);
             */

            List<Student> students = new List<Student>();
            Student s1 = new Student { FirstName = "AStudent 1", LastName = "student", address = "Ramallah", Birthdate = DateTime.Parse("08/15/1985") };
            Student s2 = new Student { FirstName = "DStudent 2", LastName = "student", address = "Hebron", Birthdate = DateTime.Parse("08/15/1987") };
            Student s3 = new Student { FirstName = "EStudent 3", LastName = "student", address = "Ramallah", Birthdate = DateTime.Parse("08/15/1990") };
            Student s4 = new Student { FirstName = "BStudent 4", LastName = "student", address = "Hebron", Birthdate = DateTime.Parse("08/15/1991") };
            Student s5 = new Student { FirstName = "CStudent 5", LastName = "student", address = "Ramallah", Birthdate = DateTime.Parse("08/15/1995") };


            students.Add(s1);
            students.Add(s2);
            students.Add(s3);
            students.Add(s4);
            students.Add(s5);




            //// //step 2 : initialize Delegate

            StudentsDel stuDel = new StudentsDel(OrderByName);
            stuDel += new StudentsDel(StuAfter88);
            stuDel += new StudentsDel(StuFromRamallah);


            // step 3 : call Delegate
            List<Student> sts = stuDel(students);



            //part 2 : 



            GroupsDel groupsDel = new GroupsDel(GroupByCity);

      
            IOrderedEnumerable<IGrouping<string, Student>> groupByAdd = groupsDel(students);

            Console.WriteLine("Students Groupped By Address: ");
            foreach (var grp in groupByAdd)
            {
                Console.WriteLine(grp.Key + ":");
                foreach (Student stu in grp)
                {
                    Console.WriteLine("\tName : {0}\tAddress: {1}", stu.FirstName, stu.address);
                }
            }
            Console.WriteLine("-----------------------------------------------------\n");



            //List<Student> stuAfter88 = StuAfter88(students);
            //List<Student> stuFromRamallah = StuFromRamallah(students);
            //List<Student> ordered = OrderByName(students);

            Console.ReadLine();
        }
        #endregion

        #region LinqGalaxy2
        private static void LinqGalaxy2Examples()
        {
            string sep = ("\n--------------------\n");


            TraineeDAO td = new TraineeDAO();
            CourseDAO cd = new CourseDAO();

            //1-)getAllTraineesByCouseName
            PrintTheTask(1, "getAllTraineesByCourseName :: JAVA");
            Dictionary<Course, List<Trainee>> AllTraineesByCourseName = cd.getAllTraineesByCourseName("JAVA");
            PrintTraineesByCourseName(AllTraineesByCourseName);
            Console.WriteLine(sep);




            //2-)getTrainerByCoueseName
            PrintTheTask(2, "getTrainersByCourseName :: C#");
            Trainer TrainerByCourseName = cd.getTrainerByCourseName("C#");
            PrintTrainerByCourseName(TrainerByCourseName);
            Console.WriteLine(sep);



            //3-)getBestTraineeByCourseName


            PrintTheTask(3, "getBestTraineeByCourseName :: JAVA");
            Trainee BestTraineeByCourseName = cd.getBestTraineeByCourseName("JAVA");
            PrintTrainee(BestTraineeByCourseName);
            Console.WriteLine(sep);


            //4)getWorseTraineeByCourseName

            PrintTheTask(4, "getWorseTraineeByCourseName :: JAVA");
            Trainee WorstTraineeByCourseName = cd.getWorstTraineeByCourseName("JAVA");
            PrintTrainee(WorstTraineeByCourseName);
            Console.WriteLine(sep);




            //5)GroupTraineesByCourse
            PrintTheTask(5, "GroupTraineesByCourse");
            IOrderedEnumerable<IGrouping<string, Course>> GropBy = cd.GroupTraineeByCourse();

            foreach (IGrouping<string, Course> gg in GropBy)
            {

                Console.WriteLine("                 " + "group :" + gg.Key + "\n");
                foreach (Trainee dd in gg.Select(x => x.Trainees).First())
                {

                    PrintTrainee(dd);



                }

            }
            Console.WriteLine(sep);



            //6)GroupCoursesByNumberOfTrainees
            PrintTheTask(6, "GroupCoursesByNumberOfTrainees");

            IOrderedEnumerable<IGrouping<int, Course>> CourseGroups = cd.GroupCoursesByNumberOfTrainees();

            foreach (var grp in CourseGroups)
            {
                Console.WriteLine("Courses With (" + grp.Key + ") Trainees : ");
                foreach (var course in grp)
                    Console.WriteLine("\t\t\t\t" + course.Name);

            }
            Console.WriteLine(sep);


            //7)GroupTraineesByCollegeName

            PrintTheTask(7, "GroupTraineesByCollegeName");
            IOrderedEnumerable<IGrouping<string, Trainee>> cg = td.GroupByCollegeName("Birzeit");
            PrintTraineeGroup(cg);
            Console.WriteLine(sep);



            //8)getTraineeByName

            PrintTheTask(8, "getTraineeByName");
            Trainee t = td.getTraineeByName("jaber Mouyad");
            PrintTrainee(t);
            Console.WriteLine(sep);


            //9)GetBestTrainee

            PrintTheTask(9, "GetBestTrainee");
            Trainee t1 = td.GetBestTrainee();
            PrintTrainee(t1);
            Console.WriteLine(sep);

            //10)GetTraineesBy Trainee Object

            PrintTheTask(10, "GetTraineesBy Trainee Object");
            Trainee TSearchBy = new Trainee { CollegeName = "Bir", Name = "Na" };
            var DaoMethodCall = td.GetTraineesBy(TSearchBy);

            foreach (var s in DaoMethodCall)
            {
                PrintTrainee(s);
            }
            Console.WriteLine(sep);





            StopConsole();
        }


        #endregion





        #region ConsoleMethods
        private static void StopConsole()
        {
            Console.Read();
        }

        private static void PrintTheTask(int p1, string p2)
        {
            string sep = ("\n--------------------\n");
            Console.WriteLine(sep);
            Console.WriteLine(p1+" :: )-  "+p2);
            Console.WriteLine(sep);
        }

        private static void PrintTrainerByCourseName(Trainer Trainer)
        {
            try
            {

                string t = "Name : " + Trainer.Name + "\n" +
                            "CompanyName : " + Trainer.CompanyName + "\n" +
                            "NumberOfYearsOfExperience : " + Trainer.NumberOfYearsOfExperience + "\n";
                Console.WriteLine(t);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in data input");
            }
        }

        private static void PrintTraineesByCourseName(Dictionary<Course, List<Trainee>> AllTraineesByCouseName)
        {
            foreach(var Cs in AllTraineesByCouseName)
            {
                Console.WriteLine(Cs.Key.Name);
            foreach(var Tr in Cs.Value)
            {
                PrintTrainee(Tr);
            }
            }
        }

        private static void PrintTraineeGroup(IOrderedEnumerable<IGrouping<string, Trainee>> aa)
        {
            Console.WriteLine("Trainee Groupped By College:\n ");
            foreach (var grp in aa)
            {
                Console.WriteLine(grp.Key + ":");
                foreach (Trainee tre in grp)
                {
                    Console.WriteLine("\tName : {0}\t College: {1}", tre.Name, tre.CollegeMajorScore);
                }
            }
            Console.WriteLine("-----------------------------------------------------\n");
        }

   

        private static void PrintTrainee(Trainee tre)
        {
         try
            {

                string t = "Name : " + tre.Name + "\n" +
                            "CollegeName : " + tre.CollegeName + "\n" +
                            "CollegeMajorScore : " + tre.CollegeMajorScore + "\n";
                Console.WriteLine(t);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error in data input");
            }
        }


        #endregion



        #region StudentHelperMethods
        public static List<Student> StuAfter88(List<Student> students)
        {
            //var stuAfter88 = from s in students where s.Birthdate.Year > 1988 select s;

            List<Student> stuAfter88 = students.Where(s => s.Birthdate.Year > 1988).OrderBy(s => s.FirstName).ToList<Student>();

            Console.WriteLine("Students who were born after 1988 are : ");
            foreach (Student st in stuAfter88)
            {
                Console.WriteLine("Name : {0}\tBirthdate: {1}", st.FirstName, st.Birthdate);
            }
            Console.WriteLine("-----------------------------------------------------\n");
            return stuAfter88;
        }


        public static List<Student> StuFromRamallah(List<Student> students)
        {
            var stuFromRamallah = from s in students where s.address == "Ramallah" select s;
            Console.WriteLine("Students who are from Ramallah are : ");
            foreach (Student st in stuFromRamallah)
            {
                Console.WriteLine("Name : {0}\tAddress: {1}", st.FirstName, st.address);
            }
            Console.WriteLine("-----------------------------------------------------\n");
            return stuFromRamallah.ToList<Student>();
        }

        public static List<Student> OrderByName(List<Student> students)
        {
            // List<Student> ordered = students.OrderBy(x => x.FirstName).ToList<Student>();

            var nonList = from s in students orderby s.FirstName select s;

            List<Student> ordered = nonList.ToList<Student>();

            Console.WriteLine("Students Ordered By name: ");
            foreach (Student st in ordered)
            {
                Console.WriteLine("Name : {0}\tAddress: {1}", st.FirstName, st.address);
            }
            Console.WriteLine("-----------------------------------------------------\n");
            return ordered;
        }

        public static dynamic GroupByCity(List<Student> students)
        {
            var groupByAdd = students.GroupBy(x => x.address).Select(group => group).OrderBy(x => x.Key);
            return groupByAdd;
        }

        #endregion



        #region AddNumber 6-steps delegate , including events and callback

        private static void AdvanceLinqAndDelegateExamples()
        {


            ////method 1 :   delegate

            ////PerformCalculation blackBox1 = new PerformCalculation(AddNumbers);

            ////Console.WriteLine("Result: {0}", blackBox1(9000, 1));
            ////Console.ReadLine();



            ////method 2 :   delegate

            ////PerformCalculation blackBox2 = null;

            ////blackBox2 = AddNumbers;

            //blackBox2 += SubNumbers; // multicasting :: when u invoke u invoke the two functions
            ////Console.WriteLine("Result: {0}", blackBox2.Invoke(9000, 1));
            ////Console.ReadLine();





            //////method 3: delegate - non reusable code

            ////PerformCalculation blackBox3 = delegate(int x, int y)
            ////{
            ////    return x + y;
            ////};




            ////Console.WriteLine("Result: {0}", blackBox3.Invoke(9000, 1));
            ////Console.ReadLine();




            ////method 4: delegate using lamda expressions

            ////PerformCalculation blackBox4 = (x, y) => x + y;

            ////Console.WriteLine("Result: {0}", blackBox4(9000, 1));
            ////Console.ReadLine();



            ////5-extension classes

            //List<decimal> ageList = new List<decimal>();
            ////   Loop through, gather ages of each person, add them to the list.
            //for (int count = 0; count < 10; count++)
            //{

            //    ageList.Add((count + 1));
            //}


            //Console.WriteLine("The average age is: {0}", ageList.GalaxySum(input=>input!="conditionforoutput"));
            //Console.ReadLine();



            //6-Delegate and Events and Call Back

            /* MainClass m = new MainClass();
             int x = m.ReiaseEvent(8, 7);
             // Console.WriteLine(x);
             Console.Read();
             * */
        }

        public static int AddNumbers(int x, int y)
        {
            return x + y;
        }

        public static int SubNumbers(int x, int y)
        {
            return x - y;
        }
        #endregion


    } // End Of Class


    // used in 5-extension classes in previous region to add GalaxySum to any list of its type of decimal 
     #region ExtensionMethods 
    static class ExtensionMethods
    {



        public static dynamic GalaxySum(this IEnumerable<decimal> list, Func<dynamic, dynamic> pred)
        {
            
                dynamic sum = 0;
                foreach (dynamic age in list)
                    sum += age;
                return sum;
            
        }

  
    }
    #endregion 
}
