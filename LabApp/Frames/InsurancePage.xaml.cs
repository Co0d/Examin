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
    /// Логика взаимодействия для InsurancePage.xaml
    /// </summary>
    public partial class InsurancePage : Page
    {
        public InsurancePage()
        {
            InitializeComponent();
            DGrid.ItemsSource = LabDBEntities.GetContext().Insurance_companes.ToList();
            if (MainWindow.Globals.type == 3)
            {
                UserBtn.Visibility = Visibility.Hidden;
                OrderBtn.Visibility = Visibility.Hidden;
                OrderBtn2.Visibility = Visibility.Visible;
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

        private void GoToOrder(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new OrdersPage());
        }

        private void GoToService(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ServicesPage());
        }

        private void AddInsurance(object sender, RoutedEventArgs e)
        {
            AddInsuranceWindow AIW = new AddInsuranceWindow();
            AIW.ShowDialog();
            DGrid.ItemsSource = LabDBEntities.GetContext().Insurance_companes.ToList();
        }

        private void DellInsurance(object sender, RoutedEventArgs e)
        {
            if (DGrid.SelectedItem != null)
            {
                var Removing = DGrid.SelectedItems.Cast<Insurance_companes>().ToList();

                if (MessageBox.Show($"Вы точно хотите удалить следующие {Removing.Count()} элеметнов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        LabDBEntities.GetContext().Insurance_companes.RemoveRange(Removing);
                        LabDBEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные удаленны");
                        DGrid.ItemsSource = LabDBEntities.GetContext().Insurance_companes.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите страховую компанию которую хотите удалить", "Вниманеие", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
