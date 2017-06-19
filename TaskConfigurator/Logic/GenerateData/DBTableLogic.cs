using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TaskConfigurator.Entity;

namespace TaskConfigurator.Logic
{
    class DBTableLogic
    {
        public void ReadDataFromDB(List<DataGridView> dgvs, string wicode, string system, string connection, System.ComponentModel.BackgroundWorker bgw)
        {
            try
            {
                var ds = new DataSet();
                DataGridView tempParent = null;

                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(GetAllData(), conn);
                    cmd.Parameters.AddWithValue("@wicode", wicode);
                    cmd.Parameters.AddWithValue("@system", system);

                    var adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(ds);

                    for (int i = 0; i <= ds.Tables.Count -1; i++)
                    {
                        ds.Tables[i].TableName = dgvs[i].Name;
                    }

                    foreach (DataGridView grid in dgvs)
                    {
                        if (grid.Name == EnumAttributes.TableName.tbl_task_configuration_data.ToString())
                        {
                            tempParent = grid;
                        }

                        if (grid.InvokeRequired)
                        {
                            grid.Invoke(new Action(() => { PopulateDataToGrid(grid, ds, bgw, tempParent); }));
                        }
                        else
                        {
                            PopulateDataToGrid(grid, ds, bgw, tempParent);
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void PopulateDataToGrid(DataGridView grid, DataSet ds, System.ComponentModel.BackgroundWorker bgw, DataGridView tempGrid)
        {
            grid.Rows.Clear();
            var table = ds.Tables[grid.Name];
            int j = 1;
            foreach (DataRow row in table.Rows)
            {
                int newId = grid.Rows.Add();
                int maxCount = table.Rows.Count;

                for (int i = 0; i <= table.Columns.Count - 1; i++)
                {
                    string columnName = table.Columns[i].ColumnName.ToLower();
                    string valueText = ValueConversion(row[columnName].ToString(), grid.Columns[columnName].Tag);
                    DataGridViewRow currentRow = grid.Rows[newId];

                    if (grid.Columns.Contains(columnName) && !Properties.Resources.constant.Split(';').ToArray().Contains(columnName))
                    {
                        currentRow.Cells[columnName].Value = valueText;
                    }
                    currentRow.Cells[columnName].ToolTipText = valueText;

                    if (grid.Name == EnumAttributes.TableName.tbl_task_configuration_data_dropdown.ToString())
                    {
                        SetParentForDataDropDown(currentRow, tempGrid);

                        foreach(DataGridViewCell cell in currentRow.Cells)
                        {
                            if (Properties.Resources.constant.ToLower().Split(';').ToArray().Contains(columnName) == false){
                                if (string.IsNullOrEmpty(currentRow.Cells["targetid"].EditedFormattedValue.ToString()))
                                {
                                    cell.Style.ForeColor = Const.ERR_ROW_FORECOLOR;
                                }
                            }
                        }
                    }

                }

                double c = (Convert.ToDouble(j) / Convert.ToDouble(maxCount)) * 100;
                bgw.ReportProgress(Convert.ToInt32(c), new string[] { "Getting data for... " + grid.Name });
                j += 1;
            }
        }

        private string ValueConversion(string textValue, object columnType)
        {
            string cText = textValue.ToLower();

            if (cText == "true")
            {
                textValue = "1";
            }
            else if (cText == "false")
            {
                textValue = "0";
            }

            if (columnType != null)
            {
                if (columnType.ToString() == "bit" && textValue == "")
                {
                    textValue = "0";
                }
            }

            return textValue;
        }

        private void SetParentForDataDropDown(DataGridViewRow row, DataGridView tempGrid)
        {
            foreach (DataGridViewRow tempRow in tempGrid.Rows)
            {
                if (tempRow.Cells["control"].EditedFormattedValue.ToString() == "DropDown")
                {
                    if (tempRow.Cells["id"].ToolTipText == row.Cells["attributeid"].ToolTipText)
                    {
                        var id = tempRow.Cells["id"].EditedFormattedValue;
                        var attributename = tempRow.Cells["attributename"].EditedFormattedValue;

                        row.Cells["targetid"].Value = id;
                        row.Cells["attributename"].Value = attributename;
                        break;
                    }
                }
            }
        }
        private string GetAllData()
        {
            StringBuilder query = new StringBuilder();

            query.AppendLine("DECLARE @id INT");
            query.AppendLine("SELECT TOP 1 @id = id FROM TBL_TASK_CONFIGURATION_DESC WITH(NOLOCK) WHERE WICODE=@wicode AND systemname = @system");
            query.AppendLine("SELECT * FROM TBL_TASK_CONFIGURATION_DESC WITH(NOLOCK) WHERE id = @id");
            query.AppendLine("SELECT * FROM TBL_TASK_CONFIGURATION_DATA WITH(NOLOCK) WHERE TASKCODEID=@id");
            query.AppendLine("SELECT * FROM TBL_TASK_CONFIGURATION_DATA_DROPDOWN WITH(NOLOCK) WHERE TASKCODEID=@id");
            query.AppendLine("SELECT * FROM TBL_TASK_CONFIGURATION_CNTRL WITH(NOLOCK) WHERE TASKCODEID=@id");
            query.AppendLine("SELECT * FROM tbl_action_status_mapping_AIB WITH(NOLOCK) WHERE WICODE=@wicode");
            query.AppendLine("SELECT * FROM tbl_task_configuration_main WITH(NOLOCK) WHERE WiCode=@wicode");
            query.AppendLine("SELECT * FROM tbl_aib_task_order_attribute_mapping WITH(NOLOCK) WHERE TASKCODEID=@id");
            return query.ToString();
        }
    }
}
