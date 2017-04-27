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
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace PencilCodeConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isEmpty = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        /*   Returns the output-file's name  */
        public string FileName
        {
            get { return GetDesktopDirectory("Data.txt"); }
        }

        /*   Changes the URL for the pencilcode project to a text format   */
        private void URL_Conversion()
        {
            string old_url = PencilCode_URL.Text;

            if (old_url != "")
            {
                isEmpty = false;
                string new_url = old_url.Replace("edit", "code");
                New_URL_TextBlock.Text = new_url;
            }
            else
                isEmpty = true;
        }

        /*   Downloads the project URL with the new and edited text-formated URL   */
        public void DownloadFile()
        {
            WebClient client = new WebClient();
            string text = client.DownloadString(New_URL_TextBlock.Text);
            FileExists(FileName, text);
        }

        /*   Checks if the project folder directory exists   */
        public void DirectoryExists(string _dir, string _file, string _data)
        {
            if (Directory.Exists(_dir))     // If so....
            {
                File.Delete(_file);         // The text file is deleted
                Directory.Delete(_dir);     // Project folder is deleted
                DirectoryExists(_dir, _file, _data);    // Checks again if the folder exists
            }
            else            // If not...
            {
                Directory.CreateDirectory(_dir);    // A new directory is created for the folder
                File.WriteAllText(_file, _data);    // The file is created and written with the updated status
            }
        }

        /*   Checks if a given file exists   */
        public void FileExists(string _file, string _data)
        {
            if (File.Exists(_file))
            {
                File.Delete(_file);
                FileExists(_file, _data);
            }
            File.WriteAllText(FileName, _data);
        }

        /*   Checks if a given file exists   */
        public void FileExists(string _file, string[] _data)
        {
            if (File.Exists(_file))
            {
                File.Delete(_file);
                FileExists(_file, _data);
            }
            File.WriteAllLines(_file, _data);
        }

        /*   Clicking this button sends the user to the pencilcode website to create a project   */
        private void PencilCode_Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://pencilcode.net/edit/first");
        }

        /*   Allows the user to create a new PencilCode account   */
        private void CreateAccount_Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://pencilcode.net/edit/first#new");
        }

        /*   Shows the user where the paste their pencilcode project code   */
        private void PencilCode_URL_GotFocus(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TextBox tb = (System.Windows.Controls.TextBox)sender;
            System.Windows.Forms.MessageBox.Show("Enter PencilCode Project URL Here");
            tb.Text = string.Empty;
            tb.GotFocus -= PencilCode_URL_GotFocus;
        }

        /*   Clicking this button sends the URL data to be converted and enables the download button   */
        private void Enter_Button_Click(object sender, RoutedEventArgs e)
        {
            URL_Conversion();

            if (isEmpty == false)                   // Checks if the URL text box is filled. If so, it activates the DOWNLOAD button
            {
                if (PencilCode_URL.Text.Contains(".pencilcode.net/edit"))
                {
                    Download_Button.IsEnabled = true;
                    Download_Button.Foreground = new SolidColorBrush(Colors.Black);
                }
                else
                {
                    string message = "ERROR! \nEnter A Valid PencilCode URL";
                    string caption = "Invalid URL";

                    if (System.Windows.Forms.MessageBox.Show(message, caption, MessageBoxButtons.OK) == System.Windows.Forms.DialogResult.OK)
                    {
                        PencilCode_URL.Text = String.Empty;
                        Keyboard.Focus(PencilCode_URL);
                    }
                }
            }
            else                                    // If the text box is empty, it shows the user the error window below
                System.Windows.Forms.MessageBox.Show("URL Address Is Empty!\nPlease Enter a Pencil Code Project URL Address");
        }

        /*    Returns the Desktop path for a given file/program  */
        public string GetDesktopDirectory(string fileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filePath = filePath + @"\"+fileName;
            return filePath;
        }

        /*   Clicking this button downloads the pencilcode text file and converts the data into a valid EV3 file and opens the Microsoft Small Basic program   */
        private void Download_Button_Click(object sender, RoutedEventArgs e)
        {
            DownloadFile();
            Files file = new Files();
            file.FileConversion(FileName);
            string message =  "Open The File Named \"robotCode.sb\" From Your Desktop To Load Your Project";
            string caption = "Open File";

            if (System.Windows.Forms.MessageBox.Show(message, caption, MessageBoxButtons.OK) == System.Windows.Forms.DialogResult.OK)
                System.Diagnostics.Process.Start(GetDesktopDirectory("Microsoft Small Basic"));
        }

        /*   Clicking this button allows the user to open Microsoft Small Basic at any time   */
        private void SB_Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(GetDesktopDirectory("Microsoft Small Basic"));
        }

        /*   Downloads the EV3 documentation file   */
        private void EV3Doc_Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://sites.google.com/site/ev3basic/ev3-basic-programming/ev3-basic-manual");
        }

        /*   Downloads the Microsoft Small Basic documentation file   */
        private void MSBDoc_Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://drive.google.com/open?id=0B2ONq__xo-94bzFuWVdvYXVCNmM");
        }
    }
}
