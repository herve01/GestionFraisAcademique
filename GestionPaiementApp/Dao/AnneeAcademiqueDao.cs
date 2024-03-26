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
    public class AnneeAcademiqueDao : Dao<AnneeAcademique>
    {
        public AnneeAcademiqueDao()
        {
            TableName = "annee_academique";
        }

        public override int Add(AnneeAcademique instance)
        {
            try
            {
                var id = TableKeyHelper.GetKey(TableName);

                Request.CommandText = "insert into annee_academique (id, annee, date_ouverture, date_cloture) " +
                    "values(@v_id, @v_annee, @v_date_ouverture, @v_date_cloture)";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_annee", DbType.String, instance.Annee));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_date_ouverture", DbType.Date, instance.DateOuverture));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_date_cloture", DbType.Date, instance.DateCloture));

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
        public override int Delete(AnneeAcademique instance)
        {
            try
            {
                Request.CommandText = "delete from  Annee where id = @v_id ";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));

                var feed = Request.ExecuteNonQuery();

                return feed;
            }
            catch (Exception)
            {

                return -1;
            }

        }
        public override int Update(AnneeAcademique instance, AnneeAcademique oldObj)
        {
            try
            {

                Request.CommandText = "update annee_academique " +
                    "set annee = @v_annee, " +
                    "date_ouverture = @v_date_ouverture, " +
                    "date_cloture = @v_date_cloture " +
                    "where id = @v_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_annee", DbType.String, instance.Annee));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_date_ouverture", DbType.Date, instance.DateOuverture));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_date_cloture", DbType.Date, instance.DateCloture));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance?.Id));

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
                { "annee", row["annee"] },
                { "date_ouverture", row["date_ouverture"] },
                { "date_cloture", row["date_cloture"] },
            };
        }
        private AnneeAcademique Create(Dictionary<string, object> row)
        {
            AnneeAcademique instance = new AnneeAcademique()
            {
                Id = row["id"].ToString(),
                Annee = row["annee"].ToString(),
                DateOuverture = DateTime.Parse(row["date_ouverture"].ToString()),
                DateCloture = DateTime.Parse(row["date_cloture"].ToString())
            };

            return instance;
        }

        public AnneeAcademique Get(string id)
        {
            AnneeAcademique instance = null;
            Dictionary<string, object> _instance = null;

            try
            {
                Request.CommandText = "select * " +
                    "from annee_academique " +
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

        public AnneeAcademique Get()
        {
            AnneeAcademique instance = null;
            Dictionary<string, object> _instance = null;

            try
            {
                Request.CommandText = "select * " +
                    "from annee_academique " +
                    "order by date_cloture desc " +
                    "limit 1";

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

        public List<AnneeAcademique> GetAll()
        {
            var intances = new List<AnneeAcademique>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from annee_academique ";

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

        public async Task<List<AnneeAcademique>> GetAllAsync()
        {
            var intances = new List<AnneeAcademique>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from annee_academique ";

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
                    var annee = Create(item);
                    annee.Number = i;

                    intances.Add(annee);
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
