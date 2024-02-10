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
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        private Users _currentUser = new Users();
        public AddUserWindow()
        {
            InitializeComponent();
            DataContext = _currentUser;
            ServCb1.ItemsSource = LabDBEntities.GetContext().Services.ToList();
            ServCb2.ItemsSource = LabDBEntities.GetContext().Services.ToList();
            ServCb3.ItemsSource = LabDBEntities.GetContext().Services.ToList();
            ServCb4.ItemsSource = LabDBEntities.GetContext().Services.ToList();
            ServCb5.ItemsSource = LabDBEntities.GetContext().Services.ToList();
            TypeCb.ItemsSource = LabDBEntities.GetContext().Type.ToList();
            _currentUser.lastenter = DateTime.Now;
        }

        private void Add_User(object sender, RoutedEventArgs e)
        {
            StringBuilder Errors = new StringBuilder();

            if (LogTxb.Text == "")
                Errors.AppendLine("Введите логин");
            if (PassTxb.Text == "")
                Errors.AppendLine("Введите пароль");

            if (Errors.Length > 0)
            {
                MessageBox.Show(Errors.ToString());
                return;
            }

            LabDBEntities.GetContext().Users.Add(_currentUser);
            try
            {
                LabDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Пользователь добавлен");
                Close();
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
