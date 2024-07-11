using ADO_NET.DataBase;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADO_NET
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DB.ReadUsersToDb();
        }

        private void SignUpBTN_Click(object sender, RoutedEventArgs e)
        {
            LoginTXT.Text = string.Empty;
            PasswordTXT.Text = string.Empty;
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.ShowDialog();
        }

        private void SignInBTN_Click(object sender, RoutedEventArgs e)
        {
            if(DB.CheckLogin(LoginTXT.Text, PasswordTXT.Text))
            {
                MessageBox.Show("Login Successfuly");
            }
            else
            {
                MessageBox.Show("Login Error!");
                Close();
            }
        }
    }
}