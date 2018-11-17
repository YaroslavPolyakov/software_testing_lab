using System.Collections.Generic;
using System.Linq;

namespace Laba_1
{
    class Group
    {
        public string GroupName { get; set; }

        public List<Student> Students { get; set; }

        public int AverageMarkStudents()
        {
            var averageMark = (int)Students?.Select(x => x.averageMarkStudent())?.Average();
            return averageMark;
        }
    }
}
