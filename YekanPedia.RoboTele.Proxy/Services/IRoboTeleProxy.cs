
namespace YekanPedia.RoboTele.Proxy.Services
{
    using System.ServiceModel;
    using Model;
    using System.Collections.Generic;

    [ServiceContract]
    public interface IRoboTeleProxy
    {
        [OperationContract(IsOneWay = true)]
        void SendMessage(List<SendMessageModel> model, SecurityModel security);
    }
}
