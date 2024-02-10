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
using System.Windows.Threading;
using LabApp.Frames;
using LabApp.Resources;

namespace LabApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для WorkerWindow.xaml
    /// </summary>
    public partial class WorkerWindow : Window
    {
        bool alert = true;
        
        private int time = 60;

        private DispatcherTimer Timer;
        
        public WorkerWindow()
        {
            InitializeComponent();
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick;
            UserName.Text = MainWindow.Globals.fullName;
            if (MainWindow.Globals.type == 1)
            {
                var uriImageSource = new Uri(@"\Resources\laborant_1.jpeg", UriKind.RelativeOrAbsolute);
                UserImage.Source = new BitmapImage(uriImageSource);
                Timer.Start();

                MainFrame.Navigate(new PatientsPage());
                Manager.MainFrame = MainFrame;

            }
            else if (MainWindow.Globals.type == 2)
            {
                var uriImageSource = new Uri(@"\Resources\laborant_2.png", UriKind.RelativeOrAbsolute);
                UserImage.Source = new BitmapImage(uriImageSource);
                Timer.Start();

                MainFrame.Navigate(new PatientsPage());
                Manager.MainFrame = MainFrame;
                //Отравлять в фрейм с анализатором
            }
            else if (MainWindow.Globals.type == 3)
            {
                var uriImageSource = new Uri(@"\Resources\Бухгалтер.jpeg", UriKind.RelativeOrAbsolute);
                UserImage.Source = new BitmapImage(uriImageSource);

                MainFrame.Navigate(new PatientsPage());
                Manager.MainFrame = MainFrame;
            }
            else
            {
                var uriImageSource = new Uri(@"\Resources\Администратор.png", UriKind.RelativeOrAbsolute);
                UserImage.Source = new BitmapImage(uriImageSource);

                MainFrame.Navigate(new UsersPage());
                Manager.MainFrame = MainFrame;
            }
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                if (time <= 10)
                {
                    if (alert == true)
                    {
                        MessageBox.Show("До кварцевания помещения осталось 30 минут");
                        alert = false;
                    }
                    else
                    {
                        time--;
                        TimerCount.Text = string.Format("00:0{0}:0{1}", time / 60, time % 60);
                    }
                }
                else
                {
                    time--;
                    TimerCount.Text = string.Format("00:0{0}:{1}", time / 60, time % 60);
                }
            }
            else
            {
                Timer.Stop();
                MessageBox.Show("Приложение будет отключенно на время кварцевания помещения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                TImeoutWindow Quartz = new TImeoutWindow();
                Quartz.Show();
                Close();
            }
        }

        private void ExitBtn(object sender, RoutedEventArgs e)
        {
            Timer.Tick -= Timer_Tick;
            Timer.Stop();
            MainWindow AuthWin = new MainWindow();
            AuthWin.Show();
            Close();
        }
    }
}
