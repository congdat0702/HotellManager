using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fManagement: Form
    {
        private string userName;
        public fManagement(string userName)
        {
            this.userName = userName;
            InitializeComponent();
            fLoad();
        }
        public bool IsAdmin()
        {
            return AccountTypeDAO.Instance.GetStaffTypeByUserName(userName).Id == "CD001";
        }
        void fLoad()
        {

            panelLeft.Width = 177;
            
        }
        private bool CheckAccess(string nameform)
        {
            return AccessDAO.Instance.CheckAccess(userName, nameform);
        }
       
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

 

       
        private void btnNavigationPanel_Click_1(object sender, EventArgs e)
        {
            if (panelLeft.Width == 42)
            {
                panelLeft.Width = 177;
                panelRight.Width = 939;
                this.Width = 1116;
            }
            else
            {
                panelLeft.Width = 42;
                panelRight.Width = 807;
                this.Width = 981;
            }
        }

        private void titleSignUpRoom_Click(object sender, EventArgs e)
        {
            if (CheckAccess("fBookRoom"))
            {
                Hide();
                fBookRoom f = new fBookRoom();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else MessageBox.Show("Bạn không quyền truy cập.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            
           
            fLogin login = new fLogin();
            this.Hide();
            login.ShowDialog();
            this.Show();
        }

        private void titleRecieveRoom_Click(object sender, EventArgs e)
        {
            if (CheckAccess("fReceiveRoom"))
            {
                
                fReceiveRoom f = new fReceiveRoom();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else MessageBox.Show("Bạn không quyền truy cập.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void titleSendRoom_Click(object sender, EventArgs e)
        {
            
            fUseService f = new fUseService(userName);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void titlePay_Click(object sender, EventArgs e)
        {
            if (CheckAccess("fUseService"))
            {
               
                fUseService f = new fUseService(userName);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else MessageBox.Show("Bạn không quyền truy cập.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void titleManageRoom_Click(object sender, EventArgs e)
        {
            if (CheckAccess("froom"))
            {
                
                fRoom fProfile = new fRoom();
                this.Hide();
                fProfile.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Bạn không quyền truy cập.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            

        }
        private void btnAccountProfile_Click(object sender, EventArgs e)
        {
            
            fProfile fProfile = new fProfile(userName);
            this.Hide();
            fProfile.ShowDialog();
            this.Show();
        }

        private void metroTile17_Click(object sender, EventArgs e)
        {
            if (CheckAccess("fcustomer"))
            {
               
                fCustomer customer = new fCustomer();
                this.Hide();
                customer.ShowDialog();
                this.Show();
            }
            else
              MessageBox.Show( "Bạn không quyền truy cập.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           
        }

        private void metroTile13_Click(object sender, EventArgs e)
        {
            if (CheckAccess("fparameter"))
            {
                fParameter parameter = new fParameter();
                this.Hide();
                parameter.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show( "Bạn không quyền truy cập.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
            if (CheckAccess("fstaff"))
            {
               
                fStaff fProfile = new fStaff();
                this.Hide();
                fProfile.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show( "Bạn không quyền truy cập.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void metroTile2_Click(object sender, EventArgs e)
        { 
            if (CheckAccess("fservice"))
            {
                
                fService fProfile = new fService();
                this.Hide();
                fProfile.ShowDialog();
                this.Show();
            }
            else
               MessageBox.Show( "Bạn không quyền truy cập.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnIntroduce_Click(object sender, EventArgs e)
        {
            
            fAbout fAbout = new fAbout();
            this.Hide();
            fAbout.ShowDialog();
            this.Show();
        }

        private void title_Click(object sender, EventArgs e)
        {
            if(CheckAccess("freport"))
            {
                fReport fAbout = new fReport();
                this.Hide();
                fAbout.ShowDialog();
                this.Show();
            }
            else
              MessageBox.Show( "Bạn không quyền truy cập.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          
        }

        private void metroTile16_Click(object sender, EventArgs e)
        {
            if (CheckAccess("fBill"))
            {
                
                fBill fAbout = new fBill();
                this.Hide();
                fAbout.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show( "Bạn không quyền truy cập.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
