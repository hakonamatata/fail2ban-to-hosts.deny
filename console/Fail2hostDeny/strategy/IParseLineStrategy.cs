using System;
using System.Collections.Generic;
using System.Text;

namespace Fail2hostDeny.strategy
{
    public interface IParseLineStrategy
    {
        string Execute(string line);
    }
}
