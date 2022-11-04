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
using BusinessObject;
using DataAccess;
namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        IntefaceMemberRepository intefaceMemberRepository;
        public WindowLogin(IntefaceMemberRepository memberRepository)
        {
            InitializeComponent();
            intefaceMemberRepository =  memberRepository;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;
            if (intefaceMemberRepository.Login(email, password) == null)
            {
                MessageBox.Show("Login fail", "login");
            }
            else
            {
                MainWindow mainWindow = new MainWindow();
                try
                {
                    intefaceMemberRepository.InsertToJson(email, password);
                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "add to json");
                }
                mainWindow.Show();
            }
        }
    }
}
