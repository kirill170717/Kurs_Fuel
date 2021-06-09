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
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            gr691_tkpEntities db = new gr691_tkpEntities();
            TypeF.ItemsSource = db.K_TypeFuel.ToList();
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
               && (!Filled.Text.Contains(".")
               && Filled.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }
        private void Button_EnterAVG(object sender, RoutedEventArgs e)
        {
            User user = new User();
            bool result = user.Button_EnterAVG(Filled.Text, Passed.Text);
            if (result)
            {
                ResultAVG.Text = Result.RAVG.ToString() + " л/100 км";
            }
        }
        private void Button_EnterCost(object sender, RoutedEventArgs e)
        {
            User user = new User();
            string typef = (TypeF.SelectedItem as K_TypeFuel).Type_Id.ToString();
            bool result = user.Button_EnterCost(Distance.Text, Consuption.Text, typef);
            if (result)
            {
                ResultCost1.Text = "Необходимо залить " + Result.RL.ToString() + " л.";
                ResultCost2.Text = Result.RCost.ToString() + " руб.";
            }
        }
        private void Button_EnterDist(object sender, RoutedEventArgs e)
        {
            User user = new User();
            bool result = user.Button_EnterDist(ConsuptionDist.Text, FilledDist.Text);
            if (result)
            {
                ResultDist.Text = "Вы проедете " + Result.RDist.ToString() + " км.";
            }
        }
        private void Button_Hist(object sender, RoutedEventArgs e)
        {
            History history = new History();
            history.Show();
            Close();
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