using MedicalLab.Model;
using MedicalLab.ViewWindow;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedicalLab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow window;

        bool CheckB;

        public MainWindow()
        {
            InitializeComponent();

            window = this;
        }

        public static class Globals
        {
            public static int UserRole;

            public static int Name;
            public static Users userinfo { get; set; }
        }

        private void MovingWin(object sender, EventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                MainWindow.window.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Check = sender as CheckBox;
            if (Check.IsChecked.Value)
            {
                TxbPassword_Open.Text = TxbPassword.Password;
                TxbPassword_Open.Visibility = Visibility.Visible;
                TxbPassword.Visibility = Visibility.Hidden;
                CheckB = true;
            }
            else
            {
                TxbPassword.Password = TxbPassword_Open.Text;
                TxbPassword_Open.Visibility = Visibility.Hidden;
                TxbPassword.Visibility = Visibility.Visible;
                CheckB = false;
            }
        }

        private async void Autorization_Click(object sender, RoutedEventArgs e)
        {
            if (TxbPassword.IsEnabled == false)
            {
                using (var db = new LabMLEntities())
                {
                    if (CheckB == true)
                    {
                        TxbPassword.Password = TxbPassword_Open.Text;
                    }
                    else
                    {
                        TxbPassword_Open.Text = TxbPassword.Password;
                    }

                    var login = db.Users.AsNoTracking().FirstOrDefault(l => l.login == TxbLogin.Text.Trim());
                    if (login == null)
                    {
                        MessageBox.Show("Неверный логин");
                    }
                    else
                    {
                        TimeSpan timeSinceLastLogin = DateTime.Now - login.lastenter;
                        if (timeSinceLastLogin.TotalMinutes > 1)
                        {
                            TxbPassword.IsEnabled = true;
                            TxbPassword_Open.IsEnabled = true;
                            TxbLogin.IsEnabled = false;
                            TxbPassword.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Между данной авторизацией и последней не прошло 15 минут!");
                            TxbPassword.IsEnabled = false;
                            TxbPassword_Open.IsEnabled = false;
                        }
                    }
                }
            }
            else
            {
                using (var db = new LabMLEntities())
                {
                    if (CheckB == true)
                    {
                        TxbPassword.Password = TxbPassword_Open.Text;
                    }
                    else
                    {
                        TxbPassword_Open.Text = TxbPassword.Password;
                    }

                    var login = db.Users.AsNoTracking().FirstOrDefault(l => l.login == TxbLogin.Text.Trim() & l.password == TxbPassword.Password);
                    if (login == null)
                    {
                        MessageBox.Show("Неверный пароль");
                        if (Auth_Win_1.Visibility == Visibility.Hidden)
                            Auth_Win_1.Visibility = Visibility.Visible;
                        showpass.IsChecked = false;
                        TxbPassword.IsEnabled = false;
                        TxbPassword.Visibility = Visibility.Visible;


                        TxbPassword_Open.Visibility = Visibility.Hidden;
                        TXB2.Focus();
                        while (true)
                        {
                            Random x = new Random();
                            int a = x.Next(1000, 9999);
                            TXB1.Text = a.ToString();
                            await Task.Delay(10000);
                        }
                    }

                    else
                    {
                        if (login.type == 1)
                        {
                            Globals.UserRole = login.type;
                            Globals.userinfo = login;
                            helloWindow helloWindow = new helloWindow();
                            helloWindow.NameTxb.Text = "ФИО: " + login.name;
                            helloWindow.LogTxb.Text = "Login: " + login.login;
                            

                            GlavWindow glavWindow = new GlavWindow();
                            glavWindow.Button_User.Visibility = Visibility.Hidden;
                            glavWindow.Button_Company.Visibility = Visibility.Hidden;
                            glavWindow.Show();
                            helloWindow.ShowDialog();
                            this.Close();
                            //glavWindow.Biometriya.Visibility = Visibility.Hidden;
                            //glavWindow.Pacient.Visibility = Visibility.Hidden;
                            //glavWindow.Incurance.Visibility = Visibility.Hidden;
                            //glavWindow.User.Visibility = Visibility.Hidden;
                        }
                        else if (login.type == 2)
                        {
                            Globals.UserRole = login.type;
                            Globals.userinfo = login;
                            helloWindow helloWindow = new helloWindow();
                            helloWindow.NameTxb2.Text = "ФИО: " + login.name;
                            helloWindow.LogTxb2.Text = "Login: " + login.login;
                            

                            GlavWindow glavWindow = new GlavWindow();
                            glavWindow.Button_User.Visibility = Visibility.Hidden;
                            glavWindow.Button_Company.Visibility = Visibility.Hidden;
                            glavWindow.Show();
                            helloWindow.ShowDialog();
                            this.Close();
                            //glavWindow.Biometriya.Visibility = Visibility.Visible;
                            //glavWindow.Pacient.Visibility = Visibility.Hidden;
                            //glavWindow.Incurance.Visibility = Visibility.Hidden;
                            //glavWindow.User.Visibility = Visibility.Hidden;
                        }
                        else if (login.type == 3)
                        {
                            Globals.UserRole = login.type;
                            Globals.userinfo = login;
                            helloWindow helloWindow = new helloWindow();
                            helloWindow.NameTxb3.Text = "ФИО: " + login.name;
                            helloWindow.LogTxb3.Text = "Login: " + login.login;
                            

                            GlavWindow glavWindow = new GlavWindow();
                            glavWindow.Button_Order.Visibility = Visibility.Hidden;
                            glavWindow.Button_User.Visibility = Visibility.Hidden;
                            glavWindow.Button_Analyzer.Visibility = Visibility.Hidden;
                            glavWindow.Button_Order.Visibility = Visibility.Hidden;
                            glavWindow.Button_Patient.Visibility = Visibility.Hidden;
                            glavWindow.Show();
                            helloWindow.ShowDialog();
                            this.Close();
                            //glavWindow.Biometriya.Visibility = Visibility.Hidden;
                            //glavWindow.Pacient.Visibility = Visibility.Hidden;
                            //glavWindow.Incurance.Visibility = Visibility.Visible;
                            //glavWindow.User.Visibility = Visibility.Hidden;
                        }
                        else if (login.type == 4)
                        {
                            Globals.userinfo = login;
                            Globals.UserRole = login.type;
                            helloWindow helloWindow = new helloWindow();
                            helloWindow.NameTxb4.Text = "ФИО: " + login.name;
                            helloWindow.LogTxb4.Text = "Login: " + login.login;
                            

                            GlavWindow glavWindow = new GlavWindow();
                            glavWindow.Button_Company.Visibility = Visibility.Hidden;
                            glavWindow.Button_Analyzer.Visibility = Visibility.Hidden;
                            glavWindow.Button_Order.Visibility = Visibility.Hidden;
                            glavWindow.Show();
                            helloWindow.ShowDialog();
                            this.Close();
                            //glavWindow.Biometriya.Visibility = Visibility.Hidden;
                            //glavWindow.Incurance.Visibility = Visibility.Hidden;
                            //glavWindow.Pacient.Visibility = Visibility.Visible;
                            //glavWindow.User.Visibility = Visibility.Visible;
                            
                        }

                    }
                }
            }
        }
        private void Next_Btn(object sender, RoutedEventArgs e)
        {
            if (TXB2.Text == TXB1.Text)
            {
                if (Auth_Win_1.Visibility == Visibility.Visible)
                    Auth_Win_1.Visibility = Visibility.Hidden;
                TxbPassword.IsEnabled = true;
                TxbPassword.Focus();
            }
            else
            {
                MessageBox.Show("Код подтверждения не верный!");
                TXB2.Clear();
            }
        }

        private void Click_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TxbLogin_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                using (var db = new LabMLEntities())
                {
                    if (CheckB == true)
                    {
                        TxbPassword.Password = TxbPassword_Open.Text;
                    }
                    else
                    {
                        TxbPassword_Open.Text = TxbPassword.Password;
                    }

                    var login = db.Users.AsNoTracking().FirstOrDefault(l => l.login == TxbLogin.Text.Trim());
                    if (login == null)
                    {
                        MessageBox.Show("Неверный логин");
                    }
                    else
                    {
                        TimeSpan timeSinceLastLogin = DateTime.Now - login.lastenter;
                        if (timeSinceLastLogin.TotalMinutes > 1)
                        {
                            TxbPassword.IsEnabled = true;
                            TxbLogin.IsEnabled = false;
                            TxbPassword.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Между данной авторизацией и последней не прошло 15 минут!");
                        }
                    }
                }
            }
        }

        private async void TxbPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                using (var db = new LabMLEntities())
                {
                    if (CheckB == true)
                    {
                        TxbPassword.Password = TxbPassword_Open.Text;
                    }
                    else
                    {
                        TxbPassword_Open.Text = TxbPassword.Password;
                    }

                    var login = db.Users.AsNoTracking().FirstOrDefault(l => l.login == TxbLogin.Text.Trim() & l.password == TxbPassword.Password);
                    if (login == null)
                    {
                        MessageBox.Show("Неверный пароль");
                        if (Auth_Win_1.Visibility == Visibility.Hidden)
                            Auth_Win_1.Visibility = Visibility.Visible;
                        showpass.IsChecked = false;
                        TxbPassword.IsEnabled = false;
                        TxbPassword.Visibility = Visibility.Visible;


                        TxbPassword_Open.Visibility = Visibility.Hidden;
                        TXB2.Focus();
                        while (true)
                        {
                            Random x = new Random();
                            int a = x.Next(1000, 9999);
                            TXB1.Text = a.ToString();
                            await Task.Delay(10000);
                        }
                    }
                    else
                    {
                        if (login.type == 1)
                        {
                            Globals.UserRole = login.type;
                            Globals.userinfo = login;
                            helloWindow helloWindow = new helloWindow();
                            helloWindow.NameTxb.Text = "ФИО: " + login.name;
                            helloWindow.LogTxb.Text = "Login: " + login.login;

                            GlavWindow glavWindow = new GlavWindow();
                            glavWindow.Button_User.Visibility = Visibility.Hidden;
                            glavWindow.Button_Company.Visibility = Visibility.Hidden;

                            
                            glavWindow.Show();
                            helloWindow.Show();
                            this.Close();
                            //glavWindow.Biometriya.Visibility = Visibility.Visible;
                            //glavWindow.Pacient.Visibility = Visibility.Hidden;
                            //glavWindow.Incurance.Visibility = Visibility.Hidden;
                            //glavWindow.User.Visibility = Visibility.Hidden;
                        }
                        else if (login.type == 2)
                        {
                            Globals.UserRole = login.type;
                            Globals.userinfo = login;
                            helloWindow helloWindow = new helloWindow();
                            helloWindow.NameTxb2.Text = "ФИО: " + login.name;
                            helloWindow.LogTxb2.Text = "Login: " + login.login;

                            GlavWindow glavWindow = new GlavWindow();
                            glavWindow.Button_User.Visibility = Visibility.Hidden;
                            glavWindow.Button_Company.Visibility = Visibility.Hidden;

                            
                            glavWindow.Show();
                            helloWindow.ShowDialog();
                            this.Close();
                            //glavWindow.Biometriya.Visibility = Visibility.Visible;
                            //glavWindow.Pacient.Visibility = Visibility.Hidden;
                            //glavWindow.Incurance.Visibility = Visibility.Hidden;
                            //glavWindow.User.Visibility = Visibility.Hidden;
                        }
                        else if (login.type == 3)
                        {
                            Globals.UserRole = login.type;
                            Globals.userinfo = login;
                            helloWindow helloWindow = new helloWindow();
                            helloWindow.NameTxb3.Text = "ФИО: " + login.name;
                            helloWindow.LogTxb3.Text = "Login: " + login.login;
                            

                            GlavWindow glavWindow = new GlavWindow();
                            glavWindow.Button_Order.Visibility = Visibility.Hidden;
                            glavWindow.Button_User.Visibility = Visibility.Hidden;
                            glavWindow.Button_Analyzer.Visibility = Visibility.Hidden;
                            glavWindow.Button_Order.Visibility = Visibility.Hidden;
                            glavWindow.Button_Patient.Visibility = Visibility.Hidden;

                            
                            glavWindow.Show();
                            helloWindow.ShowDialog();
                            this.Close();
                            //glavWindow.Biometriya.Visibility = Visibility.Hidden;
                            //glavWindow.Pacient.Visibility = Visibility.Hidden;
                            //glavWindow.Incurance.Visibility = Visibility.Visible;
                            //glavWindow.User.Visibility = Visibility.Hidden;
                        }
                        else if (login.type == 4)
                        {
                            Globals.UserRole = login.type;
                            Globals.userinfo = login;
                            helloWindow helloWindow = new helloWindow();
                            helloWindow.NameTxb4.Text = "ФИО: " + login.name;
                            helloWindow.LogTxb4.Text = "Login: " + login.login;
                            

                            GlavWindow glavWindow = new GlavWindow();
                            glavWindow.Button_Company.Visibility = Visibility.Hidden;
                            glavWindow.Button_Analyzer.Visibility = Visibility.Hidden;
                            glavWindow.Button_Order.Visibility = Visibility.Hidden;
                            
                            glavWindow.Show();
                            helloWindow.ShowDialog();
                            this.Close();
                            //glavWindow.Biometriya.Visibility = Visibility.Hidden;
                            //glavWindow.Incurance.Visibility = Visibility.Hidden;
                            //glavWindow.Pacient.Visibility = Visibility.Visible;
                            //glavWindow.User.Visibility = Visibility.Visible;
                            
                        }
                    }
                }
            }
        }
    }
}
