using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Service
    {
        string id;
        string name;
        string idServiceType;
        int price;
        public Service() { }
        public Service(DataRow data)
        {
            Id = data["id"].ToString();
            Name = data["Name"].ToString();
            IdServiceType = data["idServiceType"].ToString();
            Price = (int)data["Price"];
        }
        public bool Equals(Service servicePre)
        {
            if (servicePre == null) return false;
            if (servicePre.idServiceType != this.idServiceType) return false;
            if (servicePre.name != this.name) return false;
            if (servicePre.price != this.price) return false;
            return true;
        }
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string IdServiceType { get => idServiceType; set => idServiceType = value; }
        public int Price { get => price; set => price = value; }
    }
}
