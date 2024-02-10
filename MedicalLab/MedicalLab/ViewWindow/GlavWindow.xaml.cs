using MedicalLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Windows.Threading;
using MedicalLab.ViewWindow;

namespace MedicalLab.ViewWindow
{
    /// <summary>
    /// Логика взаимодействия для GlavWindow.xaml
    /// </summary>
    public partial class GlavWindow : Window
    {
        private DispatcherTimer sessionTimer;
        private DateTime sessionStartTime;

        public GlavWindow()
        {
            InitializeComponent();

            sessionTimer = new DispatcherTimer();
            sessionTimer.Interval = TimeSpan.FromMinutes(0.0166667);
            sessionTimer.Tick += CheckSessionTime;

            StartSessionTimer();
        }

        private void StartSessionTimer()
        {
            sessionStartTime = DateTime.Now;
            sessionTimer.Start();
        }

        private void CheckSessionTime(object sender, EventArgs e)
        {

            TimeSpan sessionDuration = DateTime.Now - sessionStartTime;
            if (sessionDuration.TotalMinutes > 15)
            {
                sessionTimer.Stop();
                MessageBox.Show("Ваша сессия истекла. Попробуйте войти через 10 минут.");
                MainWindow auth = new MainWindow();
                auth.TxbPassword.IsEnabled = false;
                auth.TxbPassword_Open.IsEnabled = false;
                auth.Show();
                this.Close();


                using (var context = new LabMLEntities())
                {
                    var user = context.Users.FirstOrDefault(u => u.login == MainWindow.Globals.userinfo.login);
                    if (user != null)
                    {
                        user.lastenter = DateTime.Now;
                        context.SaveChanges();
                    }
                }
            }
            else
            {
                TimeSpan remainingTime = TimeSpan.FromMinutes(15) - sessionDuration;
                sessionTimerText.Text = remainingTime.ToString(@"mm\:ss");                
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void User_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new UsersPage();
        }

        private void Patient_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new PatientPage();
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new OrderPage();
        }

        private void Analyzer_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new AnalyzerPage();
        }

        private void Company_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new CompanyPage();
        }
    }
}
