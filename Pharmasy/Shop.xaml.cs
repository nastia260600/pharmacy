using Pharmasy.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Pharmasy
{
    /// <summary>
    /// Логика взаимодействия для Shop.xaml
    /// </summary>
    public partial class Shop : UserControl
    {
        PharmasyContext database;
        List<Medicament> shoppingCart;

        public Shop(List<Medicament> medicaments)
        {
            InitializeComponent();
            shoppingCart = medicaments;
           
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            /*PharmasyContext database = new PharmasyContext();
            Goods.Items.Clear();
            var userList = database.Medicaments;
            Goods.ItemsSource = userList.ToList();*/
            database = new PharmasyContext();
            database.Medicaments.Load();
            medicamentsList.ItemsSource = database.Medicaments.Local.ToBindingList();

        }

        private void AddToCart(object sender, RoutedEventArgs e)
        {
            
           // ShoppingCart form = new ShoppingCart();
            Button button = (Button)sender;
            int id = (int)button.DataContext;
            shoppingCart.Add(database.Medicaments.Where(m => m.Id == id).FirstOrDefault());
             
        }

        


    }
}
