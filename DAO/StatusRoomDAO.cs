using DTO;
using System.Data;
namespace DAO
{
    public class StatusRoomDAO
    {
        #region Properties & Constructor
        private static StatusRoomDAO instance;
        private StatusRoomDAO() { }
        public static StatusRoomDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new StatusRoomDAO();
                return instance;
            }
            private set => instance = value;
        }

        #endregion

        #region Method
        public bool UpdateStatusRoom(string id, string name)
        {
            string query = "exec USP_UpdateStatusRoom @id , @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id, name }) > 0;
        }
        public bool UpdateStatusRoom(StatusRoom statusRoomNow)
        {
            return UpdateStatusRoom(statusRoomNow.Id, statusRoomNow.Name);
        }
        public DataTable LoadFullStatusRoom()
        {
            return DataProvider.Instance.ExecuteQuery("USP_LoadFullStatusRoom");
        }
        #endregion
    }
}
