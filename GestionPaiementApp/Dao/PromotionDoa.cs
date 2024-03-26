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
    public class PromotionDao : Dao<Promotion>
    {
        public PromotionDao()
        {
            TableName = "promotion";
        }

        public override int Add(Promotion instance)
        {
            try
            {
                var id = TableKeyHelper.GetKey(TableName);

                Request.CommandText = "insert into Promotion(id, niveau_id, departement_id, filiere) " +
                "values(@v_id, @v_niveau_id, @v_departement_id, @v_filiere)";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_niveau_id", DbType.String, instance?.Niveau?.Id)) ;
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_departement_id", DbType.String, instance?.Departement?.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_filiere", DbType.String, instance.Filiere));

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

        public override int Delete(Promotion instance)
        {
            try
            {
                Request.CommandText = "delete from  promotion where id = @v_id ";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));

                var feed = Request.ExecuteNonQuery();

                return feed;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        
        public override int Update(Promotion instance, Promotion oldObj)
        {
            try
            {
                Request.CommandText = "update promotion " +
                "set niveau_id = @v_niveau_id," +
                "departement_id = @v_departement_id, " +
                "filiere = @v_filiere " +
                "where id = @v_id";


                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_niveau_id", DbType.String, instance?.Niveau?.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_departement_id", DbType.String, instance?.Departement?.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_filiere", DbType.String, instance.Filiere));

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
                { "niveau_id", row["niveau_id"] },
                { "departement_id", row["departement_id"] },
                { "filiere", row["filiere"] }
            };
        }
        private Promotion Create(Dictionary<string, object> row, bool withDepartement = false)
        {
            Promotion instance = new Promotion();

            instance.Id = row["id"].ToString();
            instance.Niveau = new NiveauDao().Get(row["niveau_id"].ToString());

            if(withDepartement)
                instance.Departement = new DepartementDao().Get(row["departement_id"].ToString());

            instance.Filiere = row["filiere"].ToString();

            return instance;
        }

        public Promotion Get(string id)
        {
            Promotion instance = null;
            Dictionary<string, object> _instance = null;

            try
            {
                Request.CommandText = "select * " +
                "from promotion " +
                "where id = @v_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, id));

                Reader = Request.ExecuteReader();

                if (Reader.HasRows && Reader.Read())
                    _instance = Map(Reader);

                Reader.Close();

                if (_instance != null)
                    instance = Create(_instance, true);

            }
            catch (Exception)
            {
                if (Reader != null)
                    Reader.Close();
            }

            return instance;
        }

        public List<Promotion> GetAll()
        {
            var intances = new List<Promotion>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from promotion ";

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

        public List<Promotion> GetAll(Departement departement)
        {
            var intances = new List<Promotion>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from promotion where departement_id = @v_departement_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_departement_id", DbType.String, departement?.Id));

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

        public async Task<List<Promotion>> GetAllAsync()
        {
            var intances = new List<Promotion>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from promotion ";

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
                    var promotion = Create(item);
                    promotion.Number = i;

                    intances.Add(promotion);
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

        public async Task<List<Promotion>> GetAllAsync(Departement departement)
        {
            var intances = new List<Promotion>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from promotion where departement_id = @v_departement_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_departement_id", DbType.String, departement?.Id));

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
            }

            return intances;
        }
    }
}
