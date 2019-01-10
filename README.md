# fail2ban-to-hosts.deny
Take output from fail2ban and create a host.deny file to IP ban hackers permanently from your linux box. 

As a server administrator having an publicly accessable server with ssh, sftp etc open, one will without exception experience a constant traffic of bot-nets attempting to gain access to your server using a simple brute forcing attack (attempting different username and password combinations every few seconds). 

A common way to circumvent this problem is to run the fail2ban service. This will ban an IP for 10 minutes if it fails to log in 5 times in a row. A good enough solution to prevent access to the server (given you have a strong password), but why allow hackers to guess the password in the first place? Why not just permanently ban these hackers and not allow them to even attempt to log in ever again. That is what this project is for. 

## Preparation

The first thing you need is a log file containing log in attempts from the fail2ban service. 

If you do not have fail2ban running, you can install it with this simple command:

```sudo apt-get install fail2ban```

After running fail2ban for a while the log file will soon reveal a long list of IP addresses bellonging to malicious actors. 


## HOW TO RUN

```
NAME:
   fail2hostdeny - create host.deny file from fail2ban log file(s)

USAGE:
   dotnet fail2hostdeny.dll -r fail2ban.log -o host.deny -i 123.123.123.123

OPTIONS:
   --read, -r                           input file  (default: "fail2ban.log")
   --output, -o output file             output file (default: "host.deny")
   --verbose, -v verbose level          verbose level, 0 - minimal, 1 - info, 2 - warnings, 3 - error, 4 - all (default: 0)
   --ignore, -i ignore IP(s)            ignore IPs  (default: 127.0.0.1, 192.168.1.1, 192.168.2.1)
   --help, -h                           show help

```

## Example fail2ban.log input file

#### fail2ban.log
```
2018-12-31 09:14:43,015 fail2ban.filter         [1164]: INFO    [sshd] Found 188.92.77.235 - 2018-12-31 09:14:43
2018-12-31 09:14:43,249 fail2ban.filter         [1164]: INFO    [sshd] Found 188.92.77.235 - 2018-12-31 09:14:43
2018-12-31 09:15:45,107 fail2ban.filter         [1164]: INFO    [sshd] Found 188.92.77.235 - 2018-12-31 09:15:45
2018-12-31 09:15:45,333 fail2ban.filter         [1164]: INFO    [sshd] Found 188.92.77.235 - 2018-12-31 09:15:45
2018-12-31 09:15:45,348 fail2ban.actions        [1164]: NOTICE  [sshd] Ban 188.92.77.235
2018-12-31 14:12:58,477 fail2ban.filter         [1164]: INFO    [sshd] Found 96.27.121.211 - 2018-12-31 14:12:58
2018-12-31 14:13:02,465 fail2ban.filter         [1164]: INFO    [sshd] Found 198.211.118.157 - 2018-12-31 14:13:02
2018-12-31 14:13:17,108 fail2ban.filter         [1164]: INFO    [sshd] Found 50.226.108.234 - 2018-12-31 14:13:17
2018-12-31 14:19:16,776 fail2ban.filter         [1164]: INFO    [sshd] Found 80.67.252.7 - 2018-12-31 14:19:16
2018-12-31 14:19:24,367 fail2ban.filter         [1164]: INFO    [sshd] Found 193.201.224.232 - 2018-12-31 14:19:24
2018-12-31 14:19:25,086 fail2ban.filter         [1164]: INFO    [sshd] Found 193.201.224.232 - 2018-12-31 14:19:25
2018-12-31 14:19:25,789 fail2ban.filter         [1164]: INFO    [sshd] Found 193.201.224.232 - 2018-12-31 14:19:25
2018-12-31 14:19:26,495 fail2ban.filter         [1164]: INFO    [sshd] Found 193.201.224.232 - 2018-12-31 14:19:26
2018-12-31 14:19:28,099 fail2ban.filter         [1164]: INFO    [sshd] Found 193.201.224.232 - 2018-12-31 14:19:27
2018-12-31 14:19:28,376 fail2ban.filter         [1164]: INFO    [sshd] Found 193.201.224.232 - 2018-12-31 14:19:28
2018-12-31 14:19:28,488 fail2ban.actions        [1164]: NOTICE  [sshd] Ban 193.201.224.232
```

## Example result 

#### /etc/hosts.deny
```
##### To block SSH Access #####
sshd: 188.92.77.235
sshd: 96.27.121.211
sshd: 198.211.118.157
sshd: 50.226.108.234

##### To block FTP Access #####
vsftpd: 192.168.1.100
vsftpd: 192.168.1.0/255.255.255.0
```