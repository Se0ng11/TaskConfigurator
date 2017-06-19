using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TaskConfigurator.Entity;
using System.Drawing;
using System.Reflection;

namespace TaskConfigurator.Logic
{
    public class DataGridViewLogic
    {
        private const string _taskCodeId = "@taskcodeid";
        private const string _attributeId = "@attributeid";
        private static bool _isSetting = false; 

        #region  "Public"

        public void DoubleBufferedDataGridView(List<DataGridView> source)
        {
            foreach(DataGridView grid in source)
            {
                typeof(DataGridView).InvokeMember(
                    "DoubleBuffered",
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                    null,
                    grid,
                    new object[] { true }
                );
            }
        }

        public void AssignDropDown(ComboBox cb)
        {
            var res = Properties.Resources.systemname;
            cb.Items.AddRange(res.Split(';').Where(x => x.ToString() != "").ToArray());
            cb.SelectedItem = "AIB HE L2C";
        }

        public void AssignDataGridColumn(DataGridView dgv, List<InformationSchemaColumns> lst)
        {
            dgv.Columns.Clear();

            foreach (InformationSchemaColumns data in lst)
            {
                var newColumn = new DataGridViewColumn();

                newColumn = SetColumnType(data);
                dgv.Columns.Add(SetDefaultValue(newColumn, data));
            }

            if (dgv.Name == EnumAttributes.TableName.tbl_task_configuration_data_dropdown.ToString())
            {
                var attributeName = new DataGridViewTextBoxColumn() { Name = "attributename", HeaderText = "attributename", ReadOnly = true };
                var targetId = new DataGridViewTextBoxColumn() { Name = "targetid", HeaderText = "targetid", ReadOnly = true };

                attributeName.DefaultCellStyle.ForeColor = Color.DarkSlateGray;
                attributeName.DefaultCellStyle.Font = new Font(Control.DefaultFont, FontStyle.Italic);

                dgv.Columns.Add(attributeName);
                dgv.Columns.Add(targetId);
            }

            if (dgv.Name == EnumAttributes.TableName.tbl_action_status_mapping_AIB.ToString())
            {
                dgv.Columns["wicode"].ReadOnly = true;
            }
        }

        private DataGridViewColumn SetColumnType(InformationSchemaColumns data)
        {
            var newColumn = new DataGridViewColumn();

            if (data.DATA_TYPE == "bit")
            {
                var res = new DataGridViewComboBoxColumn() { Name = data.COLUMN_NAME, HeaderText = data.COLUMN_NAME, SortMode = DataGridViewColumnSortMode.NotSortable };

                res.Items.AddRange(new string[] { "0", "1" });
                res.DefaultCellStyle.NullValue = "1";
                res.Tag = data.DATA_TYPE;
                newColumn = res;
            }
            else if ( Properties.Resources.dropdown.ToLower().Split(';').Contains(data.COLUMN_NAME.ToLower()))
            {
                var s = new DataGridViewComboBoxColumn() { Name = data.COLUMN_NAME, HeaderText = data.COLUMN_NAME, SortMode = DataGridViewColumnSortMode.NotSortable };

                if (data.COLUMN_NAME.ToLower() == "control")
                {
                    var res = Properties.Resources.control;
                    s.Items.AddRange(res.Split(';').Where(x => x.ToString() != "").ToArray());
                    s.DefaultCellStyle.NullValue = "TextBox";
                }
                else if (data.COLUMN_NAME.ToLower() == "systemname")
                {
                    var res = Properties.Resources.systemname;
                    s.Items.AddRange(res.Split(';').Where(x => x.ToString() != "").ToArray());
                    s.DefaultCellStyle.NullValue = "AIB HE L2C";
                }
                else if (data.COLUMN_NAME.ToLower() == "attribute")
                {
                    var res = Properties.Resources.actionstatus;
                    s.Items.AddRange(res.Split(';').Where(x => x.ToString() != "").ToArray());
                    s.DefaultCellStyle.NullValue = "Action";
                }
                else if (data.COLUMN_NAME.ToLower() == "defaulttaskpriority")
                {
                    var res = Properties.Resources.taskpriority;
                    s.Items.AddRange(res.Split(';').Where(x => x.ToString() != "").ToArray());
                    s.DefaultCellStyle.NullValue = "Normal";
                }
                else if (data.COLUMN_NAME.ToLower() == "ordernotificationflag")
                {
                    var res = Properties.Resources.flag;
                    s.Items.AddRange(res.Split(';').Where(x => x.ToString() != "").ToArray());
                    s.DefaultCellStyle.NullValue = "N";
                }

                newColumn = s;
            }
            else
            {
                newColumn = new DataGridViewTextBoxColumn() { Name = data.COLUMN_NAME, HeaderText = data.COLUMN_NAME, SortMode= DataGridViewColumnSortMode.NotSortable };
            }

            return newColumn;
        }

        private DataGridViewColumn SetDefaultValue(DataGridViewColumn dgc, InformationSchemaColumns data)
        {
            var mandatory = Properties.Resources.mandatory;
            var constant = Properties.Resources.constant;
            var columnName = ";" + data.COLUMN_NAME.ToLower() + ";";

            if (data.COLUMN_DEFAULT.Trim() != "")
            {
                dgc.DefaultCellStyle.NullValue = data.COLUMN_DEFAULT.Replace(@"(", "").Replace(@")", "").Replace(@"'", "");
            }
            
            if (mandatory.ToLower().Contains(columnName))
            {
                dgc.DefaultCellStyle.BackColor = Color.LightBlue;
            }

            if (constant.ToLower().Contains(columnName))
            {
                dgc.ReadOnly = true;
                dgc.DefaultCellStyle.NullValue = "@" + data.COLUMN_NAME.ToLower();
                dgc.DefaultCellStyle.ForeColor = Color.DarkSlateGray;
                dgc.DefaultCellStyle.Font = new Font(Control.DefaultFont, FontStyle.Italic);
                if (data.COLUMN_NAME.ToLower() == "id")
                {
                    dgc.Width = 30;
                }

            }

            if (data.COLUMN_NAME.ToLower() == "editableinjourney")
            {
                dgc.DefaultCellStyle.NullValue = "ALL";
            }
            else if (data.COLUMN_NAME.ToLower() == "rownum")
            {
                dgc.DefaultCellStyle.NullValue = "1";
            }
            else if (data.COLUMN_NAME.ToLower() == "seqno")
            {
                dgc.DefaultCellStyle.NullValue = "0";
            }
            else if (data.COLUMN_NAME.ToLower() == "screenorder")
            {
                dgc.DefaultCellStyle.NullValue = "0";
            }
            else if (data.COLUMN_NAME.ToLower() == "extendwidth")
            {
                dgc.DefaultCellStyle.NullValue = "0";
            }
            return dgc;
        }



        //public void GetConfigurationDataColumn(DataGridView source, string columns)
        //{
        //    var lst = new List<ColumnAttributes>();

        //    var t = columns.Split(';');

        //    foreach (var x in t)
        //    {
        //        var cA = new ColumnAttributes();
        //        var p = x.Split(':');

        //        if (p.Length == 2)
        //        {
        //            cA.AttributeName = p[0];
        //            cA.ColumnType = p[1];
        //            lst.Add(cA);
        //        }
        //    }

        //    AssignDataGridColumn(source, lst);
        //}

        //public void PopulateSetting(string fileName, List<DataGridView> source)
        //{
        //    StreamReader file = new StreamReader(fileName);
        //    isSetting = true;
        //    string newLine;
        //    List<string> columns = new List<string>();
        //    List<string> lstData = new List<string>();
        //    int i = 0;

        //    while ((newLine = file.ReadLine()) != null)
        //    {
        //        if (newLine != "") {
        //            newLine = newLine.Remove(newLine.LastIndexOf(","));
        //            lstData.Add(newLine);
        //        }
        //    }

        //    DataGridView grid = null;
        //    foreach(var s in lstData)
        //    {
        //        if (s.Substring(0,2) == "id")
        //        {
        //            columns.Clear();
        //            var cols = s.Split(',');
        //            columns.AddRange(cols);

        //            //column
        //            grid = source[i];
        //            i += 1;
        //        }
        //        else
        //        {
        //            //data
        //            var data = s.Split(',');
        //            int newId = grid.Rows.Add();

        //            for (int j = 0; j <= columns.Count - 1; j++)
        //            {
        //                grid.Rows[newId].Cells[columns[j]].Value = data[j];
        //            }
        //        }
        //    }

        //    isSetting = false;  
        //}



        public void AssignIntoDataGridView(DataGridView source, string data)
        {
            var splitData = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            var lstDataAttributes = new List<DataAttributes>();

            foreach (var s in splitData)
            {
                if (s != "")
                {
                    var reSplit = s.Split('\t');

                    var x = new DataAttributes();

                    if (reSplit.Length == 2)
                    {
                        x.DisplayName = reSplit[0];
                        x.AttributeName = reSplit[1];
                        x.Description = reSplit[0];
                        lstDataAttributes.Add(x);
                    }
                }
            }

            foreach (var row in lstDataAttributes)
            {
                var rowIndex = source.Rows.Add();
                var t = source.Rows[rowIndex];

                t.Cells["attributename"].Value = row.AttributeName;
                t.Cells["displayname"].Value = row.DisplayName;
                t.Cells["description"].Value = row.Description;
                t.DefaultCellStyle.ForeColor = Const.NEW_ROW_FORECOLOR;
            }
        }

        public void AssignIntoDropDownGridView(DataGridView source, string data)
        {
            var splitData = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            int oldId = source.SelectedCells[0].RowIndex;

            foreach(var s in splitData)
            {
                var newId = oldId + 1;

                source.Rows.InsertCopy(oldId, newId);
                var oldRow = source.Rows[oldId];
                var newRow = source.Rows[newId];
               
                newRow.Cells["attributename"].Value = oldRow.Cells["attributename"].Value;
                newRow.Cells["attributeid"].Value = oldRow.Cells["attributeid"].Value;
                newRow.Cells["targetid"].Value = oldRow.Cells["targetid"].Value;
                newRow.Cells["attributevalue"].Value = s;
                newRow.Cells["attributetext"].Value = s;
                oldId = newId;
            }
            source.Rows.RemoveAt(source.SelectedCells[0].RowIndex);
            ResetColumnId(source);
        }

        public void DeleteRowFromDataGridView(DataGridView source, DataGridView target)
        {
            int i = -1;
            if (source.SelectedRows.Count != 0)
            {
                var currRow = source.SelectedRows[0];

                var currentId = 0; 

                if (source.Columns.Contains("id"))
                {
                    currentId = Convert.ToInt32(currRow.Cells["id"].EditedFormattedValue.ToString());
                }

                var attributeId = "";

                if (source.Columns.Contains("targetid"))
                {
                    attributeId = currRow.Cells["targetid"].EditedFormattedValue.ToString();
                }

                if (target != null)
                {
                    List<DataGridViewRow> lstDropDown = new List<DataGridViewRow>();

                    foreach (DataGridViewRow row in target.Rows)
                    {
                        if (attributeId == row.Cells["targetid"].EditedFormattedValue.ToString())
                        {
                            lstDropDown.Add(row);
                        }
                    }

                    foreach (var x in lstDropDown)
                    {
                        target.Rows.Remove(x);
                    }

                    ResetColumnId(target);

                    foreach (DataGridViewRow row in target.Rows)
                    {
                        if (target.Columns.Contains("targetid"))
                        {
                            if (Convert.ToInt32(row.Cells["targetid"].EditedFormattedValue) > currentId)
                            {
                                row.Cells["targetid"].Value = Convert.ToInt32(row.Cells["targetid"].Value) - 1;
                            }

                        }

                    }
                }

                foreach (DataGridViewRow row in source.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        var s = row.Index;

                        if (s < i || i == -1)
                        {
                            i = s;
                        }
                        
                        foreach(DataGridViewRow c in target.Rows)
                        {
                            if (c.Cells["targetid"].EditedFormattedValue.ToString() == row.Cells["id"].EditedFormattedValue.ToString())
                            {
                                target.Rows.Remove(c);
                            }
                        }
                        source.Rows.RemoveAt(s);
                    }
                }

                ResetColumnId(source);
            }
        }

        public string DeleteRowFromDropDownView(DataGridView source)
        {
            string msg = "Cannot delete selected row, at least 1 row needed for dropdown";
            int i = 0;

            if (source.SelectedRows.Count > 0)
            {
                var selectedRow = source.SelectedRows[0];
                var currentId = selectedRow.Cells["targetid"].EditedFormattedValue.ToString();

                foreach (DataGridViewRow row in source.Rows)
                {
                    if (row.Cells["targetid"].EditedFormattedValue.ToString() == currentId)
                    {
                        i += 1;
                    }
                }

                if (i > 1)
                {
                    source.Rows.RemoveAt(selectedRow.Index);
                    msg = "";
                    ResetColumnId(source);
                }
            }

            return msg;
        }

        public void UserAddedRowsNo(DataGridView source, DataGridViewRowEventArgs e)
        {
            source.SuspendLayout();

            var currRow = source.Rows[e.Row.Index];

            ResetColumnId(source);
            ColorGridAsNew(source.Rows[e.Row.Index - 1]);
            source.ResumeLayout();
        }

        public void RowsAdded(DataGridView source, DataGridViewRowsAddedEventArgs e, DataGridView target = null)
        {
            source.SuspendLayout();
            var currRow = source.Rows[e.RowIndex];
            var currNo = e.RowIndex + 1;

            if (currRow.IsNewRow)
            {
                if (source.Columns.Contains("id"))
                {
                    currRow.Cells["id"].Value = 0;
                }
                
                if (source.Name == EnumAttributes.TableName.tbl_action_status_mapping_AIB.ToString())
                {
                    if (source.Columns.Contains("wicode"))
                    {
                        if (target.Rows.Count != 0)
                        {
                            currRow.Cells["wicode"].Value = target.Rows[0].Cells["wicode"].Value;
                        }

                    }
                }

            }
            else
            {
                if (currRow.Cells.Count > 1)
                {
                    if (source.Columns.Contains("id"))
                    {
                        currRow.Cells["id"].Value = currNo;
                    }

                    if (source.Columns.Contains("screenorder"))
                    {
                        currRow.Cells["screenorder"].Value = currNo;
                    }
                }
            }

            source.ResumeLayout();
        }

       
       
        public void InsertDataDropDownFromData(DataGridView source, DataGridView target, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_isSetting == false)
                {
                    if (e.ColumnIndex > -1)
                    {
                        var currRow = source.Rows[e.RowIndex];
                        var currCol = source.Columns[e.ColumnIndex];

                        if (currCol.Name == "control")
                        {
                            if (source.SelectedCells.Count > 0)
                            {
                                AddFromDataToDropDown(currRow, currCol, target);
                            }
                            else
                            {
                                foreach (DataGridViewRow row in source.Rows)
                                {
                                    AddFromDataToDropDown(row, currCol, target);
                                }
                            }
                            
                        }
                        else if (currCol.Name == "attributename")
                        {
                            var id = currRow.Cells["id"].EditedFormattedValue.ToString();
                            var attributeName = currRow.Cells["attributename"].EditedFormattedValue.ToString();
                            var controlType = currRow.Cells["control"].EditedFormattedValue.ToString();

                            if (controlType == "DropDown")
                            {
                                foreach (DataGridViewRow row in target.Rows)
                                {
                                    if (row.Cells["targetid"].EditedFormattedValue.ToString() == id)
                                    {
                                        row.Cells["attributename"].Value = attributeName;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        public void FormatGridStyle(DataGridView source)
        {
            var currCell = source.SelectedCells[0];

            if (source.Rows[currCell.RowIndex].DefaultCellStyle.ForeColor != Const.NEW_ROW_FORECOLOR){ 
                if (currCell.EditedFormattedValue.ToString() != currCell.ToolTipText)
                {
                    //source.Rows[currCell.RowIndex].Cells[0].Style.ForeColor = Const.UPD_ROW_FORECOLOR;
                    currCell.Style.ForeColor = Const.UPD_ROW_FORECOLOR;
                }
                else
                {
                    //source.Rows[currCell.RowIndex].Cells[0].Style.ForeColor = Const.DEF_ROW_FORECOLOR;
                    currCell.Style.ForeColor = Const.DEF_ROW_FORECOLOR;
                }
            }
            else
            {
                currCell.Style.Font = source.Font;
            }
        }

        public void UpdateResponseMapping(DataGridView source, DataGridView target, DataGridViewCellEventArgs e)
        {
            foreach(DataGridViewRow row in target.Rows)
            {
                row.Cells["wicode"].Value = source.Rows[0].Cells["wicode"].EditedFormattedValue;
            }
        }

        //public void ResetDataDropDown(DataGridView source, DataGridView target, DataGridViewRowsRemovedEventArgs e)
        //{
        //    //if (e.RowIndex != 0)
        //    //{
        //    //    var grid = source.Rows[e.RowIndex];
        //    //    bool isDeleted = false;
        //    //    var currentId = grid.Cells["id"].EditedFormattedValue.ToString();
        //    //    foreach (DataGridViewRow row in target.Rows)
        //    //    {
        //    //        if (row.Cells["attributeid"].EditedFormattedValue.ToString() == (_attributeId + currentId))
        //    //        {
        //    //            target.Rows.RemoveAt(row.Index - 1);
        //    //            isDeleted = true;
        //    //        }
        //    //    }

        //    //    if (isDeleted)
        //    //    {
        //    //        int i = 1;
        //    //        foreach (DataGridViewRow row in target.Rows)
        //    //        {
        //    //            row.Cells["id"].Value = i;
        //    //            //row.Cells["attributeid"].Value = sqlAttributeId + (row.Index + 1);
        //    //            i += 1;
        //    //        }
        //    //    }
        //    //}
        //}

        public void InsertNewDataDropDown(DataGridView source)
        {
            var selectedRow = source.SelectedRows[0];
            var newRow = selectedRow.Index + 1;

            source.Rows.InsertCopy(selectedRow.Index, newRow);
            source.Rows[newRow].Cells["attributeid"].Value = selectedRow.Cells["attributeid"].EditedFormattedValue.ToString();
            source.Rows[newRow].Cells["attributename"].Value = selectedRow.Cells["attributename"].EditedFormattedValue.ToString();
            source.Rows[newRow].Cells["targetid"].Value = selectedRow.Cells["targetid"].EditedFormattedValue.ToString();
            source.Rows[newRow].DefaultCellStyle.ForeColor = Const.NEW_ROW_FORECOLOR;
            ResetColumnId(source);
        }
        #endregion


        #region "Private"

        private void ResetColumnId(DataGridView source)
        {
            int i = 1;
            foreach (DataGridViewRow s in source.Rows)
            {
                if (!s.IsNewRow)
                {
                    if (source.Columns.Contains("id")) { 
                        s.Cells["id"].Value = i;
                    }

                    if (source.Columns.Contains("screenorder"))
                    {
                        s.Cells["screenorder"].Value = i;
                    }

                    i += 1;
                }
            }
        }
        
        private void AddToDropDownGridView(DataGridView target, DataGridViewRow row, string dataId = "")
        {
            var newRowIndex = target.Rows.Add();
            var newRow = target.Rows[newRowIndex];

            newRow.Cells["id"].Value = target.Rows.Count;
            newRow.Cells["taskcodeid"].Value = _taskCodeId;
            newRow.Cells["attributeid"].Value = _attributeId;  //dataId;
            newRow.Cells["attributename"].Value = row.Cells["attributename"].Value;
            newRow.Cells["targetid"].Value = row.Cells["id"].Value;
            newRow.DefaultCellStyle.ForeColor = Const.NEW_ROW_FORECOLOR;
        }


        private void ColorGridAsNew(DataGridViewRow row)
        {
            if (!row.IsNewRow)
            {
                row.DefaultCellStyle.ForeColor = Const.NEW_ROW_FORECOLOR;
            }
          
        }

        private void AddFromDataToDropDown(DataGridViewRow row, DataGridViewColumn currCol, DataGridView target)
        {
            List<string> lstCurrentId = new List<string>();

            var dataId = row.Cells[0].EditedFormattedValue.ToString();

            if (row.Cells[currCol.Name].EditedFormattedValue.ToString() == "DropDown" && row.Cells["id"].EditedFormattedValue.ToString() != "0")
            {
                if (target.Rows.Count > 0)
                {
                    foreach (DataGridViewRow s in target.Rows)
                    {
                        lstCurrentId.Add(s.Cells["targetid"].EditedFormattedValue.ToString());
                    }

                    if (!lstCurrentId.Contains(dataId))
                    {
                        AddToDropDownGridView(target, row);
                    }
                }
                else
                {
                    AddToDropDownGridView(target, row);
                }
            }
            else
            {
                List<DataGridViewRow> lstDropDown = new List<DataGridViewRow>();

                foreach (DataGridViewRow s in target.Rows)
                {
                    if (dataId.ToString() == s.Cells["targetid"].EditedFormattedValue.ToString())
                    {
                        lstDropDown.Add(s);
                    }
                }

                foreach (var x in lstDropDown)
                {
                    target.Rows.Remove(x);
                }

                ResetColumnId(target);
            }
        }
        #endregion
    }
}
