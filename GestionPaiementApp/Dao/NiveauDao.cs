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
    public class NiveauDao : Dao<Niveau>
    {
        public NiveauDao()
        {
            TableName = "niveau";
        }

        public override int Add(Niveau instance)
        {
            try
            {
                var id = TableKeyHelper.GetKey(TableName);

                Request.CommandText = "insert into niveau(id, nom, ordre) " +
                    "values(@v_id, @v_nom,@v_ordre )";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_nom", DbType.String, instance.Nom));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_ordre", DbType.Int32, instance.Ordre));

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
        public override int Delete(Niveau instance)
        {
            try
            {
                Request.CommandText = "delete from niveau where id = @v_id ";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));

                var feed = Request.ExecuteNonQuery();

                return feed;
            }
            catch (Exception)
            {

                return -1;
            }

        }
        public override int Update(Niveau instance, Niveau oldObj)
        {
            try
            {

                Request.CommandText = "update niveau " +
                    "set nom = @v_nom, " +
                    "ordre = @v_ordre " +
                    "where id = @v_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_nom", DbType.String, instance.Nom));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_ordre", DbType.Int32, instance.Ordre));


                var feed = Request.ExecuteNonQuery();

                return feed;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        protected override Dictionary<string, object> Map(DbDataReader row)
        {
            return new Dictionary<string, object>()
            {
                { "id", row["id"] },
                { "nom", row["nom"] },
                { "ordre", row["ordre"] }

            };
        }
        private Niveau Create(Dictionary<string, object> row)
        {
            Niveau instance = new Niveau()
            {
                Id = row["id"].ToString(),
                Nom = row["nom"].ToString(),
                Ordre = int.Parse(row["ordre"].ToString())
            };

            return instance;
        }
        public Niveau Get(string id)
        {
            Niveau instance = null;
            Dictionary<string, object> _instance = null;

            try
            {
                Request.CommandText = "select * " +
                    "from niveau " +
                    "where id = @v_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, id));

                using (Reader = Request.ExecuteReader())
                {
                    if (Reader.HasRows && Reader.Read())
                        _instance = Map(Reader);

                    Reader.Close();
                };

                if (_instance != null)
                    instance = Create(_instance);

            }
            catch (Exception)
            {
                if (Reader != null)
                    Reader.Close();
            }

            return instance;
        }
       
        public List<Niveau> GetAll()
        {
            var intances = new List<Niveau>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from niveau ";

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
                if (Reader != null)
                    Reader.Close();
            }

            return intances;
        }

        public async Task<List<Niveau>> GetAllAsync()
        {
            var intances = new List<Niveau>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
               
                Request.CommandText = "select * from niveau " +
                    "order by ordre asc";

                using (Reader = await Request.ExecuteReaderAsync())
                {
                    if (Reader.HasRows)
                        while (Reader.Read())
                            _instances.Add(Map(Reader));

                    Reader.Close();
                }

                foreach (var item in _instances)
                {
                    intances.Add(Create(item));
                }
            }
            catch (Exception)
            {
                if (Reader != null)
                    Reader.Close();

                //System.Windows.Forms.MessageBox.Show(e.Message);
            }

            return intances;
        }
    }
}
