using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KSValidator
{
    class inputSource
    {
        protected string name;
        protected string code;
        protected string path= "nowhere";
        public string getName { get { return name; } }
        public string getCode { get { return code; } }
        public string getPath { get { return path; } }

    }
    class fromFile : inputSource
    {
        
        public fromFile(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("could not find" + fileName);

            FileStream fs = File.OpenRead(fileName);

            
            this.name = Path.GetFileName(fs.Name);
            this.path = Path.GetFullPath(fs.Name);
            this.code = System.IO.File.ReadAllText(this.name);
        }
        
    }
    class fromArgs : inputSource
    {
        public fromArgs(string arg)
        {
            this.name = "Command Line Argument";
            this.code = arg;
        }
    }
    class fromSTDIN : inputSource
    {
        public fromSTDIN()
        {
            this.name = "STDIN";
        }

    }
}
