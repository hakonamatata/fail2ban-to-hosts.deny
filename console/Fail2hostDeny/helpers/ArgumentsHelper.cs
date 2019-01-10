using System;
using System.Collections.Generic;
using System.Text;

namespace Fail2hostDeny.helpers
{
    public class ArgumentsHelper
    {
        public string GetInputFile(string[] args)
        {
            if (args == null)
            {
                return "fail2ban.log";
            }

            for (int i = 0; i < args.Length - 1; i++)
            {
                if (args[i] == "-r")
                {
                    return args[i + 1];
                }

            }

            return "fail2ban.log";
        }
    }
}
