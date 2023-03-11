using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class RoomTypeDAO
    {
        private static RoomTypeDAO instance;
        #region Method
        public DataTable LoadFullRoomType()
        {
            return DataProvider.Instance.ExecuteQuery("USP_LoadFullRoomType");
        }
        public bool InsertRoomType(string name, int price, int limitPerson)
        {
            string query = "USP_InsertRoomType @name , @price , @limitPerson";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { name, price, limitPerson }) > 0;

        }
        public bool InsertRoomType(RoomType roomTypeNow)
        {
            return InsertRoomType(roomTypeNow.Name, roomTypeNow.Price, roomTypeNow.LimitPerson);
        }
        public bool UpdateRoomType(RoomType roomNow, RoomType roomPre)
        {
            string query = "USP_UpdateRoomType @id , @name , @price , @limitPerson";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { roomNow.Id, roomNow.Name, roomNow.Price, roomNow.LimitPerson }) > 0;
        }
        public DataTable Search(string text, string id)
        {
            string query = "USP_SearchRoomType @string , @ma";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { text, id });
        }
        public int GetMaxPersonByRoomType(string idRoomType)
        {
            string query = "USP_GetMaxPersonByRoomType @idRoomType";
            DataRow data = DataProvider.Instance.ExecuteQuery(query, new object[] { idRoomType }).Rows[0];
            return Convert.ToInt32((double)data["Value"]);
        }
        public static RoomTypeDAO Instance { get { if (instance == null) instance = new RoomTypeDAO(); return instance; }
            private set => instance = value; }
        public RoomTypeDAO() { }
        public RoomType LoadRoomTypeInfo(string id)
        {
            string query = "USP_RoomTypeInfo @id";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
            RoomType roomType = new RoomType(data.Rows[0]);
            return roomType;
        }
        public List<RoomType> LoadListRoomType()
        {
            string query = "select * from RoomType";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<RoomType> listRoomType = new List<RoomType>();
            foreach (DataRow item in data.Rows)
            {
                RoomType roomType = new RoomType(item);
                listRoomType.Add(roomType);
            }
            return listRoomType;
        }
        //lấy thông tin loại phòng theo phòng
        public RoomType GetRoomTypeByIdRoom(string idRoom)
        {
            string query = "USP_GetRoomTypeByIdRoom @idRoom";
            DataTable data = DataProvider.Instance.ExecuteQuery(query,new object[] { idRoom });
            RoomType roomType = new RoomType(data.Rows[0]);
            return roomType;
        }
        public RoomType GetRoomTypeByIdBookRoom(string idBookRoom)
        {
            string query = "USP_GetRoomTypeByIdBookRoom @idBookRoom";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idBookRoom });
            RoomType roomType = new RoomType(data.Rows[0]);
            return roomType;
        }
        #endregion

    }
}
