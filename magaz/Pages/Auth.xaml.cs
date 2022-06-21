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
using magaz.DataBase;
using magaz.Pages;
namespace magaz.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
            
        }

        private void Button_Auth(object sender, RoutedEventArgs e)
        {
            User users = EFModel.init().Users.FirstOrDefault(u => u.UserLogin == UserLoginTb.Text &&
            u.UserPassword == UserPasswordTb.Password);
            if (users == null)
            {
                MessageBox.Show("Некорректный пароль или логин");
                return;
            }
            if (users.Role_RoleId == 1)
            {
                NavigationService.Navigate(new ListPage());
            }
        }
    }
}
