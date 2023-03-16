using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ___University_Manager
{
    internal class UniversityManager
    {
        public List<University> universities { get; set; }
        public List<Student> students { get; set; }

        //constructor       
        public UniversityManager()
        {

            //initialize the Uni and Stu
            universities = new List<University>();
            students = new List<Student>();

            //Add some Unis
            universities.Add(new University() { Id = 1, Name = "Federal University Of Technology, Akure"});
            universities.Add(new University() { Id = 2, Name = "University of Amsterdam" });
            universities.Add(new University() { Id = 3, Name = "Vilanova University" });

            //Add some Stus
            students.Add(new Student() { Id = 1, Name = "Okey Jey", Age = 22, Gender = "Male", UniversityId = 2 });
            students.Add(new Student() { Id = 2, Name = "Amarachi Eze", Age = 25, Gender = "Female", UniversityId = 2 });
            students.Add(new Student() { Id = 3, Name = "Claudia Roberts", Age = 20, Gender = "Female", UniversityId = 2 });
            students.Add(new Student() { Id = 4, Name = "Frank Abbot", Age = 23, Gender = "Male", UniversityId = 1 });
            students.Add(new Student() { Id = 5, Name = "Lisa Bonnet", Age = 22, Gender = "Female", UniversityId = 1 });
            students.Add(new Student() { Id = 6, Name = "June Miracle", Age = 26, Gender = "Female", UniversityId = 3 });
            students.Add(new Student() { Id = 7, Name = "Sam Almiron", Age = 24, Gender = "Male", UniversityId = 3});

        }

        public void MaleStudents()
        {
            //                                LINQ QUERY
            IEnumerable<Student> maleStudents = from student in students where student.Gender == "Male" select student;

            Console.WriteLine("MALE STUDENTS:");
            Console.WriteLine();
            foreach (Student student in maleStudents)
            {
                student.Print();
            }
        }

        public void FemaleStudents()
        {
            //                                LINQ QUERY

            IEnumerable<Student> femalestudents = from student in students where student.Gender == "Female" select student;

            Console.WriteLine("FEMALE STUDENTS:");
            Console.WriteLine();

            foreach (Student student in femalestudents)
            {
                student.Print();
            }
        }

        // THIS METHOD SORTS THE STUDENTS BY AGE
        public void orderByAge()
        {
            Console.WriteLine("Students - By - Age:");
            IEnumerable<Student> studentsbyAge = from student in students orderby student.Age select student;

            Console.WriteLine();

            foreach (Student student  in studentsbyAge)
            {
                student.Print();
            }
        }

        //THIS METHODS SORT THE STUDENTS AND ONLY LISTS OUT THOSE IN VILANOVA UNIVERSITY
        public void VilanovaStudents()
        {                                           //from the students list, create a var named 'student'  (just like the foreach loop does)
            IEnumerable<Student> vilanovaStudents = from student in students 
                                                    
                                                    //create a variable called 'university' of same type with 'universities' link them, wherever the student's (student we just created) UniversityId equals our univerity's (the one we just created) Id
                                                    join university in universities on student.UniversityId equals university.Id 
                                                    
                                                    //and the name of the university is 'Vilanova', select it
                                                    where university.Name == "Vilanova University" select student;

            Console.WriteLine("Students - In - Vilanova University:");
            foreach (Student student in vilanovaStudents)
            {
                student.Print();
                Console.WriteLine();
            }
        }

        //THIS METHOD LETS YOU GIVE A UNIVERSITY ID, AND IT RETURNS THE STUDENTS IN THAT UNIVERSITY
        public void nameYourUniId()
        {
            //Int32.Parse(Id);
            string newId;

            Console.WriteLine("Provide the university Id (1, 2, or 3) of the students you are searching for:");

            try
            {

                int Id = Convert.ToInt32(Console.ReadLine());
                IEnumerable<Student> studentfromgivenId = from student in students join university in universities on student.UniversityId equals university.Id where university.Id == Id select student;

                Console.WriteLine("The-Students-In-The-University-With-The-Given-Id:");
                foreach (Student student in studentfromgivenId)
                {
                    //if (Id > 3 || Id < 1)
                    //{
                    //    Console.WriteLine("No University with that Id in our database");
                    //    nameYourUniId();
                    //}
                    //else

                    //the above (Commented Out) lines don't work, why?
                    {
                        student.Print();
                    }
                }
            }
            catch (Exception)
            {
                
                {

                }
                Console.WriteLine("Wrong Value!");
                nameYourUniId(); 
            }
            

            //this _ is a discard variable, it is used when a variable is unnecessary, maybe the developer just wants to use it once here, and no storage space is needed. Hence the name (discard)

        }

        //THIS METHOD DISPPLAYS A STUDENT'S NAME AND THEIR UNIVERSITY BY CREATING A COLLECTION FROM OUR COLLECTIONS
        public void studentsANDuniversityNamesCollection()
        {                       //from the students list, create a var named 'student'  (just like the foreach loop does)
            var newCollection = from student in students
                                //create a variable called 'university' of same type with 'universities', link them, wherever the student's (student we just created) UniversityId equals our univerity's (the one we just created) Id
                                join university in universities on student.UniversityId equals university.Id
                                //order it by the student's name
                                orderby student.Name
                                //create a collection of the student and university name, and select it...
                                select new { studentName = student.Name, gender = student.Gender, universityName = university.Name };

            Console.WriteLine("New Collection:");
            foreach (var studentcollection in newCollection)
            {
                Console.WriteLine($"* Student: {studentcollection.studentName},     {studentcollection.gender},       {studentcollection.universityName}");
            }

            // as with this method, we can get data from a database, or api, then create a table or a collection as this,
            // and store only what we need, as in here: the name and uviversity of the students, not age, or anything else
            //That's one of the relative advantages of LINQ, you can apply it to databases, APIs, or just, as seen here, random Lists/Collections
        }
    }
}
