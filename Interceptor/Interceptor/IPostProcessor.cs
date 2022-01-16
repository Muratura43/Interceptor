using System.Runtime.Remoting.Messaging;

namespace Interceptor
{
    public interface IPostProcessor
    {
        void Process(IMethodCallMessage callMsg, ref IMethodReturnMessage retMsg);
    }
}
