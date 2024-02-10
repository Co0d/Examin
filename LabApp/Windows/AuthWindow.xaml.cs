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
using System.Windows.Threading;
using LabApp;
using LabApp.Windows;

namespace LabApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /* Глобальная переменная для разграничения прав */
        public static class Globals
        {
            public static string fullName;
            public static int type;
        }

        DispatcherTimer timer = new DispatcherTimer();

        string code;

        bool passVisibility;

        bool enterCapcha;
        public MainWindow()
        {
            InitializeComponent();
        }

        /* Метод генерации кода доступа, запуск таймера, разблокирование поля для ввода кода и кнопки */
        private void gencode()
        {
            code = null;
            Random random = new Random();
            string[] massiveCharacters = new string[] 
            { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "а", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            for (int i = 0; i < 4; i++)
            {
                code += massiveCharacters[random.Next(0, massiveCharacters.Length)];
            }
            CapchaBlock.Text = code;
            timer.Tick -= Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        /* Метод остановки таймера при его окончании */
        void Timer_Tick(object sender, EventArgs e)
        {
            code = null;
            MessageBox.Show("Время написания кода вышло. Повторите попытку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            timer.Stop();
            gencode();
        }

        void ban_timer()
        {
            timer.Tick -= Timer_Tick;
            LogTb.IsEnabled = false;
            PassB.IsEnabled = false;
            EnterBtn.IsEnabled = false;
            Check.IsEnabled = false;
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Tick += stop_ban_timer;
            timer.Start();
        }

        void stop_ban_timer(object sender, EventArgs e)
        {
            LogTb.IsEnabled = true;
            PassB.IsEnabled = true;
            EnterBtn.IsEnabled = true;
            Check.IsEnabled = true;
            MessageBox.Show("Вы снова можете войти");
            timer.Stop();
        }

        /* Обработчик кнопки для перегенерации кода */
        private void Refresh(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            gencode();
            CapchaBox.Text = "";
        }

        /* Обработчик кнопки для перегенерации кода */
        private void CheckCapcha(object sender, RoutedEventArgs e)
        {
            if (CapchaBox.Text == code)
            {
                timer.Stop();
                MessageBox.Show("Вы можете снова попытаться войти");
                BorderCapcha.Visibility = Visibility.Hidden;
                CodeCapcha.Visibility = Visibility.Hidden;
                CapchaBlock.Visibility = Visibility.Hidden;
                CapchaBox.Visibility = Visibility.Hidden;
                RefreshBtn.Visibility = Visibility.Hidden;
                CheckBtn.Visibility = Visibility.Hidden;
                CapchaBox.Text = "";
            }
            else
            {
                MessageBox.Show("Неверная капча, пройдите ещё раз");
                timer.Stop();
                gencode();
                CapchaBox.Text = "";
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var Check = sender as CheckBox;
            if (Check.IsChecked.Value)
            {
                Txb.Text = PassB.Password;
                Txb.Visibility = Visibility.Visible;
                PassB.Visibility = Visibility.Hidden;
                passVisibility = true;
            }
            else
            {
                PassB.Password = Txb.Text;
                Txb.Visibility = Visibility.Hidden;
                PassB.Visibility = Visibility.Visible;
                passVisibility = false;
            }
        }

        private void Entering(object sender, RoutedEventArgs e)
        {
            if (passVisibility == true)
            {
                PassB.Password = Txb.Text;
            }
            else
            {
                Txb.Text = PassB.Password;
            }

            using (var db = new LabDBEntities())
            {
                var auth = db.Users.AsNoTracking().FirstOrDefault(m => m.login == LogTb.Text && m.password == PassB.Password && m.password == Txb.Text);
                if (auth != null)
                {
                    Globals.type = auth.type;
                    Globals.fullName = auth.fullName;
                    if (Globals.type == 4)
                    {
                        MessageBox.Show("Вы вошли с правами Администратора");
                    }
                    else if (Globals.type == 3)
                    {
                        Users user = db.Users.Find(auth.id);
                        user.lastenter = DateTime.Now.Date;
                        db.SaveChanges();
                        MessageBox.Show("Вы вошли с правами Бухгалтера");
                    }
                    else if (Globals.type == 2)
                    {
                        Users user = db.Users.Find(auth.id);
                        user.lastenter = DateTime.Now.Date;
                        db.SaveChanges();
                        MessageBox.Show("Вы вошли с правами Лаборанта-исследователя");
                    }
                    else
                    {
                        Users user = db.Users.Find(auth.id);
                        user.lastenter = DateTime.Now.Date;
                        db.SaveChanges();
                        MessageBox.Show("Вы вошли с правами Лаборанта");
                    }
                    WorkerWindow Wwin = new WorkerWindow();
                    Wwin.Show();
                    Close();
                }
                else
                {
                    if (enterCapcha == true)
                    {
                        MessageBox.Show("Вход заблокирован на 10 секунд!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        ban_timer();
                    }
                    else
                    {
                        enterCapcha = true;
                        MessageBox.Show("Неверный логин или пароль, пройдите капчу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        BorderCapcha.Visibility = Visibility.Visible;
                        CodeCapcha.Visibility = Visibility.Visible;
                        CapchaBlock.Visibility = Visibility.Visible;
                        CapchaBox.Visibility = Visibility.Visible;
                        RefreshBtn.Visibility = Visibility.Visible;
                        CheckBtn.Visibility = Visibility.Visible;
                        gencode();
                    }
                }
            }
        }
    }
}
