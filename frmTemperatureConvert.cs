using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//=====================================================================================
// Leandro Fortunato - Temperature Converter F <--> C
//=====================================================================================
namespace DashBoard
{
    public partial class frmTemperatureConvert : Form
    {
        public frmTemperatureConvert()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            DateTime CurrentDateTime = DateTime.Now;  // Get current date and time for the Log string
            if (txtInput.Text != "") // Only take an action if txtInput is not empty
            {
                TemperatureConverter TempConv = new TemperatureConverter(); // Create and object TempConv of the class TemepratureConverter
                try
                {
                    TempConv.ValueToConvert = Convert.ToDouble(txtInput.Text); // Get the value to be converted
                    string strLog = txtInput.Text;   // strLog will hold the log of current conversion
                    if (rdrCtoF.Checked==true) {     // Is it set to convert from Celsius to Fahrenheit?
                        
                        txtOutput.Text = Convert.ToString(TempConv.ToFahrenheint());  // Call convertion method ToFahrenheit
                        // Add to Log string the convertion the date and time 
                        strLog = strLog + " C = " + txtOutput.Text + " F,    " + CurrentDateTime.ToString(); 
                    }
                    else {  // Convert from Celsius to Fahrenheit?
                        txtOutput.Text = Convert.ToString(TempConv.ToCelsius()); //Call conversion Method ToCelsius
                         // Add to Log string the convertion the date and time 
                        strLog = strLog + " F = "+ txtOutput.Text + " C,    " + CurrentDateTime.ToString(); 
                    }
                    string stemp= TempConv.GetMessage();  // Get Class Message from Last conversion
                    if (TempConv.bIsExactValue==true) // If the result is an exactValue, the txtMessage will be writen in bold.
                    {
                        txtMessage.Font = new Font("Microsoft Sans Serif ", 9, FontStyle.Bold); //Set font to Bold
                    }
                    else
                    {
                        txtMessage.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular); // Set font to regular
                    }
                    txtMessage.Text = stemp;


                    // Save the LOG into History file
                    HistoryGen Historic = new HistoryGen(Application.StartupPath);
                    Historic.UpdateLog("TemperatureLog.txt", strLog);


                }
                catch (Exception ex1)
                {  // User has entered an invalid data format
                    MessageBox.Show("Please enter a numerical value to be converted \n" + ex1.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInput.Text = "";
                    txtOutput.Text = "";
                }
            }
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            HistoryGen Historic = new HistoryGen(Application.StartupPath);
            string MoneyExchangeLog = Historic.ReadLog("TemperatureLog.txt");
            frmLog formLog = new frmLog(MoneyExchangeLog, "TemperatureLog");
            formLog.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            byte Option = 0;
            Option = Convert.ToByte(MessageBox.Show("Do you want to quit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (Option == 6) { this.Close(); }
        }

        private void rdrCtoF_CheckedChanged(object sender, EventArgs e)
        {
            if(rdrCtoF.Checked==true)  // User wants to convert temperature from Celsius to Farehnheit
            {
                lbl_Input.Text = "C";   // Change input label text to C(elsius)
                lbl_Output.Text = "F";  // Change output label text to F(ahrenheit)
                txtOutput.Text = "";  // Clear text fields
                txtInput.Text = "";
                txtMessage.Text = "";
            }
        }

        private void rdrFtoC_CheckedChanged(object sender, EventArgs e)
        {
            if (rdrFtoC.Checked == true)
            {
                lbl_Input.Text = "F";   // Change input label text to F(ahrenheit)
                lbl_Output.Text = "C";  // Change output label text to C(elsius)
                txtOutput.Text = "";     // Clear text fields
                txtInput.Text = "";
                txtMessage.Text = "";
            }
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            if (txtOutput.Text != "") // Once txtInput changes, txtOuput and txt Message are cleared
                {
                txtOutput.Text = "";
                }
            if (txtMessage.Text!="")
            {
                txtMessage.Text = "";
            }

        }
    }

    //This class perform the Temperature conversion from Celsius to Fahrenheit and vice-versa
    public class TemperatureConverter  
    {
        double valueToConvert;
        double CurCelsiusTemp = 0;
        bool bIsexactValue = false;

        // Set and get values to/from private variable num1
        public double ValueToConvert {set { valueToConvert = value; } get { return valueToConvert; }}
        public bool bIsExactValue {get { return bIsexactValue; }}

        public double ToFahrenheint() // Convert the vairable valueToConverto from Celsius to Fahrenheit
        {
            this.CurCelsiusTemp = this.valueToConvert;   // Current Celsius temperature is the one entered by user
            return Math.Round(((float)((valueToConvert*9)/5)+32),2); // round the converted value to 2 digits after decimal point
        }
        public double ToCelsius()  // Convert the vairable valueToConverto from Fahrenheit to Celsius
        {
            // Current Celsius temperature is the converted one
            this.CurCelsiusTemp = Math.Round(((float)((valueToConvert - 32) * 5) / 9)); // round the converted value to 2 digits after decimal point
            return this.CurCelsiusTemp;
        }

        public string GetMessage() // This method sets the message string based on Celsius temperature (input/output)
        {
            string strMsg = "";
            this.bIsexactValue = true;
            switch (this.CurCelsiusTemp)
            {
                case 100:
                    strMsg = "Water boils\r\n";
                    break;
                case 40:
                    strMsg = "Hot Bath\r\n";
                    break;
                case 37:
                    strMsg = "Body Temperature\r\n";
                    break;
                case 30:
                    strMsg = "Beach Wheater\r\n";
                    break;
                case 21:
                    strMsg = "Room Temperature\r\n";
                    this.bIsexactValue = false;
                    break;
                case 10:
                    strMsg = "Cool Day\r\n";
                    break;
                case 0:
                    strMsg = "Freezing point of  water";
                    break;
                case -18:
                    strMsg = "Very Cold Day";
                    this.bIsexactValue = false;
                    break;
                case -40:
                    strMsg = "Extremely Cold Day\r\n(and the same number!)";
                    break;
                default:
                    strMsg = "";
                    this.bIsexactValue = false;
                    break;
            }
            return strMsg;
        }
    }
}

