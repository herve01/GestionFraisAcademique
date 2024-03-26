using GestionPaiementApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPaiementApp.Dao
{
    public class AnneesDao : Dao<Annees>
    public override int Add(Annees instance)
    {
        try
        {


            var id = TableKeyHelper.GetKey(TableName);

            Request.CommandText = "insert into Annees (id, division_id) " +
                "values(@v_id, @v_division_id )";

            Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, id));
            Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_division_id", DbType.String, instance.Annees_id));
            
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
    public override int Delete(Annees instance)
    {
        try
        {
            Request.CommandText = "delete from  Annees where id = @v_id ";

            Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));

            var feed = Request.ExecuteNonQuery();

            return feed;
        }
        catch (Exception)
        {

            return -1;
        }

    }
    public override int Update(Annees instance, Annees oldObj)
    {
        try
        {
            try
            {

                Request.CommandText = "update e " +
                    "set Annees_id = @v_Annees_id,";
                 


                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_division_id", DbType.String, instance.Annees_id));
                 
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
                { "Annes_id", row["Annees_id"] }
                

            };
    }
    private Annees Create(Dictionary<string, object> row) 
    {
        Annees instance = new Annees();

        instance.Id = row["id"].ToString();
        instance.Annees_id = row["Annees_id"].ToString();
        

        return instance;
    }

    public Annees Get(string id)
    {
        Annes instance = null;
        Dictionary<string, object> _instance = null;

        try
        {
            Request.CommandText = "select * " +
                "from Annees " +
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
    public List<Annes> GetAll()
    {
        var intances = new List<Annes>();
        var _instances = new List<Dictionary<string, object>>();

        try
        {
            Request.CommandText = "select * from Anness ";

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
