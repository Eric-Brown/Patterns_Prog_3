using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program_3
{
    public abstract class StreamDecorator : IOutput
    {
        public abstract void Write(object o);
        public abstract void WriteString(string str);
    }
}