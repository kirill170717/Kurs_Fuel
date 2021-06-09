﻿using System;
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
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }
        private void Button_Auth(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            bool close = auth.Button_Auth(Login.Text, Password.Password);
            if (close)
            {
                Close();
            }
        }
        private void Button_Reg(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            Close();
        }
    }
}