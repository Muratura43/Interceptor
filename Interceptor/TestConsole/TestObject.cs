using Interceptor.Attributes;
using System;

namespace TestConsole
{
    [Intercept]
    public class TestObject : ContextBoundObject
    {
        public TestObject()
        {
        }

        public void SimpleMethod()
        {
            Console.WriteLine("SimpleMethod");
        }

        public void ExceptionMethod()
        {
            Console.WriteLine("ExceptionMethod");
            throw new Exception();
        }

        public void ParameterMethod(int n)
        {
            Console.WriteLine($"ParameterMethod({n})");
        }

        public int SimpleFunction()
        {
            Console.WriteLine("SimpleFunction");
            return 1;
        }
    }
}
