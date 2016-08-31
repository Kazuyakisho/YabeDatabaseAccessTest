using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BacnetLibrary.BACnetBase.BACnetEnum;

namespace BacnetLibrary.BACnetConverter
{
    public class BacnetArrayIndexConverter : ArrayConverter
    {

        public enum BacnetEventStates { TO_OFF_NORMAL, TO_FAULT, TO_NORMAL };

        public class BacnetArrayPropertyDescriptor : PropertyDescriptor
        {
            private PropertyDescriptor m_Property = null;
            private int m_idx;
            private Enum m_enum;

            public BacnetArrayPropertyDescriptor(PropertyDescriptor Property, int Idx, Enum e)
                : base(Property)
            {
                m_Property = Property;
                m_idx = Idx;
                m_enum = e;
            }

            // This is what we want, and only this
            public override string DisplayName
            {
                get
                {
                    if (m_enum != null)
                    {
                        string s = Enum.GetValues(m_enum.GetType()).GetValue(m_idx).ToString();
                        s = s.Replace('_', ' ');
                        return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
                    }
                    else
                        return "[" + m_idx.ToString() + "]"; // special behaviour for State Text in mutlistate objects, only array bounds shift, no more !
                }
            }
            public override bool CanResetValue(object component) { return m_Property.CanResetValue(component); }
            public override Type ComponentType { get { return m_Property.ComponentType; } }
            public override object GetValue(object component) { return m_Property.GetValue(component); }
            public override bool IsReadOnly { get { return m_Property.IsReadOnly; } }
            public override Type PropertyType { get { return m_Property.PropertyType; } }
            public override void ResetValue(object component) { m_Property.ResetValue(component); }
            public override void SetValue(object component, object value) { m_Property.SetValue(component, value); }
            public override bool ShouldSerializeValue(object component) { return m_Property.ShouldSerializeValue(component); }
        }

        Enum _e;
        public BacnetArrayIndexConverter(Enum e)
        {
            _e = e;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            try
            {
                PropertyDescriptorCollection s = base.GetProperties(context, value, attributes);
                PropertyDescriptorCollection pds = new PropertyDescriptorCollection(null);

                // PriorityArray is a C# 0 base array for a Bacnet 1 base array
                // use also for StateText property array in multistate objects : http://www.chipkin.com/bacnet-multi-state-variables-state-zero/
                int shift = 0;
                if ((_e == null) || (_e.GetType() == typeof(BacnetWritePriority)))
                    shift = 1;

                for (int i = 0; i < s.Count; i++)
                {
                    BacnetArrayPropertyDescriptor pd = new BacnetArrayPropertyDescriptor(s[i], i + shift, _e);
                    pds.Add(pd);
                }
                return pds;
            }
            catch
            {
                return base.GetProperties(context, value, attributes);
            }
        }

    }
}
