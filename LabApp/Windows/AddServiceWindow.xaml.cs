using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

namespace LabApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddServiceWindow.xaml
    /// </summary>
    public partial class AddServiceWindow : Window
    {
        private Services _currentService = new Services();
        public AddServiceWindow()
        {
            InitializeComponent();
            DataContext = _currentService;
        }

        private void Add_Service(object sender, RoutedEventArgs e)
        {
            StringBuilder Errors = new StringBuilder();

            if (CodeTxb.Text == "")
                Errors.AppendLine("Введите номер услуги");
            if (ServTxb.Text == "")
                Errors.AppendLine("Введите название услуги");
            if (PriceTxb.Text == "")
                Errors.AppendLine("Введите ценну услуги");

            if (Errors.Length > 0)
            {
                MessageBox.Show(Errors.ToString());
                return;
            }

            LabDBEntities.GetContext().Services.Add(_currentService);
            try
            {
                LabDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Услуга добавлена");
                Close();
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
