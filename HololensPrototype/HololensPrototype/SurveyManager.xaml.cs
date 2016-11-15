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
using MySql.Data.MySqlClient;
using System.IO;

namespace HololensPrototype
{
    /// <summary>
    /// Interaction logic for SurveyManager.xaml
    /// </summary>
    public partial class SurveyManager : Window
    {
        public SurveyManager()
        {
            InitializeComponent();
        }

        private void UploadSurvery_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialogWindow = new Microsoft.Win32.OpenFileDialog();

            Nullable<bool> file = dialogWindow.ShowDialog();

            if (file == true)
            {
                byte[] fileBytes = File.ReadAllBytes(@dialogWindow.FileName);
                int fileSize = Convert.ToInt32(new FileInfo(dialogWindow.FileName).Length);
                string fileName = dialogWindow.FileName.Substring(dialogWindow.FileName.LastIndexOf("\\") + 1);

                using (MySqlConnection conn = new MySqlConnection("Server=mysql-509.cs.iastate.edu; Database=db509t03;User Id=dbu509t03;Password = zebr8p@AgEsU; "))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        cmd.CommandText = "Delete FROM Survey WHERE fileName='" + fileName + "';";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "INSERT INTO Survey (fileName, fileSize, fileBytes) VALUES (?fileName, ?fileSize, ?fileBytes);";
                        MySqlParameter fName = new MySqlParameter("?fileName", MySqlDbType.VarChar, 256);
                        MySqlParameter fSize = new MySqlParameter("?fileSize", MySqlDbType.Int32, 11);
                        MySqlParameter fContent = new MySqlParameter("?fileBytes", MySqlDbType.Blob, fileBytes.Length);

                        fName.Value = fileName;
                        fSize.Value = fileSize;
                        fContent.Value = fileBytes;

                        cmd.Parameters.Add(fName);
                        cmd.Parameters.Add(fSize);
                        cmd.Parameters.Add(fContent);

                        cmd.ExecuteNonQuery();

                    }
                }
            }
        }

        private void formLoad(object sender, RoutedEventArgs e)
        {
            SurveyGrid.Items.Add(new SurveyTemplate { surveyName = "Test", uploadDate = "Test Date" });
        }
    }

    public class SurveyTemplate
    {
        public string surveyName { get; set; }
        public string uploadDate { get; set; }
    }
}
