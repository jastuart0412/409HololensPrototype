using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SurveyWindow.xaml
    /// </summary>
    public partial class SurveyWindow : Window
    {
        public ObservableCollection<string> MyCollection;
        public List<string> questions;
        public List<string> questionIDs;

        public SurveyWindow()
        {
            InitializeComponent();
        }

        private void formLoaded(object sender, RoutedEventArgs e)
        {
            MyCollection = new ObservableCollection<string>();
            using (MySqlConnection conn = new MySqlConnection("Server=mysql-509.cs.iastate.edu; Database=db509t03;User Id=dbu509t03;Password = zebr8p@AgEsU; "))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "SELECT DISTINCT SurveyName FROM SurveyQuestions;";
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string x = reader.GetString(0);
                        //int y = reader.GetInt32(1);
                        MyCollection.Add(x);
                        //byte[] buff = new byte[y];
                        //reader.GetBytes(2, (long)0, buff, 0, y);
                    }
                    reader.Close();
                }
            }
            surveys.ItemsSource = MyCollection;
        }

        private void surveys_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            questions = new List<string>();
            questionIDs = new List<string>();
            using (MySqlConnection conn = new MySqlConnection("Server=mysql-509.cs.iastate.edu; Database=db509t03;User Id=dbu509t03;Password = zebr8p@AgEsU; "))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "SELECT * FROM SurveyQuestions WHERE SurveyName = '" + surveys.SelectedValue + "';";
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string x = reader.GetString(2);
                        //int y = reader.GetInt32(1);
                        questions.Add(x);
                        questionIDs.Add(reader.GetString(0));
                        //byte[] buff = new byte[y];
                        //reader.GetBytes(2, (long)0, buff, 0, y);
                    }
                    reader.Close();
                }
            }

            int i = 0;
            NameScope.SetNameScope(this, new NameScope());
            foreach (string s in questions)
            {
                Label label = new Label();
                label.Height = 28;
                label.Width = 100;
                label.HorizontalAlignment = HorizontalAlignment.Left;
                label.VerticalAlignment = VerticalAlignment.Top;
                label.Content = s;
                QuestionGrid.Children.Add(label);
                Grid.SetColumn(label, 0);
                Grid.SetRow(label, i);

                TextBox txt = new TextBox();
                txt.Width = 200;
                txt.Height = 100;
                txt.Text = "";
                txt.Name = s.Replace(" ", "WASASPACE");
                RegisterName(txt.Name, txt);
                QuestionGrid.RowDefinitions.Add(new RowDefinition());
                Grid.SetColumn(txt, 1);
                Grid.SetRow(txt, i);
                QuestionGrid.Children.Add(txt);
                i++;
            }
        }

        private void submitSurvey(object sender, RoutedEventArgs e)
        {
            QuestionGrid.ApplyTemplate();
            int i = 0;
            foreach (string s in questions)
            {
                var x = s.Replace(" ", "WASASPACE");
                var text = (TextBox)this.FindName(x);
                
                

                using (MySqlConnection conn = new MySqlConnection("Server=mysql-509.cs.iastate.edu; Database=db509t03;User Id=dbu509t03;Password = zebr8p@AgEsU;"))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        string t = text.Text;
                        if (t == "")
                            t = "Not Answered";
                        cmd.CommandText = "INSERT INTO SurveyAnswers (SurveyQuestionID,SurveyAnswer) VALUES (" + questionIDs[i].ToString() +",'" + t + "');";

                        cmd.ExecuteNonQuery();
                    }
                }
                i++;
            }
        }
    }
}
