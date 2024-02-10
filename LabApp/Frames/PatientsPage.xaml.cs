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
    /// Логика взаимодействия для PatientsPage.xaml
    /// </summary>
    public partial class PatientsPage : Page
    {
        public PatientsPage()
        {
            InitializeComponent();
            DGrid.ItemsSource = LabDBEntities.GetContext().Patients.ToList();
            if (MainWindow.Globals.type == 1)
            {
                InsuranceBtn.Visibility = Visibility.Hidden;
                UserBtn.Visibility = Visibility.Hidden;
                ServiceBtn.Visibility = Visibility.Hidden;
                OrderBtn.Visibility = Visibility.Hidden;
                OrderBtn2.Visibility = Visibility.Visible;
            }
            else if (MainWindow.Globals.type == 3)
            {
                UserBtn.Visibility = Visibility.Hidden;

            }
        }

        private void GoToUser(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new UsersPage());
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

        private void AddPatient(object sender, RoutedEventArgs e)
        {
            AddPatientWindow APW = new AddPatientWindow();
            APW.ShowDialog();
            DGrid.ItemsSource = LabDBEntities.GetContext().Patients.ToList();
        }

        private void DellPatient(object sender, RoutedEventArgs e)
        {
            if (DGrid.SelectedItem != null)
            {
                var Removing = DGrid.SelectedItems.Cast<Patients>().ToList();

                if (MessageBox.Show($"Вы точно хотите удалить следующие {Removing.Count()} элеметнов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        LabDBEntities.GetContext().Patients.RemoveRange(Removing);
                        LabDBEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные удаленны");
                        DGrid.ItemsSource = LabDBEntities.GetContext().Patients.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите пациента которого хотите удалить", "Вниманеие", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Seatch_method(object sender, TextChangedEventArgs e)
        {
            if (SearchTxb.Text == "")
            {
                DGrid.ItemsSource = LabDBEntities.GetContext().Patients.ToList();
            }
            else
            {
                try
                {
                    var date = Convert.ToDateTime(SearchTxb.Text);

                    DGrid.ItemsSource = LabDBEntities.GetContext().Patients.Where(i => i.birthday == date).ToList();
                }
                catch
                {
                    try
                    {
                        int text = Convert.ToInt32(SearchTxb.Text);

                        DGrid.ItemsSource = LabDBEntities.GetContext().Patients.Where(i => i.id == text || i.passport_data == text).ToList();
                    }
                    catch
                    {
                        DGrid.ItemsSource = LabDBEntities.GetContext().Patients.Where(i => i.login == SearchTxb.Text || i.login.Contains(SearchTxb.Text)
                                                                                      || i.password == SearchTxb.Text || i.password.Contains(SearchTxb.Text)
                                                                                      || i.fullName == SearchTxb.Text || i.fullName.Contains(SearchTxb.Text)
                                                                                      || i.email == SearchTxb.Text || i.email.Contains(SearchTxb.Text)
                                                                                      || i.insurance_type == SearchTxb.Text || i.insurance_type.Contains(SearchTxb.Text)
                                                                                      || i.Insurance_companes.name == SearchTxb.Text || i.Insurance_companes.name.Contains(SearchTxb.Text)).ToList();
                    }
                }
            }
        }
    }
}
