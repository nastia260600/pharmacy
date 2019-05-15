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
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Window
    {
		public static PharmasyContext Database;
		public StartPage()
        {
            InitializeComponent();
        }

        public void OpenAuthorizeWindow(object sender, RoutedEventArgs e)
        {
            Authorization a = new Authorization();
            a.Show();
            Close();
        }

        public void OpenRegisterWindow(object sender, RoutedEventArgs e)
        {
            Registration r = new Registration();
            r.Show();
            Close();
        }

		public void DbSeed(object sender, RoutedEventArgs e)
		{
			Database = new PharmasyContext();
			if (!Database.Roles.Any())
			{
				Database.Roles.Add(new Role { Id = ModelConstants.AdminRoleId, RoleName = ModelConstants.AdminRoleName });
				Database.SaveChanges();
				Database.Roles.Add(new Role { Id = ModelConstants.UserRoleId, RoleName = ModelConstants.UserRoleName });
				Database.SaveChanges();
				Database.Users.Add(new User { Login = "admin", Password = "admin", RoleId = ModelConstants.AdminRoleId });
				Database.SaveChanges();
			}
		}
	}
}
