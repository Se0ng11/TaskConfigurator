using AppConfigSE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using TaskConfigurator.Entity;

namespace TaskConfigurator.Logic.GenerateScript
{
    class ScriptWriter
    {
        private string SettingFolder = Directory.GetCurrentDirectory() + "\\Settings\\Columns\\";
        private string ScriptFolder = Directory.GetCurrentDirectory() + "\\Scripts\\";
        public bool GenerateScriptFiles(string table, string text, long i, string method, string wiCode)
        {
            bool flag = true;

            try
            {
                var folder = ScriptFolder + wiCode + "\\" + DateTime.Now.ToString("ddMMyyyy");
                var filesName = folder + "\\" + (i < 9 ? "0" : "") + i + ".[TABLE][" + method + "][" + wiCode + "][" + table + "].sql";

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                File.WriteAllText(filesName, text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }

            return flag;
        }

        public bool GeneratePatchFiles(string text, long i, string method, string wiCode)
        {
            bool flag = true;

            try
            {
                var folder = ScriptFolder + wiCode + "\\PATCH";
                var filesName = folder + "\\[" + (i < 9 ? "0" : "") + i + "][TABLE][" + method + "][" + wiCode + "].sql";

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                File.WriteAllText(filesName, text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }

            return flag;
        }

        public bool GenerateCSVFiles(string text, string wiCode)
        {
            bool flag = true;
            try
            {
                var folder = ScriptFolder + wiCode + "\\" + DateTime.Now.ToString("ddMMyyyy");
                string filesName = folder + "\\" + wiCode + ".csv";

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                File.WriteAllText(filesName, text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }

            return flag;
        }


        public string GenerateCSVSetting(DataGridView source)
        {
            var csv = "";
            csv = source.Name;
            csv += "\r\n";
            foreach (DataGridViewColumn column in source.Columns)
            {
                csv += column.HeaderText + ',';
            }

            csv += "\r\n";

            foreach (DataGridViewRow row in source.Rows)
            {
                if (row.IsNewRow == false)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        csv += cell.EditedFormattedValue.ToString().Replace(",", ";") + ',';
                    }
                    csv += "\r\n";
                }
            }
            csv += source.Name;
            csv += "\r\n";
            return csv;
        }

        public void DeleteColumnsFolder()
        {
            if (Directory.Exists(SettingFolder))
            {
                Directory.Delete(SettingFolder, true);
            }
        }

        public void GenerateColumnXML(List<DataGridView> dgvs, BackgroundWorker bgw)
        {
            try
            {
                var obj = new AppConfigBAL();
                var connections = obj.ListOfConnection();
                int i = 1;
                var maxInt = connections.Count() * dgvs.Count();

                foreach (var s in connections)
                {
                    foreach (DataGridView grid in dgvs)
                    {
                        var folder = SettingFolder + s.Name;
                        string filesName = folder + "\\" + grid.Name + ".xml";

                        if (!File.Exists(filesName))
                        {
                            using (SqlConnection conn = new SqlConnection(s.ConnectionString))
                            {
                                conn.Open();
                                DataTable dt = conn.GetSchema("Columns", new[] { conn.Database, null, grid.Name });
                                List<InformationSchemaColumns> lst = new List<InformationSchemaColumns>();

                                lst = (from a in dt.AsEnumerable()
                                       select new InformationSchemaColumns
                                       {
                                           TABLE_CATALOG = a["TABLE_CATALOG"].ToString(),
                                           TABLE_SCHEMA = a["TABLE_SCHEMA"].ToString(),
                                           TABLE_NAME = a["TABLE_NAME"].ToString(),
                                           COLUMN_NAME = a["COLUMN_NAME"].ToString().ToLower(),
                                           ORDINAL_POSITION = (int)a["ORDINAL_POSITION"],
                                           COLUMN_DEFAULT = a["COLUMN_DEFAULT"].ToString(),
                                           IS_NULLABLE = a["IS_NULLABLE"].ToString(),
                                           DATA_TYPE = a["DATA_TYPE"].ToString(),
                                           CHARACTER_MAXIMUM_LENGTH = a["CHARACTER_MAXIMUM_LENGTH"].ToString(),
                                           CHARACTER_OCTET_LENGTH = a["CHARACTER_OCTET_LENGTH"].ToString(),
                                           NUMERIC_PRECISION = a["NUMERIC_PRECISION"].ToString(),
                                           NUMERIC_PRECISION_RADIX = a["NUMERIC_PRECISION_RADIX"].ToString(),
                                           NUMERIC_SCALE = a["NUMERIC_SCALE"].ToString(),
                                           DATETIME_PRECISION = a["DATETIME_PRECISION"].ToString(),
                                           CHARACTER_SET_CATALOG = a["CHARACTER_SET_CATALOG"].ToString(),
                                           CHARACTER_SET_SCHEMA = a["CHARACTER_SET_SCHEMA"].ToString(),
                                           CHARACTER_SET_NAME = a["CHARACTER_SET_NAME"].ToString(),
                                           COLLATION_CATALOG = a["COLLATION_CATALOG"].ToString()
                                       }).OrderBy(x => x.ORDINAL_POSITION).ToList();

                                var cols = new Columns();
                                var serializer = new XmlSerializer(typeof(Columns));
                                cols.Items = lst;
                                
                                if (!Directory.Exists(folder))
                                {
                                    Directory.CreateDirectory(folder);
                                }

                                using (var stream = new StringWriter())
                                {
                                    serializer.Serialize(stream, cols);
                                    File.WriteAllText(filesName, stream.ToString());
                                  
                                }

                                double c = (Convert.ToDouble(i) / Convert.ToDouble(maxInt)) * 100;
                                bgw.ReportProgress(Convert.ToInt32(c), new string[] { "Downloading... " + s.Name + ": " + grid.Name + ".xml" });
                                i += 1;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
