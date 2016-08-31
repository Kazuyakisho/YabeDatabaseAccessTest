using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Drawing.Design;

namespace BacnetLibrary.BACnetUtilities
{
    public class BacnetTimePickerEditor : UITypeEditor
    {

        IWindowsFormsEditorService editorService;
        DateTimePicker picker = new DateTimePicker();

        public BacnetTimePickerEditor()
        {
            picker.Format = DateTimePickerFormat.Time;
            picker.ShowUpDown = true;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                this.editorService = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
            }

            if (this.editorService != null)
            {
                DateTime dt = (DateTime)value;
                // this value is 1/1/1 for the date,  DatetimePicket don't accept it
                picker.Value = new DateTime(2000, 1, 1, dt.Hour, dt.Minute, dt.Second); // only HH:MM:SS is important
                this.editorService.DropDownControl(picker);
                value = picker.Value;
            }

            return value;
        }
    }
}
