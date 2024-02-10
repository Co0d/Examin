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
    /// Логика взаимодействия для AddPatientWindow.xaml
    /// </summary>
    public partial class AddPatientWindow : Window
    {
        private Patients _currentPatient = new Patients();
        public AddPatientWindow()
        {
            InitializeComponent();
            DataContext = _currentPatient;
            InsNameCB.ItemsSource = LabDBEntities.GetContext().Insurance_companes.ToList();
        }

        private void Add_Patient(object sender, RoutedEventArgs e)
        {
            StringBuilder Errors = new StringBuilder();

            if (LogTxb.Text == "")
                Errors.AppendLine("Введите логин");
            if (PassTxb.Text == "")
                Errors.AppendLine("Введите пароль");
            if (NameTxb.Text == "")
                Errors.AppendLine("Введите имя пациента");
            if (BirthTP.SelectedDate == null)
                Errors.AppendLine("Введите день рождения");
            if (PasporTxb.Text == "" || PasporTxb.Text.Length > 10)
                Errors.AppendLine("Введите паспортные данные");
            if (InsTxb.Text == "" || InsTxb.Text.Length > 14)
                Errors.AppendLine("Введите номер страхового полиса");
            if (InsTypeTxb.Text == "")
                Errors.AppendLine("Введите тип страхового полиса");
            if (InsNameCB.SelectedItem == null)
                Errors.AppendLine("Введите название страховой компании");

            if (Errors.Length > 0)
            {
                MessageBox.Show(Errors.ToString());
                return;
            }

            LabDBEntities.GetContext().Patients.Add(_currentPatient);
            try
            {
                LabDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Пациент добавлен");
                Close();
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
