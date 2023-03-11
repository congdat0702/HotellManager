using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO
{
   public class GetIDAutomaticDAO
    {
        private static GetIDAutomaticDAO instance;
  
        public string GetAutomaticID(string table, string nameID)
        {
            string query = "GetAutomaticID @table , @nameID";
            return ( string )DataProvider.Instance.ExecuteScalar(query, new object [ ] { table , nameID });
        }

        public string Actomatic_ID(string table, string nameID)
        {
            string id, newid;
            id = GetAutomaticID(table, nameID);
            string TienTo;
            int HauTo;
            TienTo = id.Substring(0, 2);
            HauTo = int.Parse(id.Substring(2).ToString());
            HauTo++;
            if ( HauTo < 10 )
            {
                newid = string.Concat(TienTo, "00", HauTo.ToString());
            }
            else
            {
                if ( HauTo < 100 )
                {
                    newid = string.Concat(TienTo, "0", HauTo.ToString());

                }
                else
                {
                    newid = string.Concat(TienTo, HauTo.ToString());
                }
            }
            return newid;
        }
        public static GetIDAutomaticDAO Instance
        {
            get { if ( instance == null ) instance = new GetIDAutomaticDAO(); return instance; }
            private set => instance = value;
        }
        private GetIDAutomaticDAO() { }
    }
}
