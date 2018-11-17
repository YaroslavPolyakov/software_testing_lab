using System.Collections.Generic;
using System.Linq;

namespace Laba_1
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<int> Marks { get; set; }
        public int averageMarkStudent() => (int)Marks?.Average();
    }
}
