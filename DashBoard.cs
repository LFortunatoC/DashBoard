using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//=====================================================================================
// Leandro Fortunato - DashBoard
//=====================================================================================
namespace DashBoard
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            byte Option = 0;
            //Ask for user confirmation before close the application
            Option = Convert.ToByte(MessageBox.Show("Do you want to quit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (Option == 6) { Application.Exit(); }
        }

        private void btnLottoMax_Click(object sender, EventArgs e)
        {
            frmLotto frmLotto = new frmLotto();
            frmLotto.Text = "Lotto Max - Leandro Fortunato"; // Set Lotto form text to "Lotto Max"
            //Set frmLotto icon to Lotto Max
            System.Drawing.Icon ico = new System.Drawing.Icon("..\\..\\images\\LottoMax2.ico");
            frmLotto.Icon =ico;
             frmLotto.ShowDialog();
        }

        private void btnLotto649_Click(object sender, EventArgs e)
        {
            frmLotto frmLotto = new frmLotto();
            frmLotto.Text = "Lotto 649 - Leandro Fortunato"; // Set Lotto form text to "Lotto 649"
            //Set frmLotto icon to Lotto 649
            System.Drawing.Icon ico = new System.Drawing.Icon("..\\..\\images\\Lotto649.ico");
            frmLotto.Icon = ico;
            frmLotto.ShowDialog();
        }

        private void btnTempConv_Click(object sender, EventArgs e)
        {
            frmTemperatureConvert frmTemp = new frmTemperatureConvert();
            frmTemp.ShowDialog();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            frmCalculator frmCalc = new frmCalculator();
            frmCalc.ShowDialog();

        }

        private void btnMoneyExch_Click(object sender, EventArgs e)
        {
            frmMoneyExchange frmExchange = new frmMoneyExchange();
            frmExchange.ShowDialog();
        }
    }
}
