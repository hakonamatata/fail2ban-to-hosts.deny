using Fail2hostDeny.helpers;
using System;

namespace Fail2hostDeny
{
    class Program
    {
        private const string usageText = "Usage: fail2hostDeny.exe -i fail2ban.log -o host.deny";

        static int Main(string[] args)
        {

            // get verbose level to determine how much to print in console
            VerboseLevel verboseLevel = ArgumentsHelper.GetVerboseLevel(args);

            if (args.Length < 2)
            {
                Console.WriteLine(usageText);
                return 1;
            }

            //foreach (string s in args)
            //{
            //    Console.WriteLine(s);
            //}

            string inputFile = ArgumentsHelper.GetInputFile(args);

            if (verboseLevel == VerboseLevel.All)
            {
                Console.WriteLine("reading log file \"{0}\".", inputFile);
            }



            return 0;

        }


    }
}
