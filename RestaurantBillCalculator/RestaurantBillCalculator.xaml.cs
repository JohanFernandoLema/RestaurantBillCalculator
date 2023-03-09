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

namespace RestaurantBillCalculator
{
    /// <summary>
    /// Interaction logic for RestaurantBillCalculator.xaml
    /// </summary>
    public partial class RestaurantBillCalculator : Window
    {
        public RestaurantBillCalculator()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var dataContext = DataContext as Model;
            var item = e.AddedItems[0] as MenuItem;
            if (dataContext == null || item == null)
                return;

            if (dataContext.Order.Any(o => o.ItemName == item.ItemName))
            {
                var orderItem = dataContext.Order.First(o => o.ItemName == item.ItemName);
                orderItem.Quantity++;
            }
            else
            {
                dataContext.Order.Add(new OrderedItem(item.ItemName, item.ItemPrice));
            }

            dataContext.RecalculateBill();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dataContext = DataContext as Model;
            dataContext.ClearBill();
        }
    }
}
