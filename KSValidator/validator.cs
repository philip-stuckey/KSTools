using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using kOS.Safe.Compilation.KS;

namespace KSValidator
{
    public class Validator
    {
        public static void PrintErrors(String code)
        {

            var v = listErrors(code);
            foreach (var e in v)
                Console.WriteLine("Error file {0} (line {1}, col {2}) :  {3}", e.File, e.Line, e.Column, e.Message);
            Console.WriteLine("code contains {0} Errors.", v.Count());
        }

        public static List<ParseError> listErrors(String code)
        {

            Parser p = (new Parser(new Scanner()));
            return p.Parse(code).Errors;

        }
    }
}
