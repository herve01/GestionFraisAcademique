using GestionPaiementApp.Dao.Helper;
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
    public class InscriptionDao: Dao<Inscription>
    {
        public InscriptionDao()
        {
            TableName = "inscription";
        }

        public override int Add(Inscription instance)
        {
            try
            {
                var id = TableKeyHelper.GetKey(TableName);

                Request.Transaction = Connection.BeginTransaction();

                var feed = new EtudiantDao().Add(Request, instance.Etudiant);

                if (feed > 0)
                {
                    Request.Parameters.Clear();

                    Request.CommandText = "insert into inscription(id, etudiant_id, annee_id, promotion_id, vacation, photo) " +
                    "values(@v_id, @v_etudiant_id, @v_annee_id, @v_promotion_id, @v_vacation,  @v_photo)";

                    Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, id));
                    Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_etudiant_id", DbType.String, instance?.Etudiant?.Id));
                    Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_annee_id", DbType.String, instance?.Annee?.Id));
                    Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_promotion_id", DbType.String, instance?.Promotion?.Id));
                    Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_vacation", DbType.String, instance.Vacation));
                    Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_photo", DbType.String, System.Convert.ToBase64String(instance.Photo) ?? null));

                    feed = Request.ExecuteNonQuery();

                    if (feed <= 0)
                    {
                        Request.Transaction.Rollback();
                        return -1;
                    }

                    instance.Id = id;
                    Request.Transaction.Commit();
                    return 1;
                }
                else
                {
                    Request.Transaction.Rollback();
                    return -3;
                }
            }
            catch (Exception)
            {
                Request.Transaction.Rollback();
                return -4;
            }
        }
        
        public override int Delete(Inscription instance)
        {
            try
            {
                Request.CommandText = "delete from inscription where id = @v_id ";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));

                var feed = Request.ExecuteNonQuery();

                return feed;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        
        public override int Update(Inscription instance, Inscription oldObj)
        {
            try
            {
                Request.Transaction = Connection.BeginTransaction();

                var feed = new EtudiantDao().Update(Request, instance.Etudiant);

                if (feed > 0)
                {
                    Request.Parameters.Clear();

                    Request.CommandText = "update inscription " +
                              "set etudiant_id = @v_etudiant_id," +
                              "promotion_id = @v_promotion_id, " +
                              "annee_id = @v_annee_id," +
                              "vacation = @v_vacation, " +
                              "photo = @v_photo " +
                              "where id = @v_id";

                    Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));
                    Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_etudiant_id", DbType.String, instance?.Etudiant?.Id));
                    Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_annee_id", DbType.String, instance?.Annee?.Id));
                    Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_promotion_id", DbType.String, instance?.Promotion?.Id));
                    Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_vacation", DbType.String, instance.Vacation));
                    Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_photo", DbType.String, System.Convert.ToBase64String(instance.Photo) ?? null));


                    feed = Request.ExecuteNonQuery();

                    if (feed <= 0)
                    {
                        Request.Transaction.Rollback();
                        return -1;
                    }
                    Request.Transaction.Commit();
                    return 1;
                }
                else
                {
                    Request.Transaction.Rollback();
                    return -2;
                } 
            }
            catch (Exception)
            {
                Request.Transaction.Rollback();
                return -3;
            }
        }

        public int SetPhoto(Inscription instance)
        {
            try
            {

                Request.CommandText = "update inscription " +
                                    "set photo = @v_photo " +
                                    "where id = @v_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_photo", DbType.String, System.Convert.ToBase64String(instance.Photo)));
               
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
                    { "etudiant_id", row["etudiant_id"] },
                    { "promotion_id", row["promotion_id"] },
                    { "annee_id", row["annee_id"] },
                    { "vacation", row["vacation"] },
                    { "photo", row["photo"] }
                };
        }
        
        private Inscription Create(Dictionary<string, object> row, bool withEtudent = true, bool withAnnee = true, bool withPromotion = true, bool withPaiement = false, AnneeAcademique annee = null)
        {
           Inscription instance = new Inscription();

            instance.Id = row["id"].ToString();

            if(withEtudent)
                instance.Etudiant =  new EtudiantDao().Get(row["etudiant_id"].ToString());

            if (!(row["photo"] is DBNull))
                instance.Photo = Convert.FromBase64String(row["photo"].ToString());

            if (withAnnee)
                instance.Annee = new AnneeAcademiqueDao().Get(row["annee_id"].ToString());

            if(withPromotion)
                instance.Promotion = new PromotionDao().Get(row["promotion_id"].ToString());

            if(annee != null)
                instance.Annee = annee;

            if (withPaiement)
                instance.Paiements = new PaiementDao().GetInfoPaiements(instance);

            instance.Vacation = Util.ToVacationType(row["vacation"].ToString());

            instance.Faculte = new FaculteDao().Get(instance.Promotion);
      
            return instance;
        }
        
        public Inscription Get(string id)
        {
            Inscription instance = null;
            Dictionary<string, object> _instance = null;

            try
            {
                Request.CommandText = "select * " +
                    "from inscription " +
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
        
        public List<Inscription> GetAll()
        {
            var intances = new List<Inscription>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from inscription ";

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

        public async Task<List<Inscription>> GetAllAsync()
        {
            var intances = new List<Inscription>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from inscription ";

                Reader = await Request.ExecuteReaderAsync();

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

        public async Task<List<Inscription>> GetAllAsync(AnneeAcademique annee)
        {
            var intances = new List<Inscription>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from inscription " +
                    "where annee_id = @v_annee_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_annee_id", DbType.String, annee?.Id));

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
                    i++;
                    var row = Create(item, withAnnee: false, withPaiement:true, annee:annee);
                    //row.Annee = annee;
                    row.Number = i;

                    intances.Add(row);
                }
            }
            catch (Exception)
            {
                if (Reader != null)
                    Reader.Close();
            }

            return intances;
        }


        public async Task<Inscription> GetAsync(Etudiant etudiant, AnneeAcademique annee)
        {
            Inscription instance = null;
            Dictionary<string, object> _instance = null;

            try
            {
                Request.CommandText = "select * " +
                    "from inscription " +
                    "where etudiant_id = @v_etudiant_id and annee_id = @v_annee_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_etudiant_id", DbType.String, etudiant?.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_annee_id", DbType.String, annee?.Id));

                Reader = await Request.ExecuteReaderAsync();

                if (Reader.HasRows && Reader.Read())
                    _instance = Map(Reader);

                Reader.Close();

                if (_instance != null)
                {
                    instance = Create(_instance, false, false, true, true);
                    instance.Annee = annee;
                    instance.Etudiant = etudiant;
                }
            }
            catch (Exception)
            {
                if (Reader != null)
                    Reader.Close();
            }

            return instance;
        }
    }
}

