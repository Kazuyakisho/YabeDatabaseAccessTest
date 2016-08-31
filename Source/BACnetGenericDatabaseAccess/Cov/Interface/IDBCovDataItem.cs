using System;
using System.Collections.Generic;

namespace BACnetGenericDatabaseAccess.Cov.Interface
{
    //subject
    public interface IDBCovDataItem
    {
        Dictionary<string, IDBCovSubscriber> Subscribers { get; }
        string TableName { get; }
        string DeviceName { get; set; }
        string Address { get; set; }
        string DeviceID { get; set; }
        string ObjectID { get; set; }
        string ObjectName { get; set; }
        string ObjectValue { get; set; }
        DateTime ObjectTime { get; set; }
        string ObjectStatus { get; set; }
        string sub_key { get; set; }
        uint subscribe_id { get; set; }
        bool is_active_subscription { get; set; }// false if subscription is refused

        void Notify();
    }

}


