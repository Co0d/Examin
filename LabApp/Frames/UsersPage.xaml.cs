using LabApp.Resources;
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
using LabApp.Windows;

namespace LabApp.Frames
{
    /// <summary>
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();
            DGrid.ItemsSource = LabDBEntities.GetContext().Users.ToList();
        }

        private void GoToPatient(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PatientsPage());
        }

        private void GoToService(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ServicesPage());
        }

        private void GoToOrder(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new OrdersPage());
        }

        private void GoToIncurance(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new InsurancePage());
        }

        private void AddUser(object sender, RoutedEventArgs e)
        {
            AddUserWindow AUW = new AddUserWindow();
            AUW.ShowDialog();
            DGrid.ItemsSource = LabDBEntities.GetContext().Users.ToList();
        }

        private void DellUser(object sender, RoutedEventArgs e)
        {
            if (DGrid.SelectedItem != null)
            {
                var Removing = DGrid.SelectedItems.Cast<Users>().ToList();

                if (MessageBox.Show($"Вы точно хотите удалить следующие {Removing.Count()} элеметнов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        LabDBEntities.GetContext().Users.RemoveRange(Removing);
                        LabDBEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные удаленны");
                        DGrid.ItemsSource = LabDBEntities.GetContext().Users.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователя которого хотите удалить", "Вниманеие", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
