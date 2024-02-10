using MedicalLab.Model;
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

namespace MedicalLab.ViewWindow
{
    /// <summary>
    /// Логика взаимодействия для PatientPage.xaml
    /// </summary>
    public partial class PatientPage : Page
    {
        LabMLEntities db = new LabMLEntities();

        public PatientPage()
        {
            InitializeComponent();
            GridPatients.ItemsSource = LabMLEntities.GetContext().patients.ToList();
            UpdateClients();


        }

        private void UpdateClients()
        {
            var currentPariens = LabMLEntities.GetContext().patients.ToList();

            currentPariens = currentPariens.Where(p => p.full_name.ToLower().Contains(TxbSearch.Text.ToLower())).ToList();


            GridPatients.ItemsSource = currentPariens.OrderBy(p => p.full_name).ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GridPatients.ItemsSource = db.patients.ToList();
        }

        private void TBoxSearch1TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateClients();
        }
    }
}
