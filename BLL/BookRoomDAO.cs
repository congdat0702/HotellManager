using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class BookRoomDAO
    {
        private static BookRoomDAO instance;
        private BookRoomDAO() { }
        public bool InsertBookRoom( string id,string idCustomer, string idRoomType,DateTime datecheckin,DateTime datecheckout, DateTime datebookroom)
        {
            string query = "USP_InsertBookRoom @ID , @idCustomer , @idRoomType , @datecheckin , @datecheckout , @datebookroom";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] {id, idCustomer, idRoomType, datecheckin, datecheckout, datebookroom }) > 0;
        }
        public DataTable LoadListBookRoom(DateTime dateTime)
        {
            string query = "USP_LoadBookRoomsByDate @date";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { dateTime });

        }
        public string GetCurrentIDBookRoom(DateTime dateTime, string idbookroom)
        {
            string query = "USP_LoadBookRoomsByDateID @date , @idbookroom";
            DataRow dataRow= DataProvider.Instance.ExecuteQuery(query, new object[] { dateTime , idbookroom}).Rows[0];
            return (string)dataRow["Mã đặt phòng"];
        }
        public bool IsIDBookRoomExists(string idBookRoom)
        {
            string query = "USP_IsIDBookRoomExists @idBookRoom , @dateNow";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { idBookRoom,DateTime.Now.Date});
            return dataTable.Rows.Count > 0;
        }
        public DataRow ShowBookRoomInfo(string idBookRoom)
        {
            string query = "ShowBookRoomInfo @idBookRoom";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { idBookRoom }).Rows[0];
        }
        public bool UpdateBookRoom(string id, string idRoomType,DateTime datecheckin,DateTime datecheckout)
        {
            string query = "USP_UpdateBookRoom @id , @idRoomType , @dateCheckIn , @datecheckOut";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id, idRoomType, datecheckin, datecheckout }) > 0;
        }
        public bool DeleteBookRoom(string id)
        {
            string query = "USP_DeleteBookRoom @id";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id }) > 0;
        }
        public static BookRoomDAO Instance { get { if (instance == null) instance = new BookRoomDAO();return instance; }
            private set => instance = value; }
    }
}
