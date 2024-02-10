using MedicalLab.Model;
using System;
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

namespace MedicalLab.ViewWindow
{
    /// <summary>
    /// Логика взаимодействия для helloWindow.xaml
    /// </summary>
    public partial class helloWindow : Window
    {
        LabMLEntities db = new LabMLEntities();

        public helloWindow()
        {
            InitializeComponent();


            if (MainWindow.Globals.UserRole == 1)
            {
                Pic1.Visibility = Visibility.Visible;
                HelloTxb.Visibility = Visibility.Visible;
                NameTxb.Visibility = Visibility.Visible;
                LogTxb.Visibility = Visibility.Visible;
                
            }
            if (MainWindow.Globals.UserRole == 2)
            {
                Pic2.Visibility = Visibility.Visible;
                HelloTxb2.Visibility = Visibility.Visible;
                NameTxb2.Visibility = Visibility.Visible;
                LogTxb2.Visibility = Visibility.Visible;
            }
            if (MainWindow.Globals.UserRole == 3)
            {
                Pic3.Visibility = Visibility.Visible;
                HelloTxb3.Visibility = Visibility.Visible;
                NameTxb3.Visibility = Visibility.Visible;
                LogTxb3.Visibility = Visibility.Visible;
            }
            if (MainWindow.Globals.UserRole == 4)
            {
                Pic4.Visibility = Visibility.Visible;
                HelloTxb4.Visibility = Visibility.Visible;
                NameTxb4.Visibility = Visibility.Visible;
                LogTxb4.Visibility = Visibility.Visible;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
