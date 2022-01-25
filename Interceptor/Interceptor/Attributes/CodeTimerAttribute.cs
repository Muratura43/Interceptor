using Interceptor.Processors;
using System;

namespace Interceptor.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor |
                    AttributeTargets.Method |
                    AttributeTargets.Property, AllowMultiple = true)]
    public class CodeTimerAttribute : ProcessAttribute
    {
        public CodeTimerAttribute()
            : base(new CodeTimerProcessor())
        {
        }
    }
}
