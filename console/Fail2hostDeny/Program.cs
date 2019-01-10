using Fail2hostDeny.helpers;
using System;

namespace Fail2hostDeny
{
    class Program
    {
        private const string usageText = "Usage: fail2hostDeny.exe -i fail2ban.log -o host.deny";

        static int Main(String[] args)
        {

            if (args.Length < 2)
            {
                Console.WriteLine(usageText);
                return 1;
            }

            foreach (string s in args)
            {
                Console.WriteLine(s);
            }

            //ArgumentsHelper argHelper = new ArgumentsHelper();
            //string inputFile = argHelper.GetInputFile(args);

            return 0;

        }


    }
}
