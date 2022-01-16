using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new TestObject();

            test.SimpleMethod();

            test.ParameterMethod(2);

            var n = test.SimpleFunction();
            Console.WriteLine($"Return {n}");

            try
            {
                test.ExceptionMethod();
            }
            catch(Exception)
            {
                //
            }
        }
    }
}
