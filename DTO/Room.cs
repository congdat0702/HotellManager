using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Room
    {
        private string id;
        private string name;
        private string idRoomType;
        private int idStatusRoom;
        public Room() { }
        public Room(string id, string name, string idRoomType,int idStatusRoom)
        {
            this.Id = id;
            this.Name = name;
            this.IdRoomType = idRoomType;
            this.IdStatusRoom = idStatusRoom;
        }
        public Room(DataRow row)
        {
            this.Id = row["ID"].ToString();
            this.Name =row["Name"].ToString();
            this.IdRoomType =row["idRoomType"].ToString();
            this.IdStatusRoom = (int)row["idStatusRoom"]; 
        }
        public bool Equals(Room roomPre)
        {
            if (roomPre == null) return false;
            if (roomPre.id != this.id) return false;
            if (roomPre.Name != this.Name) return false;
            if (roomPre.idRoomType != this.idRoomType) return false;
            if (roomPre.idStatusRoom != this.idStatusRoom) return false;
            return true;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Room);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string IdRoomType { get => idRoomType; set => idRoomType = value; }
        public int IdStatusRoom { get => idStatusRoom; set => idStatusRoom = value; }
    }
}
