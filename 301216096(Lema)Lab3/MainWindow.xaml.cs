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

namespace _301216096_Lema_Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Create a user variable
        private readonly string MyVal = "Robert";
        
        //Create a password for our user 
        private readonly string MyPass = "Robert123";
        
        //Pass userName data to our property 
        public string MyProp { get { return MyVal; } }

        //Pass userPassword data to our property 
        public string MyProp1 { get { return MyPass; } }

        //Button to allow user to login
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if statement to check if user data is valid 
            if (uName.Text != MyProp || uPass.Password != MyProp1)
            {
                MessageBox.Show("User is not recognized");
            }
            else
            {
                //Open restaurant bill calculator
                RestaurantBillCalculator order = new RestaurantBillCalculator();
                order.Show();
                //Close login tab   
                this.Close();
            }
        }
    }
}