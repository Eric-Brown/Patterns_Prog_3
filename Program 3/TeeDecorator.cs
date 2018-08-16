using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program_3
{
    public class TeeDecorator : StreamDecorator
    {
        private IOutput wrapped;
        private IOutput split;

        public TeeDecorator(IOutput output, IOutput splitted)
        {
            wrapped = output;
            split = splitted;
        }
        public override void Write(object o)
        {
            wrapped.Write(o);
            split.Write(o);
        }

        public override void WriteString(string str)
        {
            wrapped.Write(str);
            split.Write(str);
        }
    }
}