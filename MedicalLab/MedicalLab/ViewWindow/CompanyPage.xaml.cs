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
    /// Логика взаимодействия для CompanyPage.xaml
    /// </summary>
    public partial class CompanyPage : Page
    {
        LabMLEntities db = new LabMLEntities();

        public CompanyPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GridCompany.ItemsSource = db.Company.ToList();
        }
    }
}
