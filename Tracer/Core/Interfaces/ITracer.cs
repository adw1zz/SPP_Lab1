using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Tracer.Core.Classes; 

namespace Tracer.Tracer.Core.Interfaces
{
    public interface Itracer
    {
        void StartTrace();

        void StopTrace();

        TraceResult GetTraceResult();
    }
}
