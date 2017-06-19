using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using TaskConfigurator.Entity;

namespace TaskConfigurator.Logic.GenerateScript
{
    class ScriptReader
    {
        public void PopulateSetting(string fileName, List<DataGridView> source)
        {
            try
            {
                StreamReader file = new StreamReader(fileName);
                List<string> lstData = new List<string>();

                int i = 0;
                string tableName = "";
                string columns = "";
                string newLine;
                bool isSetting = false;

                while ((newLine = file.ReadLine()) != null)
                {
                    if (newLine != "")
                    {
                        if (!newLine.Contains(','))
                        {
                            isSetting = true;
                            tableName = newLine;
                            i += 1;
                        }
                        else
                        {
                            newLine = newLine.Remove(newLine.LastIndexOf(","));
                            if (isSetting)
                            {
                                columns = newLine;
                                isSetting = false;
                            }
                            else
                            {
                                lstData.Add(newLine);
                            }
                        }

                        if (i == 2)
                        {

                            foreach (DataGridView grid in source)
                            {
                                grid.Rows.Clear();
                                if (grid.Name == tableName)
                                {
                                    var sColumns = columns.Split(',');

                                    foreach (var data in lstData)
                                    {
                                        var sData = data.Split(',');

                                        int newId = grid.Rows.Add();

                                        for (int j = 0; j <= sData.Length - 1; j++)
                                        {
                                            if (sColumns[j].Trim() != "")
                                            {
                                                if (grid.Columns.Contains(sColumns[j]))
                                                {
                                                    if (!Properties.Resources.constant.Split(';').Contains(sColumns[j].ToLower())){
                                                        grid.Rows[newId].Cells[sColumns[j]].Value = sData[j];
                                                    }
                                                    grid.Rows[newId].Cells[sColumns[j]].ToolTipText = sData[j];

                                                }
                                            }

                                        }
                                    }
                                    source.Remove(grid);
                                    break;
                                }
                            }

                            i = 0;
                            columns = "";
                            lstData.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var test = "";
                test = ex.Message;
            }
        }

        public void ReadXMLColumn(string model, List<DataGridView> grids)
        {
            var serializer = new XmlSerializer(typeof(Columns));
            var obj = new Columns();
            var dbtl = new DataGridViewLogic();
            var folder = Directory.GetCurrentDirectory() + "\\Settings\\Columns\\" + model;
            var files = Directory.GetFiles(folder, "*.xml");

           XmlDocument doc = new XmlDocument();

            foreach (string sr in files)
            {
                TextReader textReader = new StreamReader(sr);
                obj = (Columns)serializer.Deserialize(textReader);

                var grid = grids.Where(x => x.Name.ToLower() == obj.Items.FirstOrDefault().TABLE_NAME.ToLower());

                dbtl.AssignDataGridColumn(grid.FirstOrDefault(), obj.Items);

            }
        }
    }
}
