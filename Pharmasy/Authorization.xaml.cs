using Pharmasy.DB;
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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public static PharmasyContext Database;

        public Authorization()
        {
            InitializeComponent();
        }

        public void Authorize(object sender, RoutedEventArgs e)
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

            User user = Database.Users.Where(u => u.Login == Login.Text && u.Password == Password.Password).FirstOrDefault();

            if (user == null)
            {
                Error.Text = "Invalid login or password";
                return;
            }

            GoToMain(user);
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
