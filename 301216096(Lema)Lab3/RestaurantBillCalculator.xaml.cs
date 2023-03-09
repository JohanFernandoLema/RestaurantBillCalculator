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

namespace _301216096_Lema_Lab3
{
    public partial class RestaurantBillCalculator : Window
    {
        public RestaurantBillCalculator()
        {
            InitializeComponent();
            DataContext = new Model();
        }
        //Press button to delete item in the DataGrid
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dataContext = DataContext as Model;
            dataContext.ClearBill();
        }
        //Combobox to select Items 
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dataContext = DataContext as Model;
            //variable to add item
            var item = e.AddedItems[0] as MenuItem;
            //if statement to chec if data an item are null
            if (dataContext == null || item == null)
                return;

            if (dataContext.Order.Any(o => o.ItemName == item.ItemName))
            {
                var orderItem = dataContext.Order.First(o => o.ItemName == item.ItemName);
                orderItem.Quantity++;
            }
            //Statement to add a new item in the dataGrid
            else
            {
                dataContext.Order.Add(new OrderedItem(item.ItemName, item.ItemPrice));
            }

            dataContext.RecalculateBill();
        }
        //Close application
        private void shutDown_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //Method to open a website
        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.centennialcollege.ca");
        }
    }
}
