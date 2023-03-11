using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BillDetails
    {
        private string idBill;
        private string idService;
        private int count;
        private int totalPrice;
        public BillDetails(DataRow data)
        {
            IdBill = data["IdBill"].ToString();
            IdService = data["idService"].ToString();
            Count = (int)data["count"];
            TotalPrice = (int)data["totalPrice"];
        }
        public string IdBill { get => idBill; set => idBill = value; }
        public string IdService { get => idService; set => idService = value; }
        public int Count { get => count; set => count = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
