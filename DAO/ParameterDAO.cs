using DTO;
using System;
using System.Data;

namespace DAO
{
    public class ParameterDAO
    {
        #region Properties && constructor
        private ParameterDAO() { }

        private static ParameterDAO instance;
        public static ParameterDAO Instance { get { if (instance == null) instance = new ParameterDAO(); return instance; } }
        #endregion

        #region Method
        public bool UpdateParameter(string name, double value, string describe)
        {
            string query = "exec USP_UpdateParameter @name , @value , @describe";
            return DataProvider.Instance.ExecuteNoneQuery(query, new Object[] { name, value, describe }) > 0;
        }
        public bool UpdateParameter(Parameter surcharge)
        {
            return UpdateParameter(surcharge.Name, surcharge.Value, surcharge.Describe);
        }
        public DataTable LoadFullParameter()
        {
            return DataProvider.Instance.ExecuteQuery("USP_LoadFullParameter");
        }
        public DataTable Search(string text)
        {
            string query = "USP_SearchParameter @string";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { text });
        }
        #endregion

    }
}
