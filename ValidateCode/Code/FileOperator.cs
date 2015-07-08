using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    public class FileOperator
    {
        public void SaveFile(string fullPath, string contents)
        {
            File.WriteAllText(fullPath, contents, Encoding.GetEncoding("UTF-8"));
        }
    }
}