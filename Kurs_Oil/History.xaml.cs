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
    public partial class History : Window
    {
        public History()
        {
            InitializeComponent();
            gr691_tkpEntities db = new gr691_tkpEntities();
            AVGCalculation.ItemsSource = db.K_AVGCalculations.Where(i => i.FK_User_Id == Idd.Id).ToList();
            CostCalculation.ItemsSource = db.K_CostCalculations.Where(i => i.FK_User_Id == Idd.Id).ToList();
            DistCalculation.ItemsSource = db.K_DistanceCalculations.Where(i => i.FK_User_Id == Idd.Id).ToList();
        }
        private void Button_Back(object sender, RoutedEventArgs e)
        {
            Main main = new Main();
            main.Show();
            Close();
        }
    }
}