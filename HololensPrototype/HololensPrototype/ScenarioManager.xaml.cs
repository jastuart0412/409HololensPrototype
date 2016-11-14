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

namespace HololensPrototype
{
    /// <summary>
    /// Interaction logic for ScenarioManager.xaml
    /// </summary>
    public partial class ScenarioManager : Window
    {
        public ScenarioManager()
        {
            InitializeComponent();
        }

        private void UploadScenario_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialogWindow = new Microsoft.Win32.OpenFileDialog();

            Nullable<bool> file = dialogWindow.ShowDialog();

            if(file==true)
            {

            }
        }
    }
}
