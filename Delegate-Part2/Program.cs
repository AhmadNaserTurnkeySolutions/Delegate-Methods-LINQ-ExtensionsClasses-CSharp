using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Part2
{
    class Program
    {
        delegate List<Student> StudentsDel(List<Student> stu);





        // IOrderedEnumerable<IGrouping<string, Student>> 
        delegate dynamic GroupsDel(List<Student> stu);



        delegate int PerformCalculation(int x, int y);



        static void Main(string[] args)
        {



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


            //step 2 : initialize Delegate

            StudentsDel stuDel = new StudentsDel(OrderByName);
            stuDel += new StudentsDel(StuAfter88);
            stuDel += new StudentsDel(StuFromRamallah);
       


            //   List<Student> sts = stuDel(students);



            stuDel(students);// step 3 : call Delegate


            GroupsDel groupsDel = new GroupsDel(GroupByCity);

           // IOrderedEnumerable<IGrouping<string, Student>> 
           dynamic groupByAdd = groupsDel(students);

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







            //method 1 :   delegate

            PerformCalculation blackBox1 = AddNumbers;

            Console.WriteLine("Result: {0}", blackBox1(9000, 1));
            Console.ReadLine();



            //method 2 :   delegate

            PerformCalculation blackBox2 = null;

            blackBox2 = AddNumbers;

            Console.WriteLine("Result: {0}", blackBox1.Invoke(9000, 1));
            Console.ReadLine();





            //method 3: delegate

            PerformCalculation blackBox3 = delegate(int x, int y)
            {
                return x + y;
            };

            Console.WriteLine("Result: {0}", blackBox3(9000, 1));
            Console.ReadLine();




            //method 4: delegate using lamda expressions

            PerformCalculation blackBox4 = (x, y) => x + y;

            Console.WriteLine("Result: {0}", blackBox4(9000, 1));
            Console.ReadLine();



            //extension classes

            List<int> ageList = new List<int>();
            // Loop through, gather ages of each person, add them to the list.
            for (int count = 0; count < 10; count++)
            {

                ageList.Add((count + 1));
            }


            Console.WriteLine("The average age is: {0}", ageList.GalaxyAverage());
            Console.ReadLine();



        }



        public static List<Student> StuAfter88(List<Student> students)
        {
            //var stuAfter88 = from s in students where s.Birthdate.Year > 1988 select s;

            List<Student> stuAfter88 = students.Where(s => s.Birthdate.Year > 1988).OrderBy(s=>s.FirstName).ToList<Student>();

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

            List<Student> ordered=nonList.ToList<Student>();

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





        public static int AddNumbers(int x, int y)
        {
            return x + y;
        }



    }

    static class ExtensionMethods
    {

        public static int GalaxyAverage(this List<int> list)
        {
            int sum = 0;
            foreach (int age in list)
                sum += age;
            return sum / list.Count;
        }
    }
}
