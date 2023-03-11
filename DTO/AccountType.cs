using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AccountType
    {
        private string id;
        private string name;
        public AccountType(DataRow dataRow)
        {
            Id = dataRow["id"].ToString();
            Name = dataRow["name"].ToString();
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
