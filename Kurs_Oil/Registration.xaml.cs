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
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        private void Button_Reg(object sender, RoutedEventArgs e)
        {
            Reg reg = new Reg();
            reg.Button_Reg(Login.Text, Password.Password, SName.Text, FName.Text, MName.Text);
        }
        private void Button_Back(object sender, RoutedEventArgs e)
        {
            Authorization auth = new Authorization();
            auth.Show();
            Close();
        }
    }
}