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
        string[] NXC = new string[100];
        string[] wordArray = new string[100];
        int for_rev = 10000;
        int left_right = 750;
        int j = 0;

        MainWindow main = new MainWindow();

        public void AddToNXCArray(string _com)
        {
            NXC[j] = _com;
            j++;
        }

        public void AddToNXCArray(string _com1, string _com2, string _com3, int _com4, string _com5)
        {
            string _com = (_com1 + _com2 + _com3 + _com4.ToString() + _com5).ToString();
            NXC[j] = _com;
            j++;
        }

        public void FileConversion(string _fileAddress)
        {
            string commands = System.IO.File.ReadAllText(_fileAddress);
            string words = System.Text.RegularExpressions.Regex.Replace(commands, @"\s+", Environment.NewLine);

            AddToNXCArray("#define right(s,t) OnFwd(OUT_A, s); OnRev(OUT_B, s); Wait(t);");
            AddToNXCArray("#define left(s,t) OnRev(OUT_A, s); OnFwd(OUT_B, s); Wait(t);");
            AddToNXCArray("#define forward(s,t) OnFwd(OUT_AB, s); Wait(t);");
            AddToNXCArray("#define reverse(s,t) OnRev(OUT_AB, s); Wait(t);");
            AddToNXCArray("\ntask main()");
            AddToNXCArray("{");

            wordArray = words.Split('\n');

            for (int i = 0; i < wordArray.Length; i++)
            {
                if (wordArray[i].Contains("fd"))
                    AddToNXCArray("\tforward(", wordArray[i + 1], ",", for_rev, ");\n");

                if (wordArray[i].Contains("bk"))
                    AddToNXCArray("\treverse(", wordArray[i + 1], ",", for_rev, ");\n");

                if (wordArray[i].Contains("rt"))
                    AddToNXCArray("\tright(", wordArray[i + 1], ",", left_right, ");\n");

                if (wordArray[i].Contains("lt"))
                    AddToNXCArray("\tleft(", wordArray[i + 1], ",", left_right, ");\n");
            }

            AddToNXCArray("\tOff(OUT_AB);");
            AddToNXCArray("}");

            string robotCode = @"C:\Users\Owner\Desktop\robotCode.nxc";
            main.FileExists(robotCode, NXC);
            File.Delete(main.FileName);
        }
    }
}
