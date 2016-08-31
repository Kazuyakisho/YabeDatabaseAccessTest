using System;
using BacnetLibrary.BACnetBase.BACnetEnum;

namespace BacnetLibrary.BACnetUtilities
{
    public class CustomProperty
    {

        private string m_name = string.Empty;
        private bool m_readonly = false;
        private object m_old_value = null;
        private object m_value = null;
        private Type m_type;
        private object m_tag;
        private DynamicEnum m_options;
        private string m_category;
        // Modif FC : change type
        private BacnetApplicationTags? m_description;

        // Modif FC : constructor
        public CustomProperty(string name, object value, Type type, bool read_only, string category = "", BacnetApplicationTags? description = null, DynamicEnum options = null, object tag = null)
        {
            this.m_name = name;
            this.m_old_value = value;
            this.m_value = value;
            this.m_type = type;
            this.m_readonly = read_only;
            this.m_tag = tag;
            this.m_options = options;
            this.m_category = "BacnetProperty";
            this.m_description = description;
        }

        public DynamicEnum Options
        {
            get { return m_options; }
        }

        public Type Type
        {
            get { return m_type; }
        }

        public string Category
        {
            get { return m_category; }
        }

        // Modif FC
        public string Description
        {
            get { return m_description == null ? null : m_description.ToString(); }
        }

        // Modif FC : added
        public BacnetApplicationTags? bacnetApplicationTags
        {
            get { return m_description; }
        }

        public bool ReadOnly
        {
            get
            {
                return m_readonly;
            }
        }

        public string Name
        {
            get
            {
                return m_name;
            }
        }

        public bool Visible
        {
            get
            {
                return true;
            }
        }

        public object Value
        {
            get
            {
                return m_value;
            }
            set
            {
                m_value = value;
            }
        }

        public object Tag
        {
            get { return m_tag; }
        }

        public void Reset()
        {
            m_value = m_old_value;
        }
    }


}
