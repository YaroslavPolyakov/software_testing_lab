using NUnit.Framework;
using FrameworkTest.Steps;

namespace Framework
{
    [TestFixture]
    public class Tests
    {
        private Step step = new Step();
        private const string USERNAME = "YPaliakou";
        private const string PASSWORD = "!@#$QWER";
        private const int REPOSITORY_RANDOM_POSTFIX_LENGTH = 6;

        [Test]
        public void CanChooseDepDateBeforeTodayDate()
        {
            Step step = new Step();
        }

        [Test]
        public void OneCanLoginGithub()
        {
            step.EnterCities(USERNAME, PASSWORD);
            Assert.AreEqual(USERNAME, step.GetLoggedInUserName());
        }
    }
}