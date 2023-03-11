using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class BookRoom
    {
        private string id;
        private string idCustomer;
        private string idRoomType;
        private DateTime dateCheckIn;
        private DateTime dateCheckOut;
        private DateTime dateBookRoom;

        public BookRoom(string id, string idCustomer, string idRoomType, DateTime dateCheckIn, DateTime dateCheckOut,DateTime dateBookRoom)
        {
            Id = id;
            IdCustomer = idCustomer;
            IdRoomType = idRoomType;
            DateCheckIn = dateCheckIn;
            DateCheckOut = dateCheckOut;
            DateBookRoom = dateBookRoom;
        }
        public BookRoom(DataRow row)
        {
            Id = row["id"].ToString();
            IdCustomer = row["idCustomer"].ToString();
            IdRoomType = row["IdRoomType"].ToString();
            DateCheckIn = (DateTime)row["DateCheckIn"];
            DateCheckOut = (DateTime)row["DateCheckOut"];
            DateBookRoom = (DateTime)row["DateBookRoom"];
        }

        public string Id { get => id; set => id = value; }
        public string IdCustomer { get => idCustomer; set => idCustomer = value; }
        public string IdRoomType { get => idRoomType; set => idRoomType = value; }
        public DateTime DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public DateTime DateBookRoom { get => dateBookRoom; set => dateBookRoom = value; }
    }
}
