using Pharmasy.DB;
using Pharmasy.Strategy;
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

namespace Pharmasy
{
    /// <summary>
    /// Логика взаимодействия для ShoppingCart.xaml
    /// </summary>
    public partial class ShoppingCart : UserControl
    {
        public List<Medicament> shoppingCart;
        public ShoppingCart(List<Medicament> medicaments)
        {
            InitializeComponent();
            Bill bill = new Bill();
            shoppingCart = medicaments;
            Cart.ItemsSource = shoppingCart;
            prise.Text = Convert.ToString(SumDlstBox());
            string a;
            a = prise.Text;
            String total1;
            if( a == "")
            {
                total.Content = "";
            }
            else
            {
                int b = int.Parse(a);
                total1 = Convert.ToString(bill.getTotal(b));
                total.Content = total1;
            }
            
        }

        public void Order(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Congratulations! Your order has been sent to the nearest pharmacy of our line. Expect it for three days.");
            Cart.ItemsSource = "";
            prise.Text = "";
            total.Content = "";
        }

            private decimal SumDlstBox()
        {
            return Cart.Items.Cast<Medicament>().Sum(f => Convert.ToInt32(f.Price));
        }

        
    }
}
