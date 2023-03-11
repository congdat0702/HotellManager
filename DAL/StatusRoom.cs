using System.Data;

namespace HotelManager.DTO
{
    public class StatusRoom
    {
        #region Properties
        private string id;
        private string name;
        public string Name { get => name; set => name = value; }
        public string Id { get => id; set => id = value; }
        #endregion

        #region Constructor
        public StatusRoom(){ }
        public StatusRoom(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public StatusRoom(DataRow row)
        {
            this.Id = row["ID"].ToString();
            this.Name = row["Name"].ToString();
        }
        #endregion

        #region Method
        public bool Equals(StatusRoom statusRoomPre)
        {
            return this.name == statusRoomPre.name;
        }
        #endregion
    }
}
