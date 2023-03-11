using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ServiceDAO
    {
        private static ServiceDAO instance;
        public List<Service> GetServices(string idServiceType)
        {
            List<Service> services = new List<Service>();
            string query = "USP_LoadServiceByServiceType @idServiceType";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { idServiceType });
            foreach (DataRow item in dataTable.Rows)
            {
                Service service = new Service(item);
                services.Add(service);
            }
            return services;
        }
        public bool InsertService(string id, string name, string idtype, int price)
        {
            string query = "USP_InsertService @id , @name , @idServiceType , @price";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[]
            {
               id, name, idtype, price
            }) > 0;
        }
        public bool InsertService(Service serviceNow)
        {
            return InsertService(serviceNow.Id, serviceNow.Name, serviceNow.IdServiceType, serviceNow.Price);
        }
        public bool UpdateService(string id, string name, string idServiceType, int price)
        {
            string query = "USP_UpdateService @id , @name , @idServiceType , @price";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id, name, idServiceType, price }) > 0;
        }
        public bool UpdateService(Service serviceNow, Service servicePre)
        {
            return UpdateService(serviceNow.Id, serviceNow.Name, serviceNow.IdServiceType, serviceNow.Price);
        }
        public DataTable LoadFullService()
        {
            string query = "USP_LoadFullService";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable Search(string name, int id)
        {
            string query = "USP_SearchService @string , @int";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { name, id });
        }
        public static ServiceDAO Instance { get { if (instance == null) instance = new ServiceDAO();return instance; }
            private set => instance = value; }
    }
}
