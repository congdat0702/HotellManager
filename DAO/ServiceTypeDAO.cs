using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ServiceTypeDAO
    {
        private static ServiceTypeDAO instance;

        #region  Method
        public bool InsertServiceType(string id ,string name)
        {
            string query = "USP_InsertServiceType @id , @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] {id , name }) > 0;
        }
        public bool InsertServiceType(ServiceType serviceTypeNow)
        {
            return InsertServiceType(serviceTypeNow.Id , serviceTypeNow.Name);
        }
        public bool UpdateServiceType(string id, string name)
        {
            string query = "USP_UpdateServiceType @id , @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id, name }) > 0;
        }
        public bool UpdateServiceType(ServiceType serviceTypeNow)
        {
            return UpdateServiceType(serviceTypeNow.Id, serviceTypeNow.Name);
        }
        public DataTable LoadFullServiceType()
        {
            string query = "USP_LoadFullServiceType";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable Search(string name, int id)
        {
            string query = "USP_SearchServiceType @string , @int";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { name, id });
        }

        public static ServiceTypeDAO Instance {
            get { if (instance == null) instance = new ServiceTypeDAO();return instance; }
            private set => instance = value; }

        public List<ServiceType> GetServiceTypes()
        {
            string query = "select * from ServiceType";
            List<ServiceType> serviceTypes = new List<ServiceType>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ServiceType serviceType = new ServiceType(item);
                serviceTypes.Add(serviceType);
            }
            return serviceTypes;
        }
        #endregion
    }
}
