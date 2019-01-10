using Fail2hostDeny;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTest
{
    public class UnitTestFail2Ban
    {
        [Fact]
        public void TestParseLine1()
        {
            Fail2Ban f2b = new Fail2Ban();
            Assert.Equal("159.65.230.251", f2b.ParseLine("2018-12-30 06:42:40,171 fail2ban.filter [1164]: INFO [sshd] Found 159.65.230.251 - 2018-12-30 06:42:40"));
        }

    }
}
