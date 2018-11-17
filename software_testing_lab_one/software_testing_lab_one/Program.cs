using System;
using System.Collections.Generic;

namespace Laba_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentPolyakov = new Student { FirstName = "Yaroslav", LastName = "Polyakov", Marks = new List<int> { 8, 9, 7 } };
            var studentKharseko = new Student { FirstName = "Nikita", LastName = "Kharseko", Marks = new List<int> { 4, 6, 5, 4 } };

            var students = new List<Student> { studentPolyakov, studentKharseko };

            var studentsGroupList = new List<Group> { new Group { GroupName = "Group №2", Students = students } };

            //commit number one
            //commit number one in develop branch
            //commit number two
            //commit number two in develop branch
            //commit number three

            foreach (var item in students)
            {
                Console.WriteLine("Average mark - " + item.FirstName + ": " + item.averageMarkStudent());
            }
            foreach (var item in studentsGroupList)
            {
                Console.WriteLine("Average mark - " + item.GroupName + ": " + item.AverageMarkStudents());
            }

            Console.ReadLine();
        }
    }
}
