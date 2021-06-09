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

namespace Kurs_Oil
{
    public partial class Administrator : Window
    {
        public Administrator()
        {
            InitializeComponent();
            gr691_tkpEntities db = new gr691_tkpEntities();
            Type_fuel.ItemsSource = db.K_TypeFuel.ToList();
            Users.ItemsSource = db.K_Users.ToList();
            UpLogin.ItemsSource = db.K_Users.ToList();
            UpTypeF.ItemsSource = db.K_TypeFuel.ToList();
        }
        private void Button_InsU(object sender, RoutedEventArgs e)
        {
            gr691_tkpEntities db = new gr691_tkpEntities();
            Admin ad = new Admin();
            ad.Button_InsU(Login.Text, Password.Password, SName.Text, FName.Text, MName.Text);
            Users.ItemsSource = db.K_Users.ToList();
            UpLogin.ItemsSource = db.K_Users.ToList();

            Login.Text = null;
            Password.Password = null;
            SName.Text = null;
            FName.Text = null;
            MName.Text = null;
        }
        private void Button_UpdU(object sender, RoutedEventArgs e)
        {
            gr691_tkpEntities db = new gr691_tkpEntities();
            Admin ad = new Admin();
            ad.Button_UpdU(UpLogin.Text, Login.Text, Password.Password, SName.Text, FName.Text, MName.Text);
            Users.ItemsSource = db.K_Users.ToList();
            UpLogin.ItemsSource = db.K_Users.ToList();

            Login.Text = null;
            Password.Password = null;
            SName.Text = null;
            FName.Text = null;
            MName.Text = null;
        }
        private void Button_DelU(object sender, RoutedEventArgs e)
        {
            gr691_tkpEntities db = new gr691_tkpEntities();
            Admin ad = new Admin();
            ad.Button_DelU(UpLogin.Text);
            Users.ItemsSource = db.K_Users.ToList();
            UpLogin.ItemsSource = db.K_Users.ToList();
        }
        private void Button_InsT(object sender, RoutedEventArgs e)
        {
            gr691_tkpEntities db = new gr691_tkpEntities();
            Admin ad = new Admin();
            ad.Button_InsT(TypeF.Text, Price.Text);
            Type_fuel.ItemsSource = db.K_TypeFuel.ToList();
            UpTypeF.ItemsSource = db.K_TypeFuel.ToList();

            TypeF.Text = null;
            Price.Text = null;
        }
        private void Button_UpdT(object sender, RoutedEventArgs e)
        {
            gr691_tkpEntities db = new gr691_tkpEntities();
            Admin ad = new Admin();
            ad.Button_UpdT(UpTypeF.Text, TypeF.Text, Price.Text);
            Type_fuel.ItemsSource = db.K_TypeFuel.ToList();
            UpTypeF.ItemsSource = db.K_TypeFuel.ToList();

            TypeF.Text = null;
            Price.Text = null;
        }
        private void Button_DelT(object sender, RoutedEventArgs e)
        {
            gr691_tkpEntities db = new gr691_tkpEntities();
            Admin ad = new Admin();
            ad.Button_DelT(UpTypeF.Text);
            Type_fuel.ItemsSource = db.K_TypeFuel.ToList();
            UpTypeF.ItemsSource = db.K_TypeFuel.ToList();
        }
        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            Authorization авторизация = new Authorization();
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Выйти из аккаунта?", "Выход", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                авторизация.Show();
                Close();
            }
        }
    }
}