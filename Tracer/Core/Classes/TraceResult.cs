using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Tracer.Core.Classes
{
    public class TraceResult
    {
        public List<ThreadMethod> Threads => threads;
        private List<ThreadMethod> threads = new List<ThreadMethod>();

        public void StopTraceMethod(int threadId)
        {
            var element = threads.Single(elem => elem.Id == threadId);
            element.StopTraceMethod();
        }

        public void AddMethodToLResList(Method method, int threadId)
        {
            var element = threads.SingleOrDefault(elem => elem.Id == threadId);
            
            if (element == null)
            {
                element = new ThreadMethod() { Id = threadId };
                threads.Add(element);
            }
            element.AddTraceMethod(method);
        }
    }
}
