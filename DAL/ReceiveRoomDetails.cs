using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class ReceiveRoomDetails
    {
        private string idReceiveRoom;
        private string idCustomerOther;
        public ReceiveRoomDetails(DataRow row)
        {
            IdReceiveRoom = row["idReceiveRoom"].ToString();
            IdCustomerOther = row["idCustomerOther"].ToString();
        }
        public string IdReceiveRoom { get => idReceiveRoom; set => idReceiveRoom = value; }
        public string IdCustomerOther { get => idCustomerOther; set => idCustomerOther = value; }
    }
}
