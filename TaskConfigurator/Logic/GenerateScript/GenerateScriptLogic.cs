using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TaskConfigurator.Entity;
using TaskConfigurator.Logic.GenerateScript;

namespace TaskConfigurator.Logic
{
    class GenerateScriptLogic
    {
        private string _wiCode = "";
        private string _system = "";
        private ScriptProcess sp = new ScriptProcess();
        private ScriptWriter sw = new ScriptWriter();

        #region "Public"
        public bool GenerateInsertCheckScript(List<DataGridView> dgv, bool isSingle, string wiCode, string systemName, BackgroundWorker bgw)
        {
            _wiCode = wiCode;
            _system = systemName;

            bool flag = (isSingle ? GenerateSingleCommonFile(dgv, bgw) : GenerateMultiCommonFile(dgv, bgw));
            flag = GenerateLatestInsertAndUpdate(dgv, bgw);

            return flag;
        }

        #endregion

        #region "Private"

        private bool GenerateMultiCommonFile(List<DataGridView> dgv, BackgroundWorker bgw)
        {
            int i = 1;
            var isFinished = false;
            var csv = "";

            foreach (var grid in dgv)
            {
                var script = GenerateCommonScript(grid, bgw);
                if (script.ToString() != "")
                {
                    isFinished = sw.GenerateScriptFiles(grid.Name, script, i, EnumAttributes.MethodType.INSERT.ToString(), _wiCode);
                    if (grid.Name == EnumAttributes.TableName.tbl_task_configuration_data.ToString())
                    {
                        script = GenerateCommonScript(grid, bgw, 1);
                        isFinished = sw.GenerateScriptFiles("tbl_bto_l2c_attributes", script, i, EnumAttributes.MethodType.INSERT.ToString(), _wiCode);

                    }
                }
                csv+= sw.GenerateCSVSetting(grid);
                i += 1;
            }
            sw.GenerateScriptFiles("TBL_UKBS_PCODES", sp.ScriptForUKBSPcodes(_wiCode), 0, EnumAttributes.MethodType.INSERT.ToString(), _wiCode);
            sw.GenerateScriptFiles("tbl_AttributeValues", sp.ScriptForAttributeValue(_wiCode, _system), 98, EnumAttributes.MethodType.INSERT.ToString(), _wiCode);
            sw.GenerateScriptFiles("Configuration", sp.ScriptForRollback(_wiCode, _system), 99, EnumAttributes.MethodType.ROLLBACK.ToString(), _wiCode);
            isFinished =  sw.GenerateCSVFiles(csv, _wiCode);
           
            return isFinished;
        }

        private bool GenerateSingleCommonFile(List<DataGridView> dgv, BackgroundWorker bgw)
        {
            int i = 1;
            var isFinished = false;
            var script = "";
            var csv = "";

            foreach (var grid in dgv)
            {
                script += Environment.NewLine + Environment.NewLine + GenerateCommonScript(grid, bgw);
                if (script.ToString() != "")
                {
                    if (grid.Name == EnumAttributes.TableName.tbl_task_configuration_data.ToString())
                    {
                        script += Environment.NewLine + Environment.NewLine + GenerateCommonScript(grid, bgw, 1);

                    }
                }
                csv+= sw.GenerateCSVSetting(grid);
            }
            script += Environment.NewLine + Environment.NewLine + sp.ScriptForUKBSPcodes(_wiCode);
            script += Environment.NewLine + Environment.NewLine + sp.ScriptForAttributeValue(_wiCode, _system);
            isFinished = sw.GenerateScriptFiles("Bulk", script, i, EnumAttributes.MethodType.INSERT.ToString(), _wiCode);

            sw.GenerateScriptFiles("Configuration", sp.ScriptForRollback(_wiCode, _system), 99, EnumAttributes.MethodType.ROLLBACK.ToString(), _wiCode);
            isFinished = sw.GenerateCSVFiles(csv, _wiCode);
            return isFinished;
        }
        
        private string GenerateCommonScript(DataGridView dgv, BackgroundWorker bgw, byte newAttr = 0)
        {
            var script = new StringBuilder();
            bool isOnce = true;
            bool outOnce = true;
            int minCount = 1;
            int maxCount = dgv.Rows.Count;
            string tableName = dgv.Name;

            if (newAttr == 1)
            {
                tableName = "tbl_bto_l2c_attributes";
            }

            script.AppendLine("----------------------------------------"+ tableName + "----------------------------------------------------------------");
            script.Append("USE [BB_INTERFACE]");
            script.AppendLine();
            script.Append("GO");
            script.AppendLine();
            script.AppendLine();

            if (dgv.Rows.Count != 0)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    script = sp.GenerateScriptText(row, script, isOnce, _wiCode, _system, out outOnce, newAttr);
                    isOnce = outOnce;
                    double c = (Convert.ToDouble(minCount) / Convert.ToDouble(maxCount)) * 100;
                    bgw.ReportProgress(Convert.ToInt32(c), new string[] { "Generating script for... " + dgv.Name });
                    minCount += 1;
                }
            }
            else
            {
                script.Clear();
            }

            if (script.ToString() != "")
            {
                isOnce = true;
                script.Append("GO");
            }
            return script.ToString();
        }

        private bool GenerateLatestInsertAndUpdate(List<DataGridView> dgvs, BackgroundWorker bgw)
        {   
            var updateScript = new StringBuilder();
            var insertScript = new StringBuilder();
            var script = new StringBuilder();
            var isUpdate = false;
            var isInsert = false;

            script.Append("USE [BB_INTERFACE]");
            script.AppendLine();
            script.Append("GO");
            script.AppendLine();
            script.AppendLine();

            foreach (DataGridView dgv in dgvs)
            {
                bool upOnceIn = true;
                bool inOnceIn = true;
                bool upOnceOut = true;
                bool inOnceOut = true;

                if (dgv.Rows.Count != 0)
                {
                    var temp = dgv.Rows.Cast<DataGridViewRow>().Where(x => x.HasDefaultCellStyle).ToList();

                    if (temp.Count > 0 && temp.Count != dgv.Rows.Count)
                    {
                        updateScript.Append(script.ToString());
                        insertScript.Append(script.ToString());
                        foreach (var data in temp)
                        {
                            var cell = data.Cells.Cast<DataGridViewCell>();
                         
                            if (cell.Where(x => x.InheritedStyle.ForeColor == Const.NEW_ROW_FORECOLOR).Count() > 0)
                            {
                                insertScript = sp.GenerateScriptText(data, insertScript, inOnceIn, _wiCode, _system, out inOnceOut, 0);

                                if (dgv.Name == EnumAttributes.TableName.tbl_task_configuration_data.ToString())
                                {
                                    insertScript = sp.GenerateScriptText(data, insertScript, inOnceIn, _wiCode, _system, out inOnceOut, 1);
                                }
                                inOnceIn = inOnceOut;
                                isInsert = true;
                            }
                            else if (cell.Where(x => x.Style.ForeColor == Const.UPD_ROW_FORECOLOR).Count() > 0)
                            {
                                updateScript.Append(sp.ScriptForPatchUpdateAndInsert(cell, _wiCode, _system, upOnceIn, out upOnceOut));
                                upOnceIn = upOnceOut;
                                isUpdate = true;
                            }
                            //if (cell.Where(x => x.Style.ForeColor == Const.NEW_ROW_FORECOLOR).Count() < 0 && cell.Where(x => x.Style.ForeColor == Const.UPD_ROW_FORECOLOR).Count() > 0)
                            //{
                                
                               
                            //}
                            //else
                            //{
                               
                            //}
                        }

                        
                        insertScript.AppendLine("GO");
                        updateScript.AppendLine("GO");

                        if (isInsert == false)
                        {
                            insertScript.Clear();
                        }

                        if (isUpdate == false)
                        {
                            updateScript.Clear();
                        }
                    }
                }
            }

            insertScript.AppendLine(updateScript.ToString());

            if (!string.IsNullOrEmpty(insertScript.ToString().Trim()))
            {
                sw.GeneratePatchFiles(insertScript.ToString(), Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")), EnumAttributes.MethodType.PATCH.ToString(), _wiCode);
            }
            return true;
        }

        #endregion
    }
}

