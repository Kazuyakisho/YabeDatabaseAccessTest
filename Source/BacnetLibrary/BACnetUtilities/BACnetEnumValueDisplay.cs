using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BacnetLibrary.BACnetBase.BACnetEnum;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Drawing.Design;

namespace BacnetLibrary.BACnetUtilities
{
    public class BacnetEnumValueDisplay : UITypeEditor
    {
        ListBox EnumList;
        IWindowsFormsEditorService editorService;

        Enum currentPropertyEnum;

        // the corresponding Enum is given in parameter
        public BacnetEnumValueDisplay(Enum e)
        {
            currentPropertyEnum = e;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public static string GetNiceName(String name)
        {
            if (name == null) return ""; // Outbound enum (proprietary)

            if (name.StartsWith("EVENT_STATE_")) name = name.Substring(12);
            if (name.StartsWith("POLARITY_")) name = name.Substring(9);
            if (name.StartsWith("RELIABILITY_")) name = name.Substring(12);
            if (name.StartsWith("SEGMENTATION_")) name = name.Substring(13);
            if (name.StartsWith("STATUS_")) name = name.Substring(7);
            if (name.StartsWith("NOTIFY_")) name = name.Substring(7);
            if (name.StartsWith("UNITS_")) name = name.Substring(6);

            name = name.Replace('_', ' ');
            name = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
            return name;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                this.editorService = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
            }
            if (this.editorService != null)
            {
                int InitialIdx = (int)(uint)value;

                if (EnumList == null)
                {
                    EnumList = new ListBox();
                    EnumList.Click += new EventHandler(EnumList_Click);
                    // get all the Enum values string
                    String[] sl = Enum.GetNames(currentPropertyEnum.GetType());
                    for (int i = 0; i < sl.Length; i++)
                    {
                        if ((currentPropertyEnum.GetType() == typeof(BacnetObjectTypes)) && (i >= (int)BacnetObjectTypes.MAX_ASHRAE_OBJECT_TYPE))
                            break; // One property with some content not usefull
                        EnumList.Items.Add(i.ToString() + " : " + GetNiceName(sl[i])); // add to the list
                    }
                    if (InitialIdx < EnumList.Items.Count)
                        EnumList.SelectedIndex = InitialIdx; // select the current item if any
                }
                this.editorService.DropDownControl(EnumList); // shows the list

                if ((EnumList.SelectedIndex != InitialIdx) && (InitialIdx < EnumList.Items.Count))
                    return (uint)EnumList.SelectedIndex; // change the value if required
            }
            return value;
        }

        void EnumList_Click(object sender, EventArgs e)
        {
            if (this.editorService != null)
                this.editorService.CloseDropDown();

        }
    }
}
