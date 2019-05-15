using Pharmasy.DB;
using Pharmasy.DB.Support;
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
using System.Windows.Shapes;

namespace Pharmasy
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public static PharmasyContext Database;

        public Registration()
        {
            InitializeComponent();
        }

        public void Register(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "")
            {
                Error.Text = "Enter your login";
                return;
            }

            if (Password.Password == "")
            {
                Error.Text = "Enter your password";
                return;
            }
            Database = new PharmasyContext();

			var existUser = Database.Users.Where(u => u.Login == Login.Text).FirstOrDefault();

            if (existUser != null)
            {
                Error.Text = "User with this login are already exist";
                return;
            }
            User newUser = new User();
            newUser.Login = Login.Text;
            newUser.Password = Password.Password;
            newUser.RoleId = (Convert.ToBoolean(Admin.IsChecked)) ? ModelConstants.AdminRoleId : ModelConstants.UserRoleId;

            Database.Users.Add(newUser);
            Database.SaveChanges();

            GoToMain(newUser);
        }

        public void BackToStart(object sender, RoutedEventArgs e)
        {
            StartPage s = new StartPage();
            s.Show();
            Close();
        }

        private void GoToMain(User user)
        {
            MainWindow m = new MainWindow(user);
            m.Show();
            Close();
        }

        private void Rectangle_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            DragMove();
        }
    }
}
