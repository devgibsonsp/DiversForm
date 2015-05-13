/*
Author: Steven Gibson
 
Date: 4/6/2014
 
Project: DiveClass.cs

Purpose: Takes diving scores from an input file, performs calculations on them to get totals, and outputs them 
         to an output file in a nicely formatted manner
 
Assumptions: N/A
 
Error Checking: N/A
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;    // System.IO for file input & output

namespace DiversForm
{
    class DiveClass
    {
        const int MAX_RECORDS = 25;              // Maximum number of records that can go into the array

        const int NUM_DIVE_SCORES = 3;           // Maximum number of dive scores that can go into a record

        const int NUM_TOTAL_DIVES = 9;           // Number of dives that take place per score

        const int NUM_RECORDED_DIVES = 7;        // Number of dives to be stored in a record


        // Private Data Members
        private DiveRec[] DiveArr;      // Array that will store the diving records
        private int intDiveCt;          // Number of dives total that took place (out of MAX_RECORDS)

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Default Constructor

        // Pre: None
        // Post: Instantiates a new DiveArr with MAX_RECORDS size
        // Purpose: Loads default values into the PDMs
        public DiveClass()
        {
            DiveArr = new DiveRec[MAX_RECORDS];
            intDiveCt = 0;
        } // End NDC

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Pre: Integer values storing the index of the score (out of NUM_DIVE_SCORES)
        //      & an integer value storing the index of the dive record (out of intDiveCt)
        //      have been passed into the method
        // Post: Instantiates a new DiveArr with MAX_RECORDS size
        // Purpose: Loads default values into the PDMs
        private float ScoreVal( int intScoreInd, // index value of ScoreArr
                                int intDiveInd)  // index value of DiveArr
        {
            // Initializing fltScoreSum with the value at the score position (excluding the difficulty)
            float fltScoreSum = DiveArr[intDiveInd].scoresArr[intScoreInd, 1];

            // Looping through a dive in a record to get the score sum
            for (int i = 0; i < NUM_RECORDED_DIVES-1; i++)
            {
                fltScoreSum += DiveArr[intDiveInd].scoresArr[intScoreInd, i+2];
            }

            // Multiplying the score sum by the difficulty of dive to get the score value
            fltScoreSum = fltScoreSum * DiveArr[intDiveInd].scoresArr[intScoreInd, 0];

            return fltScoreSum; // Returns the total score value (Sum of scores * difficulty of dive) from a single dive
        } // End ScoreVal()

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Pre: None
        // Post: Outputs the scores and total scores of diving scores from the values stored in DiveArr
        //       in nicely formatted columns
        // Purpose: Prints the calculated scores of the divers and outputs them to a file
        public void PrintReport(string strOutputFile)   // User defined output file variable
        {
            NameBubSort(); // calling a bubble sort method to sort the records based on the last & first name of the divers

            int intScoreInd = 0;    // Initializing the scoreArr index to 0
            int intDiveInd = 0;     // Initializing the diveArr index to 0

            // Declaring 3 floats that will store the total scores of a user's 3 dives
            float fltScore1;
            float fltScore2;
            float fltScore3;

            StreamWriter oSW = new StreamWriter(strOutputFile);  // Initializing a new output variable & defining the name

            /* I chose to create 3 values rather than updating a single value so that I could re-use the original DiveArr array without
             * needing to store the scores for the second report in a new array/ create a separate method for the second report*/

            // Getting the values for the 3 dive scores
            fltScore1 = ScoreVal(intScoreInd, intDiveInd);
            fltScore2 = ScoreVal(intScoreInd + 1, intDiveInd);
            fltScore3 = ScoreVal(intScoreInd + 2, intDiveInd);

            // After the values of the first dive are recorded, the [0,0] position of the first record is loaded with the total score as
            // it will not be used again and is no longer needed to be stored
            DiveArr[0].scoresArr[0, 0] = fltScore1 + fltScore2 + fltScore3;

            oSW.WriteLine("Report 1");
            oSW.WriteLine(string.Format("{0,-15}{1,8}{2,15}{3,15}",
                          "Diver Name: ", "Score 1:", "Score 2:", "Score 3:"));

            // Loop to output the 3 scores of the divers in a formatted string in ascending order based on their name
            for (int i = 0; i < intDiveCt; i++)
            {
                oSW.WriteLine(string.Format("{0,-15}{1,8}{2,15}{3,15}",
                                            DiveArr[intDiveInd].strLastNm + ", " + DiveArr[intDiveInd].strFirstNm.Substring(0, 1), fltScore1.ToString("N2"), fltScore2.ToString("N2"), fltScore3.ToString("N2")));
                if (intDiveInd < intDiveCt-1)
                {
                    // Incrementing the dive index to grab the next set of scores from DiveArr
                    intDiveInd++;
                    fltScore1 = ScoreVal(intScoreInd, intDiveInd);
                    fltScore2 = ScoreVal(intScoreInd + 1, intDiveInd);
                    fltScore3 = ScoreVal(intScoreInd + 2, intDiveInd);

                    // Replacing the next [0,0] ScoreArr with the total score
                    DiveArr[intDiveInd].scoresArr[0, 0] = fltScore1 + fltScore2 + fltScore3;
                }
            }

            ScoreBubSort(); // Bubble sort on DiveArr based on the total score

            oSW.WriteLine("");
            oSW.WriteLine("Report 2");
            oSW.WriteLine(string.Format("{0,-17}{1,8}",
                  "Total Score:", "Diver Name:"));

            // Loop to output the total scores of the divers based on the score in descending order
            for (int i = 1; i <= intDiveCt; i++)
            {
                oSW.WriteLine(string.Format("{0,-17}{1,8}",
                              DiveArr[intDiveCt - i].scoresArr[0,0].ToString("N2"), DiveArr[intDiveCt - i].strFirstNm + " " + DiveArr[intDiveCt - i].strLastNm));
            }

            oSW.Close(); // Closing the output file variable

        } // End PrintReport()

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 

        // Pre: Input file is present
        // Post: Fills DiveArr with values stored in DiveRecs from data in the input file
        // Purpose: Stores data from the input file to preserve it for use in getting the score values
        public void FillRec(string strInputFile)    // User defined input file variable
        {
            DiveRec diverInfo = new DiveRec();  // Creating a new DiveRec variable 

            diverInfo.scoresArr = new float[NUM_DIVE_SCORES, NUM_RECORDED_DIVES + 1];   // Creating a new scoresArr array within diverInfo

            float[] tempArr = new float[NUM_TOTAL_DIVES];   // creating a temporary array to store the total dives before removing highest & lowest

            string strInputVal; // Input value to store the incoming values from the input file
            StreamReader iSR;   // Input file variable for file input

            // Checking for the existence of the input file variable
            if (File.Exists(strInputFile))
            {

                iSR = new StreamReader(strInputFile);    // if the file is found, load the file into the input file variable

                strInputVal = iSR.ReadLine();   // Getting the first line from the file (Priming Read)

                // End of file while loop
                while (strInputVal != null)
                {
                    if (intDiveCt > 0)
                    {
                        // Creating a new DiveRec and new scoresArr for each new record added to diveArr
                        diverInfo = new DiveRec(); 
                        diverInfo.scoresArr = new float[NUM_DIVE_SCORES, NUM_RECORDED_DIVES + 1]; 
                    }

                    // loading the first and last names into the record
                    diverInfo.strFirstNm = strInputVal.Substring(0, (strInputVal.IndexOf(" ")));
                    diverInfo.strLastNm = strInputVal.Substring(strInputVal.IndexOf(" ") + 1);

                    int row = 0;    // Initializing a counting variable for the row in the 2D array to 0;

                    // While to store data in the columns
                    while (row < NUM_DIVE_SCORES)
                    {
                        // Grabbing the first line of data (Priming read for the for loops)
                        strInputVal = iSR.ReadLine();

                        diverInfo.scoresArr[row, 0] = float.Parse(strInputVal.Substring(0, (strInputVal.IndexOf(" "))));

                        strInputVal = strInputVal.Remove(0, strInputVal.IndexOf(" ") + 1);

                        for (int i = 0; i < NUM_TOTAL_DIVES; i++)
                        {
                            switch (i)
                            {
                                case 8: tempArr[i] = float.Parse(strInputVal); break;
                                default: tempArr[i] = float.Parse(strInputVal.Substring(0, strInputVal.IndexOf(" ")));
                                    strInputVal = strInputVal.Remove(0, strInputVal.IndexOf(" ") + 1); break;
                            }
                        } // End for

                        /* Using a bubble sort to sort the values */
                        FltBubSort(tempArr);

                        // Loop to store fill ScoresArr values 0-2 with dives 1-3
                        for (int j = 1; j < NUM_RECORDED_DIVES +1; j++)
                        {
                            diverInfo.scoresArr[row, j] = tempArr[j];
                        } // End for

                        row++;
                    } // End row while

                    DiveArr[intDiveCt] = diverInfo;

                    intDiveCt++;    // Incrementing the dive count index PDM to get the size of the stored portion of DiveArr

                    strInputVal = iSR.ReadLine(); // Modifying LCV
                } // End EOF

                iSR.Close(); // Closing the input file variable
            }
            else
            {
                // Error message if file is not found (for testing in a console)
                Console.WriteLine("File Not Found");
            }

        } // End FillRec()

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        
        // Pre: Takes an array with values and an integer value representing the current length of the stored portion of the array
        // Post: Updates the list with an alphabetically (by last name) list
        // Purpose: Takes an unsorted list and sorts it in ascending order alphabetically according to last names
        private void NameBubSort() // Bringing in the length of the stored portion of the array from main
        {
            bool booSwapIsMade = true;  // Variable to determine whether swaps are being performed

            // 2 half name variables for comparing last names and then first names if necessary
            string strHlfNm1;
            string strHlfNm2;
            int intCompVal;

            // Iterations will take place if swaps are currently taking place (booSwapIsMade == true)
            while (booSwapIsMade)
            {
                booSwapIsMade = false;  // Defaulting SwapIsMade  in the loop to false until proven otherwise (exit condition)
                int ct = 1; // initializing a counting variable to 1
                DiveRec temp; // Declaring a temporary DiveRec variable to preserve data during swap

                for (int i = 0; i < (intDiveCt - ct); i++)
                {
                    // Getting the last name of the two full names used in the comparison
                    strHlfNm1 = DiveArr[i + 1].strLastNm;
                    strHlfNm2 = DiveArr[i].strLastNm;

                    intCompVal = string.Compare(strHlfNm2.ToLower(), strHlfNm1.ToLower());

                    // If intCompVal == 1, then strHlfNm2 is greater than strHalfNm1
                    if (intCompVal == 1)
                    {
                        temp = DiveArr[i];  // Preserving the DiveArr[i] value

                        DiveArr[i] = DiveArr[i + 1];
                        DiveArr[i + 1] = temp;

                        ct++;
                        booSwapIsMade = true;
                    }
                    // If intCompVal == 1, then strHlfNm2 is equal to strHalfNm1
                    else if (intCompVal == 0)
                    {
                        // Comparing the two first names if the last names are the same
                        strHlfNm1 = DiveArr[i + 1].strFirstNm;
                        strHlfNm2 = DiveArr[i].strFirstNm;
                         

                        intCompVal = string.Compare(strHlfNm2.ToLower(), strHlfNm1.ToLower());

                        if (intCompVal == 1)
                        {
                            temp = DiveArr[i]; // Preserving the DiveArr[i] value

                            DiveArr[i] = DiveArr[i + 1];
                            DiveArr[i + 1] = temp;

                            ct++;
                            booSwapIsMade = true;
                        }
                    }
                }
            } // End while
        } // End NameBubSort()

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Pre: None
        // Post: The array will be organized based on total score value from least to greatest
        // Purpose: Sorts total scores from least to greatest value
        private void ScoreBubSort()
        {
            bool booSwapIsMade = true;  // Defaulting SwapIsMade  in the loop to false until proven otherwise (exit condition)

            DiveRec temp;   // Creating a temporary DiveRec value to preserve DiveArr[i]

            // Iterations will take place if swaps are currently taking place (booSwapIsMade == true)
            while (booSwapIsMade)
            {
                booSwapIsMade = false; // Defaulting SwapIsMade  in the loop to false until proven otherwise (exit condition)
                int ct = 1; // Initializing a counting variable to 1

                for (int i = 0; i < (intDiveCt - ct); i++)
                {
                    if (DiveArr[i].scoresArr[0, 0] > DiveArr[i + 1].scoresArr[0, 0])
                    {
                        temp = DiveArr[i];  // Preserving the DiveArr[i] value

                        DiveArr[i] = DiveArr[i + 1];
                        DiveArr[i + 1] = temp;

                        ct++;
                        booSwapIsMade = true;
                    }
                }
            }
        } // End ScoreBubSort()
 
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Pre: None
        // Post: The array will be organized based on individual diving score values stored in each record
        // Purpose: Sorts individual diving score values stored in each record from least to greatest value
        private void FltBubSort(float[] tempArr)
        {
            bool booSwapIsMade = true;  // Variable to determine whether swaps are being performed

            float fltNum1;                   // First float value to be compared
            float fltNum2;                   // second float value to be compared
            int length = tempArr.Length;     // Getting the length of the temporary array

            // Iterations will take place if swaps are currently taking place (booSwapIsMade == true)
            while (booSwapIsMade)
            {
                booSwapIsMade = false; // Defaulting SwapIsMade  in the loop to false until proven otherwise (exit condition)
                int ct = 1;

                for (int i = 0; i < (length - ct); i++)
                {
                    if (tempArr[i] > tempArr[i + 1])
                    {
                        // Performing swaps on TempArr based on the float values
                        fltNum1 = tempArr[i + 1];
                        fltNum2 = tempArr[i];

                        tempArr[i] = fltNum1;
                        tempArr[i + 1] = fltNum2;

                        ct++;
                        booSwapIsMade = true;
                    }
                }
            }
        } // End PrintReport()

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Purpose: Stores the first name, last name, and a 2D score
        //          array
        public struct DiveRec
        {
            public string strFirstNm;   // First name of a diver
            public string strLastNm;    // Last name of a diver

            public float[,] scoresArr;  // 2D array which stores a diver's 3 dive scores
        }; // End DiveRec

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    }
}
