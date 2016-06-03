using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;


using CommandLine;

//using NDesk.Options;

namespace KSValidator
{
    class Program
    {

        static void Main(string[] args)
        {
           
           var opt = getCommandLineArgs(args);

            if(opt.help)
            {
                opt.showHelp();
                exit(0);
            }//*/

           foreach(inputSource input in opt.getInputs())
           {
               Console.WriteLine("input {0}", input.getName);
               Console.WriteLine("located at {0}", input.getPath);
               Validator.PrintErrors(input.getCode, input.getName);
               Console.WriteLine("\n");
           }

            // Keep the console window open in debug mode.
            exit(0);
        }

        static options getCommandLineArgs(string[] args)
        {
            Parser p = new Parser(settings => { settings.HelpWriter = null; settings.CaseSensitive = false; });
            var opt = new options();
            var result = p.ParseArguments(args, opt);
            return opt;
        }

        static void exit(Int32 c)
        {
#if DEBUG
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
#endif
            Environment.Exit(c);
        }       
    }
    
       

}
