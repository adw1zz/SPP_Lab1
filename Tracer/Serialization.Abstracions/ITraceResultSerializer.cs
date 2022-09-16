using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Tracer.Core.Classes;

namespace Tracer.Tracer.Serialization.Abstracions
{
    public interface ITraceResultSerializer
    {
        void Serialize(TraceResult traceResult, Stream to);
    }

    public class TraceResultSerializer : ITraceResultSerializer
    {
        public void Serialize(TraceResult traceResult, Stream to)
        {
            using StreamWriter writer = new(to);

            foreach (var theread in traceResult.Threads)
            {
                writer.WriteLine($"Thread id {theread.Id}");
                foreach (var method in theread.InnerMethods)
                {
                    writer.WriteLine($" {method.Class}.{method.Name} - {method.Time}");
                    foreach (var subMethod in method.methods)
                    {
                        WriteToFile(subMethod, "  ", writer);
                    }
                }
            }

            writer.Flush();
        }

        private void WriteToFile(Method method, string offset, StreamWriter to)
        {
            to.WriteLine($"{offset}{method.Class}.{method.Name} - {method.Time}");
            foreach (var subMethod in method.methods)
            {
                WriteToFile(subMethod, offset + " ", to);
            }
        }
    }
}
