/*
1.0     20160912    Task Configurator Created
2.0     20161212    added checkbox, change the generate of script to bulk, optional can be split 
3.2     20170220    Remove hardcoded table column generation, allow to read based on server setting, enhance UI to in tab, add progress bar
4.0     20170328    Add search functionality, color the add and update of attribute, not generate for red color attribute, added script to generate latest update and insert, enhance performance, add selection toggle, fix bugs
4.1     20170404    Add main table, add more condition into update, combine common attribute, fix log script generate
4.1.2   20170419    fix couple of issue
4.1.3   2-170504    fix update for dropdown not correct
*/

using AppConfigSE;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using TaskConfigurator.Logic;
using TaskConfigurator.Logic.GenerateGridView;
using TaskConfigurator.Logic.GenerateScript;

namespace TaskConfigurator
{
    public partial class Form1 : Form
    {
        private ScriptWriter sw = new ScriptWriter();
        private AppConfigBAL acb = new AppConfigBAL();
        private ScriptReader sr = new ScriptReader();
        private DBTableLogic dtl = new DBTableLogic();
        private frmProgressBar frmPB = new frmProgressBar();
        private GridviewKeyEvent gke = new GridviewKeyEvent();
        private DataGridViewLogic dgl = new DataGridViewLogic();
        private GenerateScriptLogic gsl = new GenerateScriptLogic();

        #region "Common"
        public Form1()
        {
            InitializeComponent();
            Text = "Task Configurator V4.1.3";

            sw.GenerateColumnXML(AllGridView(), bg1);
            dgl.DoubleBufferedDataGridView(AllGridView());
            dgl.AssignDropDown(ddlSystem);
            AssignConnection();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllGrid();
            tbl_task_configuration_desc.Rows.Add();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

            CallProgressBar("Generate");
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV files (*.csv)|*.csv";

            DialogResult dr = ofd.ShowDialog();

            
            if(dr == DialogResult.OK)
            {
                ClearAllGrid();
                sr.PopulateSetting(ofd.FileName, AllGridView());
            }
        }

        private List<DataGridView> AllGridView()
        {
            var grid = new List<DataGridView>();

            grid.AddRange(new DataGridView[] {
                tbl_task_configuration_desc,
                tbl_task_configuration_data,
                tbl_task_configuration_data_dropdown,
                tbl_task_configuration_cntrl,
                tbl_action_status_mapping_AIB,
                tbl_task_configuration_main,
                tbl_aib_task_order_attribute_mapping
            });

            return grid;
        }
        private void ClearAllGrid()
        {
            foreach(DataGridView grid in AllGridView())
            {
                grid.Rows.Clear();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CallProgressBar("Search");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("This will re-generate the table from the server and will take some time, do you want to continue?","Information",MessageBoxButtons.YesNo,MessageBoxIcon.Information);

            if (msg == DialogResult.Yes){
                CallProgressBar("Refresh");
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            frmLog log = new frmLog();

            log.ShowDialog();
        }

        private void AssignConnection()
        {
            ddlServer.Tag = "N";
            ddlServer.DataSource = acb.ListOfConnection();
            ddlServer.DisplayMember = "Name";
            ddlServer.ValueMember = "ConnectionString";

            int index = ddlServer.FindString("DEV");
            ddlServer.Tag = "Y";
            ddlServer.SelectedIndex = index;
        }

        private void AssignSystem()
        {
          
        }

        private void ddlServer_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void ddlServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var dropdown = (ComboBox)sender;
                if (dropdown.Tag.ToString() == "Y")
                {
                    var entity = (AppConfigEntity)dropdown.SelectedItem;

                    sr.ReadXMLColumn(entity.Name, AllGridView());
                    tbl_task_configuration_desc.Rows.Add();
                    if (!string.IsNullOrEmpty(txtWicode.Text.Trim()))
                    {
                        btnSearch.PerformClick();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\nPlease run \"Refresh\" to re-get the setting", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F && e.Control)
            {
                foreach (var s in tabControl1.SelectedTab.Controls)
                {
                    if (s is DataGridView)
                    {
                        frmSearch frm = new frmSearch();
                        frm.grid = ((DataGridView)s);

                        var fileCheck = Application.OpenForms["frmSearch"];
                        if (fileCheck == null)
                        {
                            frm.Show();
                        }
                        else
                        {
                            fileCheck.BringToFront();
                        }
                    }
                }
            }
        }

        private void CommonColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            gke.ColumnDoubleClick((DataGridView)sender, e);
        }

        private void CommonCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            var grid = (DataGridView)sender;

            dgl.FormatGridStyle(grid);
            if (grid.IsCurrentCellDirty)
            {
                grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void CommonUserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            dgl.UserAddedRowsNo((DataGridView)sender, e);
        }

        #endregion

        #region "tbl_task_configuration_desc"
        private void tbl_task_configuration_desc_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgl.RowsAdded((DataGridView)sender, e);
        }

        private void tbl_task_configuration_desc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dgl.UpdateResponseMapping((DataGridView)sender, tbl_action_status_mapping_AIB, e);
        }

        #endregion

        #region "tbl_task_configuration_data"
        private void tbl_task_configuration_data_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgl.RowsAdded((DataGridView)sender, e);
        }
        private void tbl_task_configuration_data_KeyDown(object sender, KeyEventArgs e)
        {
            gke.CommonKeyDownEvent((DataGridView)sender, e, tbl_task_configuration_data_dropdown);
        }

        private void tbl_task_configuration_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void tbl_task_configuration_data_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dgl.InsertDataDropDownFromData((DataGridView)sender, tbl_task_configuration_data_dropdown, e);
        }

        private void tbl_task_configuration_data_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
        }

        #endregion

        #region "tbl_task_configuration_data_dropdown"
        private void tbl_task_configuration_data_dropdown_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgl.RowsAdded((DataGridView)sender, e);
        }


        private void tbl_task_configuration_data_dropdown_KeyDown(object sender, KeyEventArgs e)
        {
            string msg = "";
            msg = gke.CommonKeyDownEvent((DataGridView)sender, e, tbl_task_configuration_data);

            if (msg != "")
            {
                MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tbl_task_configuration_data_dropdown_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

            gke.CommonMouseClickEvent((DataGridView)sender, e, cmsDropDown);
        }

        private void DropDownAddNew_Click(object sender, EventArgs e)
        {
            dgl.InsertNewDataDropDown(tbl_task_configuration_data_dropdown);
        }

        #endregion

        #region "tbl_task_configuration_cntrl"
        private void tbl_task_configuration_cntrl_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgl.RowsAdded((DataGridView)sender, e);
        }

        private void tbl_task_configuration_cntrl_KeyDown(object sender, KeyEventArgs e)
        {
            gke.CommonKeyDownEvent((DataGridView)sender, e);
        }

        #endregion

        #region "tbl_action_status_mapping_AIB"
        private void tbl_action_status_mapping_AIB_KeyDown(object sender, KeyEventArgs e)
        {
            gke.CommonKeyDownEvent((DataGridView)sender, e);
        }
        private void tbl_action_status_mapping_AIB_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgl.RowsAdded((DataGridView)sender, e, tbl_task_configuration_desc);
        }

        #endregion

        #region "Backgroundworker"

        private void CallProgressBar(string method)
        {
            bg1.RunWorkerAsync(method);
            frmPB.ShowDialog();
        }

        private void bg1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string method = (string)e.Argument;

            if (method == "Refresh")
            {
                sw.DeleteColumnsFolder();
                sw.GenerateColumnXML(AllGridView(), bg1);
            }
            else if (method == "Search")
            {
                var system = "";
                var server = "";

                Invoke(new MethodInvoker(delegate { system = ddlSystem.SelectedItem.ToString().Trim(); }));
                Invoke(new MethodInvoker(delegate { server = ddlServer.SelectedValue.ToString(); }));

                dtl.ReadDataFromDB(AllGridView(), txtWicode.Text.Trim(), system, server, bg1);
            }
            else if (method == "Generate")
            {
                var desc = tbl_task_configuration_desc.Rows[0];
                var wiCode = desc.Cells["wicode"].EditedFormattedValue.ToString();
                var systemName = desc.Cells["systemname"].EditedFormattedValue.ToString();

                bool flag = gsl.GenerateInsertCheckScript(AllGridView(), chkSingle.Checked, wiCode, systemName, bg1);

                if (flag)
                {
                    e.Result = wiCode;
                }
            }

        }

        private void bg1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

            frmPB.SetProgressNoAnimation(e.ProgressPercentage);
            frmPB.ModifyText = ((string[])e.UserState)[0].ToString();

        }

        private void bg1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Thread.Sleep(1000);
            frmPB.Close();

            if (e.Result != null)
            {
                Process.Start(Directory.GetCurrentDirectory() +  "\\Scripts\\" + e.Result.ToString() + "\\" + DateTime.Now.ToString("ddMMyyyy"));
            }
        }

        #endregion

        #region  "GridError"
        private void tbl_task_configuration_data_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView s = (DataGridView)sender;

            var test = s.Columns[e.ColumnIndex].Name;
        }

        private void tbl_task_configuration_desc_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView s = (DataGridView)sender;

            var test = s.Columns[e.ColumnIndex].Name;
        }

        private void tbl_task_configuration_data_dropdown_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView s = (DataGridView)sender;

            var test = s.Columns[e.ColumnIndex].Name;

        }

        private void tbl_task_configuration_cntrl_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView s = (DataGridView)sender;

            var test = s.Columns[e.ColumnIndex].Name;
        }

        private void tbl_action_status_mapping_AIB_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView s = (DataGridView)sender;

            var test = s.Columns[e.ColumnIndex].Name;

        }
        #endregion
    }
}