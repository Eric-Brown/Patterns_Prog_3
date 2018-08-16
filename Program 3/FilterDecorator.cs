using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program_3
{
    public class FilterDecorator : StreamDecorator
    {
        private IOutput wrapped;
        private Func<object, bool> pred;
        public FilterDecorator(IOutput output, Func<object, bool> predicate)
        {
            wrapped = output;
            pred = predicate;
        }
        public override void Write(object o)
        {
            if (pred(o))
                wrapped.Write(o);
        }

        public override void WriteString(string str)
        {
            if (pred(str))
                wrapped.WriteString(str);
        }
    }
}