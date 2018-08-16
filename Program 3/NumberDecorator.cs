using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program_3
{
    public class NumberDecorator : StreamDecorator
    {
        private IOutput wrapped;
        private int currLine = 0;
        public NumberDecorator(IOutput output) { wrapped = output; }
        public override void Write(object o)
        {
            wrapped.Write(string.Format("{0,5}: {1}\n", ++currLine, o));
        }

        public override void WriteString(string str)
        {
            wrapped.WriteString(string.Format("{0,5}: {1}\n", ++currLine, str));
        }
    }
}