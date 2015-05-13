/*
Author: Steven Gibson
 
Date: 4/6/2014
 
Project: DiveClass.cs

Purpose: Form interface which uses a DiveClass object to read in a diving score input file and output a calculated score output file
 
Assumptions: N/A
 
Error Checking: N/A
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;    // System.IO for file input & output

namespace DiversForm
{
    public partial class frmDivers : Form
    {
        string strOutputVal;  // User defined output file name

        public frmDivers()
        {
            InitializeComponent();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {

            string strInputVal = txtInput.Text;     // User defined input file name
            strOutputVal = txtOutput.Text; 

            try
            {   
                if (File.Exists(strInputVal))
                {
                    DiveClass diveScores = new DiveClass(); // Instantiating a new DiveClass object
                    diveScores.FillRec(strInputVal); // Calling FillRec() to fill the DiveArr with records based on an input file
                    diveScores.PrintReport(strOutputVal);   // Calling the PrintReport() method to output the report to a file

                    // Enabling the view report button & disabling the make report button
                    btnView.Enabled = true;
                    btnReport.Enabled = false;

                    MessageBox.Show("Report Successfully Created!",
                                    "Success!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);

                }
                else
                {
                    // File Not Found error handling
                    MessageBox.Show("File Not Found!",
                                "Error!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                }
            }
            catch
            {
                // Checks for file formatting mistakes
                MessageBox.Show("Invalid File Format! \n Application will now exit.",
                                "Error!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                Application.Exit();

            }
            
        }

        private void btnView_Click(object sender, EventArgs e)
        {

            StreamReader iSR = new StreamReader(strOutputVal);  // input file using the output file created by PrintRecord 
            string strInpVal = iSR.ReadLine(); // Priming Read

            rtxtOutput.Visible = true; // Making an output text field visible

            // Formatting the window of the application to fit the output text field
            frmDivers.ActiveForm.Size = new System.Drawing.Size(462, 475);
            btnReport.Location = new Point(42, 410);
            btnView.Location = new Point(164, 410);
            BtnExit.Location = new Point(288, 410);
            txtInput.Hide();
            txtOutput.Hide();

            while (strInpVal != null)
            {
                rtxtOutput.Text = rtxtOutput.Text + strInpVal + "\n";
                strInpVal = iSR.ReadLine();
            } // End EOF

            btnView.Enabled = false; // Disabling the View Button
            BtnExit.Focus();

            iSR.Close(); // Closing input file variable
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Terminates application
        }
    }
}
