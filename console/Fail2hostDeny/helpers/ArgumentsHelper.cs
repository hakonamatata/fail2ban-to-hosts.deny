using System;
using System.Collections.Generic;
using System.Text;

namespace Fail2hostDeny.helpers
{
    /// <summary>
    /// Enum describing the logging level / verbose level1
    /// </summary>
    public enum VerboseLevel
    {
        Minimal, Info, All
    }

    /// <summary>
    /// Class for handling console arguments
    /// </summary>
    public class ArgumentsHelper
    {
        // remove constructor to prevent creating a ArgumentHelper object
        private ArgumentsHelper()
        {

        }

        /// <summary>
        /// Parse arguments and look for input log file
        /// </summary>
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

        /// <summary>
        /// Check command line arguments for verbose argument and set verbose level.  
        /// </summary>
        /// <returns>VerboseLevel enum</returns>
        public static VerboseLevel GetVerboseLevel(string[] args)
        {
            if (args == null)
            {
                return VerboseLevel.Minimal;
            }

            for (int i = 0; i < args.Length - 1; i++)
            {
                if (args[i] == "-v" || args[i] == "--verbose")
                {

                    switch (args[i + 1])
                    {
                        case "0": return VerboseLevel.Minimal;
                        case "1": return VerboseLevel.Info;
                        case "2": return VerboseLevel.All;

                        default: return VerboseLevel.Minimal;
                    }

                }

            }

            return VerboseLevel.Minimal;
        }


    }
}
