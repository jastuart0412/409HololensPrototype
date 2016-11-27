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
using System.Threading;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Security.Principal;
using System.Security.Permissions;

namespace HololensPrototype
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = usernameBox.Text;
            string hash = CalculateHash(passwordBox.Password);
            string dbHash = "";
            string[] roles = new string[2];

            try
            {
                using (MySqlConnection conn = new MySqlConnection("Server=mysql-509.cs.iastate.edu; Database=db509t03;User Id=dbu509t03;Password = zebr8p@AgEsU; "))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        cmd.CommandText = "SELECT Password, Role FROM Users WHERE Username = '" + user + "';";
                        MySqlDataReader rdr = cmd.ExecuteReader();
                        rdr.Read();
                        dbHash = rdr[0].ToString();
                        roles[0] = rdr[1].ToString();
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            

            if (hash.Equals(dbHash, StringComparison.OrdinalIgnoreCase))
            {
                // login successful
                Console.WriteLine("successful login by " + user);
                GenericIdentity id = new GenericIdentity(user, "");
                GenericPrincipal principal = new GenericPrincipal(id, roles);
                AppDomain.CurrentDomain.SetThreadPrincipal(principal);
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();
            }
            else
            {
                Console.WriteLine("unsuccessful login attempt by " + user);
                Console.WriteLine("input hash: " + hash);
                Console.WriteLine("db hash: " + dbHash);
                usernameBox.Clear();
                passwordBox.Clear();
                Status.Text = "Invalid credentials. Please try again.";
            }

        }

        private string CalculateHash(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
            byte[] hash = md5.Hash;
            StringBuilder strb = new StringBuilder();
            for (int i=0; i<hash.Length; i++)
            {
                strb.Append(hash[i].ToString("x2"));
            }

            return strb.ToString();
        }
    }
}
