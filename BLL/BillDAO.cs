using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;
        internal string GetIdBillMax()
        {
            string query = "USP_GetIdBillMax";
            return (string)DataProvider.Instance.ExecuteScalar(query);
        }
        internal string GetIdBillFromIdRoom(string idRoom)
        {
            string query = "USP_GetIdBillFromIdRoom @idRoom";
            DataRow dataRow = DataProvider.Instance.ExecuteQuery(query, new object[] { idRoom }).Rows[0];
            Bill bill = new Bill(dataRow);
            return bill.Id;
        }
        internal bool IsExistsBill(string idRoom)// > 0 Tồn tại Bill
        {
            string query = "USP_IsExistBillOfRoom @idRoom";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { idRoom }).Rows.Count > 0;
        }
        internal bool InsertBill( string id,string idReceiveRoom, string staffSetUp)
        {
            string query = "USP_InsertBill @id , @idReceiveRoom , @staffSetUp";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] {id , idReceiveRoom, staffSetUp }) > 0;
        }
        internal DataTable ShowBill(string idRoom)
        {
            string query = "USP_ShowBill @idRoom";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { idRoom });
        }
        internal DataTable ShowBillPreView(string idBill)
        {
            string query = "USP_ShowBillPreView @idRoom";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { idBill });
        }
        internal DataRow ShowBillRoom(string idRoom)
        {
            string query = "USP_ShowBillRoom @getToday , @idRoom";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { DateTime.Now.Date, idRoom }).Rows[0];
        }
        internal bool UpdateRoomPrice(string idBill)
        {
            string query = "USP_UpdateBill_RoomPrice @idBill";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idBill }) > 0;
        }
        internal bool UpdateServicePrice(string idBill)
        {
            string query = "USP_UpdateBill_ServicePrice @idBill";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idBill }) > 0;
        }
        internal bool UpdateOther(string idBill, int discount)
        {
            string query = "USP_UpdateBill_Other @idBill , @discount";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idBill, discount }) > 0;
        }
        internal DataTable LoaddFullBill()
        {
            string query = "USP_LoadFullBill";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        internal DataTable SearchBill(string text, int mode)
        {
            string query = "USP_SearchBill @string , @mode";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { text, mode });
        }

        internal static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return instance; }
            private set => instance = value;
        }
    }
}
