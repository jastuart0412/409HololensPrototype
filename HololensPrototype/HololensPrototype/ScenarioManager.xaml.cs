using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Security.Principal;
using System.Security.Permissions;

namespace HololensPrototype
{
    /// <summary>
    /// Interaction logic for ScenarioManager.xaml
    /// </summary>
    [PrincipalPermission(SecurityAction.Demand, Role = "Developer")]
    public partial class ScenarioManager : Window
    {
        public ObservableCollection<SurveyTemplate> MyCollection;

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

                using (MySqlConnection conn = new MySqlConnection("Server=mysql-509.cs.iastate.edu; Database=db509t03;User Id=dbu509t03;Password = zebr8p@AgEsU;"))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        cmd.CommandText = "Delete FROM Scenario WHERE fileName='" + fileName + "';";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "INSERT INTO Scenario (fileName, fileSize, fileBytes, uploadDate) VALUES (?fileName, ?fileSize, ?fileBytes, ?uploadDate);";
                        MySqlParameter fName = new MySqlParameter("?fileName", MySqlDbType.VarChar, 256);
                        MySqlParameter fSize = new MySqlParameter("?fileSize", MySqlDbType.Int32, 11);
                        MySqlParameter fContent = new MySqlParameter("?fileBytes", MySqlDbType.Blob, fileBytes.Length);
                        MySqlParameter uploadDate = new MySqlParameter("?uploadDate", MySqlDbType.Date);

                        fName.Value = fileName;
                        fSize.Value = fileSize;
                        fContent.Value = fileBytes;
                        uploadDate.Value = DateTime.Now;

                        cmd.Parameters.Add(fName);
                        cmd.Parameters.Add(fSize);
                        cmd.Parameters.Add(fContent);
                        cmd.Parameters.Add(uploadDate);

                        cmd.ExecuteNonQuery();
                        MyCollection.Add(new SurveyTemplate { selected = false, surveyName = fileName, uploadDate = DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year });
                    }
                }
            }
        }

        private void DeleteScenarios_Click(object sender, RoutedEventArgs e)
        {
            List<SurveyTemplate> removedItems = new List<SurveyTemplate>();
            using (MySqlConnection conn = new MySqlConnection("Server=mysql-509.cs.iastate.edu; Database=db509t03;User Id=dbu509t03;Password = zebr8p@AgEsU; "))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    foreach (SurveyTemplate s in SurveyGrid.ItemsSource)
                    {
                        if (s.selected)
                        {
                            cmd.CommandText = "DELETE FROM Scenario WHERE fileName = '" + s.surveyName + "';";
                            cmd.ExecuteNonQuery();
                            removedItems.Add(s);
                        }
                    }
                }
            }
            foreach (SurveyTemplate s in removedItems)
            {
                MyCollection.Remove(s);
            }
        }

        private void SendScenario_Click(object sender, RoutedEventArgs e)
        {
            //Send signal and files
        }

        private void windowLoaded(object sender, RoutedEventArgs e)
        {
            MyCollection = new ObservableCollection<SurveyTemplate>();
            using (MySqlConnection conn = new MySqlConnection("Server=mysql-509.cs.iastate.edu; Database=db509t03;User Id=dbu509t03;Password = zebr8p@AgEsU; "))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "SELECT fileName,uploadDate FROM Scenario;";
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string x = reader.GetString(0);
                        //int y = reader.GetInt32(1);
                        DateTime date = reader.GetDateTime(1);
                        MyCollection.Add(new SurveyTemplate { selected = false, surveyName = x, uploadDate = date.Month + "/" + date.Day + "/" + date.Year });
                        //byte[] buff = new byte[y];
                        //reader.GetBytes(2, (long)0, buff, 0, y);
                    }
                    reader.Close();
                }
            }
            SurveyGrid.ItemsSource = MyCollection;
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
