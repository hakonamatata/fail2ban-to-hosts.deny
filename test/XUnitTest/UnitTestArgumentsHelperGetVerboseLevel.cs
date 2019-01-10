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
            // return default on null
            Assert.Equal(VerboseLevel.Minimal, ArgumentsHelper.GetVerboseLevel(null));
        }

        [Fact]
        public void TestGetVerboseLevel2()
        {
            string[] input = new string[] { };

            // return default on null
            Assert.Equal(VerboseLevel.Minimal, ArgumentsHelper.GetVerboseLevel(input));
        }
    }
}
