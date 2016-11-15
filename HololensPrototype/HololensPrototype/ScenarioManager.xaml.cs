using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
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
                byte[] fileBytes = File.ReadAllBytes(@dialogWindow.FileName);
                int fileSize = Convert.ToInt32(new FileInfo(dialogWindow.FileName).Length);
                string fileName = dialogWindow.FileName.Substring(dialogWindow.FileName.LastIndexOf("\\") + 1);

                using (MySqlConnection conn = new MySqlConnection("ENTER SQL CONNECTION HERE"))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "Delete * FROM Scenarios WHERE fileName='" + fileName + "';";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "INSERT INTO Scenarios (fileName, fileSize, file) VALUES (?fileName, ?fileSize, ?fileBytes);";
                        MySqlParameter fName = new MySqlParameter("?fileName", MySqlDbType.VarChar, 256);
                        MySqlParameter fSize = new MySqlParameter("?fileSize", MySqlDbType.Int32, 11);
                        MySqlParameter fContent = new MySqlParameter("?fileBytes", MySqlDbType.Blob, fileBytes.Length);

                        fName.Value = fileName;
                        fSize.Value = fileSize;
                        fContent.Value = fileBytes;

                        cmd.Parameters.Add(fName);
                        cmd.Parameters.Add(fSize);
                        cmd.Parameters.Add(fContent);

                        conn.Open();

                        cmd.ExecuteNonQuery();

                    }
                }
            }
        }
    }
}
