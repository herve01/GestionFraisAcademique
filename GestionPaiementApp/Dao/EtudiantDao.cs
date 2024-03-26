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
    public class EtudiantDao : Dao<Etudiant>
    {
        public EtudiantDao()
        {
            TableName = "etudiant";

        }

        public override int Add(Etudiant instance)
        {
            try
            {
                var id = TableKeyHelper.GetKey(TableName);

                Request.CommandText = "insert into etudiant(id, matricule, nom, postnom, prenom, sexe, telephone, adresse) " +
                    "values(@v_id, @v_matricule, @v_nom, @v_postnom, @v_prenom, @v_sexe, @v_telephone, @v_adresse)";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_matricule", DbType.String, instance.Matricule));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_nom", DbType.String, instance.Nom));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_postnom", DbType.String, instance.Postnom));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_prenom", DbType.String, instance.Prenom));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_sexe", DbType.String, instance.Sexe));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_telephone", DbType.String, instance.Telephone));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_adresse", DbType.String, instance.Adresse));         

                var feed = Request.ExecuteNonQuery();

                if (feed > 0)
                {
                    instance.Id = id;

                    if(instance.Empreintes.Count > 0)
                        foreach (var empreinte in instance.Empreintes)
                        {
                            if (new EtudiantEmpreinteDao().Add(Request, empreinte) > 0)
                                feed = 1;
                        }                     
                }

                return feed;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public int Add(DbCommand command, Etudiant instance)
        {
            Request = command;

            Request.Parameters.Clear();

            return Add(instance);
        }

        public int AddT(Etudiant instance)
        {
            try
            {
                Request.Transaction = Connection.BeginTransaction();

                var id = TableKeyHelper.GetKey(TableName);

                Request.CommandText = "insert into etudiant(id, matricule, nom, postnom, prenom, sexe, telephone, adresse) " +
                    "values(@v_id, @v_matricule, @v_nom, @v_postnom, @v_prenom, @v_sexe, @v_telephone, @v_adresse)";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_matricule", DbType.String, instance.Matricule));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_nom", DbType.String, instance.Nom));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_postnom", DbType.String, instance.Postnom));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_prenom", DbType.String, instance.Prenom));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_sexe", DbType.String, instance.Sexe));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_telephone", DbType.String, instance.Telephone));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_adresse", DbType.String, instance.Adresse));
               
                var feed = Request.ExecuteNonQuery();

                if (feed <= 0)
                {
                    Request.Transaction.Rollback();
                    return -1;
                }

                instance.Id = id;

                foreach (var empreinte in instance.Empreintes)
                    if (new EtudiantEmpreinteDao().Add(Request, empreinte) <= 0)
                    {
                        instance.Id = null;
                        Request.Transaction.Rollback();

                        return -2;
                    }

                Request.Transaction.Commit();

                return feed;
            }
            catch (Exception)
            {
                Request.Transaction.Rollback();
                return -10;
            }
        }

        public override int Delete(Etudiant instance)
        {
            try
            {
                Request.CommandText = "delete from  etudiant where id = @v_id ";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));

                var feed = Request.ExecuteNonQuery();

                return feed;
            }
            catch (Exception)
            {

                return -1;
            }
           
        }
        
        public override int Update(Etudiant instance, Etudiant oldObj)
        {
            try
            {

                Request.CommandText = "update etudiant " +
                    "set nom = @v_nom, " +
                    "matricule = @v_matricule, " +
                    "postnom = @v_postnom, " +
                    "prenom = @v_prenom, " +
                    "sexe = @v_sexe, " +
                    "telephone = @v_telephone, " +
                    "adresse = @v_adresse " +
                    "where id = @v_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_matricule", DbType.String, instance.Matricule));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_nom", DbType.String, instance.Nom));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_postnom", DbType.String, instance.Postnom));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_prenom", DbType.String, instance.Prenom));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_sexe", DbType.String, instance.Sexe));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_telephone", DbType.String, instance.Telephone));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_adresse", DbType.String, instance.Adresse));
                
                var feed = Request.ExecuteNonQuery();

                return feed;
            }
            catch (Exception e)
            {
                return -1;
            }
        }


        public int Update(DbCommand command, Etudiant instance)
        {
            Request = command;

            Request.Parameters.Clear();

            return Update(instance, null);
        }

        protected override Dictionary<string, object> Map(DbDataReader row)
        {
            return new Dictionary<string, object>()
            {
                { "id", row["id"] },
                { "nom", row["nom"] },
                { "postnom", row["postnom"] },
                { "prenom", row["prenom"] },
                { "sexe", row["sexe"] },
                { "telephone", row["telephone"] },
                { "adresse", row["adresse"] }
            };
        }
        
        private Etudiant Create(Dictionary<string, object> row, bool withEmpreintes = true)
        {
            Etudiant instance = new Etudiant();

            instance.Id = row["id"].ToString();
            instance.Nom = row["nom"].ToString();
            instance.Postnom = row["postnom"].ToString();
            instance.Prenom = row["prenom"].ToString();
            instance.Sexe = row["sexe"].ToString();
            instance.Telephone = row["telephone"].ToString();
            instance.Adresse = row["adresse"].ToString();


            if (withEmpreintes)
                instance.Empreintes = new Dao.EtudiantEmpreinteDao().GetAll(instance);

            return instance;
        }
        
        public Etudiant Get(string id, bool withEmpreints = true)
        {
            Etudiant instance = null;
            Dictionary<string, object> _instance = null;

            try
            {
                Request.CommandText = "select * " +
                    "from etudiant " +
                    "where id = @v_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, id));

                Reader = Request.ExecuteReader();

                if (Reader.HasRows && Reader.Read())
                    _instance = Map(Reader);

                Reader.Close();

                if (_instance != null)
                    instance = Create(_instance, withEmpreints);

            }
            catch (Exception)
            {
                if (Reader != null)
                    Reader.Close();
            }

            return instance;
        }
        
        public List<Etudiant> GetAll()
        {
            var intances = new List<Etudiant>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from etudiant ";

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

        public List<Etudiant> GetAll(Inscription inscription)
        {
            var intances = new List<Etudiant>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from etudiant E " +
                    "inner join inscription I ON E.id = I.etudiant_id " +
                    "where I.promotion_id = @v_promotion_id and I.annee_id = @v_annee_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_promotion_id", DbType.String, inscription?.Promotion?.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_annee_id", DbType.String, inscription?.Annee?.Id));

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
    }
}
