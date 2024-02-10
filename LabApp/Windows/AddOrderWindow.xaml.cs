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
    /// Логика взаимодействия для AddOrderWindow.xaml
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        private Orders _currentOrder = new Orders();
        public AddOrderWindow()
        {
            InitializeComponent();
            DataContext = _currentOrder;
            ServCb1.ItemsSource = LabDBEntities.GetContext().Services.ToList();
            ServCb2.ItemsSource = LabDBEntities.GetContext().Services.ToList();
            ServCb3.ItemsSource = LabDBEntities.GetContext().Services.ToList();
            ServCb4.ItemsSource = LabDBEntities.GetContext().Services.ToList();
            ServCb5.ItemsSource = LabDBEntities.GetContext().Services.ToList();
            UserCb.ItemsSource = LabDBEntities.GetContext().Users.ToList();
            PatientCb.ItemsSource = LabDBEntities.GetContext().Patients.ToList();
        }

        private void Add_Order(object sender, RoutedEventArgs e)
        {
            StringBuilder Errors = new StringBuilder();

            if (ServCb1.SelectedItem == null)
                Errors.AppendLine("Введите услугу");
            if (UserCb.SelectedItem == null)
                Errors.AppendLine("Введите работника");
            if (PatientCb.SelectedItem == null)
                Errors.AppendLine("Введите пациента");

            if (Errors.Length > 0)
            {
                MessageBox.Show(Errors.ToString());
                return;
            }

            _currentOrder.createDate = DateTime.Now.Date;
            _currentOrder.order_status = false;
            _currentOrder.service_status = false;

            if (BarcodeTxb.Text == "" || BarcodeTxb.Text == "0")
            {
                LabDBEntities.GetContext().Orders.Add(_currentOrder);
                try
                {
                    LabDBEntities.GetContext().SaveChanges();

                    int id_pacient = ((Patients)PatientCb.SelectedItem).id;
                    Orders Order = LabDBEntities.GetContext().Orders.FirstOrDefault(i => i.patient_id == id_pacient && i.createDate == _currentOrder.createDate);
                    string code = "";
                    Random random = new Random();
                    string[] massiveCharacters = new string[]
                    { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                    for (int i = 0; i < 6; i++)
                    {
                        code += massiveCharacters[random.Next(0, massiveCharacters.Length)];
                    }
                    string barGen = Convert.ToString(Order.id) + DateTime.Now.Date.ToString().Remove(2, 1).Remove(4, 1).Remove(8) + code;
                    _currentOrder.barcode = Convert.ToInt64(barGen);

                    LabDBEntities.GetContext().SaveChanges();

                    MessageBox.Show("Заказ добавлен");
                    Close();
                }
                catch (DbEntityValidationException ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                try
                {
                    _currentOrder.barcode = Convert.ToInt64(BarcodeTxb.Text);

                    LabDBEntities.GetContext().Orders.Add(_currentOrder);
                    LabDBEntities.GetContext().SaveChanges();

                    MessageBox.Show("Заказ добавлен");
                    Close();
                }
                catch (DbEntityValidationException ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
