using System.Drawing;
using System.Windows.Forms;

namespace TaskConfigurator.Logic
{
    public class ValidateLogic
    {
        #region "Public"

        public string ValidateMandatory(DataGridView[] source)
        {
            var msg = "";
            //bool IsError = false;   
            //foreach(DataGridView grid in source)
            //{
            //    if(IsError == false)
            //    {
            //        foreach (DataGridViewRow row in grid.Rows)
            //        {
            //            if (IsError == false && row.Cells["id"].EditedFormattedValue.ToString() != "0")
            //            {
            //                foreach (DataGridViewCell cell in row.Cells)
            //                {
            //                    if (cell.InheritedStyle.BackColor == Color.LightBlue && cell.EditedFormattedValue.ToString().Trim() == string.Empty)
            //                    {
            //                        msg = "Please correct the highlighted field as the field is require to generate complete script";
            //                        IsError = true;
            //                        break;
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                break;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}

            return msg;
        }

        public string ValidateMandatoryOnFieldChange(DataGridView source, DataGridView target = null)
        {
            var errmg = "";


            return errmg;
        }
        #endregion

        #region "Private"

        #endregion
    }
}
