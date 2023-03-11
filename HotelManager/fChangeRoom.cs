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
    public partial class fChangeRoom : Form
    {
        string idRoom,idReceiveRoom;
        public fChangeRoom(string _idRoom,string _idReceiveRoom)
        {
            InitializeComponent();
            idRoom = _idRoom;
            idReceiveRoom = _idReceiveRoom;
            LoadListRoomType();
            LoadRoomTypeInfo(_idRoom);
        }
        //lấy danh sách loại phòng
        public void LoadListRoomType()
        {
            List<RoomType> rooms = RoomTypeDAO.Instance.LoadListRoomType();
            cbRoomType.DataSource = rooms;
            cbRoomType.DisplayMember = "Name";
        }
        //kiểm trả phòng 
        public void LoadEmptyRoom(string idRoomType)
        {
            List<Room> rooms = RoomDAO.Instance.LoadEmptyRoom(idRoomType);
            cbRoom.DataSource = rooms;
            cbRoom.DisplayMember = "Name";
        }
        //lấy thông tin loại phòng
        public void LoadRoomTypeInfo(string idRoom)
        {
            CultureInfo cultureInfo = new CultureInfo("vi-vn");
            RoomType roomType = RoomTypeDAO.Instance.GetRoomTypeByIdRoom(idRoom);
            txbLimitPerson.Text = roomType.LimitPerson.ToString();
            txbPrice.Text = roomType.Price.ToString("c",cultureInfo);
            txbRoomTypeName.Text = roomType.Name;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            Close();
        }
        //thay đổi cbLoaiphong
        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbRoomTypeName.Text = (cbRoomType.SelectedItem as RoomType).Name;
            LoadEmptyRoom((cbRoomType.SelectedItem as RoomType).Id);
            LoadRoomTypeInfo((cbRoom.SelectedItem as Room).Id);
        }
        //thay đổi cbPhong
        private void cbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbRoomName.Text = (cbRoom.SelectedItem as Room).Name;
        }
        //đổi phòng
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            //Phải cập nhật trạng thái của phòng cũ
            RoomDAO.Instance.UpdateStatusRoom(idRoom);
            ReceiveRoomDAO.Instance.UpdateReceiveRoom(idReceiveRoom, (cbRoom.SelectedItem as Room).Id);
            MessageBox.Show("Đổi phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
