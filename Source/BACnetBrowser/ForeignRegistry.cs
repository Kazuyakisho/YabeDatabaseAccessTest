using System;
using System.Windows.Forms;
using BacnetLibrary.BACnetClient;
using BACnetBrowser.Properties;

namespace BACnetBrowser
{
    public partial class ForeignRegistry : Form
    {
        private TextBox BBMD_Port;
        private Button SendWhois;
        private Button sendFDR;
        private Label label1;
        private TextBox BBMD_IP;
        BacnetClient client;

        public ForeignRegistry(BacnetClient client)
        {
            this.client = client;
            InitializeComponent();
            BBMD_IP.Text = Settings.Default.DefaultBBMD;
        }

        private int PortNumber()
        {
            int Port;
            Int32.TryParse(BBMD_Port.Text, out Port);
            return Port==0 ? 47808 : Port;

        }
        private void sendFDR_Click(object sender, EventArgs e)
        {

        }

        private void SendWhois_Click(object sender, EventArgs e)
        {

        }

        private void BBMD_IP_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.BBMD_Port = new System.Windows.Forms.TextBox();
            this.SendWhois = new System.Windows.Forms.Button();
            this.sendFDR = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BBMD_IP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BBMD_Port
            // 
            this.BBMD_Port.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BBMD_Port.Location = new System.Drawing.Point(139, 47);
            this.BBMD_Port.Name = "BBMD_Port";
            this.BBMD_Port.Size = new System.Drawing.Size(51, 20);
            this.BBMD_Port.TabIndex = 9;
            this.BBMD_Port.Text = "47808";
            this.BBMD_Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SendWhois
            // 
            this.SendWhois.Enabled = false;
            this.SendWhois.Location = new System.Drawing.Point(19, 135);
            this.SendWhois.Name = "SendWhois";
            this.SendWhois.Size = new System.Drawing.Size(171, 27);
            this.SendWhois.TabIndex = 8;
            this.SendWhois.Text = "Send Remote Whois";
            this.SendWhois.UseVisualStyleBackColor = true;
            // 
            // sendFDR
            // 
            this.sendFDR.Location = new System.Drawing.Point(19, 91);
            this.sendFDR.Name = "sendFDR";
            this.sendFDR.Size = new System.Drawing.Size(171, 27);
            this.sendFDR.TabIndex = 7;
            this.sendFDR.Text = "Register";
            this.sendFDR.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Remote BBMD IPv4, IPv6 Endpoint";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BBMD_IP
            // 
            this.BBMD_IP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BBMD_IP.Location = new System.Drawing.Point(19, 47);
            this.BBMD_IP.Name = "BBMD_IP";
            this.BBMD_IP.Size = new System.Drawing.Size(114, 20);
            this.BBMD_IP.TabIndex = 5;
            // 
            // ForeignRegistry
            // 
            this.ClientSize = new System.Drawing.Size(206, 168);
            this.Controls.Add(this.BBMD_Port);
            this.Controls.Add(this.SendWhois);
            this.Controls.Add(this.sendFDR);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BBMD_IP);
            this.Name = "ForeignRegistry";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
