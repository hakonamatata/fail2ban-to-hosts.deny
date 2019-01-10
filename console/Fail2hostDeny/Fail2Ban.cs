using Fail2hostDeny.strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fail2hostDeny
{
    /// <summary>
    /// All the main logic for handling the fail2ban.log file
    /// </summary>
    public class Fail2Ban
    {
        /// <summary>
        /// list of all IP's found in log file
        /// </summary>
        HashSet<string> IPs = new HashSet<string>();

        private IParseLineStrategy _parseLineStrategy;

        /// <summary>
        /// Set default parse line strategy / behavior
        /// </summary>
        public Fail2Ban()
        {
            this._parseLineStrategy = new ParseLineStrategy();
        }

        public Fail2Ban(IParseLineStrategy pls)
        {
            this._parseLineStrategy = pls;
        }

        /// <summary>
        /// Take a line from fail2ban.log file
        /// 
        /// Example: 2018-12-30 06:42:40,171 fail2ban.filter [1164]: INFO [sshd] Found 159.65.230.251 - 2018-12-30 06:42:40
        /// 
        /// Parse the text and extract the IP, in this example return "159.65.230.251"
        /// 
        /// </summary>
        /// <param name="line">line in fail2ban.log file</param>
        /// <returns>IP address</returns>
        public string ParseLine(string line)
        {
            // use strategy pattern to extract away parsing logic
            return this._parseLineStrategy.Execute(line);
        }
    }
}
