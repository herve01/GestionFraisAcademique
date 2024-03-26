using GestionPaiementApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPaiementApp.Dao
{
    public class PromotionDao : Dao<Promotion>

    {
        public override int Add(Promotion instance)
            {
                try
                {


                    var id = TableKeyHelper.GetKey(TableName);

                    Request.CommandText = "insert into Promotion(id, division_id, direction_id, denomination) " +
                        "values(@v_id, @v_division_id, @v_direction_id, @v_denomination)";

                    Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, id));
                    Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_division_id", DbType.String, instance.Promotion_id));
                    Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_direction_id", DbType.String, instance.Niveau_id);
                    Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_denomination", DbType.String, instance.Filier));

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
                    try
                    {

                        Request.CommandText = "update e " +
                            "set Promotion_id = @v_Promotion_id," +
                            "Niveau = @v_Niveau_id, " +
                            "Filiere = @v_Filiere";


                        Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, id));
                        Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_division_id", DbType.String, instance.Promotion_id));
                        Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_direction_id", DbType.String, instance.Niveau_id);
                        Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_denomination", DbType.String, instance.Filier));

                        var feed = Request.ExecuteNonQuery();

                        return feed;
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            protected override Dictionary<string, object> Map(DbDataReader row)
            {
                return new Dictionary<string, object>()
                        {
                            { "id", row["id"] },
                            { "Promotion_id", row["Promotion_id"] },
                            { "Niveau_id", row["Niveau_id"] },
                            { "Filiere", row["Filiere"] }

                        };
            }
            private Promotion Create(Dictionary<string, object> row)
            {
                Promotion instance = new Promotion();

                instance.Id = row["id"].ToString();
                instance.Promotion_id = row["Promotion_id"].ToString();
                instance.Niveau_id = row["pNiveau_id"].ToString();
                instance.Filiere = row["Filiere"].ToString();


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
                        instance = Create(_instance);

                }
                catch (Exception)
                {
                    if (Reader != null && !Reader.IsClosed)
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
            if (Reader != null && !Reader.IsClosed)
                Reader.Close();
        }

        return intances;
    }

    }


}
