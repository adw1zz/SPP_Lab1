using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Tracer.Tracer.Core.Classes;
using Tracer.Tracer.Serialization.Abstracions;

namespace Tracer.Serialization.SerializationXml
{
    public class TraceResultSerializerXml : ITraceResultSerializer
    {
        public void Serialize(TraceResult traceResult, Stream to)
        {
            using StreamWriter writer = new(to);
            XmlSerializer ser = new XmlSerializer(typeof(TraceResult));
            ser.Serialize(writer, traceResult);
            writer.Flush();
        }
    }
}
