using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommandLine;
using CommandLine.Text;

namespace KSValidator
{
    class options
    {

        [OptionArray('f', "inputFiles", MetaValue = "files", HelpText = "a list of input files to validate")]
        public String[] inputFiles { get; set; }

        [Option("useSTDIN",HelpText = "option  to enter code through standard input")]
        public bool useStdIn { get; set; }

        [Option("rawCode", HelpText = "enter raw code through the command line (Should be in quotes with all internal quotes properly escaped)", MetaValue = "\"...\"")]
        public string rawCode { get; set; }

        [Option('h', "Help", HelpText = "shows the help text")]
        public bool help { get; set; }

        [Option("longFileNames", HelpText = "use full path when printing a file name")]
        public bool longNames { get; set; }

        public void showHelp()
        {

            HelpText ht = new HelpText(
                "KSValidator: A simple out of game validator for the KerboScript Language\ncommand line switches are NOT case sensitive",
                "Free to share, distribute, and modify", this);
            Console.WriteLine(ht);

        }
        public IEnumerable<inputSource> getInputs()
        {
            List<inputSource> inputs = new List<inputSource>();

            if (rawCode != null)
            {
                inputs.Add(new fromArgs(rawCode));
#if DEBUG
                Console.WriteLine("got arguments");
#endif
            }
            if (useStdIn)
            {
                inputs.Add(new fromSTDIN());
            }

            if (inputFiles != null)
            foreach(string fileName in inputFiles)
            {
                inputs.Add(new fromFile(fileName));
            }
#if DEBUG
            else
                Console.WriteLine("no input files");
#endif
            return inputs;
        }

    }
}
