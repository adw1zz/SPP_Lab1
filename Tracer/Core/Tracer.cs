using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Tracer.Tracer.Core.Interfaces;
using Tracer.Tracer.Core.Classes;

namespace Tracer.Tracer.Core
{
    internal class Tracer : Itracer
    {

        private TraceResult result = new TraceResult();

        public void StartTrace()
        {
            StackTrace stackTrace = new StackTrace();
            var method = stackTrace.GetFrame(1).GetMethod();
            Method tracemethod = new Method() { Name = method.Name, Class = method.DeclaringType.Name };

            result.AddMethodToLResList(tracemethod, Environment.CurrentManagedThreadId);
            tracemethod.StartTracing();
        }

        public void StopTrace()
        {
            result.StopTraceMethod(Environment.CurrentManagedThreadId);
        }

        public TraceResult GetTraceResult()
        {
            return result;
        }
    }
}