using DAO;
using DTO;
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

namespace HotelManager
{
    
    public partial class fReceiveRoom : Form
    {
        List<string> ListIDCustomer=new List<string>();
        string IDBookRoom;
        DateTime dateCheckIn;
        public fReceiveRoom(string idBookRoom)
        {
            IDBookRoom = idBookRoom;
            InitializeComponent();
            LoadData();
            ShowBookRoomInfo(IDBookRoom);
        }
        public fReceiveRoom()
        {
            InitializeComponent();
            LoadData();
          
        }
        public void LoadData()
        {
            LoadListRoomType();
            LoadReceiveRoomInfo();
        }
        public void LoadListRoomType()
        {
            List<RoomType> rooms = RoomTypeDAO.Instance.LoadListRoomType();
            cbRoomType.DataSource = rooms;
            cbRoomType.DisplayMember = "Name";
        }
        public void LoadEmptyRoom(string idRoomType)
        {
            List<Room> rooms = RoomDAO.Instance.LoadEmptyRoom(idRoomType);
            cbRoom.DataSource = rooms;
            cbRoom.DisplayMember = "Name";
        }
        public bool IsIDBookRoomExists(string idBookRoom)
        {
            return BookRoomDAO.Instance.IsIDBookRoomExists(idBookRoom);
        }
        public void ShowBookRoomInfo(string idBookRoom)
        {
            DataRow dataRow = BookRoomDAO.Instance.ShowBookRoomInfo(idBookRoom);
            txbFullName.Text = dataRow["FullName"].ToString();
            txbIDCard.Text = dataRow["IDCard"].ToString();
            txbRoomTypeName.Text = dataRow["RoomTypeName"].ToString();
            cbRoomType.Text= dataRow["RoomTypeName"].ToString();//*
            txbDateCheckIn.Text = dataRow["DateCheckIn"].ToString().Split(' ')[0];
            dateCheckIn = (DateTime)dataRow["DateCheckIn"];
            txbDateCheckOut.Text = dataRow["DateCheckOut"].ToString().Split(' ')[0];
            txbAmountPeople.Text= dataRow["LimitPerson"].ToString();
            txbPrice.Text= dataRow["Price"].ToString();
        }
        public bool InsertReceiveRoom(string id,string idBookRoom, string idRoom)
        {
            return ReceiveRoomDAO.Instance.InsertReceiveRoom(id,idBookRoom, idRoom);
        }
        public bool InsertReceiveRoomDetails(string idReceiveRoom, string idCustomerOther)
        {
            return ReceiveRoomDetailsDAO.Instance.InsertReceiveRoomDetails(idReceiveRoom, idCustomerOther);
        }
        public void LoadReceiveRoomInfo()
        {
            dataGridViewReceiveRoom.DataSource = ReceiveRoomDAO.Instance.LoadReceiveRoomInfo();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbRoomTypeName.Text = (cbRoomType.SelectedItem as RoomType).Name;
            LoadEmptyRoom((cbRoomType.SelectedItem as RoomType).Id);
        }

        private void cbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbRoomName.Text = cbRoom.Text;
        }

        private void txbIDBookRoom_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            //    e.Handled = true;
            if (e.KeyChar == 13)
                btnSearch_Click(sender, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txbIDBookRoom.Text!=string.Empty)
            {
                if (IsIDBookRoomExists(txbIDBookRoom.Text))
                {
                    btnSearch.Tag = txbIDBookRoom.Text;
                    ShowBookRoomInfo(txbIDBookRoom.Text);
                }
                else
                   MessageBox.Show( "Mã đặt phòng không tồn tại.\nVui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbIDBookRoom.Text = string.Empty;
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (txbRoomName.Text != string.Empty && txbRoomTypeName.Text != string.Empty && txbFullName.Text != string.Empty && txbIDCard.Text != string.Empty && txbDateCheckIn.Text != string.Empty && txbDateCheckOut.Text != string.Empty && txbAmountPeople.Text != string.Empty && txbPrice.Text != string.Empty)
            {
                fAddCustomerInfo fAddCustomerInfo = new fAddCustomerInfo();
                fAddCustomerInfo.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Vui lòng nhập lại đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReceiveRoom_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn nhận phòng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txbRoomName.Text != string.Empty && txbRoomTypeName.Text != string.Empty && txbFullName.Text != string.Empty && txbIDCard.Text != string.Empty && txbDateCheckIn.Text != string.Empty && txbDateCheckOut.Text != string.Empty && txbAmountPeople.Text != string.Empty && txbPrice.Text != string.Empty)
                {
                    if (dateCheckIn == DateTime.Now.Date)
                    {
                        //string idBookRoom = GetAutomaticIDBookRoom();
                        string idBookRoom;
                        if ( IDBookRoom != "" ) idBookRoom = IDBookRoom;
                        else idBookRoom = btnSearch.Tag.ToString();
                        string idRoom = ( cbRoom.SelectedItem as Room ).Id;
                        //string idRoom = GetAutomaticIDRoom();
                        string idReceiveRoom = GetAutomaticIDReceiveRoom();
                        if (InsertReceiveRoom(idReceiveRoom, idBookRoom, idRoom))
                        {
                            if (fAddCustomerInfo.ListIdCustomer != null)
                            {
                                foreach (string item in fAddCustomerInfo.ListIdCustomer)
                                {
                                    if (item != txbIDCard.Text)
                                        InsertReceiveRoomDetails(ReceiveRoomDAO.Instance.GetIDCurrent(), item);
                                }
                            }
                            MessageBox.Show("Nhận phòng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadEmptyRoom((cbRoomType.SelectedItem as RoomType).Id);
                        }
                        else
                            MessageBox.Show("Tạo phiếu nhận phòng thất bại.\nVui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show( "Ngày nhận phòng không hợp lệ.\nVui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearData();
                    LoadReceiveRoomInfo();
                }
                else
                    MessageBox.Show("Vui lòng nhập lại đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ClearData()
        {
            txbFullName.Text = txbIDCard.Text = txbRoomTypeName.Text = txbDateCheckIn.Text = txbDateCheckOut.Text = txbAmountPeople.Text = txbPrice.Text = string.Empty;

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            fReceiveRoomDetails f = new fReceiveRoomDetails((string)dataGridViewReceiveRoom.SelectedRows[0].Cells[0].Value);
            this.Hide();
            f.ShowDialog();
            this.Show();
            LoadReceiveRoomInfo();
        }
        private string GetAutomaticIDReceiveRoom()
        {
            return GetIDAutomaticDAO.Instance.Actomatic_ID("ReceiveRoom", "ID");
        }
        private string GetAutomaticIDRoom()
        {
            return GetIDAutomaticDAO.Instance.Actomatic_ID("Room", "ID");
        }
        private string GetAutomaticIDBookRoom()
        {
            return GetIDAutomaticDAO.Instance.Actomatic_ID("BookRoom", "ID");
        }
    }
}
