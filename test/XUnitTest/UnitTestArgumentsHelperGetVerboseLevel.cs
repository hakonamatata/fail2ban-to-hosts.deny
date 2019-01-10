using Fail2hostDeny.helpers;
using System;
using Xunit;

namespace XUnitTest
{
    public class UnitTestArgumentsHelperGetVerboseLevel
    {
        [Fact]
        public void TestGetVerboseLevel1()
        {
            Assert.Equal(VerboseLevel.Minimal, ArgumentsHelper.GetVerboseLevel(null));
        }

        [Fact]
        public void TestGetVerboseLevel2()
        {
            string[] input = new string[] { };
            Assert.Equal(VerboseLevel.Minimal, ArgumentsHelper.GetVerboseLevel(input));
        }

        [Fact]
        public void TestGetVerboseLevel3()
        {
            string[] input = new string[] { "-v", "1" };
            Assert.Equal(VerboseLevel.Info, ArgumentsHelper.GetVerboseLevel(input));
        }

        [Fact]
        public void TestGetVerboseLevel4()
        {
            string[] input = new string[] { "--verbose", "2" };
            Assert.Equal(VerboseLevel.All, ArgumentsHelper.GetVerboseLevel(input));
        }
    }
}
