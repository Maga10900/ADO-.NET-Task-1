using ADO_NET.DataBase;
using ADO_NET.Models;

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

namespace ADO_NET
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void SignUpBTN_Click_1(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.Name = NameTXT.Text;
            user.Surname = SurnameTXT.Text;
            user.Age = int.Parse(AgeTXT.Text);
            user.Login = LoginTXT.Text;
            user.Password = PasswordTXT.Text;
            if ((DB.CheckUserName(user.Login)))
            {

                if (DB.CheckPassword(PasswordTXT.Text, C_PasswordTXT.Text))
                {
                    DB.users.Add(user);
                    DB.WriteUsersToDb();
                    MessageBox.Show("Regisered Successfuly");
                    Close();
                }
                else 
                {
                    C_PasswordTXT.Text = string.Empty;
                    MessageBox.Show("Confirm Password Error!");
                }
            }
            else
            {
                MessageBox.Show("Bu Login-e sahib bir user var!");
                Close();
            }

        }
    }
}
