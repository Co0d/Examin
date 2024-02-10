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


namespace LabApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для TImeoutWindow.xaml
    /// </summary>
    public partial class TImeoutWindow : Window
    {
        private int time = 5;

        private DispatcherTimer Timer;
        public TImeoutWindow()
        {
            InitializeComponent();
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            time--;
            Time.Text = string.Format("00:0{0}:0{1}", time / 60, time % 60);
            if (time == 0)
            {
                MessageBox.Show("Вход доступен");
                MainWindow MW = new MainWindow();
                MW.Show();
                Close();
            }
        }
    }
}
