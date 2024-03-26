using GestionPaiementApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPaiementApp.Dao
{
    public class FaculterDao : Dao<Faculter>
    {
        public override int Add(Faculter instance)
        {
            try
            {


                var id = TableKeyHelper.GetKey(TableName);

                Request.CommandText = "insert into Faculter(id, division_id, direction_id) " +
                    "values(@v_id, @v_division_id )";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_division_id", DbType.String, instance.Faculter_id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "direction_id", DbType.String, instance.Nom));

                var feed = Request.ExecuteNonQuery();

                if (feed > 0)
                    instance.Id = id;


                return feed;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public override int Delete(Faculter instance)
        {
            try
            {
                Request.CommandText = "delete from  Faculter where id = @v_id ";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));

                var feed = Request.ExecuteNonQuery();

                return feed;
            }
            catch (Exception)
            {

                return -1;
            }

        }
        public override int Update(Faculter instance, Faculter oldObj)
        {
            try
            {
                try
                {

                    Request.CommandText = "update Faculter " +
                        "set Faculter_id = @v_Faculter_id," +
                        "Nom = @v_Nom, " +
                        "where id = @v_id";

                    Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));
                    Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_division_id", DbType.String, instance.Faculter_id));
                    Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_direction_id", DbType.String, instance.Nom ));
 
 
                    var feed = Request.ExecuteNonQuery();

                    return feed;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected override Dictionary<string, object> Map(DbDataReader row)
        {
            return new Dictionary<string, object>()
            {
                { "id", row["id"] },
                { "Faculter_id", row["Faculter_id"] },
                { "Nom", row["Nom"] }
                 
            };
        }
        private Faculter Create(Dictionary<string, object> row)
        {
            Faculter instance = new Faculter();

            instance.Id = row["id"].ToString();
            instance.Faculter_id = row["Faculter_id"].ToString();
            instance.Nom = row["Nom"].ToString();
            
            return instance;
        }
        public Faculter Get(string id)
        {
            Faculter instance = null;
            Dictionary<string, object> _instance = null;

            try
            {
                Request.CommandText = "select * " +
                    "from Faculter " +
                    "where id = @v_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, id));

                Reader = Request.ExecuteReader();

                if (Reader.HasRows && Reader.Read())
                    _instance = Map(Reader);

                Reader.Close();

                if (_instance != null)
                    instance = Create(_instance);

            }
            catch (Exception)
            {
                if (Reader != null && !Reader.IsClosed)
                    Reader.Close();
            }

            return instance;
        }
        public List<Etudiant> GetAll()
        {
            var intances = new List<Faculter>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from Faculter ";

                Reader = Request.ExecuteReader();

                if (Reader.HasRows)
                    while (Reader.Read())
                        _instances.Add(Map(Reader));

                Reader.Close();

                foreach (var item in _instances)
                {
                    intances.Add(Create(item));
                }
            }
            catch (Exception)
            {
                if (Reader != null && !Reader.IsClosed)
                    Reader.Close();
            }

            return intances;
        }


    }


}
