using System.Windows.Forms;
using TaskConfigurator.Entity;

namespace TaskConfigurator.Logic.GenerateGridView
{
    class GridviewKeyEvent
    {
        public string CommonKeyDownEvent(DataGridView source, KeyEventArgs e, DataGridView target = null)
        {
            DataGridViewLogic dl = new DataGridViewLogic();

            string msg = "";
            if (e.KeyCode == Keys.V && e.Control && source.Name == EnumAttributes.TableName.tbl_task_configuration_data.ToString())
            {
                var s = Clipboard.GetText();
                dl.AssignIntoDataGridView(source, s);
            }
            else if (e.KeyCode == Keys.V && e.Control && source.Name == EnumAttributes.TableName.tbl_task_configuration_data_dropdown.ToString())
            {
                var s = Clipboard.GetText();
                dl.AssignIntoDropDownGridView(source, s);

            }
            else if (e.KeyCode == Keys.Delete && source.Name != EnumAttributes.TableName.tbl_task_configuration_data_dropdown.ToString())
            {
                dl.DeleteRowFromDataGridView(source, target);
            }
            else if (e.KeyCode == Keys.Delete && source.Name == EnumAttributes.TableName.tbl_task_configuration_data_dropdown.ToString())
            {
                msg = dl.DeleteRowFromDropDownView(source);
            }
            return msg;
        }

        public void CommonMouseClickEvent(DataGridView source, DataGridViewCellMouseEventArgs e, ContextMenuStrip cms = null)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex > -1)
                {
                    cms.Show(Cursor.Position);
                    source.ClearSelection();
                    source.Rows[e.RowIndex].Selected = true;
                }

            }
        }

        public void ColumnDoubleClick(DataGridView source, DataGridViewCellMouseEventArgs e)
        {
            if (source.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in source.SelectedRows)
                {
                    SwitchValueForDropDown(row, e);
                }
            }
            else
            {
                foreach (DataGridViewRow row in source.Rows)
                {
                    SwitchValueForDropDown(row, e);
                }
            }
        }

        private void SwitchValueForDropDown(DataGridViewRow row, DataGridViewCellMouseEventArgs e)
        {
            var currCol = row.Cells[e.ColumnIndex];

            if (currCol is DataGridViewComboBoxCell)
            {
                var s = ((DataGridViewComboBoxCell)currCol).Items;
                var total = s.Count;

                for (var i = 0; i <= total - 1; i++)
                {
                    if (currCol.EditedFormattedValue.ToString() == s[i].ToString())
                    {
                        if ((i + 1) < total)
                        {
                            currCol.Value = s[i + 1];
                            if (currCol.EditedFormattedValue.ToString() != currCol.ToolTipText)
                            {
                                currCol.Style.ForeColor = Const.UPD_ROW_FORECOLOR;
                            }
                            else
                            {
                                currCol.Style.ForeColor = Const.DEF_ROW_FORECOLOR;
                            }
   
                            break;
                        }
                        else
                        {
                            currCol.Value = s[0];
                            if (currCol.EditedFormattedValue.ToString() != currCol.ToolTipText)
                            {
                                currCol.Style.ForeColor = Const.UPD_ROW_FORECOLOR;
                            }
                            else
                            {
                                currCol.Style.ForeColor = Const.DEF_ROW_FORECOLOR;
                            }
                        }
                    }
                }
            }
        }
    }
}
