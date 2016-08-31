/**************************************************************************
*                           MIT License
* 
* Copyright (C) 2014 Morten Kvistgaard <mk@pch-engineering.dk>
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
using System.Windows.Forms;
using BacnetLibrary.BACnetBase.BACnetEnum;

namespace BACnetBrowser
{
    public partial class DeviceCommunicationControlDialog : Form
    {
        private GroupBox groupBox4;
        private RadioButton m_communicationRadio;
        private RadioButton m_reinitializeRadio;
        private GroupBox m_reinitializeGroup;
        private Label label3;
        private ComboBox m_StateCombo;
        private GroupBox m_communicationGroup;
        private CheckBox m_disableCheck;
        private NumericUpDown m_durationValue;
        private Label label1;
        private GroupBox groupBox1;
        private TextBox m_passwordText;
        private Label label2;
        private Button m_CancelButton;
        private Button m_OKButton;

        public DeviceCommunicationControlDialog()
        {
            InitializeComponent();
        }

        public bool IsReinitialize { get { return m_reinitializeRadio.Checked; } set { m_reinitializeRadio.Checked = value; } }
        public bool DisableCommunication { get { return m_disableCheck.Checked; } set { m_disableCheck.Checked = value; } }
        public uint Duration { get { return (uint)m_durationValue.Value; } set { m_durationValue.Value = value; } }
        public string Password { get { return m_passwordText.Text; } set { m_passwordText.Text = value; } }
        public BacnetReinitializedStates ReinitializeState { get { return (BacnetReinitializedStates)Enum.Parse(typeof(BacnetReinitializedStates), "BACNET_REINIT_" + m_StateCombo.Text); } set { m_StateCombo.Text = value.ToString(); } }

        private void DeviceCommunicationControlDialog_Load(object sender, EventArgs e)
        {
            string[] names = Enum.GetNames(typeof(BacnetReinitializedStates));
            for (int i = 0; i < names.Length; i++)
                names[i] = names[i].Replace("BACNET_REINIT_", "");
            m_StateCombo.Items.AddRange(names);
            if (names.Length > 0)
                m_StateCombo.Text = names[0];
        }

        private void InitializeComponent()
        {
            groupBox4 = new GroupBox();
            m_communicationRadio = new RadioButton();
            m_reinitializeRadio = new RadioButton();
            m_reinitializeGroup = new GroupBox();
            label3 = new Label();
            m_StateCombo = new ComboBox();
            m_communicationGroup = new GroupBox();
            m_disableCheck = new CheckBox();
            m_durationValue = new NumericUpDown();
            label1 = new Label();
            groupBox1 = new GroupBox();
            m_passwordText = new TextBox();
            label2 = new Label();
            m_CancelButton = new Button();
            m_OKButton = new Button();
            groupBox4.SuspendLayout();
            m_reinitializeGroup.SuspendLayout();
            m_communicationGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(m_durationValue)).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox4
            // 
            groupBox4.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
            | AnchorStyles.Right)));
            groupBox4.Controls.Add(m_communicationRadio);
            groupBox4.Controls.Add(m_reinitializeRadio);
            groupBox4.Location = new System.Drawing.Point(12, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(225, 73);
            groupBox4.TabIndex = 18;
            groupBox4.TabStop = false;
            groupBox4.Text = "Action";
            // 
            // m_communicationRadio
            // 
            m_communicationRadio.AutoSize = true;
            m_communicationRadio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            m_communicationRadio.Location = new System.Drawing.Point(21, 42);
            m_communicationRadio.Name = "m_communicationRadio";
            m_communicationRadio.Size = new System.Drawing.Size(97, 17);
            m_communicationRadio.TabIndex = 1;
            m_communicationRadio.Text = "Communication";
            m_communicationRadio.UseVisualStyleBackColor = true;
            // 
            // m_reinitializeRadio
            // 
            m_reinitializeRadio.AutoSize = true;
            m_reinitializeRadio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            m_reinitializeRadio.Checked = true;
            m_reinitializeRadio.Location = new System.Drawing.Point(43, 19);
            m_reinitializeRadio.Name = "m_reinitializeRadio";
            m_reinitializeRadio.Size = new System.Drawing.Size(75, 17);
            m_reinitializeRadio.TabIndex = 0;
            m_reinitializeRadio.TabStop = true;
            m_reinitializeRadio.Text = "Reinitialize";
            m_reinitializeRadio.UseVisualStyleBackColor = true;
            // 
            // m_reinitializeGroup
            // 
            m_reinitializeGroup.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
            | AnchorStyles.Right)));
            m_reinitializeGroup.Controls.Add(label3);
            m_reinitializeGroup.Controls.Add(m_StateCombo);
            m_reinitializeGroup.Location = new System.Drawing.Point(12, 83);
            m_reinitializeGroup.Name = "m_reinitializeGroup";
            m_reinitializeGroup.Size = new System.Drawing.Size(225, 57);
            m_reinitializeGroup.TabIndex = 17;
            m_reinitializeGroup.TabStop = false;
            m_reinitializeGroup.Text = "Reinitialize";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(66, 22);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(32, 13);
            label3.TabIndex = 8;
            label3.Text = "State";
            // 
            // m_StateCombo
            // 
            m_StateCombo.FormattingEnabled = true;
            m_StateCombo.Location = new System.Drawing.Point(104, 19);
            m_StateCombo.Name = "m_StateCombo";
            m_StateCombo.Size = new System.Drawing.Size(121, 21);
            m_StateCombo.TabIndex = 0;
            // 
            // m_communicationGroup
            // 
            m_communicationGroup.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
            | AnchorStyles.Right)));
            m_communicationGroup.Controls.Add(m_disableCheck);
            m_communicationGroup.Controls.Add(m_durationValue);
            m_communicationGroup.Controls.Add(label1);
            m_communicationGroup.Enabled = false;
            m_communicationGroup.Location = new System.Drawing.Point(12, 146);
            m_communicationGroup.Name = "m_communicationGroup";
            m_communicationGroup.Size = new System.Drawing.Size(225, 75);
            m_communicationGroup.TabIndex = 16;
            m_communicationGroup.TabStop = false;
            m_communicationGroup.Text = "Communication";
            // 
            // m_disableCheck
            // 
            m_disableCheck.AutoSize = true;
            m_disableCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            m_disableCheck.Checked = true;
            m_disableCheck.CheckState = CheckState.Checked;
            m_disableCheck.Location = new System.Drawing.Point(57, 18);
            m_disableCheck.Name = "m_disableCheck";
            m_disableCheck.Size = new System.Drawing.Size(61, 17);
            m_disableCheck.TabIndex = 4;
            m_disableCheck.Text = "Disable";
            m_disableCheck.UseVisualStyleBackColor = true;
            // 
            // m_durationValue
            // 
            m_durationValue.Location = new System.Drawing.Point(104, 41);
            m_durationValue.Name = "m_durationValue";
            m_durationValue.Size = new System.Drawing.Size(56, 20);
            m_durationValue.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 43);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(92, 13);
            label1.TabIndex = 6;
            label1.Text = "Duration (minutes)";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
            | AnchorStyles.Right)));
            groupBox1.Controls.Add(m_passwordText);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new System.Drawing.Point(12, 227);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(225, 57);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Optional";
            // 
            // m_passwordText
            // 
            m_passwordText.Location = new System.Drawing.Point(104, 19);
            m_passwordText.Name = "m_passwordText";
            m_passwordText.PasswordChar = '*';
            m_passwordText.Size = new System.Drawing.Size(121, 20);
            m_passwordText.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(45, 22);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(53, 13);
            label2.TabIndex = 7;
            label2.Text = "Password";
            // 
            // m_CancelButton
            // 
            m_CancelButton.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            m_CancelButton.DialogResult = DialogResult.Cancel;
            m_CancelButton.Location = new System.Drawing.Point(147, 286);
            m_CancelButton.Name = "m_CancelButton";
            m_CancelButton.Size = new System.Drawing.Size(112, 23);
            m_CancelButton.TabIndex = 14;
            m_CancelButton.Text = "Cancel";
            m_CancelButton.UseVisualStyleBackColor = true;
            // 
            // m_OKButton
            // 
            m_OKButton.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            m_OKButton.DialogResult = DialogResult.OK;
            m_OKButton.Location = new System.Drawing.Point(147, 315);
            m_OKButton.Name = "m_OKButton";
            m_OKButton.Size = new System.Drawing.Size(112, 23);
            m_OKButton.TabIndex = 13;
            m_OKButton.Text = "OK";
            m_OKButton.UseVisualStyleBackColor = true;
            // 
            // DeviceCommunicationControlDialog
            // 
            ClientSize = new System.Drawing.Size(262, 342);
            Controls.Add(groupBox4);
            Controls.Add(m_reinitializeGroup);
            Controls.Add(m_communicationGroup);
            Controls.Add(groupBox1);
            Controls.Add(m_CancelButton);
            Controls.Add(m_OKButton);
            Name = "DeviceCommunicationControlDialog";
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            m_reinitializeGroup.ResumeLayout(false);
            m_reinitializeGroup.PerformLayout();
            m_communicationGroup.ResumeLayout(false);
            m_communicationGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(m_durationValue)).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);

        }
    }
}
