using LabApp.Resources;
using LabApp.Windows;
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

namespace LabApp.Frames
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            InitializeComponent();
            DGrid.ItemsSource = LabDBEntities.GetContext().Orders.ToList();
            if (MainWindow.Globals.type == 1)
            {
                InsuranceBtn.Visibility = Visibility.Hidden;
                UserBtn.Visibility = Visibility.Hidden;
                ServiceBtn.Visibility = Visibility.Hidden;
            }
            else if (MainWindow.Globals.type == 3)
            {
                UserBtn.Visibility = Visibility.Hidden;
            }
        }

        private void GoToPatient(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PatientsPage());
        }

        private void GoToUser(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new UsersPage());
        }

        private void GoToService(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ServicesPage());
        }

        private void GoToIncurance(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new InsurancePage());
        }

        private void AddOrder(object sender, RoutedEventArgs e)
        {
            AddOrderWindow AOW = new AddOrderWindow();
            AOW.ShowDialog();
            DGrid.ItemsSource = LabDBEntities.GetContext().Orders.ToList();
        }

        private void DellOrder(object sender, RoutedEventArgs e)
        {
            if (DGrid.SelectedItem != null)
            {
                var Removing = DGrid.SelectedItems.Cast<Orders>().ToList();

                if (MessageBox.Show($"Вы точно хотите удалить следующие {Removing.Count()} элеметнов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        LabDBEntities.GetContext().Orders.RemoveRange(Removing);
                        LabDBEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные удаленны");
                        DGrid.ItemsSource = LabDBEntities.GetContext().Orders.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите заказ который хотите удалить", "Вниманеие", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
