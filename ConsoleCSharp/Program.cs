
        /*
         * Wellcome to Bashminal Prompt
         * Copy right 2017
         * Lience: Nguyen Van Anh Tuan
         * This is the combine of 3 commandline: Bash on Linux, Terminal on MacOS X and Command Prompt on Windows.
         */




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using "login.cs";

//using System.Deployment.Application;
//using System.Boolean;

namespace ConsoleCSharp
{
    
    class Program
    {
        static string uName;
        static string passWord;
        static string confirmPass;
        static string hostName;
        static string command;
        static string title;
        static string dir = Directory.GetCurrentDirectory();
        static string tempDir = @"c:\temp";
        static string cd;
        static string currentDir;
        static string temp;
        static string path;
        static string[] commandList = new string[] 
        { // all the command
            " help", " cd", " ls", " dir", " cls", " clr", " clear", " title", " ext", " rm", " mkdir", " rn", " new", " mv",       " hostname -ch", " quit", " password -ch", " echo", " print", " username -ch", "color", 
        };
        static string currentPass;

        //public bool IsFirstRun
        //{
        //    [PermissionSetAttribute(SecurityAction.Assert, Name = "FullTrust")]
        //    get;
        //}


        static void Main(string[] args)
        {
            //Cal();
            Hello();
            Console.ForegroundColor = ConsoleColor.White;
        Start:
            if (passWord != null)
            {
                SetUserFirstTime();
            }
            else
            {
                Command(); // start typing command
            }

            //Command();   
            goto Start;
        }
        static void Hello()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = "Bashminal Prompt";
            Console.WriteLine("Wellcome to Bashminal Prompt!");
        }
        static void ChangePassword()
        {
            Console.Write("Enter current password: ");
            currentPass = Console.ReadLine();
            Console.Write("Enter new password: ");
            passWord = Console.ReadLine();
            Console.Write("Confirm password: ");
            confirmPass = Console.ReadLine();
        }
        static void SetUserFirstTime()
        {
            if (passWord == null)
            {
                Console.Write("New User name: ");
                uName = Console.ReadLine();                

            Again:
                Console.Write("New Password: ");
                passWord = Console.ReadLine();
                Console.Write("Retype Password: ");
                confirmPass = Console.ReadLine();
                Console.Write("Change your host name: ");
                hostName = Console.ReadLine();
                StreamWriter sr = new StreamWriter("Save-User-Info.txt");
                sr.WriteLine(uName);
                Console.WriteLine(Environment.NewLine); // new line
                sr.WriteLine(passWord);
                sr.WriteLine(confirmPass);
                sr.WriteLine(hostName);
                sr.Close();
                if ((passWord == confirmPass) && (uName != null) && (hostName != null))
                {
                    Console.WriteLine("Set User and Password Complete!");
                    Command();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("PassWord not match, retype password!");
                    goto Again;
                }
            }
        }
        static void ChangeUserName()
        {
            //again:
            if (passWord == null)
            {
                SetUserFirstTime();
            }
            else
            {
                Console.Write("New User name: ");
                uName = Console.ReadLine();
                Console.WriteLine("Set user name complete!");
            }
        }
        static void ChangeHostName()   
        {
            again:
            if (passWord == null)
            {
                SetUserFirstTime();
            }
            else
            {
                Console.Write("Password: ");
                currentPass = Console.ReadLine();
                if (currentPass == passWord)
                {
                    Console.Write("Enter your hostname: ");
                    hostName = Console.ReadLine();
                    Console.WriteLine("Hostname set done!");
                }
                else
                {
                    Console.WriteLine("Password is wrong!");
                    if (passWord == "exit" || passWord == "quit")
                    {
                        Command(); // back to the command() function when user type exit or quit
                    }
                    else
                    {
                        goto again;
                    }
                }
            }

        }
        // define some command use in bashminal prompt (b-m-p)
        static void Command()
        {
        again:
            Console.WriteLine();
            Console.Write("{0}@{1}>", uName, hostName);
            command = Console.ReadLine();
            Console.WriteLine();

            if (command == "help") 
            {
                foreach (string item in commandList)
                {
                    Console.WriteLine("{0}", item);
                }
            } 
            else 
            {
                #region switch case command
                            // old version // this is old version
                // i use switch case for user choose command
                //switch (command)
                //{
                //    case "cls":
                //    case "clr":
                //    case "clear":
                //        Console.Clear();
                //        goto again;
                //    case "title":
                //        Console.Write("Enter new title: ");
                //        title = Console.ReadLine();
                //        Console.Title = title;
                //        goto again;
                //    case "dir":
                //        Console.WriteLine("{0}", dir);
                //        goto again;
                //    case "cd":
                //        Console.Write("Enter your directory: \n {0}\\{1}", dir, temp);
                //        temp = Console.ReadLine();
                //        //Directory.CreateDirectory(temp); // create new folder
                //        Directory.SetCurrentDirectory(dir);
                //        Console.WriteLine("The current directory is: {0}", dir);
                //        goto again;
                //    case "mkdir":
                //        Directory.CreateDirectory(temp = Console.ReadLine());
                //        goto again;
                //    case "rm":
                //        Console.Write("Enter your file name");
                //        temp = Console.ReadLine();
                //        File.Delete(temp);
                //        if (!File.Exists(temp))
                //        {
                //            Console.WriteLine("Unrecognize File Path or file name");
                //        }
                //        else
                //        {
                //            File.Delete(temp);
                //        }
                //        goto again;
                //    case "exit":
                //        Environment.Exit(0);
                //        goto again;
                //    case "rn":
                //        temp = Console.ReadLine();
                //        Console.WriteLine(temp);
                //        goto again;
                //    case "new":

                //        goto again;
                //    case "mv":
                //        // end here
                //        goto again;
                //    default:
                //        Console.Write("Unrecognize command!");
                //        break;
                //}
                #endregion 
                #region if else command list function 
                // this is new version
                if (command == "cls" || command == "clr" || command == "clear")
                {
                    Console.Clear();
                    goto again; // re-print username@hostname>
                }
                else if (command == "mkdir")
                {
                    Directory.CreateDirectory(temp = Console.ReadLine());
                    goto again;
                }
                else if (command == "rm")
                {
                    Console.Write("Enter your file name");
                    temp = Console.ReadLine();
                    File.Delete(temp);
                    if (!File.Exists(temp))
                    {
                        Console.WriteLine("unrecognize file path or file name");
                    }
                    else
                    {
                        File.Delete(temp);
                    }
                    goto again;
                }
                else if (command == "echo" || command == "Echo" || command == "eCho" || command == "ecHo" || command == "echO")
                {
                    // code here!
                    Console.Write("Echo: ");
                    temp = Console.ReadLine();
                    Console.WriteLine(temp);
                    goto again;
                }
                else if (command == "print" || command == "Print" || command == "pRint" || command == "prInt" || command == "priNt" || command == "prinT")
                {
                    Console.Write("Print: ");
                    temp = Console.ReadLine();
                    Console.WriteLine(temp);
                    goto again;
                }
                else if (command == "color")
                { 
                
                }
                else if (command == "title")
                {
                    Console.Write("Title change to: ");
                    title = Console.ReadLine();
                    Console.Title = title;
                    goto again;
                }
                else if (command == "hostname -ch")
                {
                    ChangeHostName();
                    goto again;
                }
                else if (command == "username -ch")
                {
                    ChangeUserName();
                    goto again;
                }
                else if (command == "password -ch")
                {
                    ChangePassword();
                    goto again;
                }
                else if (command == "ls" || command == "dir")
                {
                    //ProcessFile(path); 
                    goto again;
                }
                else if (command == "exit" || command == "quit")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Unrecognize Command. Use 'help' to know more!");
                    goto again;
                }
                #endregion
            }
        }
    }
}
