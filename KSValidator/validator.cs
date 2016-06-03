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
        public static void PrintErrors(String code, string name)
        {
            var v = listErrors(code, name);
            foreach (var e in v)
                Console.WriteLine("Error code {0} (line {1}, col {2}) : {3}", e.Code, e.Line, e.Column, e.Message);
            Console.WriteLine("{0} Errors.", v.Count());
        }

        public static List<ParseError> listErrors(String code)
        {
            return listErrors(code, "");
        }

        public static List<ParseError> listErrors(String code, string name)
        {

            Parser p = (new Parser(new Scanner()));
            return p.Parse(code,name).Errors;

        }
    }
}
