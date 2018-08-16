using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Program_3
{
    public class StreamOutput : IOutput
    {
        private StreamWriter sink;
        public StreamOutput(Stream toSink)
        {
            sink = new StreamWriter(toSink);
            sink.AutoFlush = true;
        }
        public void Write(object o)
        {
            sink.Write(o);
        }

        public void WriteString(string str)
        {
            sink.Write(str);
        }
    }
}