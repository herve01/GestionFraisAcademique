using GestionPaiementApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GestionPaiementApp.Dao
{
    public class FaculteDao : Dao<Faculte>
    {
        public FaculteDao()
        {
            TableName = "faculte";
        }

        public override int Add(Faculte instance)
        {
            try
            {
                var id = TableKeyHelper.GetKey(TableName);

                Request.CommandText = "insert into faculte(id, nom) " +
                    "values(@v_id, @v_nom)";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_nom", DbType.String, instance.Nom));

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
        public override int Delete(Faculte instance)
        {
            try
            {
                Request.CommandText = "delete from faculte where id = @v_id ";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));

                var feed = Request.ExecuteNonQuery();

                return feed;
            }
            catch (Exception)
            {

                return -1;
            }

        }
        public override int Update(Faculte instance, Faculte oldObj)
        {
            try
            {

                Request.CommandText = "update faculte " +
                    "set nom = @v_nom " +
                    "where id = @v_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_nom", DbType.String, instance.Nom));

                var feed = Request.ExecuteNonQuery();

                return feed;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        protected override Dictionary<string, object> Map(DbDataReader row)
        {
            return new Dictionary<string, object>()
            {
                { "id", row["id"] },
                { "nom", row["nom"] }            
            };
        }

        private Faculte Create(Dictionary<string, object> row)
        {
            Faculte instance = new Faculte()
            {
                Id = row["id"].ToString(),
                Nom = row["nom"].ToString()
             };
            
            return instance;
        }

        public Faculte Get(string id)
        {
            Faculte instance = null;
            Dictionary<string, object> _instance = null;

            try
            {
                Request.CommandText = "select * " +
                    "from faculte " +
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

        public Faculte Get(Promotion promotion)
        {
            Faculte instance = null;
            Dictionary<string, object> _instance = null;

            try
            {
                Request.CommandText = "select F.* " +
                    "from faculte F inner join departement D " +
                    "on F.id = D.faculte_id " +
                    "inner join promotion P " +
                    "on P.departement_id = D.id " +
                    "where p.id = @v_promotion_id " +
                    "limit 1";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_promotion_id", DbType.String, promotion?.Id));

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

        public List<Faculte> GetAll()
        {
            var intances = new List<Faculte>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from faculte ";

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

        public async Task<List<Faculte>> GetAllAsync(CancellationToken token)
        {
            var intances = new List<Faculte>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from faculte ";

                using (Reader = await Request.ExecuteReaderAsync())
                {
                    if (Reader.HasRows)
                        while (Reader.Read())
                            _instances.Add(Map(Reader));

                    Reader.Close();
                }

                int i = 0;

                foreach (var item in _instances)
                {
                    if (token.IsCancellationRequested)
                        break;

                    i++;
                    var factule = Create(item);
                    factule.Number = i;

                    intances.Add(factule);
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

        public async Task<List<Faculte>> GetAll2Async(CancellationToken token)
        {
            var intances = new List<Faculte>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from faculte ";

                using (Reader = await Request.ExecuteReaderAsync())
                {
                    if (Reader.HasRows)
                        while (Reader.Read())
                            _instances.Add(Map(Reader));

                    Reader.Close();
                }

                foreach (var item in _instances)
                {
                    if (token.IsCancellationRequested)
                        break;

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
