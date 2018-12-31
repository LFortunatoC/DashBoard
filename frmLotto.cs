/*
The form application that allows the user to generate 7 + 1 or 6 + 1 random numbers out of 49 
for the game Lotto Max or Lotto 649.
Random random = new Random();
int randomNumber = random.Next(1, 49);
The 8 or 7 unique numbers should be presented to the user into a multiline read only TextBox and 
also saved into a text file LottoNbrs.txt (one series of numbers per line, using comma to separate the numbers). 
Identify the name of the lottery and add the current date and time. 
Ex.:
Max,7/21/2017 2:17:36 PM, 40,33,12,06,36,04,18 Extra 29
649, 7/21/2017 2:17:42 PM, 05,11,14,03,46,21 Extra 23
====================================================================================================================================================*/

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
// Leandro Fortunato - Lotto
//=====================================================================================
namespace DashBoard
{
    public partial class frmLotto : Form
    {
        public frmLotto()
        {
            InitializeComponent();
        }
        private void brnGenerate_Click(object sender, EventArgs e)
        {
            int numOfNUmbers =7;         // Default number of numbers to be generated (will be used in Loto949)
            Random random = new Random();
            int randomNumber = 0;
            string log="Lotto 649, ";   //Default Name of Lotto to be inserted in the Historic Log = Lotto 649
            DateTime CurrentDateTime = DateTime.Now;
            //===============================================================================================
            // The current Text of this form will be set by the calling button in DashBoard form.
            // if this form were called by Lotto Max button, the text of the form will be set as "Lotto Max"
            // if this form were called by Lotto 649 button, the text of the form will be set as "Lotto 649"
            // The form icon, will also be set likewise.
            //===============================================================================================
            if (this.Text== "Lotto Max - Leandro Fortunato") //Check if it is generating Lotto Max numbers. 
            {
                //"Max,7 / 21 / 2017 2:17:36 PM, 40,33,12,06,36,04,18 Extra 29"
                log = "Lotto Max, ";
                numOfNUmbers = 8;
            }

            List<int> randomList = new List<int>();         // create a list to hold the random numbers
            for (int counter=0; counter< numOfNUmbers; )    // This for loop generate 7 or 8 random number
            {
                randomNumber = random.Next(1, 49);
                if (!randomList.Contains(randomNumber))     // Check if the generated number is already in the list.
                {

                    randomList.Add(randomNumber);           // If its not in the list add it to the list   
                    textBox1.Text = textBox1.Text + "\r\n" + randomNumber; // Show the sorted number in the output textbox
                    counter++;   // Only increment the counter in for loop if a new number was inserted into the list
                }
            }

            // Add a line to make easier to user to find out the new set of numbers
            textBox1.Text = textBox1.Text + "\r\n" + "==================================\n";
            
            //The following lines, scroll down the text box in order to show the  new set of numbers...
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();  

            string sNumbers="";  // This temporary string variable will hold the numbers to be saved in the historic file
            for (int counter = 0; counter < (numOfNUmbers); counter++)
            {
                if (counter== (numOfNUmbers-1))  // if it is the last number add the "Extra "
                {
                    sNumbers = sNumbers + "Extra " + randomList[counter].ToString();
                }
                else  // Insert the number in the list to the log string 
                {
                    sNumbers = sNumbers + randomList[counter].ToString()+ ", ";
                }
            }
            // Build up the Log string adding current date and time and the generated numbers
            log = log + CurrentDateTime.ToString() + ", "+ sNumbers;

            
            // Save the LOG into History file
            HistoryGen Historic = new HistoryGen(Application.StartupPath);
            Historic.UpdateLog("LottoLog.txt",log);
      

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            byte Option = 0;
            //Ask for user confirmation , before  closing the application
            Option = Convert.ToByte(MessageBox.Show("Do you want \nto quit this application?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (Option == 6) { this.Close(); }
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            HistoryGen Historic = new HistoryGen(Application.StartupPath);
            string LottoLog = Historic.ReadLog("LottoLog.txt");
            frmLog formLog = new frmLog(LottoLog, "LottoLog");
            formLog.ShowDialog();
        }
    }
}
