using BACnetGenericDatabaseAccess.Cov.Interface;
using System;
using System.Collections.Generic;

namespace BACnetGenericDatabaseAccess.Cov
{
    public class DBCovDataItem : IDBCovDataItem, IEqualityComparer<DBCovDataItem>
    {

        public Dictionary<string, IDBCovSubscriber> Subscribers { get;  }


        public DBCovDataItem(string address, string deviceId, string deviceName, string objectId, string objectName, string objectValue, DateTime objectTime, string objectStatus, bool is_activeSub)
        {
            if (!is_activeSub) return;

            Address = address;
            DeviceName = deviceName;
            DeviceID = deviceId;
            ObjectID = objectId;
            ObjectName = objectName;
            _objectValue = objectValue;
            ObjectTime = objectTime;
            ObjectStatus = objectStatus;
            is_active_subscription = is_activeSub;

            Subscribers = new Dictionary<string, IDBCovSubscriber>();

        }



        public string TableName => (DeviceName + "_" + DeviceID + "_" + ObjectID).Replace(":", "_").Replace(".", "_").Replace("[", "_").Replace("]", "_").ToLower();
        public string DeviceName { get; set; }

        public string Address { get; set; }

        public string DeviceID { get; set; }

        public string ObjectID { get; set; }

        public string ObjectName { get; set; }

        private string _objectValue;
        public string ObjectValue
        {
            get
            {
                return _objectValue;

            }
            set
            {
                _objectValue = value;
                Notify();
            }
        }

        public DateTime ObjectTime { get; set; }

        public string ObjectStatus { get; set; }

        public string sub_key { get; set; }

        public uint subscribe_id { get; set; }

        public bool is_active_subscription { get; set; }

        public void Notify()
        {
            foreach (var subscriber in Subscribers)
            {
                subscriber.Value.Update(this);
            }
        }

        public void AddSubscriber(string subscriberKey, IDBCovSubscriber sub)
        {
            Subscribers.Add(subscriberKey, sub);

        }

        public void RemoveSubscriber(string subscriberKey)
        {

            this.Subscribers.Remove(subscriberKey);
        }

        public bool Equals(DBCovDataItem x, DBCovDataItem y)
        {
            return x.TableName != y.TableName;
        }

        public int GetHashCode(DBCovDataItem obj)
        {
            return obj.TableName.GetHashCode();
        }
    }
}
