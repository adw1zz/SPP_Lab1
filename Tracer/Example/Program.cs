using System.Reflection;
using Tracer.Tracer.Core.Interfaces;
using Tracer.Tracer.Core.Classes;
using Tracer.Tracer.Serialization.Abstracions;
using System.Diagnostics;

namespace Tracer.Tracer.Example
{
    public class Foo
    {
        private Bar _bar;
        private Tracer.Core.Interfaces.Itracer _tracer;

        internal Foo(Tracer.Core.Interfaces.Itracer tracer)
        {
            _tracer = tracer;
            _bar = new Bar(_tracer);
        }

        public void MyMethod()
        {
            _tracer.StartTrace();
            _bar.InnerMethod();
            _bar.InnerMethod();
            _bar.InnerMethod();

            Thread.Sleep(200);
            _tracer.StopTrace();
        }
    }
    public class Bar
    {
        private Tracer.Core.Interfaces.Itracer _tracer;

        internal Bar(Tracer.Core.Interfaces.Itracer tracer)
        {
            _tracer = tracer;
        }

        public void InnerMethod()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            _tracer.StopTrace();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Itracer tracer = new Tracer.Core.Tracer();

            var obj = new Foo(tracer);

            obj.MyMethod();

            var res = tracer.GetTraceResult();

            XmlRes(res);
            JsonRes(res);
            YamRes(res);

        }

        static void XmlRes(TraceResult result)
        {
            using var to = File.Open("dump.xml", FileMode.Create);

            Assembly a = Assembly.LoadFrom(@"D:\SPP\1\Tracer.Serialization\bin\Debug\net6.0\Tracer.Serialization.dll");

            Type myType = a.GetType("Tracer.Serialization.SerializationXml.TraceResultSerializerXml", true);
            var obj = (ITraceResultSerializer)Activator.CreateInstance(myType);
            obj.Serialize(result, to);

            to.Close();
        }


        static void YamRes(TraceResult result)
        {
            using var to = File.Open("dump.yaml", FileMode.Create);

            Assembly a = Assembly.LoadFrom(@"D:\SPP\1\Tracer.Serialization\bin\Debug\net6.0\Tracer.Serialization.dll");

            Type myType = a.GetType("Tracer.Serialization.SerializationYaml.TraceResultSerializerYaml", true);
            var obj = (ITraceResultSerializer)Activator.CreateInstance(myType);
            obj.Serialize(result, to);

            to.Close();
        }

        static void JsonRes(TraceResult result)
        {
            using var to = File.Open("dump.json", FileMode.Create);

            Assembly a = Assembly.LoadFrom(@"D:\SPP\1\Tracer.Serialization\bin\Debug\net6.0\Tracer.Serialization.dll");

            Type myType = a.GetType("Tracer.Serialization.SerializationJson.TraceResultSerializerJson", true);
            var obj = (ITraceResultSerializer)Activator.CreateInstance(myType);
            obj.Serialize(result, to);

            to.Close();
        }
    }
}

