using System;
using System.IO;
using System.Collections;
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
using System.Windows.Shapes;

namespace PencilCodeConverter
{
    /// <summary>
    /// Interaction logic for Setup.xaml
    /// </summary>
    public partial class Setup : Window
    {
        string path = @"C:\EV3FilesInstalled.txt";
        string dirPath = Directory.GetCurrentDirectory();

        public Setup()
        {
            try
            {
                if (Checker())      // Checks if the required software is installed in the local computer
                {
                    MainWindow main = new MainWindow();     // If so, the next window will pop up
                    main.Show();
                    this.Close();       // The current installation window will close
                }
                else
                    InitializeComponent();      // If the software is not installed, the installation window will prompt the user to install the files
            }
            catch {}
        }

        /*   Checks if the files are installed in the user's computer and returns the status   */
        public bool Checker()
        {
            string check = System.IO.File.ReadAllText(path);
            if (check == "true")
                return true;
            return false;
        }

        /*   Clicking this button will install the EV3 software and makes the next button visible to the user   */
        private void EV3_Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://drive.google.com/file/d/0B2ONq__xo-94MEhHWTExb1k5eUE/view?usp=sharing");
            MSB_Button.IsEnabled = true;
            MSB_Button.Foreground = new SolidColorBrush(Colors.Black);
        }

        /*   Clicking this button will install the Microsoft Small Basic software and makes the next button visible to the user   */
        private void MSB_Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://drive.google.com/open?id=0B2ONq__xo-94NkZOMkVGNEZPeTQ");
            Continue_Button.IsEnabled = true;
            System.IO.File.Create(path);
        }

        /*   Clicking this button will close the current window and open the next window to continue the file conversion   */
        private void Continue_Button_Click(object sender, RoutedEventArgs e)
        {
            try { System.IO.File.WriteAllText(path, "true"); }
            catch { }
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
