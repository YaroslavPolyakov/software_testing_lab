using System;

namespace FrameworkTest.Utils
{
    class GettingTwoDaysAgoDate
    {
        public static DateTime date = DateTime.Now;
        public string twoDaysAgoDate = date.AddDays(-2).ToString("dd.MM.yyyy");
    }
}
