using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PencilCodeConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string outFile = @"C:\Users\Owner\Desktop\Data.txt";

        public MainWindow()
        {
            InitializeComponent();
        }

        public string FileName
        {
            get { return outFile; }
        }

        private void URL_Conversion()
        {
            //string old_url = PencilCode_URL.Text;
            string old_url = "http://batmanizzy2.pencilcode.net/edit/intro";
            /*    ^^^^ REMOVE ^^^^    */
            string new_url = old_url.Replace("edit", "code");
            New_URL_TextBlock.Text = new_url;
        }

        public void DownloadFile()
        {
            WebClient client = new WebClient();
            string text = client.DownloadString(New_URL_TextBlock.Text);
            FileExists(text);
        }

        /*
        public static bool CheckNum(string _word)
        {
            
            //int num;
            //return Int32.TryParse(_word, out num);
            
            foreach(char c in _word)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
        */

        public void FileExists(string _data)
        {
            if (File.Exists(outFile))
            {
                File.Delete(outFile);
                FileExists(_data);
            }
            File.WriteAllText(outFile, _data);
        }

        public void FileExists(string _file, string[] _data)
        {
            if (File.Exists(_file))
            {
                File.Delete(_file);
                FileExists(_file, _data);
            }
            File.WriteAllLines(_file, _data);
        }

        private void PencilCode_Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://pencilcode.net/edit/first");
        }

        private void PencilCode_URL_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            //MessageBox.Show("Enter PencilCode Project URL Here");
            tb.Text = string.Empty;
            tb.GotFocus -= PencilCode_URL_GotFocus;
        }

        private void Enter_Button_Click(object sender, RoutedEventArgs e)
        {
            URL_Conversion();
            Download_Button.IsEnabled = true;
        }

        private void Download_Button_Click(object sender, RoutedEventArgs e)
        {
            DownloadFile();
            Files file = new Files();
            file.FileConversion(outFile);
        }
    }
}
