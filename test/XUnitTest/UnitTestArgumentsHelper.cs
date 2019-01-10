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
            // return default on null
            Assert.Equal("fail2ban.log", ArgumentsHelper.GetInputFile(null));
        }

        [Fact]
        public void TestGetLogFile2()
        {
            string[] input = new string[] { };

            // return default on null
            Assert.Equal("fail2ban.log", ArgumentsHelper.GetInputFile(input));
        }

        [Fact]
        public void TestGetLogFile3()
        {
            string[] input = new string[] { "-o", "output.txt" };

            // return default on null
            Assert.Equal("fail2ban.log", ArgumentsHelper.GetInputFile(input));
        }


        [Fact]
        public void TestGetLogFile4()
        {
            string[] input = new string[] { "-r", "test.log" };
            Assert.Equal("test.log", ArgumentsHelper.GetInputFile(input));
        }

        [Fact]
        public void TestGetLogFile5()
        {
            string[] input = new string[] { "-r", "logfile.txt", "-o", "host.deny", "-i", "123.123.123.123" };
            Assert.Equal("logfile.txt", ArgumentsHelper.GetInputFile(input));
        }

        [Fact]
        public void TestGetLogFile6()
        {
            string[] input = new string[] { "--read", "logfile.txt", "-o", "host.deny", "-i", "123.123.123.123" };
            Assert.Equal("logfile.txt", ArgumentsHelper.GetInputFile(input));
        }

        [Fact]
        public void TestGetLogFile7()
        {
            string[] input = new string[] { "-o", "host.deny", "--read", "logfile.txt", "-i", "123.123.123.123" };
            Assert.Equal("logfile.txt", ArgumentsHelper.GetInputFile(input));
        }
        [Fact]
        public void TestGetLogFile8()
        {
            string[] input = new string[] { "-o", "host.deny", "-i", "123.123.123.123", "--read", "logfile.txt" };
            Assert.Equal("logfile.txt", ArgumentsHelper.GetInputFile(input));
        }

        [Fact]
        public void TestGetLogFile9()
        {
            string[] input = new string[] { "-o", "host.deny", "-i", "123.123.123.123", "--read", };
            Assert.Equal("fail2ban.log", ArgumentsHelper.GetInputFile(input));
        }

        [Fact]
        public void TestGetLogFile10()
        {
            string[] input = new string[] { "-o", "host.deny", "-i", "123.123.123.123", "-r" };
            Assert.Equal("fail2ban.log", ArgumentsHelper.GetInputFile(input));
        }

    }
}
