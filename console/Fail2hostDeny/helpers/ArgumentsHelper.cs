using System;
using System.Collections.Generic;
using System.Text;

namespace Fail2hostDeny.helpers
{
    public enum VerboseLevel
    {
        Error, Info, Warnings, All
    }

    public class ArgumentsHelper
    {
        // remove constructor to prevent creating a ArgumentHelper object
        private ArgumentsHelper()
        {

        }

        public static string GetInputFile(string[] args)
        {
            if (args == null)
            {
                return "fail2ban.log";
            }

            for (int i = 0; i < args.Length - 1; i++)
            {
                if (args[i] == "-r" || args[i] == "--read")
                {
                    return args[i + 1];
                }

            }

            return "fail2ban.log";
        }

        public static VerboseLevel GetVerboseLevel(string[] args)
        {
            //if (args == null)
            //{
            //    return "fail2ban.log";
            //}

            //for (int i = 0; i < args.Length - 1; i++)
            //{
            //    if (args[i] == "-r" || args[i] == "--read")
            //    {
            //        return args[i + 1];
            //    }

            //}

            return VerboseLevel.All;
        }


    }
}
