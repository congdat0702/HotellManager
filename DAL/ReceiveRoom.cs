using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class ReceiveRoom
    {
        private string id;
        private string idBookRoom;
        private string idRoom;
        public ReceiveRoom(DataRow row)
        {
            Id = row["id"].ToString();
            IdBookRoom = row ["idBookRoom"].ToString();
            IdRoom = row["idroom"].ToString();
        }
        public string Id { get => id; set => id = value; }
        public string IdBookRoom { get => idBookRoom; set => idBookRoom = value; }
        public string IdRoom { get => idRoom; set => idRoom = value; }
    }
}
