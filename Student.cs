using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ___University_Manager
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int UniversityId { get; set; }



        public void Print()
        {
            Console.WriteLine($"Name: {Name} \nID: {Id} \nGender: {Gender} \nAge: {Age} \nUniversityID: {UniversityId}");
            Console.WriteLine();

            //I added the spacing here so the next student will be printed after a linespacing; to make it appear neater,
            //and so that the University manager does not have to manually print an empty space when calling the print() 
        }
    }
}
