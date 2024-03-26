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
    public class PrevisionDao : Dao<Prevision>
    {
        public PrevisionDao()
        {
            TableName = "prevision";
        }

        public override int Add(Prevision instance)
        {
            try
            {
                var id = TableKeyHelper.GetKey(TableName);

                Request.Transaction = Connection.BeginTransaction();

                Request.CommandText = "insert into prevision(id, annee_id, niveau_id, date, nombre_tranche, montant) " +
                       "values(@v_id, @v_annee_id, @v_niveau_id, @v_date, @v_nombre_tranche, @v_montant)";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_annee_id", DbType.String, instance?.Annee?.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_niveau_id", DbType.String, instance?.Niveau?.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_date", DbType.Date, instance.Date));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_nombre_tranche", DbType.Int32, instance.NombreTranche));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_montant", DbType.Decimal, instance.Montant));

                var feed = Request.ExecuteNonQuery();

                if (feed <= 0)
                {
                    Request.Transaction.Rollback();
                    return -1;
                }
    
                if(instance.Tranches.Count > 0)
                    foreach (var tranche in instance.Tranches)
                    {
                        tranche.Prevision = new Prevision() { Id = id };
                        if(new TrancheDao().Add(Request, tranche) < 0)
                        {
                            Request.Transaction.Rollback();
                            return -2;
                        }
                    }

                instance.Id = id;
                Request.Transaction.Commit();
                return 1;
            }
            catch (Exception)
            {
                Request.Transaction.Rollback();
                return -3;
            }
        }
        public override int Delete(Prevision instance)
        {
            try
            {
                Request.CommandText = "delete from prevision where id = @v_id ";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));

                var feed = Request.ExecuteNonQuery();

                return feed;
            }
            catch (Exception)
            {

                return -1;
            }

        }
        public override int Update(Prevision instance, Prevision oldObj)
        {
            try
            {

                Request.CommandText = "update prevision " +
                    "set annee_id = @v_annee_id, " +
                    "niveau_id = @v_niveau_id, " +
                    "date = @v_date, " +
                    "nombre_tranche = @v_nombre_tranche, " +
                    "montant = @v_montant " +
                    "where id = @v_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_annee_id", DbType.String, instance?.Annee?.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_niveau_id", DbType.String, instance?.Niveau?.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_date", DbType.Date, instance.Date));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_nombre_tranche", DbType.Int32, instance.NombreTranche));
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
                { "annee_id", row["annee_id"] },
                { "niveau_id", row["niveau_id"] },
                { "date", row["date"] },
                { "nombre_tranche", row["nombre_tranche"] },
                { "montant", row["montant"] },
            };
        }

        private Prevision Create(Dictionary<string, object> row, bool withTranche = true)
        {
            var instance = new Prevision();

            instance.Id = row["id"].ToString();
            instance.Annee = new AnneeAcademiqueDao().Get(row["annee_id"].ToString());
            instance.Niveau = new NiveauDao().Get(row["niveau_id"].ToString());
            instance.Date = DateTime.Parse(row["date"].ToString());
            instance.NombreTranche = int.Parse(row["nombre_tranche"].ToString());
            instance.Montant = decimal.Parse(row["montant"].ToString());

            if(withTranche)
                instance.Tranches = new TrancheDao().GetAll(instance);

            return instance;
        }
        public Prevision Get(string id)
        {
            Prevision instance = null;
            Dictionary<string, object> _instance = null;

            try
            {
                Request.CommandText = "select * " +
                    "from prevision " +
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

        public List<Prevision> GetAll()
        {
            var intances = new List<Prevision>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from prevision ";

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

        public async Task<Prevision> GetAsync(string anneeId, string niveauId, bool withTranches = false)
        {
            Prevision instance = null;
            Dictionary<string, object> _instance = null;

            try
            {
                Request.CommandText = "select * " +
                    "from prevision " +
                    "where annee_id = @v_annee_id and niveau_id = @v_niveau_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_annee_id", DbType.String, anneeId));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_niveau_id", DbType.String, niveauId));

                Reader = await Request.ExecuteReaderAsync();

                if (Reader.HasRows && Reader.Read())
                    _instance = Map(Reader);

                Reader.Close();

                if (_instance != null)
                    instance = Create(_instance, withTranches);

            }
            catch (Exception)
            {
                if (Reader != null)
                    Reader.Close();
            }

            return instance;
        }

        public async Task<List<Prevision>> GetAllAsync()
        {
            var intances = new List<Prevision>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from prevision ";

                Reader = await Request.ExecuteReaderAsync();

                if (Reader.HasRows)
                    while (Reader.Read())
                        _instances.Add(Map(Reader));

                Reader.Close();

                int i = 0;
                foreach (var item in _instances)
                {
                    i++;
                    var instance = Create(item);
                    instance.Number = i;
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

