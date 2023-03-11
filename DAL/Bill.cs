using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class Bill
    {
        private string id;
        private string idReceiveRoom;
        private string staffSetUp;
        private DateTime dateOfCreate;
        private int roomPrice;
        private int servicePrice;
        private int totalPrice;
        private int discount;
        private int idStatusBill;
        public Bill(DataRow data)
        {
            Id = data["id"].ToString();
            IdReceiveRoom = data["idReceiveRoom"].ToString();
            StaffSetUp = data["StaffSetUp"].ToString();
            DateOfCreate = (DateTime)data["dateOfCreate"];
            RoomPrice = (int)data["RoomPrice"];
            ServicePrice = (int)data["ServicePrice"];
            TotalPrice = (int)data["TotalPrice"];
            Discount = (int)data["discount"];
            IdStatusBill = (int)data["idStatusBill"];
        }

        public string Id { get => id; set => id = value; }
        public string IdReceiveRoom { get => idReceiveRoom; set => idReceiveRoom = value; }
        public string StaffSetUp { get => staffSetUp; set => staffSetUp = value; }
        public DateTime DateOfCreate { get => dateOfCreate; set => dateOfCreate = value; }
        public int RoomPrice { get => roomPrice; set => roomPrice = value; }
        public int ServicePrice { get => servicePrice; set => servicePrice = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }
        public int Discount { get => discount; set => discount = value; }
        public int IdStatusBill { get => idStatusBill; set => idStatusBill = value; }
    }
}
