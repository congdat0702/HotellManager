
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;
namespace HotelManager
{
    public partial class fBookRoom : Form
    {

     string idbookroom;
        public fBookRoom()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            LoadRoomType();
            LoadCustomerType();
            LoadDate();
            LoadDays();
            LoadListBookRoom();
        }
        //Lấy danh sách loại phòng
        public void LoadRoomType()
        {
            cbRoomType.DataSource= RoomTypeDAO.Instance.LoadListRoomType();
            cbRoomType.DisplayMember = "Name";
        }
        //Thông tin loại phòng
        public void LoadRoomTypeInfo(string id)
        {
            RoomType roomType = RoomTypeDAO.Instance.LoadRoomTypeInfo(id);
            txbRoomTypeID.Text = roomType.Id.ToString();
            txbRoomTypeName.Text = roomType.Name;
            CultureInfo cultureInfo = new CultureInfo("vi-vn");
            txbPrice.Text = roomType.Price.ToString("c0",cultureInfo);
            txbAmountPeople.Text = roomType.LimitPerson.ToString();
        }
        //LoadDate
        public void LoadDate()
        {
            dpkDateOfBirth.Value = new DateTime(2000, 5, 30);
            dpkDateCheckIn.Value = DateTime.Now;
            dpkDateCheckOut.Value = DateTime.Now.AddDays(1);
        }
        //Tính ngày 
        public void LoadDays()
        {
            txbDays.Text = (dpkDateCheckOut.Value.Date - dpkDateCheckIn.Value.Date).Days.ToString();
        }
        //Load loại khách hàng
        public void LoadCustomerType()
        {
            cbCustomerType.DataSource = CustomerTypeDAO.Instance.LoadListCustomerType();
            cbCustomerType.DisplayMember = "Name";
        }
        //kiểm tra idcard có tồn tại hay không?
        public bool IsIdCardExists(string idCard)
        {
            return CustomerDAO.Instance.IsIdCardExists(idCard);
        }
        //Thêm thông tin khách hàng
        public void InsertCustomer(string id, string idCard, string name, string idCustomerType, DateTime dateofBirth, string address, int phonenumber, string sex, string nationality)
        {
            CustomerDAO.Instance.InsertCustomer(id,idCard, name, idCustomerType, dateofBirth, address, phonenumber, sex, nationality);
        }
        //Thông tin của khách hàng
        public void GetInfoByIdCard(string idCard)
        {
            Customer customer = CustomerDAO.Instance.GetInfoByIdCard(idCard);
            txbIDCard.Text = customer.IdCard.ToString();
            txbFullName.Text = customer.Name;
            txbAddress.Text = customer.Address;
            dpkDateOfBirth.Value = customer.DateOfBirth;
            cbSex.Text = customer.Sex;
            txbPhoneNumber.Text = customer.PhoneNumber.ToString();
            cbNationality.Text = customer.Nationality;
            cbCustomerType.Text = CustomerTypeDAO.Instance.GetNameByIdCard(idCard);
        }
        public void InsertBookRoom(string id, string idCustomer, string idRoomType, DateTime datecheckin, DateTime datecheckout, DateTime datebookroom)
        {
            BookRoomDAO.Instance.InsertBookRoom(id,idCustomer, idRoomType, datecheckin, datecheckout, datebookroom);
        }
        public string GetCurrentIDBookRoom(DateTime dateTime, string idbookroom)
        {
            return BookRoomDAO.Instance.GetCurrentIDBookRoom(dateTime, idbookroom);
        }
        public void LoadListBookRoom()
        {
            dataGridViewBookRoom.DataSource = BookRoomDAO.Instance.LoadListBookRoom(DateTime.Now.Date);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txbDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoomTypeInfo((cbRoomType.SelectedItem as RoomType).Id);
        }

        private void dpkDateCheckOut_onValueChanged(object sender, EventArgs e)
        {
            if (dpkDateCheckOut.Value < DateTime.Now)
                LoadDate();
            if (dpkDateCheckOut.Value <= dpkDateCheckIn.Value)
                LoadDate();
            LoadDays();
        }

        private void dpkDateCheckIn_onValueChanged(object sender, EventArgs e)
        {
            if (dpkDateCheckIn.Value <= DateTime.Now)
                LoadDate();
            if (dpkDateCheckOut.Value <= dpkDateCheckIn.Value)
                LoadDate();
            LoadDays();
        }

        private void txbIDCardSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                btnSearch_Click(sender, null);
        }

        private void txbIDCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        //Tìm kiếm thông tin khách hàng
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txbIDCardSearch.Text != String.Empty)
            {
                if (IsIdCardExists(txbIDCardSearch.Text))
                    GetInfoByIdCard(txbIDCardSearch.Text);
                else
                    MessageBox.Show("Thẻ căn cước/ CMND không tồn tại.\nVui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }
        public void ClearData()
        {
            txbIDCardSearch.Text = txbIDCard.Text = txbFullName.Text = txbAddress.Text = txbPhoneNumber.Text = cbNationality.Text = String.Empty;
            LoadDate();
        }
        //Đặt phòng
        private void btnBookRoom_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đặt phòng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txbIDCard.Text != String.Empty && txbFullName.Text != String.Empty && txbAddress.Text != String.Empty && txbPhoneNumber.Text != String.Empty && cbNationality.Text != String.Empty)
                {
                    if (!IsIdCardExists(txbIDCard.Text))
                    {
                        string idCustomerType = (cbCustomerType.SelectedItem as CustomerType).Id;
                        txtIDCustomer.Text =GetAutomaticIDCustomer();

                        InsertCustomer(txtIDCustomer.Text,txbIDCard.Text, txbFullName.Text, idCustomerType, dpkDateOfBirth.Value, txbAddress.Text, int.Parse(txbPhoneNumber.Text), cbSex.Text, cbNationality.Text);
                    }
                    string idBookroom =  GetAutomaticIDBookRoom();
                    InsertBookRoom(idBookroom,CustomerDAO.Instance.GetInfoByIdCard(txbIDCard.Text).Id, (cbRoomType.SelectedItem as RoomType).Id, dpkDateCheckIn.Value, dpkDateCheckOut.Value, DateTime.Now);
                    MessageBox.Show("Đặt phòng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                    LoadListBookRoom();
                    //if (bunifuCheckbox1.Checked)
                    //{

                    //    fReceiveRoom fReceiveRoom = new fReceiveRoom(GetCurrentIDBookRoom(DateTime.Now.Date));
                    //    this.Hide();
                    //    fReceiveRoom.ShowDialog();
                    //    fReceiveRoom.Show();
                    //}
                    bunifuCheckbox1_OnChange(sender, e);
                }
                else
                    MessageBox.Show( "Vui lòng nhập đầy đủ thông tin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }   
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Xem thông tin chi tiết
        private void btnDetails_Click(object sender, EventArgs e)
        {
            string idBookRoom = dataGridViewBookRoom.SelectedRows[0].Cells[0].Value.ToString();
            string idCard= dataGridViewBookRoom.SelectedRows[0].Cells[2].Value.ToString();
            fBookRoomDetails f = new fBookRoomDetails(idBookRoom, idCard);
            this.Hide();
            f.ShowDialog();
            this.Show();
            LoadListBookRoom();
        }

        private void txbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private string GetAutomaticIDCustomer()
        {
            return GetIDAutomaticDAO.Instance.Actomatic_ID("Customer", "ID");
        }
        private string GetAutomaticIDBookRoom()
        {
            return GetIDAutomaticDAO.Instance.Actomatic_ID("BookRoom", "ID");
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if ( bunifuCheckbox1.Checked )
            {

                fReceiveRoom fReceiveRoom = new fReceiveRoom(GetCurrentIDBookRoom(DateTime.Now.Date,idbookroom));
                this.Hide();
                fReceiveRoom.ShowDialog();
                this.Show();

            }
        }

        private void dataGridViewBookRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           int cell= e.RowIndex;
            idbookroom = dataGridViewBookRoom [ 0, cell ].Value.ToString();

        }
    }
}
