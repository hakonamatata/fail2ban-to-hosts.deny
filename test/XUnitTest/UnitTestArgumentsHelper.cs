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

            string[] input = new string[] { };

            // return default on null
            Assert.Equal("fail2ban.log", argHelper.GetInputFile(input));
        }

        [Fact]
        public void TestGetLogFile3()
        {
            ArgumentsHelper argHelper = new ArgumentsHelper();

            string[] input = new string[] { "-o", "output.txt" };

            // return default on null
            Assert.Equal("fail2ban.log", argHelper.GetInputFile(input));
        }


        [Fact]
        public void TestGetLogFile4()
        {
            ArgumentsHelper argHelper = new ArgumentsHelper();

            string[] input = new string[] { "-r", "test.log" };

            Assert.Equal("test.log", argHelper.GetInputFile(input));
        }

        [Fact]
        public void TestGetLogFile5()
        {
            ArgumentsHelper argHelper = new ArgumentsHelper();

            string[] input = new string[] { "-r", "logfile.txt", "-o", "host.deny", "-i", "123.123.123.123" };

            Assert.Equal("logfile.txt", argHelper.GetInputFile(input));
        }

        [Fact]
        public void TestGetLogFile6()
        {
            ArgumentsHelper argHelper = new ArgumentsHelper();

            string[] input = new string[] { "--read", "logfile.txt", "-o", "host.deny", "-i", "123.123.123.123" };

            Assert.Equal("logfile.txt", argHelper.GetInputFile(input));
        }

        [Fact]
        public void TestGetLogFile7()
        {
            ArgumentsHelper argHelper = new ArgumentsHelper();

            string[] input = new string[] { "-o", "host.deny", "--read", "logfile.txt", "-i", "123.123.123.123" };

            Assert.Equal("logfile.txt", argHelper.GetInputFile(input));
        }
        [Fact]
        public void TestGetLogFile8()
        {
            ArgumentsHelper argHelper = new ArgumentsHelper();

            string[] input = new string[] { "-o", "host.deny", "-i", "123.123.123.123", "--read", "logfile.txt" };

            Assert.Equal("logfile.txt", argHelper.GetInputFile(input));
        }

        [Fact]
        public void TestGetLogFile9()
        {
            ArgumentsHelper argHelper = new ArgumentsHelper();

            string[] input = new string[] { "-o", "host.deny", "-i", "123.123.123.123", "--read", };

            Assert.Equal("fail2ban.log", argHelper.GetInputFile(input));
        }

        [Fact]
        public void TestGetLogFile10()
        {
            ArgumentsHelper argHelper = new ArgumentsHelper();

            string[] input = new string[] { "-o", "host.deny", "-i", "123.123.123.123", "-r" };

            Assert.Equal("fail2ban.log", argHelper.GetInputFile(input));
        }

    }
}
