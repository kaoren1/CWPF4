using System;
using System.Collections.Generic;
using System.IO;
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

namespace PR4WPF1
{
    /// <summary>
    /// Логика взаимодействия для AutorizeWindow.xaml
    /// </summary>
    public partial class AutorizeWindow : Window
    {
        public AutorizeWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Redactor_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new RedactorPage();
        }

        private void GoTest_Click(object sender, RoutedEventArgs e)
        {
            FileInfo fileInfo = new FileInfo("test.json");
            if (fileInfo.Exists && fileInfo.Length > 0)
            {
                PageFrame.Content = new TestPage();
            }
            else
            {
                PageFrame.Content = new PustoPage();
            }
        }


    }
}
