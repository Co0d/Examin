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
    /// Логика взаимодействия для AddInsuranceWindow.xaml
    /// </summary>
    public partial class AddInsuranceWindow : Window
    {
        private Insurance_companes _currentInsurance = new Insurance_companes();
        public AddInsuranceWindow()
        {
            InitializeComponent();
            DataContext = _currentInsurance;
        }

        private void Add_Insurance(object sender, RoutedEventArgs e)
        {
            StringBuilder Errors = new StringBuilder();

            if (NameTxb.Text == "")
                Errors.AppendLine("Введите название страховой компании");
            if (AddressTxb.Text == "")
                Errors.AppendLine("Введите адрес страховой компании");
            if (INNTxb.Text == "" || INNTxb.Text.Length > 12)
                Errors.AppendLine("Введите ИНН страховой компании");
            if (KPPTxb.Text == "" || KPPTxb.Text.Length > 9)
                Errors.AppendLine("Введите КПП страховой комании");
            if (BIKTxb.Text == "" || BIKTxb.Text.Length > 8)
                Errors.AppendLine("Введите БИК страховой компании");

            if (Errors.Length > 0)
            {
                MessageBox.Show(Errors.ToString());
                return;
            }

            LabDBEntities.GetContext().Insurance_companes.Add(_currentInsurance);
            try
            {
                LabDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Страховая компания добавлена");
                Close();
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
