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
using Pharmasy.DB;
using Pharmasy.DB.Support;

namespace Pharmasy
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User currentUser;
        public List<Medicament> shoppingCart;
        public static PharmasyContext Database;

        public MainWindow(User user)
        {
            InitializeComponent();
            currentUser = user;
            shoppingCart = new List<Medicament>();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
			UserHello.Text = "Hello, " + currentUser.Login;
            
            if(currentUser.RoleId != ModelConstants.AdminRoleId)
            {
                AddShop.Visibility = Visibility.Hidden;
            }
        }

        public void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void Logout(object sender, RoutedEventArgs e)
        {
            currentUser = null;
            StartPage s = new StartPage();
            s.Show();
            Close();
        }


        /*public MainWindow()
        {
            InitializeComponent();
        }*/

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            currentUser = null;
            Authorization auth = new Authorization();
            auth.Show();
            this.Close();
        }

        private void StackPanel_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            this.DragMove();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "Main":
                    usc = new Main();
                    GridMain.Children.Add(usc);
                    break;
                case "AddShop":
                    usc = new AddShop();
                    GridMain.Children.Add(usc);
                    break;
                case "Shop":
                    usc = new Shop(shoppingCart);
                    GridMain.Children.Add(usc);
                    break;
                case "ShoppingCart":
                    usc = new ShoppingCart(shoppingCart);
                    GridMain.Children.Add(usc);
                    break;
                default:
                    break;
            }
        }

        private void TabablzControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
