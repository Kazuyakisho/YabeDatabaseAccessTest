namespace BACnetBrowser
{
    partial class FormConnectionString
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbConnectionString = new System.Windows.Forms.TextBox();
            this.lblCon = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbProviderName = new System.Windows.Forms.TextBox();
            this.tbass = new System.Windows.Forms.Label();
            this.tbAsmName = new System.Windows.Forms.TextBox();
            this.btnSaveConString = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbConnectionName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbConnectionString
            // 
            this.tbConnectionString.Location = new System.Drawing.Point(107, 49);
            this.tbConnectionString.Name = "tbConnectionString";
            this.tbConnectionString.Size = new System.Drawing.Size(620, 20);
            this.tbConnectionString.TabIndex = 0;
            // 
            // lblCon
            // 
            this.lblCon.AutoSize = true;
            this.lblCon.Location = new System.Drawing.Point(6, 52);
            this.lblCon.Name = "lblCon";
            this.lblCon.Size = new System.Drawing.Size(91, 13);
            this.lblCon.TabIndex = 1;
            this.lblCon.Text = "ConnectionString:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ProviderName:";
            // 
            // tbProviderName
            // 
            this.tbProviderName.Enabled = false;
            this.tbProviderName.Location = new System.Drawing.Point(339, 78);
            this.tbProviderName.Name = "tbProviderName";
            this.tbProviderName.Size = new System.Drawing.Size(115, 20);
            this.tbProviderName.TabIndex = 2;
            // 
            // tbass
            // 
            this.tbass.AutoSize = true;
            this.tbass.Location = new System.Drawing.Point(471, 81);
            this.tbass.Name = "tbass";
            this.tbass.Size = new System.Drawing.Size(54, 13);
            this.tbass.TabIndex = 5;
            this.tbass.Text = "Assembly:";
            // 
            // tbAsmName
            // 
            this.tbAsmName.Enabled = false;
            this.tbAsmName.Location = new System.Drawing.Point(531, 78);
            this.tbAsmName.Name = "tbAsmName";
            this.tbAsmName.Size = new System.Drawing.Size(115, 20);
            this.tbAsmName.TabIndex = 6;
            // 
            // btnSaveConString
            // 
            this.btnSaveConString.Location = new System.Drawing.Point(652, 76);
            this.btnSaveConString.Name = "btnSaveConString";
            this.btnSaveConString.Size = new System.Drawing.Size(75, 23);
            this.btnSaveConString.TabIndex = 7;
            this.btnSaveConString.Text = "Save";
            this.btnSaveConString.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "ConnectionName:";
            // 
            // tbConnectionName
            // 
            this.tbConnectionName.Enabled = false;
            this.tbConnectionName.Location = new System.Drawing.Point(107, 78);
            this.tbConnectionName.Name = "tbConnectionName";
            this.tbConnectionName.Size = new System.Drawing.Size(143, 20);
            this.tbConnectionName.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(544, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Attention! Be careful with entering  a connection string. Look to the page www.co" +
    "nnectionstrings.com for patterns.";
            // 
            // FormConnectionString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 115);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbConnectionName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSaveConString);
            this.Controls.Add(this.tbAsmName);
            this.Controls.Add(this.tbass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbProviderName);
            this.Controls.Add(this.lblCon);
            this.Controls.Add(this.tbConnectionString);
            this.Name = "FormConnectionString";
            this.Text = "ConnectionString";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCon;
        public System.Windows.Forms.TextBox tbConnectionString;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbProviderName;
        private System.Windows.Forms.Label tbass;
        public System.Windows.Forms.TextBox tbAsmName;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tbConnectionName;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnSaveConString;
    }
}