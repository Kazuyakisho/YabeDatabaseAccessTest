namespace BACnetBrowser
{
    partial class Logger
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
            this.m_LogText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // m_LogText
            // 
            this.m_LogText.BackColor = System.Drawing.Color.White;
            this.m_LogText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_LogText.Location = new System.Drawing.Point(0, 0);
            this.m_LogText.Multiline = true;
            this.m_LogText.Name = "m_LogText";
            this.m_LogText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_LogText.Size = new System.Drawing.Size(609, 290);
            this.m_LogText.TabIndex = 1;
            // 
            // Logger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 290);
            this.Controls.Add(this.m_LogText);
            this.Name = "Logger";
            this.Text = "Logger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox m_LogText;
    }
}