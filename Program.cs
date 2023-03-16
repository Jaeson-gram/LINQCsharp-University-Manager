using System;

namespace LINQ___University_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating The Uiversity Manager object we'll use
            UniversityManager UniManager = new UniversityManager();

            //here's a list of the students we'll be using
            UniManager.studentsANDuniversityNamesCollection();
            Console.WriteLine();


            ////Get Male Students across our list
            //UniManager.MaleStudents();

            ////Get Female Students across our list
            //UniManager.FemaleStudents();

            ////Get students in a particular university
            //UniManager.VilanovaStudents();

            ////Get students by age
            //UniManager.orderByAge();

            //Provide a list of students in the unversity with ID provided 
            UniManager.nameYourUniId();


        }
    }
}