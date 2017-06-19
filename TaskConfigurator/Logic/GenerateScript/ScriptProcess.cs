using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TaskConfigurator.Entity;

namespace TaskConfigurator.Logic.GenerateScript
{
    class ScriptProcess
    {
        #region "GenerateScript"
        public StringBuilder ScriptForDesc(StringBuilder script, DataGridViewRow row, string wiCode, string system)
        {
            script = ScriptForCommonAttributes(script, system);
            script.AppendFormat("IF (NOT EXISTS(SELECT 1 FROM {0} WHERE WiCode='{1}' AND systemname='{2}'))"
                , EnumAttributes.TableName.tbl_task_configuration_desc.ToString()
                , wiCode
                , system
            );

            return script;
        }

        public StringBuilder ScriptForData(StringBuilder script, DataGridViewRow row, bool isOnce, string wiCode, string system, out bool outOnce)
        {
            outOnce = false;
            if (isOnce)
            {
                script.AppendLine("DECLARE @taskcodeid INT");
                script.AppendFormat("SELECT @taskcodeid = id FROM {0} WHERE WiCode='{1}' AND systemname='{2}'"
                    , EnumAttributes.TableName.tbl_task_configuration_desc.ToString()
                    , wiCode
                    , system
                );
                
                script = ScriptForCommonAttributes(script, system);
                outOnce = false;
            }
            script.AppendFormat("IF (NOT EXISTS(SELECT 1 FROM {0} WHERE TaskCodeId={1} AND AttributeName='{2}' ))"
                , EnumAttributes.TableName.tbl_task_configuration_data.ToString()
                , row.Cells["taskcodeid"].EditedFormattedValue
                , row.Cells["attributename"].EditedFormattedValue.ToString().Replace("'", "''"));

            return script;
        }

        public StringBuilder ScriptForDropDown(StringBuilder script, DataGridViewRow row, bool isOnce, string previousDropDown, string wiCode, string system, out bool outOnce)
        {
            outOnce = false;
            if (isOnce)
            {
                script.AppendLine("DECLARE @taskcodeid INT");
                script.AppendFormat("DECLARE @attributeid VARCHAR(50)");
                script.AppendLine();
                script.AppendFormat("SELECT @taskcodeid = id FROM tbl_task_configuration_desc WHERE WiCode='{0}' AND systemname='{1}'", wiCode, system);
                script = ScriptForCommonAttributes(script, system);
                outOnce = false;
            }

            if (previousDropDown != row.Cells["attributename"].EditedFormattedValue.ToString())
            {
                script.AppendLine("---------------------------------------*" + row.Cells["attributename"].EditedFormattedValue + "*---------------------------------------------------------------");
                script.AppendFormat("SELECT {0} = id FROM {1} WHERE TaskCodeId={2} AND AttributeName='{3}'"
                    , "@attributeid"
                    , EnumAttributes.TableName.tbl_task_configuration_data.ToString()
                    , row.Cells["taskcodeid"].EditedFormattedValue
                    , row.Cells["attributename"].EditedFormattedValue
                );
                previousDropDown = row.Cells["attributename"].EditedFormattedValue.ToString();
                script.AppendLine();
                script.AppendLine();
            }

            script.AppendFormat("IF (NOT EXISTS(SELECT 1 FROM {0} WHERE TaskCodeId={1} AND AttributeId={2} AND AttributeValue='{3}'))"
               , EnumAttributes.TableName.tbl_task_configuration_data_dropdown.ToString()
               , row.Cells["taskcodeid"].EditedFormattedValue
               , row.Cells["attributeid"].EditedFormattedValue
               , row.Cells["attributevalue"].EditedFormattedValue.ToString().Replace("'", "''")
            );

            return script;
        }

        public StringBuilder ScriptForCntrl(StringBuilder script, DataGridViewRow row, bool isOnce, string wiCode, string system, out bool outOnce)
        {
            outOnce = false;
            if (isOnce)
            {
                script.AppendLine("DECLARE @taskcodeid INT");
                script.AppendFormat("SELECT @taskcodeid = id FROM {0} WHERE WiCode='{1}' AND systemname='{2}'"
                    , EnumAttributes.TableName.tbl_task_configuration_desc
                    , wiCode
                    , system
                );
                script = ScriptForCommonAttributes(script, system);
                outOnce = false;
            }
            script.AppendFormat("IF (NOT EXISTS(SELECT 1 FROM {0} WHERE TaskCodeId={1} AND Attribute='{2}' AND Value='{3}' ))"
                , EnumAttributes.TableName.tbl_task_configuration_cntrl.ToString()
                , row.Cells["taskcodeid"].EditedFormattedValue
                , row.Cells["attribute"].EditedFormattedValue
                , row.Cells["Value"].EditedFormattedValue.ToString().Replace("'", "''")
            );

            return script;
        }

        public StringBuilder ScriptForMapping(StringBuilder script, DataGridViewRow row, bool isOnce, string wiCode, string system, out bool outOnce)
        {
            outOnce = false;
            if (isOnce)
            {
                script.AppendLine("DECLARE @WiCode VARCHAR(50)");
                script.AppendFormat("SET @WiCode ='{0}'"
                    , wiCode
                );
                script = ScriptForCommonAttributes(script, system);
                outOnce = false;
            }
            script.AppendFormat("IF (NOT EXISTS(SELECT 1 FROM {0} WHERE WiCode=@WiCode AND TaskStatus='{1}' AND TaskAction='{2}' AND WiStatus='{3}' AND WiSubStatus='{4}' AND oiStatus='{5}' AND oiSubStatus='{6}'))"
                , EnumAttributes.TableName.tbl_action_status_mapping_AIB.ToString()
                , row.Cells["taskstatus"].EditedFormattedValue
                , row.Cells["taskaction"].EditedFormattedValue
                , row.Cells["wistatus"].EditedFormattedValue
                , row.Cells["wiSubStatus"].EditedFormattedValue
                , row.Cells["oistatus"].EditedFormattedValue
                , row.Cells["oisubstatus"].EditedFormattedValue
            );

            return script;
        }

        public StringBuilder ScriptForAttributes(StringBuilder script, DataGridViewRow row)
        {
            string controlType = "";
            script.AppendFormat("IF (NOT EXISTS(SELECT 1 FROM tbl_bto_l2c_attributes WHERE System='AIB HE L2C' AND Displayname='{0}'))"
                                    , row.Cells["attributename"].EditedFormattedValue.ToString().Replace("'", "''"));
            script.AppendLine();
            script.Append("BEGIN");
            script.AppendLine();

            if (row.Cells["Control"].EditedFormattedValue.ToString() != "Date")
                controlType = "VARCHAR";
            else
                controlType = "DATETIME";

            script.AppendFormat("INSERT INTO {0}({1}) VALUES({2})", "tbl_bto_l2c_attributes", "AttributeName,AttributeType,DisplayName,AttributeDataType,GroupID,SYSTEM",
                                "'" + row.Cells["attributename"].Value.ToString().Replace("'","''") + "'," + 64 + ",'" + row.Cells["attributename"].Value.ToString().Replace("'", "''") + "','" + controlType + "', 0,'AIB HE L2C'");
            script.AppendLine();
            script.Append("END");
            script.AppendLine();
            script.AppendLine();

            return script;
        }

        public StringBuilder ScriptForMain(StringBuilder script, DataGridViewRow row, bool isOnce, string wiCode, string system, out bool outOnce)
        {
            outOnce = false;
            if (isOnce)
            {
                script.AppendLine("DECLARE @WiCode VARCHAR(50)");
                script.AppendFormat("SET @WiCode ='{0}'"
                    , wiCode
                );
                script = ScriptForCommonAttributes(script, system);
                outOnce = false;
            }
            script.AppendFormat("IF (NOT EXISTS(SELECT 1 FROM {0} WHERE WiCode=@WiCode))"
                , EnumAttributes.TableName.tbl_task_configuration_main.ToString()
            );

            return script;
        }

        public StringBuilder ScriptForOrder(StringBuilder script, DataGridViewRow row, bool isOnce, string wiCode, string system, out bool outOnce)
        {
            outOnce = false;
            if (isOnce)
            {
                script.AppendLine("DECLARE @taskcodeid INT");
                script.AppendFormat("SELECT @taskcodeid = id FROM {0} WHERE WiCode='{1}' AND systemname='{2}'"
                    , EnumAttributes.TableName.tbl_task_configuration_desc.ToString()
                    , wiCode
                    , system
                );

                script = ScriptForCommonAttributes(script, system);
                outOnce = false;
            }
            script.AppendFormat("IF (NOT EXISTS(SELECT 1 FROM {0} WHERE TaskCodeId={1} AND AttributeName='{2}' ))"
                , EnumAttributes.TableName.tbl_aib_task_order_attribute_mapping.ToString()
                , row.Cells["taskcodeid"].EditedFormattedValue
                , row.Cells["attributename"].EditedFormattedValue.ToString().Replace("'", "''"));

            return script;
        }

        public string ScriptForUKBSPcodes(string wiCode)
        {
            var script = new StringBuilder();
            var tableName = "TBL_UKBS_PCODES";
            var sWicode = "'" + wiCode + "'";
            script.AppendLine("----------------------------------------" + tableName + "----------------------------------------------------------------");
            script.Append("USE [BB_INTERFACE]");
            script.AppendLine();
            script.Append("GO");
            script.AppendLine();
            script.AppendLine();
            script.AppendFormat("IF (NOT EXISTS(SELECT 1 FROM {0} WHERE Pcode={1} AND Tag='{2}'))", tableName, sWicode, "wicode");
            script.AppendLine();
            script.Append("BEGIN");
            script.AppendLine();
            script.AppendFormat("INSERT INTO {0}({1}) VALUES({2})", tableName, "Pcode, Tag, Product, new, WiTemplate", sWicode + ", 'wiCode', 'HE', '1'," + sWicode);
            script.AppendLine();
            script.Append("END");
            script.AppendLine();
            script.AppendLine();
            script.Append("GO");

            return script.ToString();
        }

        public string ScriptForAttributeValue(string wiCode, string system)
        {
            var script = new StringBuilder();

            var tableName = "tbl_AttributeValues";
            var parentTable = "tbl_AttributeNames";
            script.AppendLine("----------------------------------------" + tableName + "----------------------------------------------------------------");
            script.Append("USE [BB_INTERFACE]");
            script.AppendLine();
            script.Append("GO");
            script.AppendLine();
            script.AppendLine();
            script.AppendLine("DECLARE @ID INT");
            script.AppendFormat("SELECT @ID = ID FROM {0} WHERE SystemName='{1}' AND AttributeNm='{2}'", parentTable, system, "ddl:wicode");
            script.AppendLine();
            script.AppendLine();
            script.AppendFormat("IF (NOT EXISTS(SELECT 1 FROM {0} WHERE AttributeValue='{1}' AND Attribute_ID= @ID))", tableName, wiCode);
            script.AppendLine();
            script.Append("BEGIN");
            script.AppendLine();
            script.AppendFormat("INSERT INTO {0}({1}) VALUES({2})", tableName, "AttributeValue, Attribute_ID", "'" + wiCode + "',@ID");
            script.AppendLine();
            script.Append("END");
            script.AppendLine();
            script.AppendLine();
            script.Append("GO");

            return script.ToString();
        }

        public string ScriptForRollback(string wiCode, string system)
        {
            var script = new StringBuilder();

            script.AppendLine("USE [BB_INTERFACE]");
            script.AppendLine("GO");
            script.AppendLine();

            script.AppendLine("DECLARE @id INT");
            script.AppendLine("DECLARE @WiCode VARCHAR(50)");
            script.AppendLine("DECLARE @AttributeId INT");
            script.AppendLine();
            script.AppendFormat("SELECT @id = ID, @WiCode = WiCode FROM {0} WHERE WiCode='{1}' AND systemname='{2}'", EnumAttributes.TableName.tbl_task_configuration_desc.ToString(), wiCode, system);
            script.AppendLine();
            script.AppendFormat("SELECT @AttributeId = id FROM {0} WHERE AttributeNm='{1}' AND SystemName='{2}'", EnumAttributes.TableName.tbl_AttributeNames.ToString(), "ddl:wicode", system);
            script.AppendLine();
            script.AppendFormat("DELETE FROM {0} WHERE Pcode=@WiCode AND Product='HE'", EnumAttributes.TableName.tbl_ukbs_Pcodes.ToString());
            script.AppendLine();
            script.AppendFormat("DELETE FROM {0} WHERE WiCode=@WiCode", EnumAttributes.TableName.tbl_action_status_mapping_AIB.ToString());
            script.AppendLine();
            script.AppendFormat("DELETE FROM {0} WHERE TaskCodeId=@id", EnumAttributes.TableName.tbl_task_configuration_cntrl.ToString());
            script.AppendLine();
            script.AppendFormat("DELETE FROM {0} WHERE TaskCodeId=@id", EnumAttributes.TableName.tbl_task_configuration_data_dropdown.ToString());
            script.AppendLine();
            script.AppendFormat("DELETE FROM {0} WHERE TaskCodeId=@id", EnumAttributes.TableName.tbl_task_configuration_data.ToString());
            script.AppendLine();
            script.AppendFormat("DELETE FROM {0} WHERE WiCode=@WiCode", EnumAttributes.TableName.tbl_task_configuration_desc.ToString());
            script.AppendLine();
            script.AppendFormat("DELETE FROM {0} WHERE AttributeValue='{1}' AND Attribute_ID=@AttributeId", EnumAttributes.TableName.tbl_AttributeValues.ToString(), wiCode);
            script.AppendLine();
            script.Append("GO");
            //testing 
            return script.ToString();
        }

        public StringBuilder ScriptForPatchUpdateAndInsert(IEnumerable<DataGridViewCell> cell, string wiCode, string system, bool isOnce, out bool outOnce)
        {
            var condition = cell.Where(x => x.InheritedStyle.BackColor == Color.LightBlue);
            var updated = cell.Where(x => x.InheritedStyle.ForeColor == Color.DarkBlue);
            var tempCond = new StringBuilder();
            var tempUpdate = new StringBuilder();
            var script = new StringBuilder();
            var values = "";

            outOnce = false;
            if (isOnce)
            {
                script.AppendLine("DECLARE @taskcodeid INT");
                script.AppendLine();
                script.AppendLine("DECLARE @lobid INT");
                script.AppendLine();
                script.AppendFormat("DECLARE @attributeid INT");
                script.AppendLine();
                script.AppendFormat("SELECT @taskcodeid = id FROM tbl_task_configuration_desc WHERE WiCode='{0}' AND systemname='{1}'", wiCode, system);
                script.AppendLine();
                script.AppendFormat("SET @lobid = (SELECT ID FROM NEPTUNE124.SIRESOURCE.DBO.SEC_LOB WITH(NOLOCK) WHERE LOBName = '{0}')", (system.ToLower() == "aib he l2c" || system.ToLower() == "neo he l2c" ? "HE L2C" : system));
                script.AppendLine();
                script.AppendLine();

                outOnce = false;
            }

            if (cell.Where(x => x.DataGridView.Name == EnumAttributes.TableName.tbl_task_configuration_data_dropdown.ToString()).Count() > 1)
            {
                script.AppendFormat("SET @attributeid = (SELECT ID FROM tbl_task_configuration_data WITH(NOLOCK) WHERE taskcodeid = {0} AND attributename='{1}')", "@taskcodeid", cell.Where(x => x.ColumnIndex == x.DataGridView.Columns["attributename"].Index).Select(x => x.Value).FirstOrDefault());
                script.AppendLine();
            }

            foreach (var s in updated)
            {
                if (s.ReadOnly || (s.EditedFormattedValue.ToString().Substring(0, 1) == "@" || s.EditedFormattedValue.ToString().ToLower().ToString() == "null"))
                {
                    values = s.EditedFormattedValue.ToString().Replace("'", "''") + ",";
                }
                else
                {
                    values = "'" + s.EditedFormattedValue.ToString().Replace("'", "''") + "',";
                }

                tempUpdate.AppendFormat("{0} = {1}", s.DataGridView.Columns[s.ColumnIndex].Name, values);
            }

            tempUpdate = tempUpdate.Remove(tempUpdate.Length - 1, 1);
            tempCond.AppendFormat("UPDATE {0} SET {1}", cell.FirstOrDefault().DataGridView.Name, tempUpdate);
            tempCond.Append(" WHERE ");

            foreach (var s in condition)
            {
                if (s.ReadOnly || (s.EditedFormattedValue.ToString().Substring(0, 1) == "@" || s.EditedFormattedValue.ToString().ToLower().ToString() == "null"))
                {
                    values = s.EditedFormattedValue.ToString().Replace("'", "''") + " AND ";
                }
                else
                {
                    values = "'" + s.ToolTipText.ToString().Replace("'", "''") + "' AND ";
                }

                tempCond.AppendFormat("{0} = {1}", s.DataGridView.Columns[s.ColumnIndex].Name, values);
            }
            tempCond = tempCond.Remove(tempCond.Length - 5, 5);
            tempCond.AppendLine();

            script.AppendLine(tempCond.ToString());
            return script;
        }

        public StringBuilder GenerateScriptText(DataGridViewRow row, StringBuilder script, bool isOnce, string wiCode, string system, out bool outOnce,  byte newAttr = 0)
        {
            string cols = "";
            string rowVal = "";
            string previousDropDown = "";
            outOnce = false;
            ScriptProcess sp = new ScriptProcess();

            if (row.IsNewRow == false)
            {
                if (row.Cells[0].InheritedStyle.ForeColor != Const.ERR_ROW_FORECOLOR)
                {
                    if (row.DataGridView.Name == EnumAttributes.TableName.tbl_task_configuration_desc.ToString())
                    {
                        script = sp.ScriptForDesc(script, row, wiCode, system);
                    }
                    else if (row.DataGridView.Name == EnumAttributes.TableName.tbl_task_configuration_data.ToString() && newAttr == 0)
                    {
                        script = sp.ScriptForData(script, row, isOnce, wiCode, system, out outOnce);
                        isOnce = outOnce;
                    }
                    else if (row.DataGridView.Name == EnumAttributes.TableName.tbl_task_configuration_data_dropdown.ToString())
                    {
                        script = sp.ScriptForDropDown(script, row, isOnce, previousDropDown, wiCode, system, out outOnce);
                        isOnce = outOnce;
                    }
                    else if (row.DataGridView.Name == EnumAttributes.TableName.tbl_task_configuration_cntrl.ToString())
                    {
                        script = sp.ScriptForCntrl(script, row, isOnce, wiCode, system, out outOnce);
                        isOnce = outOnce;
                    }
                    else if (row.DataGridView.Name == EnumAttributes.TableName.tbl_action_status_mapping_AIB.ToString())
                    {
                        script = sp.ScriptForMapping(script, row, isOnce, wiCode, system, out outOnce);
                        isOnce = outOnce;
                    }
                    else if (row.DataGridView.Name == EnumAttributes.TableName.tbl_task_configuration_data.ToString() && newAttr == 1)
                    {
                        script = sp.ScriptForAttributes(script, row);
                    }
                    else if (row.DataGridView.Name == EnumAttributes.TableName.tbl_task_configuration_main.ToString())
                    {
                        script = sp.ScriptForMain(script, row, isOnce, wiCode, system, out outOnce);
                        isOnce = outOnce;
                    }
                    else if (row.DataGridView.Name == EnumAttributes.TableName.tbl_aib_task_order_attribute_mapping.ToString())
                    {
                        script = sp.ScriptForOrder(script, row, isOnce, wiCode, system, out outOnce);
                        isOnce = outOnce;
                    }

                    if (newAttr != 1)
                    {
                        script.AppendLine();
                        script.Append("BEGIN");
                        script.AppendLine();
                        ReturnListOfRowsValue(row, row.DataGridView.Columns, out cols, out rowVal);
                        script.AppendFormat("INSERT INTO {0}({1}) VALUES({2})", row.DataGridView.Name, cols, rowVal);
                        script.AppendLine();
                        script.Append("END");
                        script.AppendLine();
                        script.AppendLine();
                    }

                }
                else
                {
                    outOnce = isOnce;
                }

            }
            else
            {
                if (row.DataGridView.Rows.Count == 1)
                {
                    script.Clear();
                }
            }

            return script;
        }

        private StringBuilder ScriptForCommonAttributes(StringBuilder script, string system)
        {
            script.AppendLine();
            script.AppendLine("DECLARE @modifydate DATETIME");
            script.AppendLine("DECLARE @ein INT");
            script.AppendLine("DECLARE @lobid INT");
            script.AppendLine();
            script.AppendLine("SET @modifydate = GETDATE()");
            script.AppendFormat("SET @ein = {0}", System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(6));
            script.AppendLine();
            script.AppendFormat("SET @lobid = (SELECT ID FROM NEPTUNE124.SIRESOURCE.DBO.SEC_LOB WITH(NOLOCK) WHERE LOBName = '{0}')", (system.ToLower() == "aib he l2c" || system.ToLower() == "neo he l2c" ? "HE L2C" : system));
            script.AppendLine();
            script.AppendLine();
            return script;
        }

        private void ReturnListOfRowsValue(DataGridViewRow row, DataGridViewColumnCollection columns, out string colsVal, out string rowVal)
        {
            var values = "";
            var cols = "";
            List<int> colUsed = new List<int>();
            string include = Properties.Resources.include;

            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.ReadOnly == false || (cell.ReadOnly && include.ToLower().Split(';').Where(x => x.ToString() == columns[cell.ColumnIndex].Name).Any()))
                {
                    if (cell.EditedFormattedValue.ToString().Trim() != "")
                    {
                        if (cell.ReadOnly && (cell.EditedFormattedValue.ToString().Substring(0, 1) == "@" || cell.EditedFormattedValue.ToString().ToLower().ToString() == "null"))
                        {
                            values += cell.EditedFormattedValue.ToString().Replace("'", "''") + ",";
                        }
                        else
                        {
                            values += "'" + cell.EditedFormattedValue.ToString().Replace("'", "''") + "',";
                        }

                        colUsed.Add(cell.ColumnIndex);
                    }
                }
            }
            rowVal = values.Remove(values.Length - 1);

            foreach (DataGridViewColumn col in columns)
            {
                if (colUsed.Contains(col.Index))
                {
                    cols += "[" + col.Name + "],";
                }
            }

            colsVal = cols.Remove(cols.Length - 1);
        }
        #endregion
    }
}
