using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Tracer.Core.Classes;
using Tracer.Tracer.Serialization.Abstracions;
using YamlDotNet.Serialization;

namespace Tracer.Serialization.SerializationYaml
{
    public class TraceResultSerializerYaml : ITraceResultSerializer
    {
        public void Serialize(TraceResult traceResult, Stream to)
        {
            using StreamWriter writer = new(to);
            TextWriter yamlWriter = writer;
            Serializer ser = new();
            ser.Serialize(yamlWriter, traceResult);
            yamlWriter.Flush();
        }
    }
}
