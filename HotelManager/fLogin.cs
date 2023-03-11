using DAO;
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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }
        public bool Login()
        {
            return AccountDAO.Instance.Login(txbUserName.Text, txbPassWord.Text);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

       
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (Login())
            {
               
                fManagement f = new fManagement(txbUserName.Text);
                this.Hide();
                f.ShowDialog();

                //txbUserName.Text = String.Empty;
                //txbPassWord.Text = String.Empty;
                //txbUserName.Focus();

            }
            else
            {
                MessageBox.Show( "Tên Đăng Nhập không tồn tại hoặc Mật Khẩu không đúng.\nVui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit__Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txbPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnLogin_Click_1(sender, null);
        }

      
    }
}
