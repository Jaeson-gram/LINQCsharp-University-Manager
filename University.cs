using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ___University_Manager
{
    internal class University
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public void Print()
        {
            Console.WriteLine($"Universitty Name: {Name} \nUniversity ID: {Id}");
            Console.WriteLine();
        }

        public void universityNamePrint()
        {
            Console.Write(Name);
        }
    }
}
