using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program_3
{
    public class LineDecorator : StreamDecorator
    {
        private IOutput wrapped;
        public LineDecorator(IOutput output)
        {
            wrapped = output;
        }
        public override void Write(object o)
        {
            wrapped.Write(string.Format("{0}\n", o));
        }

        public override void WriteString(string str)
        {
            wrapped.WriteString(str + '\n');
        }
    }
}