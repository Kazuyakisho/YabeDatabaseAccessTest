using BACnetBrowser.Properties;
using BACnetGenericDatabaseAccess;
using BACnetGenericDatabaseAccess.Database.Enum;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BACnetBrowser
{
    public partial class DatabaseConnectionForm : Form
    {


        private readonly DBManager _dbManager = DBManager.Instance;

        private int uploadTimeSpan = 10;


        public DatabaseConnectionForm()
        {
            InitializeComponent();

            //event stop
            comBoxDatabases.SelectedIndexChanged -= comBoxDatabases_SelectedIndexChanged;


            //collapsed the panel for tables
            splitContainer3.Panel2Collapsed = true;
            splitContainer3.Panel2MinSize = 0;

            //set imagelist for Listview Items
            listViewUploadList.SmallImageList = imagelist;
            //Load the connections from config file
            if (!_dbManager.LoadConnectionsFromConfigFile())
            {
                m_StatusStripLabel2.Text = "No Servers in config file";
            }

            //Add providerconnection from dictioniary to combobox
            FillListViewUpload();


            //Column Width Change
            listViewUploadList.Columns[0].Width = groupBoxConnectionsAndSubsriber.Width - 90;

            //undiscribe event
            this.tbConnectionName.TextChanged -= this.tbConnectionName_TextChanged;
            //Load weekdays for uploading data
            LoadWeekDays();

            //Timespan for uploading data in s
            LoadUploadTimeSpan();

            ScrollUploadTime.Value = Settings.Default.SQLDataUploadTimeSpan / 1000;

        }

        private void btnTryConnection_Click(object sender, EventArgs e)
        {




            //set properties for connection
            _dbManager.SetCurrentProviderByAttributes((EnumDB)cbBoxConnectionType.SelectedIndex, tbConnectionName.Text,
                tbServer.Text, tbServerPort.Text, tbUsername.Text, tbPW.Text);




            //test the connection
            if (_dbManager.TryConnection())
            {
                btnTryConnection.BackColor = Color.LawnGreen;
                btnSaveConnection.Visible = true;
                btnNewDatabase.Enabled = true;
                listViewTableNames.Visible = true;
                comBoxDatabases.Enabled = true;
                panConnectionDetails.Enabled = false;
                comBoxDatabases.DataSource = _dbManager.CurrentProvider.Handle.DbAbstractFactoryQueries.GetDatabases();

                comBoxDatabases.SelectedIndexChanged += comBoxDatabases_SelectedIndexChanged;

            }
            else
            {
                btnTryConnection.BackColor = Color.Red;
                m_StatusStripLabel1.Text = @"Error while connecting to server";
                btnSaveConnection.Visible = false;
                btnNewDatabase.Enabled = false;
                panConnectionDetails.Enabled = true;
                btnShowTable.Visible = false;
            }



        }

        private void btnSaveConnection_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckLoginData()) return;


                //change window size to normal
                Width = splitContainer1.SplitterDistance + splitContainer3.SplitterDistance + 10;

                //for database access
                _dbManager.SaveCurrentProvider(comBoxDatabases.Text);

                //load upload lsit
                FillListViewUpload();

                //set save button unvisible
                btnSaveConnection.Visible = false;

                //set try connection background color empty
                btnTryConnection.BackColor = Color.Empty;

                //save default for weekdays and counter
                Settings.Default.Save();

                //panel enabled false
                panTryConnection.Enabled = false;
                panConnectionDetails.Enabled = false;
                panConnectionName.Enabled = false;

                btnCancel.Enabled = false;

                tbConnectionName.Enabled = true;
                btnNewDatabase.Enabled = false;
                listViewTableNames.Visible = false;
                listViewUploadList.Enabled = true;
                btnShowTable.Visible = false;

                //disable eventhandlers
                tbConnectionName.TextChanged -= tbConnectionName_TextChanged;
                comBoxDatabases.SelectedIndexChanged -= comBoxDatabases_SelectedIndexChanged;

                //show message 
                m_StatusStripLabel1.Text = @"Data saved successfully!!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private bool CheckLoginData()
        {
            bool result = true;

            if (string.IsNullOrEmpty(tbConnectionName.Text))
            {
                result = false;
                tbConnectionName.BackColor = Color.IndianRed;
            }
            else
            {
                tbConnectionName.BackColor = Color.White;
            }
            if (string.IsNullOrEmpty(tbServer.Text))
            {
                result = false;
                tbServer.BackColor = Color.IndianRed;
            }
            else
            {
                tbServer.BackColor = Color.White;
            }
            if (string.IsNullOrEmpty(tbServerPort.Text))
            {
                result = false;
                tbServerPort.BackColor = Color.IndianRed;
            }
            else
            {
                tbServerPort.BackColor = Color.White;
            }
            if (string.IsNullOrEmpty(tbUsername.Text))
            {
                result = false;
                tbUsername.BackColor = Color.IndianRed;
            }
            else
            {
                tbUsername.BackColor = Color.White;
            }
            if (string.IsNullOrEmpty(tbPW.Text))
            {
                result = false;
                tbPW.BackColor = Color.IndianRed;
            }
            else
            {
                tbPW.BackColor = Color.White;
            }


            return result;
        }

        private void SaveWeekDays()
        {
            string weekDays =
                $"{nameof(cbSo)}.{cbSo.Checked}_{nameof(cbMo)}.{cbMo.Checked}_{nameof(cbDi)}.{cbDi.Checked}_{nameof(cbMi)}.{cbMi.Checked}_{nameof(cbDo)}.{cbDo.Checked}_{nameof(cbFr)}.{cbFr.Checked}_{nameof(cbSa)}.{cbSa.Checked}";

            Settings.Default.SQLDataUploadWeekDays = weekDays;
            DBManager.Instance.daysOfWeek.SetWeekdays(weekDays);
            Settings.Default.Save();
        }

        private void SaveUploadTimeSpan()
        {
            Settings.Default.SQLDataUploadTimeSpan = uploadTimeSpan * 1000;
            Settings.Default.Save();
        }

        private void LoadWeekDays()
        {
            if (Settings.Default.SQLDataUploadWeekDays == "") return;

            string str = Settings.Default.SQLDataUploadWeekDays;



            foreach (Control c in tLayPanWeekdays.Controls)
            {
                if (c is CheckBox)
                {
                    if (str.Substring((str.IndexOf(c.Name, StringComparison.Ordinal) + c.Name.Length) + 1, 4) == "True")
                    {
                        ((CheckBox)c).Checked = true;
                    }
                    else
                    {
                        ((CheckBox)c).Checked = false;
                    }
                }


            }
        }

        private void LoadUploadTimeSpan()
        {
            uploadTimeSpan = Settings.Default.SQLDataUploadTimeSpan / 1000;
            if (uploadTimeSpan == 0) uploadTimeSpan = 10;
            hScrollBar1.Value = uploadTimeSpan;
            lblSecondsToUplaod.Text = $"Seconds to upload cov-data(timespan): {uploadTimeSpan.ToString()} s";

        }

        private void btnShowTableNames_Click(object sender, EventArgs e)
        {
            FormConnectionString dlg = new FormConnectionString();


            dlg.tbConnectionString.Text = _dbManager.CurrentProvider.ConnectionsString;
            dlg.tbAsmName.Text = _dbManager.CurrentProvider.Name;
            dlg.tbConnectionName.Text = _dbManager.CurrentProvider.Name;
            dlg.tbProviderName.Text = _dbManager.CurrentProvider.ProviderName;


            dlg.btnSaveConString.Click += (o, args) =>
            {
                _dbManager.CurrentProvider.ConnectionsString = dlg.tbConnectionString.Text;
                _dbManager.CurrentProvider.SetAttributes();

                dlg.Close();

                //set properties for connection
                _dbManager.UpdateDBProvider(tbConnectionName.Text);
                LoadProviderData();



            };

            dlg.ShowDialog(this);

        }



        private void LoadProviderData()
        {

            //load provider data from selected item in combobox

            cbBoxConnectionType.SelectedIndex = (int)_dbManager.CurrentProvider.EnumDb;

            tbConnectionName.Text = _dbManager.CurrentProvider.Name;
            tbServer.Text = _dbManager.CurrentProvider.ConStringServer;
            tbServerPort.Text = _dbManager.CurrentProvider.ConStringPort.ToString();
            tbUsername.Text = _dbManager.CurrentProvider.ConStringUserName;
            tbPW.Text = _dbManager.CurrentProvider.ConStringPW;
            comBoxDatabases.Text = _dbManager.CurrentProvider.ConStringDataBase;


        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            tbConnectionName.TextChanged -= tbConnectionName_TextChanged;
            comBoxDatabases.SelectedIndexChanged -= comBoxDatabases_SelectedIndexChanged;

            Width = splitContainer1.SplitterDistance + splitContainer3.SplitterDistance + 10;

            panConnectionName.Enabled = false;
            panTryConnection.Enabled = false;
            panConnectionDetails.Enabled = false;

            comBoxDatabases.Enabled = false;
            btnCancel.Enabled = false;
            btnNewDatabase.Enabled = false;
            btnSaveConnection.Visible = false;
            btnShowTable.Visible = false;

            tbConnectionName.Enabled = true;
            btnTryConnection.BackColor = Color.Empty;

            splitContainer3.Panel2Collapsed = true;
            listViewUploadList.Enabled = true;
            btnShowTable.Visible = false;

        }



        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            // lblSecondsToUplaod.Text = $" s to upload";
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            lblSecondsToUplaod.Text = $"Seconds to upload cov-data (timespan): {e.NewValue} s";
            uploadTimeSpan = e.NewValue;
        }

        private void btnSaveDatabase_Click(object sender, EventArgs e)
        {
            SaveWeekDays();
            SaveUploadTimeSpan();

            this.Close();

        }

        private void cbBoxConnectionType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void btnNewDatabase_Click(object sender, EventArgs e)
        {

            var message = MessageBox.Show("Do you want create a DataBase?", "Create Database",
                MessageBoxButtons.OKCancel);

            if (message == DialogResult.OK)
            {
                FormCreateDatabase cdb = new FormCreateDatabase();
                cdb.Show();
                cdb.btnCreateDatabase.Click += (s, args) =>
                {


                    if (_dbManager.CurrentProvider.Handle.DbAbstractFactoryQueries.CreateDatabase(cdb.tbCreateDatabase.Text))
                    {
                        btnTryConnection.BackColor = Color.Empty;
                        comBoxDatabases.DataSource = _dbManager.CurrentProvider.Handle.DbAbstractFactoryQueries.GetDatabases();
                        cdb.Close();
                        MessageBox.Show("Successfully created");
                    }
                    else
                    {
                        MessageBox.Show(_dbManager.CurrentProvider.Handle.DbAbstractFactoryQueries.ErrorMessage);
                    }


                };
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Width = 940;

            _dbManager.CurrentProvider.ConStringDataBase = comBoxDatabases.Text;
            listViewTableNames.Items.Clear();
            splitContainer3.Panel2Collapsed = false;

            splitContainer1.SplitterDistance = 330;
            splitContainer3.SplitterDistance = 360;





            foreach (var tablename in _dbManager.CurrentProvider.Handle.DbAbstractFactoryQueries.GetTableNames())
            {
                listViewTableNames.Items.Add(tablename);
            }

        }

        private void tbConnectionName_TextChanged(object sender, EventArgs e)
        {
            if (tbConnectionName.Text == "")
            {
                tbConnectionName.BackColor = Color.Coral;
                panTryConnection.Enabled = panConnectionDetails.Enabled = false;
                m_statusStripLabelErgebnis.Text = @"Please name the connection!";
                return;
            }


            if (_dbManager.DbProviders.ContainsKey(tbConnectionName.Text))
            {
                tbConnectionName.BackColor = Color.Coral;
                panTryConnection.Enabled = panConnectionDetails.Enabled = false;
                m_statusStripLabelErgebnis.Text = @"Already exits in Providerlist!";
                return;
            }

            panTryConnection.Enabled = panConnectionDetails.Enabled = true;
            tbConnectionName.BackColor = Color.Empty;
            m_statusStripLabelErgebnis.Text = "";

        }


        private void groupBoxConnectionsAndSubsriber_SizeChanged(object sender, EventArgs e)
        {
            listViewUploadList.Columns[0].Width = groupBoxConnectionsAndSubsriber.Width - 90;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tbConnectionName.TextChanged += this.tbConnectionName_TextChanged;

            listViewUploadList.Enabled = false;
            _dbManager.SetCurrentProvider();

            LoadProviderData();

            panConnectionName.Enabled = true;
            panTryConnection.Enabled = false;
            panConnectionDetails.Enabled = false;

            btnCancel.Enabled = true;


            comBoxDatabases.Enabled = false;
        }

        private void listViewUploadList_Click(object sender, EventArgs e)
        {
            //Load Provider Data
            _dbManager.SetCurrentProviderByKeyname(listViewUploadList.SelectedItems[0].SubItems[0].Text);

            LoadProviderData();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewUploadList.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"Please select a connection name!");
                return;
            }
            if (listViewUploadList.SelectedItems.Count > 1)
            {
                MessageBox.Show(@"Please select only one connection for editing");
                return;
            }


            if (_dbManager.DbSubsribers.ContainsKey(listViewUploadList.SelectedItems[0].SubItems[0].Text))
            {
                MessageBox.Show(@"Please unsubscribe the connection first!");
                return;
            }




            _dbManager.SetCurrentProviderByKeyname(listViewUploadList.SelectedItems[0].SubItems[0].Text);
            listViewUploadList.Enabled = false;

            comBoxDatabases.DataSource = null;

            LoadProviderData();

            panTryConnection.Enabled = true;
            panConnectionDetails.Enabled = true;
            panConnectionName.Enabled = false;


            btnCancel.Enabled = true;


        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewUploadList.SelectedItems.Count > 0)
            {

                var messageResult = MessageBox.Show("You really want delete?", "Delete connection(s)",
                    MessageBoxButtons.YesNo);

                if (messageResult == DialogResult.No) return;

                bool erg = true;

                for (int i = 0; i < listViewUploadList.SelectedItems.Count; i++)
                {
                    if (_dbManager.DbSubsribers.ContainsKey(listViewUploadList.SelectedItems[i].SubItems[0].Text))
                    {
                        MessageBox.Show(
                            $"Please remove the connection {listViewUploadList.SelectedItems[i].SubItems[0].Text} from upload list first!");
                        continue;
                    }

                    _dbManager.SetCurrentProviderByKeyname(listViewUploadList.SelectedItems[i].SubItems[0].Text);
                    //check if the current provider is a subscriber

                    _dbManager.Remove();

                }

                FillListViewUpload();
            }
            else
            {
                MessageBox.Show(@"Please select one or more connections! ");
            }


        }

        private void subscribeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewUploadList.SelectedItems.Count > 0)
            {
                bool erg = true;

                for (int i = 0; i < listViewUploadList.SelectedItems.Count; i++)
                {

                    _dbManager.SetCurrentProviderByKeyname(listViewUploadList.SelectedItems[i].SubItems[0].Text);

                    //check connection 
                    bool isConnection = _dbManager.TryConnection();

                    //Add subsriber to uploadlist
                    if (isConnection) _dbManager.AddDBSubscriber();

                    listViewUploadList.Items[listViewUploadList.SelectedItems[i].Index].ImageIndex = isConnection ? 0 : 1;
                    listViewUploadList.SelectedItems[i].SubItems[1].Text = isConnection ? "True" : "False";

                    erg = erg && isConnection;
                }

                if (!erg)
                {
                    MessageBox.Show($"Some providers are not valid for subscribtion - please check the connections");
                    return;
                }



            }

            //Fill Uploadlistview
            FillListViewUpload();


            m_statusStripLabelErgebnis.Text = "Subscribtion added!";
            m_statusStripLabelErgebnis.ForeColor = Color.Blue;


        }

        private void unsubscribeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < listViewUploadList.SelectedItems.Count; i++)
            {
                _dbManager.RemoveDBSubscriber(listViewUploadList.SelectedItems[i].Text);

            }

            FillListViewUpload();
        }

        public void FillListViewUpload()
        {
            listViewUploadList.Items.Clear();

            if (_dbManager.DbProviders.Count != 0)
            {

                int i = 0;
                foreach (var dbProvider in _dbManager.DbProviders)
                {

                    string[] arr = new string[2];
                    arr[0] = dbProvider.Key;

                    bool result = _dbManager.DbSubsribers.ContainsKey(dbProvider.Key);

                    arr[1] = result.ToString();
                    listViewUploadList.Items.Add(new ListViewItem(arr));

                    listViewUploadList.Items[i].ImageIndex = result ? 0 : 1;


                    i++;




                }

            }

        }

        private void contextMenuStripSettings_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (listViewUploadList.SelectedItems.Count == 0)
            {

                for (int i = 1; i < contextMenuStripSettings.Items.Count; i++)
                {
                    contextMenuStripSettings.Items[i].Visible = false;
                }

            }
            else
            {
                for (int i = 1; i < contextMenuStripSettings.Items.Count; i++)
                {
                    contextMenuStripSettings.Items[i].Visible = true;
                }
            }
        }

        private void comBoxDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnShowTable.Visible = true;
        }

        private void toolStripMenuItemSaveSettings_Click(object sender, EventArgs e)
        {
            SaveWeekDays();
            SaveUploadTimeSpan();


            this.Close();

        }

        private void toolStripMenuItemNew_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem.PerformClick();
        }

        private void toolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            if (listViewUploadList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item form list!");
                return;
            }
            editToolStripMenuItem.PerformClick();
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (listViewUploadList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item from list!");
                return;
            }
            deleteToolStripMenuItem.PerformClick();
        }

        private void addToolStripMenuItemAddSub_Click(object sender, EventArgs e)
        {
            if (listViewUploadList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item from list!");
                return;
            }

            subscribeToolStripMenuItem.PerformClick();
        }

        private void removeToolStripMenuItemRemoveSub_Click(object sender, EventArgs e)
        {
            if (listViewUploadList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item from list!");
                return;
            }
            unsubscribeToolStripMenuItem.PerformClick();
        }

        private void sELECTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewUploadList.SelectedItems.Count == 0)
            {
                return;
            }
            if (listViewUploadList.SelectedItems.Count > 1)
            {
                MessageBox.Show(@"Please select only one Table g");
                return;
            }

            Commands com = new Commands();
            com.tbCommand.Text = $"SELECT * FROM {listViewTableNames.SelectedItems[0].Text}";
            com.Show();



        }

        private void contextMenuStripCommands_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
