using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Tracer.Tracer.Core.Classes
{
    public class Method
    {
        public List<Method> methods = new List<Method>();
        public string Name { get; set; }
        public string Class { get; set; }
        public long Time => _time;
        private Stopwatch sw;
        private long _time;
        public void StartTracing()
        {
            sw = new Stopwatch();
            sw.Start();
        }

        public void StopTracing()
        {
            sw.Stop();
           _time = sw.ElapsedMilliseconds;
        }
        

    }
}
