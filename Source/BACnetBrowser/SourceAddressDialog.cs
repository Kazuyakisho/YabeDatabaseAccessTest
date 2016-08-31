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

using System.Windows.Forms;

namespace BACnetBrowser
{
    public partial class SourceAddressDialog : Form
    {
        private NumericUpDown m_SourceAddressValue;
        private Label label1;
        private Button m_CancelButton;
        private Button m_OKButton;

        public SourceAddressDialog()
        {
            InitializeComponent();
        }

        public byte SourceAddress
        {
            get
            {
                return (byte)m_SourceAddressValue.Value;
            }
            set
            {
                m_SourceAddressValue.Value = value;
            }
        }

        private void InitializeComponent()
        {
            this.m_SourceAddressValue = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.m_CancelButton = new System.Windows.Forms.Button();
            this.m_OKButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_SourceAddressValue)).BeginInit();
            this.SuspendLayout();
            // 
            // m_SourceAddressValue
            // 
            this.m_SourceAddressValue.Location = new System.Drawing.Point(119, 7);
            this.m_SourceAddressValue.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.m_SourceAddressValue.Name = "m_SourceAddressValue";
            this.m_SourceAddressValue.Size = new System.Drawing.Size(42, 20);
            this.m_SourceAddressValue.TabIndex = 7;
            this.m_SourceAddressValue.Value = new decimal(new int[] {
            127,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = @"Set Source Address";
            // 
            // m_CancelButton
            // 
            this.m_CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_CancelButton.Location = new System.Drawing.Point(44, 34);
            this.m_CancelButton.Name = "m_CancelButton";
            this.m_CancelButton.Size = new System.Drawing.Size(56, 23);
            this.m_CancelButton.TabIndex = 5;
            this.m_CancelButton.Text = "Cancel";
            this.m_CancelButton.UseVisualStyleBackColor = true;
            // 
            // m_OKButton
            // 
            this.m_OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_OKButton.Location = new System.Drawing.Point(106, 34);
            this.m_OKButton.Name = "m_OKButton";
            this.m_OKButton.Size = new System.Drawing.Size(56, 23);
            this.m_OKButton.TabIndex = 4;
            this.m_OKButton.Text = "OK";
            this.m_OKButton.UseVisualStyleBackColor = true;
            // 
            // SourceAddressDialog
            // 
            this.ClientSize = new System.Drawing.Size(174, 69);
            this.Controls.Add(this.m_SourceAddressValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_CancelButton);
            this.Controls.Add(this.m_OKButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SourceAddressDialog";
            this.Text = "Set Source Address";
            ((System.ComponentModel.ISupportInitialize)(this.m_SourceAddressValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
