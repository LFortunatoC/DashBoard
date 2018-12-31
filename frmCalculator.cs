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
// Leandro Fortunato  - Calculator
//=====================================================================================
namespace DashBoard
{
    public partial class frmCalculator : Form
    {
        MyCalculator Calc = new MyCalculator();  // Declares and create a new Calculator object

        // This flag controls the cleaning of txtOutput, after a operation is set (+,-,*,/) 
        // the next digit will cause this field to be cleaned
        bool bClearTxtOutput = false;

        // This flag controls the equal '=' button. This button only will be enabledo to
        // take an action after one of the operations (+,-,*,/) is set
        bool bEnableEquals = false;

        public frmCalculator()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            byte Option = 0;
            // Ask user confirmation before close the application
            Option = Convert.ToByte(MessageBox.Show("Do you want to quit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (Option == 6) { this.Close(); }
        }
        //=======================================================================================
        // The numeric buttons 0 up to 9 will check if the OutputText field need to be cleaned.
        // If so, it will be cleaned.
        // The respective number will be concatenated to the OutputText content.
        //========================================================================================
        private void btn1_Click(object sender, EventArgs e)
        {
            if (bClearTxtOutput == true) { txtOutput.Text = ""; bClearTxtOutput = false; }
            txtOutput.Text = txtOutput.Text + '1';
        }

        private void bn2_Click(object sender, EventArgs e)
        {
            if (bClearTxtOutput == true) { txtOutput.Text = ""; bClearTxtOutput = false; }
            txtOutput.Text = txtOutput.Text + '2';
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (bClearTxtOutput == true) { txtOutput.Text = ""; bClearTxtOutput = false; }
            txtOutput.Text = txtOutput.Text + '3';
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (bClearTxtOutput == true) { txtOutput.Text = ""; bClearTxtOutput = false; }
            txtOutput.Text = txtOutput.Text + '4';
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (bClearTxtOutput == true) { txtOutput.Text = ""; bClearTxtOutput = false; }
            txtOutput.Text = txtOutput.Text + '5';
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (bClearTxtOutput == true) { txtOutput.Text = ""; bClearTxtOutput = false; }
            txtOutput.Text = txtOutput.Text + '6';
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (bClearTxtOutput == true) { txtOutput.Text = ""; bClearTxtOutput = false; }
            txtOutput.Text = txtOutput.Text + '7';
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (bClearTxtOutput == true) { txtOutput.Text = ""; bClearTxtOutput = false; }
            txtOutput.Text = txtOutput.Text + '8';
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (bClearTxtOutput == true) { txtOutput.Text = ""; bClearTxtOutput = false; }
            txtOutput.Text = txtOutput.Text + '9';
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (bClearTxtOutput == true) { txtOutput.Text = ""; bClearTxtOutput = false; }
            txtOutput.Text = txtOutput.Text + '0';
        }

        // This button adds a decimal point to OutputText content.
        private void btnPoint_Click(object sender, EventArgs e)
        {
            if (txtOutput.TextLength == 0)
            {
                txtOutput.Text = "0.";  // If txtOutput is empty add "0."
            }
            else if (txtOutput.Text.IndexOf('.') == -1) // Check if there is already a decimal point
            {
                txtOutput.Text = txtOutput.Text + '.'; // If is not there,  insert a decimal point
            }
        }

        // This button changes the signal of TxtOutput content from positive to negative and vice-versa
        private void btnSignal_Click(object sender, EventArgs e)
        {
            if (txtOutput.TextLength > 0)  // Only do it if is there some content in TxtOutput field
            {
                if (txtOutput.Text.IndexOf('-') == 0)
                {
                    txtOutput.Text = txtOutput.Text.Substring(1); // if is there a minus signal remove it.
                }
                else
                {
                    string strTemp = txtOutput.Text;
                    txtOutput.Text = "-" + strTemp;  // add a minus signal to TxtOutput content
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtOutput.Text != "") // Only take an action if txtOutput is not empty
            {
                try  // Try to convert the content of txtOutput to a decimal number.
                {
                    decimal dTemp = 0;
                    //The following two lines checks if user has already pressed some of the operators buttons
                    int i = txtOutput.Text.IndexOfAny(new char[] { '-', '+', '*', '/', '^' });
                    // If there is some operation set, clear it.
                    if (i > -1) { txtOutput.Text = txtOutput.Text.Remove(i, 1); }

                    dTemp = Convert.ToDecimal(txtOutput.Text); // convert the content of txtOutput to decimal
                    Calc.Add(dTemp); // Set the object calc to perform a addiction
                    txtOutput.Text = txtOutput.Text + "+"; // Add to txtOutput the operation to be performed
                    bClearTxtOutput = true;                // Next digit will requires txtOutput to be cleared
                    bEnableEquals = true;                  // Equals button is now enabled
                }
                catch (Exception ex1)
                {
                    //User entered and invalid data format
                    MessageBox.Show("Invalid number format\n" + ex1.Message, "Wrong number format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOutput.Text = "";    // Clear txtOutput content
                    bClearTxtOutput = false; // Next digit does not requires an empty content in txtOutput
                    Calc.Clear();            // Set all variables in Calc object to their default values
                }
            }
        }

        private void btnInverse_Click(object sender, EventArgs e)
        {
            if (txtOutput.Text != "") // Only take an action if txtOutput is not empty
            {
                try
                {
                    decimal dTemp = 0;
                    dTemp = Convert.ToDecimal(txtOutput.Text);
                    dTemp = Calc.Inv(dTemp);                // Calc.Inv returns the 1/dTemp
                    txtOutput.Text = dTemp.ToString();      // The value is show in txtOutput
                    bClearTxtOutput = true;                 // Next digit will requires txtOutput to be cleared
                }
                catch (Exception ex1)
                {
                    MessageBox.Show("Invalid number format\n" + ex1.Message, "Wrong number format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOutput.Text = "";        // Clear txtOutput content
                    bClearTxtOutput = false;    // Next digit does not requires an empty content in txtOutput
                    Calc.Clear();               // Set all variables in Calc object to their default values
                }
            }
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if ((txtOutput.Text != "") && (bEnableEquals == true)) // Only take an action if txtOutput is not empty and
            {                                                   // and operation was set previously
                try
                {
                    decimal dTemp = 0;
                    dTemp = Convert.ToDecimal(txtOutput.Text);
                    dTemp = Calc.Percent(dTemp); // Calc.Percent retunrs the percentage value of its Operand1 content
                    txtOutput.Text = dTemp.ToString(); // Shows in txtOutput the percentage value of previous entered value

                }
                catch (Exception ex1)
                {
                    MessageBox.Show("Invalid number format\n" + ex1.Message, "Wrong number format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOutput.Text = "";        // Clear txtOutput content
                    bClearTxtOutput = false;    // Next digit does not requires an empty content in txtOutput
                    Calc.Clear();               // Set all variables in Calc object to their default values
                }
            }
        }

        private void b1tnSubb_Click(object sender, EventArgs e)
        {
            if (txtOutput.Text != "")
            {
                try
                {
                    decimal dTemp = 0;
                    //The following two lines checks if user has already pressed some of the operators buttons
                    int i = txtOutput.Text.IndexOfAny(new char[] { '-', '+', '*', '/', '^' });
                    // If there is some operation set, clear it.
                    if (i > -1) { txtOutput.Text = txtOutput.Text.Remove(i, 1); }

                    dTemp = Convert.ToDecimal(txtOutput.Text);
                    Calc.Subtract(dTemp);

                    txtOutput.Text = txtOutput.Text + "-"; // Add to txtOutput the operation to be performed
                    bClearTxtOutput = true;                // Next digit will requires txtOutput to be cleared
                    bEnableEquals = true;                  // Equals button is now enabled
                }
                catch (Exception ex1)
                {
                    MessageBox.Show("Invalid number format\n" + ex1.Message, "Wrong number format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOutput.Text = "";        // Clear txtOutput content
                    bClearTxtOutput = false;    // Next digit does not requires an empty content in txtOutput
                    Calc.Clear();               // Set all variables in Calc object to their default values
                }
            }
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            if (txtOutput.Text != "")
            {
                try
                {
                    decimal dTemp = 0;
                    //The following two lines checks if user has already pressed some of the operators buttons
                    int i = txtOutput.Text.IndexOfAny(new char[] { '-', '+', '*', '/', '^' });
                    // If there is some operation set, clear it.
                    if (i > -1) { txtOutput.Text = txtOutput.Text.Remove(i, 1); }

                    dTemp = Convert.ToDecimal(txtOutput.Text);
                    Calc.Multiply(dTemp);
                    txtOutput.Text = txtOutput.Text + "*"; // Add to txtOutput the operation to be performed
                    bClearTxtOutput = true;                // Next digit will requires txtOutput to be cleared
                    bEnableEquals = true;                  // Equals button is now enabled
                }
                catch (Exception ex1)
                {
                    MessageBox.Show("Invalid number format\n" + ex1.Message, "Wrong number format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOutput.Text = "";        // Clear txtOutput content
                    bClearTxtOutput = false;    // Next digit does not requires an empty content in txtOutput
                    Calc.Clear();               // Set all variables in Calc object to their default values
                }
            }
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            if (txtOutput.Text != "")
            {
                try
                {
                    decimal dTemp = 0;
                    //The following two lines checks if user has already pressed some of the operators buttons
                    int i = txtOutput.Text.IndexOfAny(new char[] { '-', '+', '*', '/', '^' });
                    // If there is some operation set, clear it.
                    if (i > -1) { txtOutput.Text = txtOutput.Text.Remove(i, 1); }

                    dTemp = Convert.ToDecimal(txtOutput.Text);
                    Calc.Divide(dTemp);
                    txtOutput.Text = txtOutput.Text + "/"; // Add to txtOutput the operation to be performed
                    bClearTxtOutput = true;                // Next digit will requires txtOutput to be cleared
                    bEnableEquals = true;                  // Equals button is now enabled
                }
                catch (Exception ex1)
                {
                    MessageBox.Show("Invalid number format\n" + ex1.Message, "Wrong number format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOutput.Text = "";        // Clear txtOutput content
                    bClearTxtOutput = false;    // Next digit does not requires an empty content in txtOutput
                    Calc.Clear();               // Set all variables in Calc object to their default values
                }
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if ((txtOutput.Text != "") && (bEnableEquals == true)) // Only take an action if txtOutput is not empty and
            {                                                      // Button Equals is enabled
                bEnableEquals = false;
                try
                {
                    decimal dTemp = 0;
                    dTemp = Convert.ToDecimal(txtOutput.Text);
                    Calc.Equals(dTemp);                         // Calc.Equals will take dTemp as Operand2 and perform the calculus previously set
                    txtOutput.Text = Calc.Operand1.ToString();  // The result of the calculus is stored in Operand1.
                    bClearTxtOutput = true;                     // Next digit will requires txtOutput to be cleared

                    // Save the LOG into History file
                    HistoryGen Historic = new HistoryGen(Application.StartupPath);
                    Historic.UpdateLog("CalculatorLog.txt", Calc.Log);
                }
                catch (Exception ex1)
                {
                    MessageBox.Show("Invalid number format\n" + ex1.Message, "Wrong number format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOutput.Text = "";        // Clear txtOutput content
                    bClearTxtOutput = false;    // Next digit does not requires an empty content in txtOutput
                    Calc.Clear();               // Set all variables in Calc object to their default values
                }
            }
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            if (txtOutput.Text != "")
            {
                try
                {
                    decimal dTemp = 0;
                    dTemp = Convert.ToDecimal(txtOutput.Text);
                    dTemp = Calc.Sqrt(dTemp);              // Calc.Sqrt returns the square root of dTemp;
                    txtOutput.Text = dTemp.ToString();   // the result is displayed in txtOutput
                    bEnableEquals = true;                // Equals button is now enabled
                }
                catch (Exception ex1)
                {
                    MessageBox.Show("Invalid number format\n" + ex1.Message, "Wrong number format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOutput.Text = "";        // Clear txtOutput content
                    bClearTxtOutput = false;    // Next digit does not requires an empty content in txtOutput
                    Calc.Clear();               // Set all variables in Calc object to their default values
                }
            }
        }

        private void btnPow_Click(object sender, EventArgs e)
        {
            if (txtOutput.Text != "")
            {
                try
                {
                    decimal dTemp = 0;
                    //The following two lines checks if user has already pressed some of the operators buttons
                    int i = txtOutput.Text.IndexOfAny(new char[] { '-', '+', '*', '/', '^' });
                    // If there is some operation set, clear it.
                    if (i > -1) { txtOutput.Text = txtOutput.Text.Remove(i, 1); }

                    dTemp = Convert.ToDecimal(txtOutput.Text);
                    Calc.Pow(dTemp);
                    txtOutput.Text = txtOutput.Text + "^"; // Add to txtOutput the operation to be performed
                    bClearTxtOutput = true;                // Next digit will requires txtOutput to be cleared
                    bEnableEquals = true;                  // Equals button is now enabled
                }
                catch (Exception ex1)
                {
                    MessageBox.Show("Invalid number format\n" + ex1.Message, "Wrong number format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOutput.Text = "";        // Clear txtOutput content
                    bClearTxtOutput = false;    // Next digit does not requires an empty content in txtOutput
                    Calc.Clear();               // Set all variables in Calc object to their default values
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";
            bClearTxtOutput = false;
            bEnableEquals = false;
            Calc.Clear();
        }

        private void frmCalculator_Load(object sender, EventArgs e)
        {

        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistoryGen Historic = new HistoryGen(Application.StartupPath);
            string CalculatorLog = Historic.ReadLog("CalculatorLog.txt");
            frmLog formLog = new frmLog(CalculatorLog, "CalculatorLog");
            formLog.ShowDialog();
        }
    }

    class MyCalculator
    {
        decimal operand1;     // First Operand
        decimal operand2;     // Second Operand
        decimal currentValue; // Holds the value of the last operation
        string op;            // Store the operation to be performed     
        string log;           // Store the log of the last operation performed

        // Set and get values to/from private variable num1
        public decimal Operand1 { set { operand1 = value; } get { return operand1; } }
        public decimal Operand2 { set { operand2 = value; } get { return operand2; } }
        public string Operation { set { op = value; } }
        public string Log { get { return log; } }

        public void Clear() // Sets class variables to their default value
        {
            operand1 = 0;
            operand2 = 0;
            currentValue = 0;
            Operation = "";
            log = "";
        }

        public void Add(decimal displayValue)  // Prepare properties to perform a addiction
        {
            currentValue = displayValue;
            operand1 = displayValue;
            op = "+";

        }

        public void Subtract(decimal displayValue) // Prepare properties to perform a subtraction
        {
            currentValue = displayValue;
            operand1 = displayValue;
            op = "-";
        }

        public void Multiply(decimal displayValue) // Prepare properties to perform a multiplication
        {
            currentValue = displayValue;
            operand1 = displayValue;
            op = "*";
        }

        public void Divide(decimal displayValue) // Prepare properties to perform a division
        {
            currentValue = displayValue;
            operand1 = displayValue;
            op = "/";
        }


        public void Pow(decimal displayValue) // Prepare properties to perform a power operation
        {
            currentValue = displayValue;
            operand1 = displayValue;
            op = "^";
        }

        public decimal Percent(decimal percentVal) // Returns the percentagem value of Operand1
        {
            currentValue = ((operand1 * percentVal) / 100);
            return currentValue;
        }
        //Sqrt method returns the square root of the parameters passed to it
        public decimal Sqrt(decimal oper) { currentValue = Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(oper))); return currentValue; }
        //Inv method returns the 1/X of the parameters passed to it
        public decimal Inv(decimal oper) { currentValue = Decimal.Round((1 / oper), 12); return currentValue; }

        public void Equals(decimal displayValue) // Overload function of Method Equals.
        {
            operand2 = displayValue; // Set the parameter display value to Operand2
            this.Equals();           // Call Equals method to perform the calculus
        }

        public void Equals()
        {
            decimal temp = 0;
            DateTime dt = DateTime.Now;
            string strTemp = "";  // strTemp holds will receive the log string
            switch (op)           // Check the sort of operation to be performed
            {
                case "+":
                    strTemp = operand1.ToString() + " + " + operand2.ToString() + " = ";
                    operand1 += operand2;

                    break;

                case "-":
                    strTemp = operand1.ToString() + " - " + operand2.ToString() + " = ";
                    operand1 -= operand2;
                    break;

                case "*":
                    strTemp = operand1.ToString() + " * " + operand2.ToString() + " = ";
                    operand1 *= operand2;
                    break;

                case "/":
                    strTemp = operand1.ToString() + " / " + operand2.ToString() + " = ";
                    //Use round method of decimal class to take a maximum of 12 digits after the point
                    operand1 = Decimal.Round((operand1 /= operand2), 12);
                    break;

                case "^":
                    strTemp = operand1.ToString() + " ^ " + operand2.ToString() + " = ";
                    temp = Convert.ToDecimal(Math.Pow((double)operand1, (double)operand2));
                    operand1 = temp;
                    break;

                case "Sqrt":
                    strTemp = operand1.ToString() + " Sqrt( " + operand2.ToString() + ") = ";
                    temp = Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(operand1)));
                    //Use round method of decimal class to take a maximum of 12 digits after the point
                    operand1 = Decimal.Round(temp, 12);
                    break;

                default:
                    break;
            }
            //Build the log string with operation and current date and time of the operation
            log = strTemp + operand1.ToString() + "    " + dt.ToString();
        }

    }
}
