using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DashBoard
{
    public partial class frmLog : Form
    {
        string strLog = "";
        string formName="";

        public frmLog(string Log,string frmName="")
        {
            strLog = Log;
            formName = frmName;
            InitializeComponent();

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Log_Load(object sender, EventArgs e)
        {
            textBoxLog.Text = strLog;
            this.Text = formName;
        }
    }
}
