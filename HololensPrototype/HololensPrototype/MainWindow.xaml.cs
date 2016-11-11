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

namespace HololensPrototype
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

        private void openWindow(object sender, RoutedEventArgs e)
        {
            ScenarioManager window = new ScenarioManager();
            window.Show();
        }

        private void openSurveyWndow(object sender, RoutedEventArgs e)
        {
            SurveyManager window = new SurveyManager();
            window.Show();
        }

        private void openSurveyAnswerWindow(object sender, RoutedEventArgs e)
        {
            SurveyAnswerManager window = new SurveyAnswerManager();
            window.Show();
        }
    }
}
