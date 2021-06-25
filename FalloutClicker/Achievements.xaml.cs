using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace FalloutClicker
{
    /// <summary>
    /// Логика взаимодействия для Achievements.xaml
    /// </summary>
    public partial class Achievements : Window
    {
        player player = new player();
        private double val;
        private double srav = 0;
        public Achievements()
        {
            InitializeComponent();
            kostil.Visibility = Visibility.Visible;  
        }
      }

    }
