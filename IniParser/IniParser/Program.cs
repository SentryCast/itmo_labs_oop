using System;
using System.IO;
using System.Text;
using System.Collections.Generic;


namespace IniParser
{
    class Program
    {
        static IniParser TryAgainInitialize()
        {
            Console.WriteLine("Try again? (y/n)");
            string userTryAgain = Console.ReadLine();
            if (userTryAgain == "y" || userTryAgain == "yes")
            {
                Console.WriteLine("Enter the filename: ");
                string filename = Console.ReadLine();
                try
                {
                    IniParser iniparser = new IniParser(filename);
                    return iniparser;
                }
                catch (WrongEnteredException wee)
                {
                    Console.WriteLine(wee.weeMessage(filename));
                    return TryAgainInitialize();
                }
                
            }
            else
                return null;
        }
        static IniParser Initialize(string filename)
        {
            if(filename is null)
            {
                Console.WriteLine("You haven't entered anything. Provide filename.");
                return null;
            }
            try
            {
                IniParser iniparser = new IniParser(filename);
                return iniparser;
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("File not found");
                return TryAgainInitialize();
            }
            catch(PathTooLongException) {
                Console.WriteLine("filename exceeds the maximum supported filename length.");
            }
            catch (WrongEnteredException wee)
            {
                Console.WriteLine(wee.weeMessage(filename));
                return TryAgainInitialize();
                
            }
            return null;
        }
        

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the filename: ");

            string filename = Console.ReadLine();

            IniParser inip = Initialize(filename);
            if (inip is null)
            {
                Console.WriteLine("The program is closing");
                return;
            }

            try
            {
                inip.Parse();
            }
            catch(IncorrectStringFoundException e)
            {
                Console.WriteLine(e.isfeMessage());
            }

            Console.WriteLine("SECTION: ");
            string userSection = Console.ReadLine();
            Console.WriteLine("PARAMETER: ");
            string userParam = Console.ReadLine();
            Console.WriteLine("TYPE (int, double, string): ");
            string userType = Console.ReadLine();

            string value = inip.GetValue(userSection, userParam);
            if(value == null)
            {
                Console.WriteLine("Can't extract the value. The file doesn't contain entered Section or Parameter or both.");
            }
            else
            {
                try
                {
                    switch (userType)
                    {
                        case "int":
                            Convert.ToInt32(value);
                            if (value == null)
                                throw new MyCastException(userType, value);
                            break;
                        case "double":
                            Convert.ToDouble(value);
                            break;
                        case "string":
                            break;
                        default:
                            throw new MyCastException(userType, value);
                    }
                    Console.WriteLine(value);
                }
                catch(MyCastException e)
                {
                    Console.WriteLine(e.mceMessage());
                }
                catch(FormatException)
                {
                    Console.WriteLine($"Fail to convert value of \"{userParam}\" to {userType}");
                }

            }

        }
    }
}