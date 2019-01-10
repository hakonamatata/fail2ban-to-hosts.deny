using Fail2hostDeny.helpers;
using System;
using Xunit;

namespace XUnitTest
{
    public class UnitTestArgumentsHelper
    {
        [Fact]
        public void TestGetLogFile1()
        {
            ArgumentsHelper argHelper = new ArgumentsHelper();

            // return default on null
            Assert.Equal("fail2ban.log", argHelper.GetInputFile(null));
        }

        [Fact]
        public void TestGetLogFile2()
        {
            ArgumentsHelper argHelper = new ArgumentsHelper();

            string[] input = new string[] { "-r", "test.log" };

            Assert.Equal("test.log", argHelper.GetInputFile(input));
        }

    }
}
