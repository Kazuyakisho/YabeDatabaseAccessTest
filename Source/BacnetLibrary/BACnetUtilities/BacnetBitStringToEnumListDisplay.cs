using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace BacnetLibrary.BACnetUtilities
{
    public class BacnetBitStringToEnumListDisplay : UITypeEditor
    {
        IWindowsFormsEditorService editorService;

        ListBox ObjetList;

        bool LinearEnum;
        Enum currentPropertyEnum;

        // the corresponding Enum is given in parameters
        // and also how the value is fixed 0,1,2... or 1,2,4,8... in the enumeration
        public BacnetBitStringToEnumListDisplay(Enum e, bool LinearEnum, bool DisplayAll = false)
        {
            currentPropertyEnum = e;
            this.LinearEnum = LinearEnum;

            if (DisplayAll == true)
                ObjetList = new CheckedListBox();
            else
                ObjetList = new ListBox();
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        private static string GetNiceName(String name)
        {
            if (name.StartsWith("OBJECT_")) name = name.Substring(7);
            if (name.StartsWith("SERVICE_SUPPORTED_")) name = name.Substring(18);
            if (name.StartsWith("STATUS_FLAG_")) name = name.Substring(12);
            if (name.StartsWith("EVENT_ENABLE_")) name = name.Substring(13);
            if (name.StartsWith("EVENT_")) name = name.Substring(6);

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
                String bbs = value.ToString();

                for (int i = 0; i < bbs.Length; i++)
                {
                    try
                    {
                        String Text;
                        if (LinearEnum == true)
                            Text = Enum.GetName(currentPropertyEnum.GetType(), i); // for 'classic' Enum like 0,1,2,3 ...
                        else
                            Text = Enum.GetName(currentPropertyEnum.GetType(), 1 << i); // for 2^n shift Enum like 1,2,4,8, ...

                        if ((bbs[i] == '1') && !(ObjetList is CheckedListBox))
                            ObjetList.Items.Add(GetNiceName(Text));
                        if (ObjetList is CheckedListBox)
                            (ObjetList as CheckedListBox).Items.Add(GetNiceName(Text), bbs[i] == '1');
                    }
                    catch { }
                }

                if (ObjetList.Items.Count == 0) // when bitstring is only 00000...
                    ObjetList.Items.Add("... Nothing");
                // shows the list
                this.editorService.DropDownControl(ObjetList);
            }
            return value; // do not allows any change
        }
    }

}
