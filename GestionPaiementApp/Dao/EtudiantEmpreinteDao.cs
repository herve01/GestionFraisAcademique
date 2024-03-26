using GestionPaiementApp.Dao.Helper;
using GestionPaiementApp.Model;
using GestionPaiementApp.Model.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPaiementApp.Dao
{
    public class EtudiantEmpreinteDao : Dao<EtudiantEmpreinte>
    {
        public EtudiantEmpreinteDao()
        {
            TableName = "etudiant_empreinte";

        }
        public override int Add(EtudiantEmpreinte instance)
        {
            try
            {
                var id = TableKeyHelper.GetKey(TableName);

                Request.CommandText = "insert into etudiant_empreinte(id, etudiant_id, size, empreinte_image, empreinte_template, finger) " +
                                    "values(@v_id, @v_etudiant_id, @v_size, @v_empreinte_image, @v_empreinte_template, @v_finger)";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_etudiant_id", DbType.String, instance?.Etudiant?.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_size", DbType.Int32, instance.Size));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_empreinte_image", DbType.Binary, instance.Image));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_empreinte_template", DbType.Binary, instance.Template));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_finger", DbType.String, instance.Finger));

                var feed = Request.ExecuteNonQuery();

                if (feed > 0)
                    instance.Id = id;


                return feed;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public int Add(DbCommand command, List<EtudiantEmpreinte> instances)
        {
            Request = command;

            Request.Transaction = Connection.BeginTransaction();

            foreach (var instance in instances)
            {
                Request.Parameters.Clear();

                if (Add(instance) <= 0)
                {
                    Request.Transaction.Rollback();

                    return -1;
                }
            }

            Request.Transaction.Commit();

            return instances.Count;
        }

        public int Add(DbCommand command, EtudiantEmpreinte instance)
        {
            Request = command;

            Request.Parameters.Clear();

            return Add(instance);
        }

        public override int Delete(EtudiantEmpreinte instance)
        {
            try
            {
                Request.CommandText = "delete from  etudiant_empreinte where id = @v_id ";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));

                var feed = Request.ExecuteNonQuery();

                return feed;
            }
            catch (Exception)
            {

                return -1;
            }
           
        }

        public int SetEmpreintes(List<EtudiantEmpreinte> instances)
        {
            Request.Transaction = Connection.BeginTransaction();

            foreach (var instance in instances)
            {
                Request.Parameters.Clear();

                if (Add(instance) <= 0)
                {
                    Request.Transaction.Rollback();

                    return -1;
                }
            }

            Request.Transaction.Commit();

            return instances.Count;
        }

        public override int Update(EtudiantEmpreinte instance, EtudiantEmpreinte oldObj)
        {
            try
            {

                Request.CommandText = "update etudiant_empreinte " +
                                "set etudiant_id = @v_etudiant_id, " +
                                "size = @v_size, " +
                                "empreinte_template = @v_empreinte_template, " +
                                "empreinte_image = @v_empreinte_image, " +
                                "finger = @v_finger, " +
                                "where id = @v_id;";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_etudiant_id", DbType.String, instance?.Etudiant?.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_size", DbType.Int32, instance.Size));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_empreinte_image", DbType.Binary, instance.Image));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_empreinte_template", DbType.Binary, instance.Template));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_finger", DbType.String, instance.Finger));
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
                { "etudiant_id", row["etudiant_id"] },
                { "size", row["size"] },
                { "empreinte_image", row["empreinte_image"] },
                { "empreinte_template", row["empreinte_template"] },
                { "finger", row["finger"] }
            };
        }
        
        private EtudiantEmpreinte Create(Dictionary<string, object> row, bool withEtudiant = false)
        {
            var instance = new EtudiantEmpreinte();

            instance.Id = row["id"].ToString();
            instance.Size = int.Parse(row["size"].ToString());
            instance.Image = (byte[])row["empreinte_image"];
            instance.Template = (byte[])row["empreinte_template"];
            instance.Finger = Util.ToFingers(row["finger"].ToString());

            if (withEtudiant)
                instance.Etudiant = new EtudiantDao().Get(row["etudiant_id"].ToString(), false);

            return instance;
        }
        
        public EtudiantEmpreinte Get(string id)
        {
            EtudiantEmpreinte instance = null;
            Dictionary<string, object> _instance = null;

            try
            {
                Request.CommandText = "select * " +
                    "from etudiant_empreinte " +
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
        
        public List<EtudiantEmpreinte> GetAll()
        {
            var intances = new List<EtudiantEmpreinte>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from etudiant_empreinte ";

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

        public List<EtudiantEmpreinte> GetAll(Etudiant etudiant)
        {
            var intances = new List<EtudiantEmpreinte>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from etudiant_empreinte " +
                    "where etudiant_id = @v_etudiant_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_etudiant_id", DbType.String, etudiant.Id));

                Reader = Request.ExecuteReader();

                if (Reader.HasRows)
                    while (Reader.Read())
                        _instances.Add(Map(Reader));

                Reader.Close();

                foreach (var item in _instances)
                {
                    var empreinte = Create(item);
                    empreinte.Etudiant = etudiant;
                    intances.Add(empreinte);
                }
            }
            catch (Exception)
            {
                if (Reader != null)
                    Reader.Close();
            }

            return intances;
        }

        public async Task<EtudiantEmpreinte> GetAsync(DPFP.Sample Sample)
        {
            EtudiantEmpreinte instance = null;
            Dictionary<string, object> _instance = null;

            try
            {
                Request.CommandText = "select * " +
                    "from etudiant_empreinte ";

                Reader = await Request.ExecuteReaderAsync();

                if (Reader.HasRows)
                    while (await Reader.ReadAsync())
                    {
                        var row = Map(Reader);

                        if (FingerPrintUtil.verifiy(Sample, (byte[])row["empreinte_template"]))
                        {
                            _instance = row;
                            break;
                        }
                    }

                Reader.Close();

                if (_instance != null)
                    instance = Create(_instance, true);

            }
            catch (Exception e)
            {
                if (Reader != null && !Reader.IsClosed)
                    Reader.Close();
            }

            return instance;
        }
    }
}
