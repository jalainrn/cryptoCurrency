using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrency
{
    interface IFileParser
    {
        void Read(string path);
        void Write(string path, string toCopy);
        void Reformat(string fromPath, string toPath);
    }
}