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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Security.Principal;

namespace HololensPrototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [PrincipalPermission(SecurityAction.Demand)]
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        private void openWindow(object sender, RoutedEventArgs e)
        {
            ScenarioManager window = new ScenarioManager();
            window.Show();
            this.Close();
        }

        private void openSurveyWndow(object sender, RoutedEventArgs e)
        {
            SurveyManager window = new SurveyManager();
            window.Show();
            this.Close();
        }

        private void openSurveyAnswerWindow(object sender, RoutedEventArgs e)
        {
            SurveyAnswerManager window = new SurveyAnswerManager();
            window.Show();
            this.Close();
        }

        private void logOut(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Application.Restart();
            System.Windows.Application.Current.Shutdown();
        }
    }
}
