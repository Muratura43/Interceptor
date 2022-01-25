using Interceptor.Attributes;
using Interceptor.Processors;
using System;

namespace TestConsole
{
    [Intercept]
    public class TestObject : ContextBoundObject
    {
        public TestObject()
        {
        }

        [CodeTimer]
        public void SimpleMethod()
        {
            Console.WriteLine("SimpleMethod");
        }

        public void ExceptionMethod()
        {
            Console.WriteLine("ExceptionMethod");
            throw new Exception();
        }

        [Trace]
        public void ParameterMethod(int n)
        {
            Console.WriteLine($"ParameterMethod({n})");
        }

        [PostProcess(typeof(TraceProcessor))]
        public int SimpleFunction()
        {
            Console.WriteLine("SimpleFunction");
            return 1;
        }
    }
}
