namespace BACnetBrowser
{
    partial class FormCreateDatabase
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbCreateDatabase = new System.Windows.Forms.TextBox();
            this.btnCreateDatabase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name of new DB:";
            // 
            // tbCreateDatabase
            // 
            this.tbCreateDatabase.Location = new System.Drawing.Point(101, 19);
            this.tbCreateDatabase.Name = "tbCreateDatabase";
            this.tbCreateDatabase.Size = new System.Drawing.Size(212, 20);
            this.tbCreateDatabase.TabIndex = 1;
            // 
            // btnCreateDatabase
            // 
            this.btnCreateDatabase.Location = new System.Drawing.Point(319, 17);
            this.btnCreateDatabase.Name = "btnCreateDatabase";
            this.btnCreateDatabase.Size = new System.Drawing.Size(75, 23);
            this.btnCreateDatabase.TabIndex = 2;
            this.btnCreateDatabase.Text = "Create";
            this.btnCreateDatabase.UseVisualStyleBackColor = true;
             // 
            // FormCreateDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 55);
            this.Controls.Add(this.btnCreateDatabase);
            this.Controls.Add(this.tbCreateDatabase);
            this.Controls.Add(this.label1);
            this.Name = "FormCreateDatabase";
            this.Text = "Create Database ...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbCreateDatabase;
        public System.Windows.Forms.Button btnCreateDatabase;
    }
}