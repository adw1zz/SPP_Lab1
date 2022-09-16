using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Tracer.Core.Classes;
using Tracer.Tracer.Serialization.Abstracions;

namespace Tracer.Serialization.SerializationJson
{
    public class TraceResultSerializerJson : ITraceResultSerializer
    {
        public void Serialize(TraceResult traceResult, Stream to)
        {
            using StreamWriter writer = new(to);
            using JsonTextWriter jsonWriter = new(writer);
            JsonSerializer ser = new();
            ser.Serialize(jsonWriter, traceResult);
            jsonWriter.Flush();
        }
    }
}
