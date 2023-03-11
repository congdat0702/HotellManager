using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class ServiceType
    {
        private string id;
        private string name;
        public ServiceType() { }
        public ServiceType(DataRow dataRow)
        {
            Id = dataRow["id"].ToString();
            Name = dataRow["name"].ToString();
        }
        public bool Equals(ServiceType serviceTypePre)
        {
            return this.name == serviceTypePre.name;
        }
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
