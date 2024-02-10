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
    /// Логика взаимодействия для ServicesPage.xaml
    /// </summary>
    public partial class ServicesPage : Page
    {
        public ServicesPage()
        {
            InitializeComponent();
            DGrid.ItemsSource = LabDBEntities.GetContext().Services.ToList();
            if (MainWindow.Globals.type == 3)
            {
                UserBtn.Visibility = Visibility.Hidden;
                InsuranceBtn2.Visibility = Visibility.Visible;
                InsuranceBtn.Visibility = Visibility.Hidden;
                OrderBtn2.Visibility = Visibility.Visible;
                OrderBtn.Visibility = Visibility.Hidden;
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

        private void GoToIncurance(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new InsurancePage());
        }

        private void AddService(object sender, RoutedEventArgs e)
        {
            AddServiceWindow ASW = new AddServiceWindow();
            ASW.ShowDialog();
            DGrid.ItemsSource = LabDBEntities.GetContext().Services.ToList();
        }

        private void DellService(object sender, RoutedEventArgs e)
        {
            if (DGrid.SelectedItem != null)
            {
                var Removing = DGrid.SelectedItems.Cast<Services>().ToList();

                if (MessageBox.Show($"Вы точно хотите удалить следующие {Removing.Count()} элеметнов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        LabDBEntities.GetContext().Services.RemoveRange(Removing);
                        LabDBEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные удаленны");
                        DGrid.ItemsSource = LabDBEntities.GetContext().Services.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите услугу которую хотите удалить", "Вниманеие", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Seatch_method(object sender, TextChangedEventArgs e)
        {
            if (SearchTxb.Text == "")
            {
                DGrid.ItemsSource = LabDBEntities.GetContext().Services.ToList();
            }
            else
            {
                try
                {
                    int text = Convert.ToInt32(SearchTxb.Text);

                    DGrid.ItemsSource = LabDBEntities.GetContext().Services.Where(i => i.code == text).ToList();
                }
                catch
                {
                    DGrid.ItemsSource = LabDBEntities.GetContext().Services.Where(i => i.price == SearchTxb.Text || i.price.Contains(SearchTxb.Text)
                                                                                  || i.service == SearchTxb.Text || i.service.Contains(SearchTxb.Text)).ToList();
                }
            }
        }
    }
}
