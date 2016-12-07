using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TemperaturRestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITemperaturService" in both code and config file together.
    [ServiceContract]
    public interface ITemperaturService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetTemperaturList/")]

        List<Temperatur> GetTemperaturList();
    }
}
