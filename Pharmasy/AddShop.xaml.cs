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
    /// Логика взаимодействия для AddShop.xaml
    /// </summary>
    public partial class AddShop : UserControl
    {
        PharmasyContext database;
        public AddShop()
        {
            InitializeComponent();
            database = new PharmasyContext();
            database.Medicaments.Load(); // загружаем данные
            medicamentsGrid.ItemsSource = database.Medicaments.Local.ToBindingList(); // устанавливаем привязку к кэшу
        }
        private void Button_Save(object sender, RoutedEventArgs e)
        {
            database.SaveChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (medicamentsGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < medicamentsGrid.SelectedItems.Count; i++)
                {
                    Medicament medicament = medicamentsGrid.SelectedItems[i] as Medicament;
                    if (medicament != null)
                    {
                        database.Medicaments.Remove(medicament);
                    }
                }
            }
            database.SaveChanges();
        }
    }
}
