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
    public class DepartementDao : Dao<Departement>
    {
        public DepartementDao()
        {
            TableName = "departement";
        }

        public override int Add(Departement instance)
        {
            try
            {
                var id = TableKeyHelper.GetKey(TableName);

                Request.CommandText = "insert into departement(id, faculte_id, nom) " +
                    "values(@v_id, @v_faculte_id, @v_nom)";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_faculte_id", DbType.String, instance?.Faculte?.Id));
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
        public override int Delete(Departement instance)
        {
            try
            {
                Request.CommandText = "delete from departement where id = @v_id ";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));

                var feed = Request.ExecuteNonQuery();

                return feed;
            }
            catch (Exception)
            {

                return -1;
            }

        }
        public override int Update(Departement instance, Departement oldObj)
        {
            try
            {

                Request.CommandText = "update departement " +
                    "set nom = @v_nom, " +
                    "faculte_id = @v_faculte_id " +
                    "where id = @v_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_faculte_id", DbType.String, instance?.Faculte?.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_nom", DbType.String, instance.Nom));

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
                { "faculte_id", row["faculte_id"] },
                { "nom", row["nom"] } ,           
            };
        }

        private Departement Create(Dictionary<string, object> row, bool withFaculte = false)
        {
            Departement instance = new Departement()
            {
                Id = row["id"].ToString(),
                Nom = row["nom"].ToString()
             };

            if (withFaculte)
                instance.Faculte = new FaculteDao().Get(row["faculte_id"].ToString());
            
            return instance;
        }

        public Departement Get(string id)
        {
            Departement instance = null;
            Dictionary<string, object> _instance = null;

            try
            {
                Request.CommandText = "select * " +
                    "from departement " +
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
        public List<Departement> GetAll(bool withFaculte = true)
        {
            var intances = new List<Departement>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from departement ";

                Reader = Request.ExecuteReader();

                if (Reader.HasRows)
                    while (Reader.Read())
                        _instances.Add(Map(Reader));

                Reader.Close();

                foreach (var item in _instances)
                {
                    intances.Add(Create(item, withFaculte));
                }
            }
            catch (Exception)
            {
                if (Reader != null)
                    Reader.Close();
            }

            return intances;
        }

        public List<Departement> GetAll(Faculte faculte)
        {
            var intances = new List<Departement>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from departement where faculte_id = @v_faculte_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_faculte_id", DbType.String, faculte?.Id));

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

        public async Task<List<Departement>> GetAllAsync()
        {
            var intances = new List<Departement>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from departement ";

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
                    var dep = Create(item, true);
                    dep.Number = i;
                    intances.Add(dep);
                }
            }
            catch (Exception)
            {
                if (Reader != null)
                    Reader.Close();
            }

            return intances;
        }

        public async Task<List<Departement>> GetAllAsync(Faculte faculte)
        {
            var intances = new List<Departement>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from departement where faculte_id = @v_faculte_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_faculte_id", DbType.String, faculte?.Id));

                using (Reader = await Request.ExecuteReaderAsync())
                {
                    if (Reader.HasRows)
                        while (Reader.Read())
                            _instances.Add(Map(Reader));

                    Reader.Close();
                }

                foreach (var item in _instances)
                {
                    var dep = Create(item);
                    dep.Faculte = faculte;

                    intances.Add(dep);
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
