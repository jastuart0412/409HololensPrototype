using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Permissions;
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
    /// Interaction logic for SurveyAnswerManager.xaml
    /// </summary>
    [PrincipalPermission(SecurityAction.Demand, Role = "Developer")]
    [PrincipalPermission(SecurityAction.Demand, Role = "Tester")]
    [PrincipalPermission(SecurityAction.Demand, Role = "Evaluator")]
    public partial class SurveyAnswerManager : Window
    {
        public ObservableCollection<String> surveys;
        public int selectedQuestion;
        List<String> questions;
        List<int> questionIndexes;
        List<String> surveyAnswers;

        public SurveyAnswerManager()
        {
            InitializeComponent();
        }

        private void loadSurveySelector(object sender, RoutedEventArgs e)
        {
            surveys = new ObservableCollection<String>();
            using (MySqlConnection conn = new MySqlConnection("Server=mysql-509.cs.iastate.edu; Database=db509t03;User Id=dbu509t03;Password = zebr8p@AgEsU; "))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "SELECT fileName FROM Survey;";
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        surveys.Add(reader.GetString(0));
                    }
                    reader.Close();
                }
            }
            SurveySelector.ItemsSource = surveys;
        }

        private void surveySelected(object sender, SelectionChangedEventArgs e)
        {
            questions = new List<String>();
            questionIndexes = new List<int>();
            using (MySqlConnection conn = new MySqlConnection("Server=mysql-509.cs.iastate.edu; Database=db509t03;User Id=dbu509t03;Password = zebr8p@AgEsU; "))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "SELECT ID,SurveyQuestion FROM SurveyQuestions;";
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        questions.Add(reader.GetString(1));
                        questionIndexes.Add(reader.GetInt32(0));
                    }
                    reader.Close();
                }
            }
            QuestionSelector.ItemsSource = questions;
        }

        private void QuestionSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            surveyAnswers = new List<String>();
            selectedQuestion = questionIndexes[QuestionSelector.SelectedIndex];
            using (MySqlConnection conn = new MySqlConnection("Server=mysql-509.cs.iastate.edu; Database=db509t03;User Id=dbu509t03;Password = zebr8p@AgEsU; "))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "SELECT SurveyAnswer FROM SurveyAnswers WHERE SurveyQuestionID=" + selectedQuestion + ";";
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        surveyAnswers.Add(reader.GetString(0));
                    }
                    reader.Close();
                }
            }
            AnswersList.ItemsSource = surveyAnswers;
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
