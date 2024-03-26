using GestionPaiementApp.Dao.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;

namespace GestionPaiementApp.Dao
{
    public abstract class Dao<T>
    {
        public abstract int Add(T instance);
        public abstract int Delete(T instance);
        public abstract int Update(T newObj, T oldObj);

        protected abstract Dictionary<string, object> Map(DbDataReader row);

        protected DbConnection Connection;
        protected DbCommand Request;
        protected DbDataAdapter Adapter;
        protected DbDataReader Reader;
        protected DataTable Table;
        protected bool OwnAction = true;
        protected string TableName = string.Empty;

        public Dao()
        {
            try
            {
                Connection = ConnectionHelper.GetConnection();
                Request = Connection.CreateCommand();
                Adapter = DbProviderFactories.GetFactory("MySql.Data.MySqlClient").CreateDataAdapter();
                Table = new DataTable();

                if (Connection.State == ConnectionState.Closed)
                    Connection.Open();
            }
            catch (Exception)
            {

            }
        }

        public void NewConnection()
        {
            try
            {
                Connection = ConnectionHelper.GetNewInstance();
                Request = Connection.CreateCommand();
                Adapter = DbProviderFactories.GetFactory("MySql.Data.MySqlClient").CreateDataAdapter();
                Table = new DataTable();

                if (Connection.State == ConnectionState.Closed)
                    Connection.Open();
            }
            catch (Exception)
            {

            }
        }
    }

    public class DbUtil
    {
        public static DbParameter CreateParameter(DbCommand cmd, string paramName, DbType type, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            var param = cmd.CreateParameter();
            param.ParameterName = paramName;
            param.DbType = type;
            param.Value = value;
            param.Direction = direction;

            return param;
        }
    }

    public class TableKeyHelper
    {

        public static string GetKey(string tableName, string add = "")
        {
            var key = string.Empty;

            key = tableName + "" + GetMacAddress();

            key += DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffffff");

            key += "STONE";

            return MD5Hash(key).ToUpper();
        }

        static string GetMacAddress()
        {
            byte[] macAddress = null;

            foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    macAddress = nic.GetPhysicalAddress().GetAddressBytes();
                    break;
                }
            }
            return string.Join(":", macAddress.Select(m => m.ToString("X2")));
        }

        static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
