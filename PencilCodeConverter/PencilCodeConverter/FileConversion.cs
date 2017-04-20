using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace PencilCodeConverter
{
    class Files
    {
        string[] SB = new string[100];          // Will hold the converted code in Microsoft Small Basic format
        string[] wordArray = new string[100];   // Will hold the data from the pencilcode text file
        int j = 0;      // Counter for the words in the text file

        MainWindow main = new MainWindow();

        /*   Adds any given string command into the new array   */
        public void AddToNewArray(string _com)
        {
            SB[j] = _com;
            j++;
        }

        /*   Parses the pencilcode text file line-by-line and looks for specific commands and converts those commands into MSB code   */
        public void FileConversion(string _fileAddress)
        {
            string commands = System.IO.File.ReadAllText(_fileAddress);
            string words = System.Text.RegularExpressions.Regex.Replace(commands, @"\s+", Environment.NewLine);

            wordArray = words.Split('\n');            

            for (int i = 0; i < wordArray.Length; i++)
            {
                if (wordArray[i].Contains("fd"))
                    AddToNewArray("Motor.Move(\"AB\", 50, 360, \"true\")");


                else if (wordArray[i].Contains("bk"))
                    AddToNewArray("Motor.Move(\"AB\", -50, 360, \"true\")");

                else if (wordArray[i].Contains("rt"))
                    AddToNewArray("Motor.Move(\"AB\", 50, 270, \"true\")");

                else if (wordArray[i].Contains("lt"))
                    AddToNewArray("Motor.Move(\"AB\", 50, 90, \"true\")");

                else
                    break;
            }

            string robotCode = main.GetDesktopDirectory("robotCode.sb");    //Gets the desktop directory for the robotCode file
            main.FileExists(robotCode, SB);             // After the file is completely read, the program checks if the new converted file exists
            File.Delete(main.FileName);                 // The original pencilcode text file is deleted for cleanup
        }
    }
}
