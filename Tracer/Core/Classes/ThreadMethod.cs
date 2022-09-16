using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Tracer.Core.Classes
{
    public class ThreadMethod
    {
        public int Id { get; set; }

        public List<Method> InnerMethods => roots;

        private Stack<Method> methodStack = new Stack<Method>();

        private List<Method> roots = new List<Method>();
        public long FullTime => roots.Sum(elem => elem.Time);

        private bool IsRoot => methodStack.Count == 0;

        public void AddTraceMethod(Method method)
        {
            if (IsRoot)
            {
                roots.Add(method);
            }
            else
            {
                methodStack.Peek().methods.Add(method);
            }
            methodStack.Push(method);
        }

       public void StopTraceMethod()
        {
            methodStack.Pop().StopTracing();
        }

    }
}
