using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program_3
{
    public interface IOutput
    {
        void Write(Object o);
        void WriteString(String str);
    }
}