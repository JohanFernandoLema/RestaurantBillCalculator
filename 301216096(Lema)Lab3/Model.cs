using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301216096_Lema_Lab3
{
    public class MenuItem
    {
        //Constructor to store the name and price of our items 
        public MenuItem(string name, float price)
        {
            //Create to fields within our Constructor to store our name and price
            ItemName = name;
            ItemPrice = price;
        }

        //Properties for item and price
        public string ItemName { get; set; }
        public float ItemPrice { get; set; }
    }

    //class that is inherited from another class

    public class OrderedItem : MenuItem, INotifyPropertyChanged
    {

        public OrderedItem(string name, float price) : base(name, price)
        {
            Quantity = 1;
        }

        //variable
        private int quantity;

        public event PropertyChangedEventHandler PropertyChanged;

        //Property 
        public int Quantity
        {
            //return quantity value
            get
            {
                return quantity;
            }
            //set quantity of value 2
            set
            {
                quantity = value;
            }
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    public class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Model()
        {
            Total = Tax = SubTotal = 0.0f;
            //Create a collection for beveragesd
            Beverages = new ObservableCollection<MenuItem>()
            {
            new MenuItem("Soda", 1.95f),
            new MenuItem("Tea", 1.50f),
            new MenuItem("Coffee", 1.25f),
            new MenuItem("Mineral Water", 2.95f),
            new MenuItem("Juice", 2.50f),
            new MenuItem("Milk", 1.50f)
            };
            //Create a collection for maincourse food
            MainCourse = new ObservableCollection<MenuItem>()
            {
            new MenuItem("Chicken Alfredo", 13.95f),
            new MenuItem("Chicken Picatta", 13.95f),
            new MenuItem("Turkey Club", 11.95f),
            new MenuItem("Lobster Pie", 19.95f),
            new MenuItem("Prime Rib", 20.95f),
            new MenuItem("Shrimp Scampi", 18.95f),
            new MenuItem("Turkey Dinner", 13.95f),
            new MenuItem("Stuffed Chicken", 14.95f)
            };
            //Create a collection for Appetizers
            Appetizer = new ObservableCollection<MenuItem>()
            {
            new MenuItem("Buffalo Wings", 5.95f),
            new MenuItem("Buffalo Fingers", 6.95f),
            new MenuItem("Potato Skins", 8.95f),
            new MenuItem("Nachos", 8.95f),
            new MenuItem("Mushroom Caps", 10.95f),
            new MenuItem("Chips and Salsa", 6.95f)
            };
            //Create a collection for Desserts
            Dessert = new ObservableCollection<MenuItem>()
            {
            new MenuItem("Apple Pie", 5.95f),
            new MenuItem("Sundae", 3.95f),
            new MenuItem("Carrot Cake", 5.95f),
            new MenuItem("Mud Pie", 4.95f),
            new MenuItem("Apple Crisp", 5.95f)
            };

            Order = new ObservableCollection<OrderedItem>();
        }

        //Property for beverages
        public ObservableCollection<MenuItem> Beverages { get; set; }

        //Property for maincourse
        public ObservableCollection<MenuItem> MainCourse { get; set; }

        //Property for appetizer
        public ObservableCollection<MenuItem> Appetizer { get; set; }

        //Property for dessert
        public ObservableCollection<MenuItem> Dessert { get; set; }

        //Property for order
        public ObservableCollection<OrderedItem> Order { get; set; }

        //double variable
        private float total;

        //property
        public float Total
        {
            //get property to return total variable value
            get { return total; }
            //change total value to the value of Total 
            set
            {
                total = value;
                RaisePropertyChanged(nameof(Total));
            }
        }

        //variable
        private float tax;

        //property
        public float Tax
        {
            //return tax value 
            get { return tax; }
            //change value of tax for Tax
            set
            {
                tax = value;
                RaisePropertyChanged(nameof(Tax));
            }
        }

        //variable
        private float subTotal;

        //Propery with get and set methods
        public float SubTotal
        {
            //get method to return the subtotal value
            get { return subTotal; }

            //Set the subtotal value to 
            set
            {
                subTotal = value;
                RaisePropertyChanged(nameof(SubTotal));
            }
        }
        //method to change the value of any item assigned to it. 
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Mtehod to calculate the bill over and over again. It depends on the items the user picks.
        public void RecalculateBill()
        {
            Total = Tax = SubTotal = 0.0f;
            foreach (var item in Order)
            {
                Total += item.ItemPrice * item.Quantity;
            }
            Tax = (float)(Total * 0.13);
            SubTotal = Total + Tax;
        }
        // Method to reduce prices until 0 again. 
        public void ClearBill()
        {
            Total = Tax = SubTotal = 0.0f;
        }
    }
}