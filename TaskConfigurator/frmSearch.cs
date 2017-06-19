using System;
using System.Windows.Forms;

namespace TaskConfigurator
{
    public partial class frmSearch : Form
    {
        public DataGridView grid { get; set; }

        public frmSearch()
        {
            InitializeComponent();
        }
        private void frmSearch_Load(object sender, EventArgs e)
        {
            txtSearch.Select();
            txtSearch.Focus();
        }

        private void frmSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string sSearch = ((TextBox)sender).Text.Trim().ToLower();
            int i = 0;
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Visible = false;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.EditedFormattedValue.ToString().ToLower().Contains(sSearch))
                        {
                            row.Visible = true;
                            i += 1;
                            break;
                        }
                    }
                }

            }

            lblMessage.Text = "Total found " + i + " row(s)"; 
        }

        private void ResetGrid()
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                row.Visible = true;
            }
        }

        private void frmSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            ResetGrid();
        }
    }
}
