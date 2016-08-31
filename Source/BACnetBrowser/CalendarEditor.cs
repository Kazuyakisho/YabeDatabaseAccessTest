/**************************************************************************
*                           MIT License
* 
* Copyright (C) 2015 Frederic Chaxel <fchaxel@free.fr>
*
* Permission is hereby granted, free of charge, to any person obtaining
* a copy of this software and associated documentation files (the
* "Software"), to deal in the Software without restriction, including
* without limitation the rights to use, copy, modify, merge, publish,
* distribute, sublicense, and/or sell copies of the Software, and to
* permit persons to whom the Software is furnished to do so, subject to
* the following conditions:
*
* The above copyright notice and this permission notice shall be included
* in all copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
* EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
* MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
* IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
* CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
* TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
* SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*
*********************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;
using BacnetLibrary.BACnetBase;
using BacnetLibrary.BACnetBase.BACnetEnum;
using BacnetLibrary.BACnetBase.BACnetStruct;
using BacnetLibrary.BACnetClient;

namespace BACnetBrowser
{
    public partial class CalendarEditor : Form
    {
        BacnetClient comm; BacnetAddress adr; BacnetObjectId object_id;
        // dates in the bacnetobject
        BACnetCalendarEntry calendarEntries;

        DateTime CalendarStartRequested;
        private Button btDelete;
        private Button btAdd;
        private Label label1;
        private Button btReadWrite;
        private ListBox listEntries;
        private MonthCalendar dateSelect;
        private System.Windows.Forms.Calendar.Calendar calendarView;
        bool InternalListeEntriesSelect =false;

        public CalendarEditor(BacnetClient comm, BacnetAddress adr, BacnetObjectId object_id)
        {
            InitializeComponent();

            this.comm = comm;
            this.adr = adr;
            this.object_id = object_id;

            LoadCalendar();
        }

        private void LoadCalendar()
        {
            IList<BacnetValue> values;
            comm.ReadPropertyRequest(adr, object_id, BacnetPropertyIds.PROP_DATE_LIST, out values);

            if ((values != null) && (values.Count == 1))
                calendarEntries = (BACnetCalendarEntry)values[0].Value;
            else
            {
                calendarEntries = new BACnetCalendarEntry(); // empty
                calendarEntries.Entries = new List<object>();
            }

            dateSelect.SelectionRange = new SelectionRange(DateTime.Now, DateTime.Now);

            listEntries.Items.Clear();
            foreach (object e in calendarEntries.Entries)
                listEntries.Items.Add(e);

            //  calendarView will be updated by the calendarView_LoadItems event
            SetCalendarDisplayDate(DateTime.Now);

        }

        private void WriteCalendar()
        {
            try
            {
                List<BacnetValue> v = new List<BacnetValue>();
                v.Add(new BacnetValue(calendarEntries));
                comm.WritePropertyRequest(adr, object_id, BacnetPropertyIds.PROP_DATE_LIST, v);
            }
            catch { }
        }

        private void btReadWrite_Click(object sender, EventArgs e)
        {
            WriteCalendar();
            LoadCalendar();
        }

        private void SetCalendarDisplayDate (DateTime d)
        {
            DateTime start = new DateTime(d.Year, d.Month, 1);
            DateTime stop = start.AddMonths(1).AddHours(-1);

            CalendarStartRequested = start;

            calendarView.SetViewRange(start, stop);
        }

        private void dateSelect_DateChanged(object sender, DateRangeEventArgs e)
        {
            SetCalendarDisplayDate(e.Start);
        }

        private void listEntries_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddCalendarEntry(DateTime _start, DateTime _end,  Color color, String Text, object tag)
        {
            DateTime start, end;
            start = new DateTime(_start.Year, _start.Month, _start.Day, 0, 0, 0);
            end = new DateTime(_end.Year, _end.Month, _end.Day, 23, 59, 59);
            CalendarItem ci = new CalendarItem(calendarView, start, end, Text);
            ci.ApplyColor(color);
            ci.Tag = tag;

            if (start <= calendarView.Days[calendarView.Days.Length-1].Date && calendarView.Days[0] .Date <= end)
                calendarView.Items.Add(ci);          
        }

        private void PlaceItemsInCalendarView()
        {
            foreach (object e in calendarEntries.Entries)
            {
                if (e is BacnetDate)
                {
                    BacnetDate bd = (BacnetDate)e;
                    if (bd.IsPeriodic)
                    {
                        foreach (CalendarDay dt in calendarView.Days)
                            if (bd.IsAFittingDate(dt.Date))
                                AddCalendarEntry(dt.Date,dt.Date, Color.Blue,"Periodic",bd);
                    }
                    else
                        AddCalendarEntry(bd.toDateTime(), bd.toDateTime(), Color.Green, "", bd);
                }
                else if (e is BacnetDateRange) 
                {
                    BacnetDateRange bdr = (BacnetDateRange)e;
                    DateTime start,end;

                    if (bdr.startDate.year != 255)
                        start = new DateTime(bdr.startDate.year+1900, bdr.startDate.month, bdr.startDate.day, 0, 0, 0);
                    else
                        start = DateTime.MinValue;
                    if (bdr.endDate.year != 255)
                        end = new DateTime(bdr.endDate.year+1900, bdr.endDate.month, bdr.endDate.day, 23, 59, 59);
                    else
                        end = DateTime.MaxValue;
                    CalendarItem ci = new CalendarItem(calendarView, start, end, "");
                    ci.ApplyColor(Color.Yellow);
                    ci.Tag = bdr;

                    if (start <= calendarView.Days[calendarView.Days.Length - 1].Date && calendarView.Days[0].Date <= end)
                        calendarView.Items.Add(ci);
                }
                else
                {
                    BacnetweekNDay bwnd = (BacnetweekNDay)e;
                    foreach (CalendarDay dt in calendarView.Days)
                        if (bwnd.IsAFittingDate(dt.Date))
                            AddCalendarEntry(dt.Date, dt.Date, Color.Red, "Periodic", bwnd);
                }
            }
        }

        // Called to renew all the data inside the control
        private void calendarView_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            PlaceItemsInCalendarView();
        }

        private void calendarView_ItemDeleted(object sender, CalendarItemEventArgs e)
        {

        }

        private void calendarView_ItemSelected(object sender, CalendarItemEventArgs e)
        {

        }

        private void calendarView_ItemCreated(object sender, CalendarItemCancelEventArgs e)
        {

        }

        private void calendarView_ItemDatesChanged(object sender, CalendarItemEventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                calendarEntries.Entries.Remove(listEntries.SelectedItem);
                listEntries.Items.RemoveAt(listEntries.SelectedIndex);
            }
            catch { }
            SetCalendarDisplayDate(CalendarStartRequested);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {

        }

        private void btDelete_Click(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BacnetweekNDay bwd = new BacnetweekNDay(1, 1);
            CalendarEntryEdit Edit = new CalendarEntryEdit(bwd);
            Edit.ShowDialog();
            if (Edit.OutOK)
            {
                object o = Edit.GetBackEntry();
                listEntries.Items.Add(o);
                calendarEntries.Entries.Add(o);
                SetCalendarDisplayDate(CalendarStartRequested);
            }
        }

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listEntries.SelectedIndex == -1) return;
            try
            {
                object selected = listEntries.SelectedItem;
                CalendarEntryEdit Edit = new CalendarEntryEdit(listEntries.SelectedItem);
                Edit.ShowDialog();
                if (Edit.OutOK)
                {
                    object o = Edit.GetBackEntry();

                    calendarEntries.Entries.Remove(listEntries.SelectedItem);
                    int Idx = listEntries.SelectedIndex;

                    try // Don't understand, exception, but all is OK , and the job is done !
                    {
                        listEntries.Items.Remove(selected);
                    }
                    catch { }

                    listEntries.Items.Insert(Idx, o);
                    calendarEntries.Entries.Add(o);
                }
            }
            catch { }
            SetCalendarDisplayDate(CalendarStartRequested);
        }
        private void listEntries_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            modifyToolStripMenuItem_Click(null, null);
        }

        private void calendarView_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            modifyToolStripMenuItem_Click(null, null);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange1 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange2 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange3 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange4 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange5 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            this.btDelete = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btReadWrite = new System.Windows.Forms.Button();
            this.listEntries = new System.Windows.Forms.ListBox();
            this.dateSelect = new System.Windows.Forms.MonthCalendar();
            this.calendarView = new System.Windows.Forms.Calendar.Calendar();
            this.SuspendLayout();
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(259, 393);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(51, 24);
            this.btDelete.TabIndex = 15;
            this.btDelete.Text = "Delete";
            this.btDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(321, 393);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(51, 24);
            this.btAdd.TabIndex = 14;
            this.btAdd.Text = "Add";
            this.btAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAdd.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Dates entries :";
            // 
            // btReadWrite
            // 
            this.btReadWrite.Location = new System.Drawing.Point(617, 389);
            this.btReadWrite.Name = "btReadWrite";
            this.btReadWrite.Size = new System.Drawing.Size(149, 35);
            this.btReadWrite.TabIndex = 12;
            this.btReadWrite.Text = "Write && Read back";
            this.btReadWrite.UseVisualStyleBackColor = true;
            // 
            // listEntries
            // 
            this.listEntries.FormattingEnabled = true;
            this.listEntries.Location = new System.Drawing.Point(18, 218);
            this.listEntries.Name = "listEntries";
            this.listEntries.Size = new System.Drawing.Size(227, 199);
            this.listEntries.TabIndex = 11;
            // 
            // dateSelect
            // 
            this.dateSelect.Location = new System.Drawing.Point(18, 18);
            this.dateSelect.MaxSelectionCount = 1;
            this.dateSelect.Name = "dateSelect";
            this.dateSelect.TabIndex = 10;
            // 
            // calendarView
            // 
            this.calendarView.Font = new System.Drawing.Font("Segoe UI", 9F);
            calendarHighlightRange1.DayOfWeek = System.DayOfWeek.Monday;
            calendarHighlightRange1.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange1.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange2.DayOfWeek = System.DayOfWeek.Tuesday;
            calendarHighlightRange2.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange2.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange3.DayOfWeek = System.DayOfWeek.Wednesday;
            calendarHighlightRange3.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange3.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange4.DayOfWeek = System.DayOfWeek.Thursday;
            calendarHighlightRange4.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange4.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange5.DayOfWeek = System.DayOfWeek.Friday;
            calendarHighlightRange5.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange5.StartTime = System.TimeSpan.Parse("08:00:00");
            this.calendarView.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[] {
        calendarHighlightRange1,
        calendarHighlightRange2,
        calendarHighlightRange3,
        calendarHighlightRange4,
        calendarHighlightRange5};
            this.calendarView.Location = new System.Drawing.Point(259, 18);
            this.calendarView.Name = "calendarView";
            this.calendarView.Size = new System.Drawing.Size(526, 365);
            this.calendarView.TabIndex = 9;
            this.calendarView.Text = "calendar1";
            // 
            // CalendarEditor
            // 
            this.ClientSize = new System.Drawing.Size(790, 431);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btReadWrite);
            this.Controls.Add(this.listEntries);
            this.Controls.Add(this.dateSelect);
            this.Controls.Add(this.calendarView);
            this.Name = "CalendarEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }

    #region CalendarEntryEdit
    class CalendarEntryEdit : Form
    {
        public bool OutOK = false;

        object Entry;

        private void InitCalendarEntryEdit()
        {
            InitializeComponent();

            for (int i = 1; i < 7; i++)
                wday.Items.Add(CultureInfo.CurrentCulture.DateTimeFormat.DayNames[i]);
            wday.Items.Add(CultureInfo.CurrentCulture.DateTimeFormat.DayNames[0]);
            wday.Items.Add("****");

            for (int i = 1; i < 32; i++)
                day.Items.Add(i);
            day.Items.Add("Last");
            day.Items.Add("**");

            for (int i = 0; i < 12; i++)
                month.Items.Add(CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[i]);
            month.Items.Add("Even");
            month.Items.Add("Odd");
            month.Items.Add("****");
        }

        public CalendarEntryEdit(object entry)
        {
            InitCalendarEntryEdit();

            this.Entry = entry;

            if (entry is BacnetDate)
            {
                dateRangeGrp.Visible = false;
                DateGrp.Visible = true;
                DateGrp.Location = dateRangeGrp.Location;

                BacnetDate bd = (BacnetDate)entry;

                if (bd.wday != 255)
                    wday.SelectedIndex = bd.wday - 1;
                else
                    wday.SelectedIndex = 7;

                if (bd.day != 255)
                    day.SelectedIndex = bd.day - 1;
                else
                    day.SelectedIndex = 32;

                if (bd.month != 255)
                    month.SelectedIndex = bd.month - 1;
                else
                    month.SelectedIndex = 14;

                if (bd.year != 255)
                    year.Text = (bd.year + 1900).ToString();
                else
                    year.Text = "****";
            }

            if (entry is BacnetDateRange)
            {
                dateRangeGrp.Visible = true;
                DateGrp.Visible = false;
                BacnetDateRange bdr = (BacnetDateRange)entry;

                if (bdr.startDate.year != 255)
                    startDate.Value = bdr.startDate.toDateTime();
                else
                    startDate.Value = DateTimePicker.MinimumDateTime ;

                if (bdr.endDate.year != 255)
                    endDate.Value = bdr.endDate.toDateTime();
                else
                    endDate.Value = DateTimePicker.MaximumDateTime;
            }

            if (entry is BacnetweekNDay)
            {
                dateRangeGrp.Visible = false;
                DateGrp.Visible = true;
                DateGrp.Location = dateRangeGrp.Location;
                year.Visible = false;
                day.Visible = false;
                wday.Location=new Point(wday.Location.X+50,wday.Location.Y);

                BacnetweekNDay bwd = (BacnetweekNDay)entry;

                if (bwd.wday != 255)
                    wday.SelectedIndex = bwd.wday - 1;
                else
                    wday.SelectedIndex = 7;

                if (bwd.month != 255)
                    month.SelectedIndex = bwd.month - 1;
                else
                    month.SelectedIndex = 14;
            }
        }

        public object GetBackEntry()
        {
            if (Entry is BacnetDate)
            {
                BacnetDate bd = new BacnetDate();

                if (wday.SelectedIndex == 7)
                    bd.wday = 255;
                else
                    bd.wday = (byte)(wday.SelectedIndex + 1);

                if (day.SelectedIndex == 32)
                    bd.day = 255;
                else
                    bd.day = (byte)(day.SelectedIndex + 1);

                if (month.SelectedIndex == 14)
                    bd.month = 255;
                else
                    bd.month = (byte)(month.SelectedIndex + 1);

                int valyear = 255;
                try
                {
                    valyear = Convert.ToInt32(year.Text) - 1900;
                }
                catch { }

                bd.year = (byte)valyear;

                return bd;

            }

            if (Entry is BacnetDateRange)
            {
                BacnetDateRange bdr = new BacnetDateRange();

                if (startDate.Value == DateTimePicker.MinimumDateTime)
                    bdr.startDate = new BacnetDate(255, 255, 255);
                else
                    bdr.startDate = new BacnetDate((byte)(startDate.Value.Year - 1900), (byte)startDate.Value.Month, (byte)startDate.Value.Day);

                if (endDate.Value == DateTimePicker.MaximumDateTime)
                    bdr.startDate = new BacnetDate(255, 255, 255);
                else
                    bdr.endDate = new BacnetDate((byte)(endDate.Value.Year - 1900), (byte)endDate.Value.Month, (byte)endDate.Value.Day);

                return bdr;
            }
            if (Entry is BacnetweekNDay)
            {
                BacnetweekNDay bwd = (BacnetweekNDay)Entry;

                if (wday.SelectedIndex == 7)
                    bwd.wday = 255;
                else
                    bwd.wday = (byte)(wday.SelectedIndex + 1);

                if (month.SelectedIndex == 14)
                    bwd.month = 255;
                else
                    bwd.month = (byte)( month.SelectedIndex + 1);

                return bwd;
            }
            return null;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            OutOK = true;
            Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateRangeGrp = new System.Windows.Forms.GroupBox();
            this.DateGrp = new System.Windows.Forms.GroupBox();
            this.year = new System.Windows.Forms.TextBox();
            this.month = new System.Windows.Forms.ComboBox();
            this.day = new System.Windows.Forms.ComboBox();
            this.wday = new System.Windows.Forms.ComboBox();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.dateRangeGrp.SuspendLayout();
            this.DateGrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // startDate
            // 
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDate.Location = new System.Drawing.Point(31, 29);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(106, 20);
            this.startDate.TabIndex = 0;
            // 
            // endDate
            // 
            this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDate.Location = new System.Drawing.Point(162, 29);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(106, 20);
            this.endDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "End";
            // 
            // dateRangeGrp
            // 
            this.dateRangeGrp.Controls.Add(this.startDate);
            this.dateRangeGrp.Controls.Add(this.label1);
            this.dateRangeGrp.Controls.Add(this.label2);
            this.dateRangeGrp.Controls.Add(this.endDate);
            this.dateRangeGrp.Location = new System.Drawing.Point(12, 12);
            this.dateRangeGrp.Name = "dateRangeGrp";
            this.dateRangeGrp.Size = new System.Drawing.Size(293, 62);
            this.dateRangeGrp.TabIndex = 4;
            this.dateRangeGrp.TabStop = false;
            // 
            // DateGrp
            // 
            this.DateGrp.Controls.Add(this.year);
            this.DateGrp.Controls.Add(this.month);
            this.DateGrp.Controls.Add(this.day);
            this.DateGrp.Controls.Add(this.wday);
            this.DateGrp.Location = new System.Drawing.Point(43, 125);
            this.DateGrp.Name = "DateGrp";
            this.DateGrp.Size = new System.Drawing.Size(293, 66);
            this.DateGrp.TabIndex = 5;
            this.DateGrp.TabStop = false;
            // 
            // year
            // 
            this.year.Location = new System.Drawing.Point(231, 27);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(50, 20);
            this.year.TabIndex = 3;
            // 
            // month
            // 
            this.month.FormattingEnabled = true;
            this.month.Location = new System.Drawing.Point(162, 27);
            this.month.Name = "month";
            this.month.Size = new System.Drawing.Size(53, 21);
            this.month.TabIndex = 2;
            // 
            // day
            // 
            this.day.FormattingEnabled = true;
            this.day.Location = new System.Drawing.Point(101, 27);
            this.day.Name = "day";
            this.day.Size = new System.Drawing.Size(53, 21);
            this.day.TabIndex = 1;
            // 
            // wday
            // 
            this.wday.FormattingEnabled = true;
            this.wday.Location = new System.Drawing.Point(16, 27);
            this.wday.Name = "wday";
            this.wday.Size = new System.Drawing.Size(79, 21);
            this.wday.TabIndex = 0;
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(73, 90);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(76, 29);
            this.btOk.TabIndex = 6;
            this.btOk.Text = "OK";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(192, 90);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(76, 29);
            this.btCancel.TabIndex = 7;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // CalendarEntryEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 148);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.DateGrp);
            this.Controls.Add(this.dateRangeGrp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalendarEntryEdit";
            this.Text = "Calendar Entry";
            this.dateRangeGrp.ResumeLayout(false);
            this.dateRangeGrp.PerformLayout();
            this.DateGrp.ResumeLayout(false);
            this.DateGrp.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox dateRangeGrp;
        private System.Windows.Forms.GroupBox DateGrp;
        private System.Windows.Forms.TextBox year;
        private System.Windows.Forms.ComboBox month;
        private System.Windows.Forms.ComboBox day;
        private System.Windows.Forms.ComboBox wday;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
    }
    #endregion
}
