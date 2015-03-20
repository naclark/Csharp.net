using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFanRegistrationService" in both code and config file together.
[ServiceContract]
public interface IFanRegistrationService
{
    [OperationContract]
    bool RegisterFan(FanLite f);

    [OperationContract]
    int FanLogin(string userName, string password);
}

public class FanLite
{
    [DataMember]
    public string fanName { set; get; }

    [DataMember]
    public string userName { set; get; }

    [DataMember]
    public string email { set; get; }

    [DataMember]
    public string password { set; get; }
}