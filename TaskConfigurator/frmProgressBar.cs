using System.Windows.Forms;

namespace TaskConfigurator
{
    public partial class frmProgressBar : Form
    {
        public string ModifyText
        {
            get
            {
                return lblText.Text;
            }
            set
            {
                if (this.lblText.InvokeRequired)
                {
                    this.lblText.BeginInvoke((MethodInvoker)delegate () { this.lblText.Text = value; });
                }
                else
                {
                    this.lblText.Text = value;
                }
                this.lblText.Refresh();
            }
        }

        public frmProgressBar()
        {
            InitializeComponent();

        }

        public void SetProgressBarValue(int iValue)
        {
            pgb1.Value = iValue;
        }

        public void SetProgressNoAnimation(int value)
        {
            if (value == pgb1.Maximum)
            {

                pgb1.Value = value;
                pgb1.Value = value - 1;      
            }
            else {
                pgb1.Value = value + 1;      
            }
            pgb1.Value = value;             
        }
    }
}
