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
        string[] SB = new string[20];          // Will hold the converted code in Microsoft Small Basic format
        string[] wordArray = new string[20];   // Will hold the data from the pencilcode text file
        int j = 0;      // Counter for the words in the text file

        MainWindow main = new MainWindow();

        /*   Adds any given string command into the new array   */
        public void AddToNewArray(string _com)
        {
            SB[j] = _com;
            j++;
        }

        /*   Removes the new line character in the word array   */
        public string RemoveNewLine(string word)
        {
            string replacement = System.Text.RegularExpressions.Regex.Replace(word, @"\t|\n|\r", "");
            return replacement;
        }

        /*   Converts the pencilcode string number to an integer   */
        public string ConvertToNum(string word, double num)
        {
            double doubleWord = Convert.ToDouble(word);
            double temp = num * doubleWord; 
            string newVal = Convert.ToString(temp);
            return newVal;
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
                    AddToNewArray("Motor.Move(\"BC\", 50, " + ConvertToNum(RemoveNewLine(wordArray[i + 1]), 7.2) + ", \"true\")");

                else if (wordArray[i].Contains("bk"))

                    AddToNewArray("Motor.Move(\"BC\", -50, " + ConvertToNum(RemoveNewLine(wordArray[i + 1]), 7.2) + ", \"true\")");

                else if (wordArray[i].Contains("rt"))
                    AddToNewArray("Motor.Move(\"B\", 180, " + ConvertToNum(RemoveNewLine(wordArray[i + 1]), 2) + ", \"true\")");

                else if (wordArray[i].Contains("lt"))
                    AddToNewArray("Motor.Move(\"C\", 180, " + ConvertToNum(RemoveNewLine(wordArray[i + 1]), 2) + ", \"true\")");

                i++;
            }

            string robotCode = main.GetDesktopDirectory("robotCode.sb");    //Gets the desktop directory for the robotCode file
            main.FileExists(robotCode, SB);             // After the file is completely read, the program checks if the new converted file exists
            File.Delete(main.FileName);                 // The original pencilcode text file is deleted for cleanup
        }
    }
}
