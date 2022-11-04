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
using DataAccess;
using BusinessObject;
namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowMembers.xaml
    /// </summary>
    public partial class WindowMembers : Window
    {
        IntefaceMemberRepository interMemberRepository;
        public WindowMembers(IntefaceMemberRepository memberRepository)
        {
            InitializeComponent();
            interMemberRepository = memberRepository;
        }

        private Member GetMemberObject()
        {
            Member member = null;
            try
            {
                member = new Member
                {
                    MemberId = int.Parse(txtMemberId.Text.Trim()),
                    Email = txtEmail.Text.Trim(),
                    CompanyName = txtCompanyName.Text.Trim(),
                    City = txtCity.Text.Trim(),
                    Country = txtCountry.Text.Trim(),
                    Password = txtPassword.Text.Trim()
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get member");
            }
            return member;
        }

        public void LoadMemberList()
        {
            lvMembers.ItemsSource = interMemberRepository.GetMembers();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadMemberList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load member list");
            }
        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Member _member = GetMemberObject();
                interMemberRepository.InsertMember(_member);
                LoadMemberList();
                MessageBox.Show($"{_member.MemberId} inserted successfully", "Insert Member");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Member");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Member _member = GetMemberObject();
                interMemberRepository.UpdateMember(_member);
                LoadMemberList();
                MessageBox.Show($"{_member.MemberId} updated successfully", "Update Member");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Member");
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Member _member = GetMemberObject();
                interMemberRepository.DeleteMember(_member);
                LoadMemberList();
                MessageBox.Show($"{_member.MemberId} deleted successfully", "Delete Member");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Member");
            }

        }
        private void btnClose_Click(object sender, RoutedEventArgs e) => Close();

    }
}
