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
    public class PaiementDao : Dao<Paiement>
    {
        public PaiementDao()
        {
            TableName = "paiement";
        }
        public override int Add(Paiement instance)
        {
            try
            {
                var unitId = instance.Type == PaiementType.TRANCHE ? instance?.Tranche?.Id : 
                                                                instance?.Prevision?.Id;

                var id = TableKeyHelper.GetKey(TableName);

                Request.CommandText = "insert into paiement(id, inscription_id, type, mode_id, est_paye_totalite, date, montant) " +
                       "values(@v_id, @v_inscription_id, @v_type, @v_mode_id, @v_est_paye_totalite, @v_date, @v_montant)";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_inscription_id", DbType.String, instance?.Inscription?.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_type", DbType.String, instance.Type));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_mode_id", DbType.String, unitId));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_est_paye_totalite", DbType.Boolean, instance.EstPayeTotalite));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_date", DbType.DateTime, instance.Date));
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
        
        public override int Delete(Paiement instance)
        {
            try
            {
                Request.CommandText = "delete from paiement where id = @v_id ";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));

                var feed = Request.ExecuteNonQuery();

                return feed;
            }
            catch (Exception)
            {

                return -1;
            }

        }
        
        public override int Update(Paiement instance, Paiement oldObj)
        {
            try
            {
                var unitId = instance.Type == PaiementType.TRANCHE ? instance?.Tranche?.Id :
                                                           instance?.Prevision?.Id;

                Request.CommandText = "update paiement " +
                    "set inscription_id = @v_inscription_id," +
                    "type = @v_type, " +
                    "mode_id = @v_mode_id, " +
                    "est_paye_totalite = @v_est_paye_totalite, " +
                    "date = @v_date, " +
                    "montant = @v_montant " +
                    "where id = @v_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_inscription_id", DbType.String, instance?.Inscription?.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_type", DbType.String, instance.Type));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_mode_id", DbType.String, unitId));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_est_paye_totalite", DbType.Boolean, instance.EstPayeTotalite));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_date", DbType.DateTime, instance.Date));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_montant", DbType.Decimal, instance.Montant));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));

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
                { "inscription_id", row["inscription_id"] },
                { "type", row["type"] },
                { "mode_id", row["mode_id"] },
                { "est_paye_totalite", row["est_paye_totalite"] },
                { "date", row["date"] },
                { "montant", row["montant"] },
            };
        }
        
        private Paiement Create(Dictionary<string, object> row, bool withInscription = true)
        {
            Paiement instance = new Paiement();

            instance.Id = row["id"].ToString();
            instance.Type = Helper.Util.ToPaiementType(row["type"].ToString());
            instance.EstPayeTotalite = bool.Parse(row["est_paye_totalite"].ToString());
            instance.Date = DateTime.Parse(row["date"].ToString());
            instance.Montant = decimal.Parse(row["montant"].ToString());

            if (withInscription)
                instance.Inscription = new InscriptionDao().Get(row["inscription_id"].ToString());

            instance.Unit = instance.Type == PaiementType.PREVISION ?
                (object)new PrevisionDao().Get(row["mode_id"].ToString()) :
                (object)new TrancheDao().Get(row["mode_id"].ToString());

            return instance;
        }

        public Paiement Get(string id)
        {
            Paiement instance = null;
            Dictionary<string, object> _instance = null;

            try
            {
                Request.CommandText = "select * " +
                    "from paiement " +
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
        
        public List<Paiement> GetAll()
        {
            var instances = new List<Paiement>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from paiement ";

                Reader = Request.ExecuteReader();

                if (Reader.HasRows)
                    while (Reader.Read())
                        _instances.Add(Map(Reader));

                Reader.Close();

                foreach (var item in _instances)
                {
                    instances.Add(Create(item));
                }
            }
            catch (Exception)
            {
                if (Reader != null)
                    Reader.Close();
            }

            return instances;
        }

        public List<Paiement> GetAll(Inscription inscription)
        {
            var instances = new List<Paiement>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from paiement where inscription_id = @v_inscription_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_inscription_id", DbType.String, inscription?.Id));

                Reader = Request.ExecuteReader();

                if (Reader.HasRows)
                    while (Reader.Read())
                        _instances.Add(Map(Reader));

                Reader.Close();

                foreach (var item in _instances)
                {
                    var paiement = Create(item, false);
                    paiement.Inscription = inscription;

                    instances.Add(paiement);
                }
            }
            catch (Exception)
            {
                if (Reader != null)
                    Reader.Close();
            }

            return instances;
        }

        public List<Model.POCO.PaiementDetail> GetInfoPaiements(Inscription inscription)
        {
            var instances = new List<Model.POCO.PaiementDetail>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.Parameters.Clear();

                Request.CommandText = "sp_get_info_paiement";
                Request.CommandType = CommandType.StoredProcedure;

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_inscription_id", DbType.String, inscription?.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_niveau_id", DbType.String, inscription?.Promotion?.Niveau?.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_annee_id", DbType.String, inscription?.Annee?.Id));

                Reader = Request.ExecuteReader();


                if (Reader.HasRows)
                    while (Reader.Read())
                    {
                        _instances.Add(
                            new Dictionary<string, object>()
                            {
                                { "paiement", Reader["paiement"] },
                                { "numero", Reader["numero"] },
                                { "montant", Reader["montant"] },
                                { "modalite", Reader["modalite"] }
                            });  
                    }

                Reader.Close();

                foreach (var item in _instances)
                {
                    instances.Add(new Model.POCO.PaiementDetail() {
                        Numero = int.Parse( item["numero"].ToString()),
                        Paiement = Math.Round(decimal.Parse(item["paiement"].ToString()), 0),
                        Montant = Math.Round(decimal.Parse(item["montant"].ToString()), 0),
                        Type = Helper.Util.ToPaiementType(item["modalite"].ToString())
                    });
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
            return instances;
        }

        public async Task<List<Model.POCO.PaiementDetail>> GetInfoPaiementsAsync(Inscription inscription)
        {
            var instances = new List<Model.POCO.PaiementDetail>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.Parameters.Clear();

                Request.CommandText = "sp_get_info_paiement";
                Request.CommandType = CommandType.StoredProcedure;

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_inscription_id", DbType.String, inscription?.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_niveau_id", DbType.String, inscription?.Promotion?.Niveau?.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_annee_id", DbType.String, inscription?.Annee?.Id));

                Reader = await Request.ExecuteReaderAsync();


                if (Reader.HasRows)
                    while (Reader.Read())
                    {
                        _instances.Add(
                            new Dictionary<string, object>()
                            {
                                { "paiement", Reader["paiement"] },
                                { "numero", Reader["numero"] },
                                { "montant", Reader["montant"] },
                                { "modalite", Reader["modalite"] }
                            });
                    }

                Reader.Close();

                foreach (var item in _instances)
                {
                    instances.Add(new Model.POCO.PaiementDetail()
                    {
                        Numero = int.Parse(item["numero"].ToString()),
                        Paiement = Math.Round(decimal.Parse(item["paiement"].ToString()), 0),
                        Montant = Math.Round(decimal.Parse(item["montant"].ToString()), 0),
                        Type = Helper.Util.ToPaiementType(item["modalite"].ToString())
                    });
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
            return instances;
        }

        public async Task<List<Paiement>> GetAllAsync()
        {
            var instances = new List<Paiement>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from paiement ";

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

                    instances.Add(instance);
                }
            }
            catch (Exception)
            {
                if (Reader != null)
                    Reader.Close();
            }

            return instances;
        }
    }
}

