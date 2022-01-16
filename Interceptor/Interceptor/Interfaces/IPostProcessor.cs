using System.Runtime.Remoting.Messaging;

namespace Interceptor.Interfaces
{
    public interface IPostProcessor
    {
        void Process(IMethodCallMessage callMsg, ref IMethodReturnMessage retMsg);
    }
}
