using System;
using System.Collections;
using System.Collections.Generic;

namespace BacnetLibrary.BACnetUtilities
{
    public class DynamicEnum : ICollection
    {
        private Dictionary<string, int> m_stringIndex = new Dictionary<string, int>();
        private Dictionary<int, string> m_intIndex = new Dictionary<int, string>();
        public bool IsFlag { get; set; }

        public int this[string name]
        {
            get
            {
                int value = 0;

                if (name.IndexOf(',') != -1)
                {
                    int num = 0;
                    foreach (string str2 in name.Split(new char[] { ',' }))
                    {
                        m_stringIndex.TryGetValue(str2.Trim(), out value);
                        num |= value;
                    }
                    return num;
                }

                m_stringIndex.TryGetValue(name, out value);
                return value;
            }
        }
        public string this[int value]
        {
            get
            {
                if (IsFlag)
                {
                    string str = "";
                    foreach (KeyValuePair<string, int> entry in m_stringIndex)
                    {
                        if ((value & entry.Value) > 0 || (entry.Value == 0 && value == 0)) str += ", " + entry.Key;
                    }
                    if (str != "") str = str.Substring(2);
                    return str;
                }
                else
                {
                    string name;
                    m_intIndex.TryGetValue(value, out name);
                    return name;
                }
            }
        }
        public void Add(string name, int value)
        {
            m_stringIndex.Add(name, value);
            m_intIndex.Add(value, name);
        }
        public bool Contains(string name)
        {
            return m_stringIndex.ContainsKey(name);
        }
        public bool Contains(int value)
        {
            return m_intIndex.ContainsKey(value);
        }

        public IEnumerator GetEnumerator()
        {
            return m_stringIndex.GetEnumerator();
        }

        public int Count
        {
            get { return m_stringIndex.Count; }
        }

        public void CopyTo(Array array, int index)
        {
            int i = 0;
            foreach (KeyValuePair<string, int> entry in this)
                array.SetValue(entry, i++ + index);
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }
    }
}
