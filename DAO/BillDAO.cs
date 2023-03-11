
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class BillDAO
    {
        private static BillDAO instance;
        public string GetIdBillMax()
        {
            string query = "USP_GetIdBillMax";
            return (string)DataProvider.Instance.ExecuteScalar(query);
        }
        public string GetIdBillFromIdRoom(string idRoom)
        {
            string query = "USP_GetIdBillFromIdRoom @idRoom";
            DataRow dataRow = DataProvider.Instance.ExecuteQuery(query, new object[] { idRoom }).Rows[0];
            Bill bill = new Bill(dataRow);
            return bill.Id;
        }
        public bool IsExistsBill(string idRoom)// > 0 Tồn tại Bill
        {
            string query = "USP_IsExistBillOfRoom @idRoom";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { idRoom }).Rows.Count > 0;
        }
        public bool InsertBill( string id,string idReceiveRoom, string staffSetUp)
        {
            string query = "USP_InsertBill @id , @idReceiveRoom , @staffSetUp";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] {id , idReceiveRoom, staffSetUp }) > 0;
        }
        //
        public DataTable ShowBill(string idRoom)
        {
            string query = "USP_ShowBill @idRoom";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { idRoom });
        }
        ///
        public DataTable ShowBillPreView(string idBill)
        {
            string query = "USP_ShowBillPreView @idRoom";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { idBill });
        }

        public DataRow ShowBillRoom(string idRoom)
        {
            string query = "USP_ShowBillRoom @getToday , @idRoom";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { DateTime.Now.Date, idRoom }).Rows[0];
        }

        public bool UpdateRoomPrice(string idBill)
        {
            string query = "USP_UpdateBill_RoomPrice @idBill";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idBill }) > 0;
        }
        public bool UpdateServicePrice(string idBill)
        {
            string query = "USP_UpdateBill_ServicePrice @idBill";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idBill }) > 0;
        }
        public bool UpdateOther(string idBill, int discount)
        {
            string query = "USP_UpdateBill_Other @idBill , @discount";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idBill, discount }) > 0;
        }
        public DataTable LoaddFullBill()
        {
            string query = "USP_LoadFullBill";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable SearchBill(string text, int mode)
        {
            string query = "USP_SearchBill @string , @mode";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { text, mode });
        }

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return instance; }
            private set => instance = value;
        }
    }
}
