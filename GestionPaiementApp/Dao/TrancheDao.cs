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
    public class TrancheDao : Dao<Tranche>
    {
        public TrancheDao()
        {
            TableName = "tranche";
        }

        public override int Add(Tranche instance)
        {
            try
            {
                var id = TableKeyHelper.GetKey(TableName);

                Request.CommandText = "insert into tranche(id, prevision_id, numero, montant) " +
                       "values(@v_id, @v_prevision_id, @v_numero, @v_montant)";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_prevision_id", DbType.String, instance?.Prevision?.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_numero", DbType.String, instance.Numero));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_montant", DbType.Decimal, instance.Montant));

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

        public int Add(DbCommand command, Tranche instance)
        {
            command.Parameters.Clear();
            Request = command;
            return Add(instance);
        }
        public override int Delete(Tranche instance)
        {
            try
            {
                Request.CommandText = "delete from tranche where id = @v_id ";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));

                var feed = Request.ExecuteNonQuery();

                return feed;
            }
            catch (Exception)
            {

                return -1;
            }

        }
        public override int Update(Tranche instance, Tranche oldObj)
        {
            try
            {

                Request.CommandText = "update tranche " +
                    "set prevision_id = @v_prevision_id, " +
                    "numero = @v_numero, " +
                    "montant = @v_montant " +
                    "where id = @v_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_prevision_id", DbType.String, instance?.Prevision?.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_numero", DbType.String, instance.Numero));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_montant", DbType.Decimal, instance.Montant));


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
                { "prevision_id", row["prevision_id"] },
                { "numero", row["numero"] },
                { "montant", row["montant"] },
            };
        }
        private Tranche Create(Dictionary<string, object> row, bool withPrevision = false)
        {
            var instance = new Tranche();

            instance.Id = row["id"].ToString();
            instance.Numero = int.Parse(row["numero"].ToString());
            instance.Montant = decimal.Parse(row["montant"].ToString());

            if(withPrevision)
                instance.Prevision = new PrevisionDao().Get(row["prevision_id"].ToString());

            return instance;
        }
        public Tranche Get(string id)
        {
            Tranche instance = null;
            Dictionary<string, object> _instance = null;

            try
            {
                Request.CommandText = "select * " +
                    "from tranche " +
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
                if (Reader != null)
                    Reader.Close();
            }

            return instance;
        }
        public List<Tranche> GetAll()
        {
            var intances = new List<Tranche>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from tranche ";

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

        public List<Tranche> GetAll(Prevision prevision)
        {
            var intances = new List<Tranche>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from tranche where prevision_id = @v_prevision_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_prevision_id", DbType.String, prevision?.Id)) ;

                Reader = Request.ExecuteReader();

                if (Reader.HasRows)
                    while (Reader.Read())
                        _instances.Add(Map(Reader));

                Reader.Close();

                foreach (var item in _instances)
                {
                    var instance = Create(item);
                    instance.Prevision = prevision;

                    intances.Add(instance);
                }
            }
            catch (Exception)
            {
                if (Reader != null)
                    Reader.Close();
            }

            return intances;
        }

        public async Task<List<Tranche>> GetAllAsync(string anneeId, string niveauId)
        {
            var intances = new List<Tranche>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select T.* " +
                    "from tranche T INNER JOIN prevision P " +
                    "where P.annee_id = @v_annee_id and P.niveau_id = @v_niveau_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_annee_id", DbType.String, anneeId));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_niveau_id", DbType.String, niveauId));

                Reader = await Request.ExecuteReaderAsync();

                if (Reader.HasRows)
                    while (Reader.Read())
                        _instances.Add(Map(Reader));

                Reader.Close();

                foreach (var item in _instances)
                {
                    var instance = Create(item);
                    //instance.Prevision = prevision;

                    intances.Add(instance);
                }
            }
            catch (Exception)
            {
                if (Reader != null)
                    Reader.Close();
            }

            return intances;
        }
    }
}

