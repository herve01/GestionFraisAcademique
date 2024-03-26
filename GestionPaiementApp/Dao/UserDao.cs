using GestionPaiementApp.Model;
using GestionPaiementApp.Model.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GestionPaiementApp.Dao
{
    public class UserDao : Dao<User>
    {
        public UserDao()
        {
            TableName = "user";
        }

        public override int Add(User instance)
        {
            try
            {
                var hash = PasswordStorage.CreateHash(instance.PassWord);
                var split = hash.Split(':');
                var salt = split[0];
                var pwd = string.Format("{0}:{1}", split[1], split[2]);

                var id = TableKeyHelper.GetKey(TableName);

                Request.CommandText = "insert into user " +
                    "values(@v_id, @v_role, @v_nom, @v_prenom, @v_username, @v_type, @v_email, @v_passwd, @v_m_salt, @v_etat)";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_role", DbType.String, instance.Role));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_nom", DbType.String, instance.Nom));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_prenom", DbType.String, instance.Prenom));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_username", DbType.String, instance.UserName));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_type", DbType.String, instance.Type));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_email", DbType.String, instance?.Email));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_passwd", DbType.String, pwd));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_m_salt", DbType.String, salt));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_etat", DbType.String, instance.Etat));

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
        public override int Delete(User instance)
        {
            try
            {
                Request.CommandText = "delete from user where id = @v_id ";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));

                var feed = Request.ExecuteNonQuery();

                return feed;
            }
            catch (Exception)
            {

                return -1;
            }

        }
        public override int Update(User instance, User oldObj)
        {
            try
            {

                Request.CommandText = "update user " +
                             "set nom = @v_nom, " +
                             "prenom = @v_prenom, " +
                             "type = @v_type, " +
                             "username = @v_username, " +
                             "role = @v_role, " +
                             "email = @v_email " +
                             "where id = @v_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_role", DbType.String, instance.Role));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_nom", DbType.String, instance.Nom));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_prenom", DbType.String, instance.Prenom));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_username", DbType.String, instance.UserName));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_type", DbType.String, instance.Type));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_email", DbType.String, instance.Email));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, instance.Id));

                var feed = Request.ExecuteNonQuery();

                return feed;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        protected override Dictionary<string, object> Map(DbDataReader row)
        {
            return new Dictionary<string, object>()
            {
                { "id", row["id"] },
                { "role", row["role"] },
                { "nom", row["nom"] },
                { "prenom", row["prenom"] },
                { "username", row["username"] },
                { "type", row["type"] },
                { "email", row["email"] },
                { "etat", row["etat"] }
            };
        }

        private User Create(Dictionary<string, object> row)
        {
            User instance = new User()
            {
                Id = row["id"].ToString(),
                Nom = row["nom"].ToString(),
                Prenom = row["prenom"].ToString(),
                UserName = row["username"].ToString(),
                Email = row["email"]?.ToString()
            };

            RoleType role;
            if(Enum.TryParse<RoleType>(row["role"].ToString(), true, out role))
                instance.Role = role;

            UserType type;
            if (Enum.TryParse<UserType>(row["type"].ToString(), true, out type))
                instance.Type = type;

            UserEtat etat;
            if (Enum.TryParse<UserEtat>(row["etat"].ToString(), true, out etat))
                instance.Etat = etat;

            return instance;
        }

        public User Get(string id)
        {
            User instance = null;
            Dictionary<string, object> _instance = null;

            try
            {
                Request.CommandText = "select * " +
                    "from user " +
                    "where id = @v_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, id));

                using (Reader = Request.ExecuteReader())
                {
                    if (Reader.HasRows && Reader.Read())
                        _instance = Map(Reader);

                    Reader.Close();
                };

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

        public async Task<User> GetAsync(string username, string passwd)
        {
            User user = null;
            Dictionary<string, object> _user = null;

            try
            {
                Request.CommandText = "select * " +
                    "from user " +
                    "where username = @v_username or email = @v_username";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_username", DbType.String, username));

                Reader = await Request.ExecuteReaderAsync();

                if (Reader.HasRows && Reader.Read())
                {
                    var uPwd = Reader["passwd"].ToString();
                    var uSalt = Reader["m_salt"].ToString();

                    if (PasswordStorage.VerifyPassword(passwd, uSalt, uPwd))
                        _user = Map(Reader);

                }

                Reader.Close();

                if (_user != null)
                    user = Create(_user);
            }
            catch (Exception)
            {
            }

            return user;
        }

        public User Get(string username, string passwd)
        {
            User user = null;
            Dictionary<string, object> _user = null;

            try
            {
                Request.CommandText = "select * " +
                    "from user " +
                    "where username = @v_username or email = @v_username";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_username", DbType.String, username));

                Reader = Request.ExecuteReader();

                if (Reader.HasRows && Reader.Read())
                {
                    var uPwd = Reader["passwd"].ToString();
                    var uSalt = Reader["m_salt"].ToString();

                    if (PasswordStorage.VerifyPassword(passwd, uSalt, uPwd))
                        _user = Map(Reader);
                }

                Reader.Close();

                if (_user != null)
                    user = Create(_user);
            }
            catch (Exception)
            {
            }

            return user;
        }

        public int Lock(User user)
        {
            try
            {
                Request.CommandText = "update user " +
                    "set etat = @v_etat " +
                    "where id = @v_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, user.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_etat", DbType.String, user.Etat));


                var id = Request.ExecuteNonQuery();
                /*
             if (id > 0)
                 user.Etat = Model.UserState.Bloqué;
                 */
                return id;

            }
            catch (Exception)
            {
                return -1;
            }

        }

        public int Unlock(User user)
        {
            try
            {
                Request.CommandText = "update user " +
                    "set etat = @v_etat " +
                    "where id = @v_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, user.Id));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_etat", DbType.Boolean, user.Etat));


                var id = Request.ExecuteNonQuery();

                //if (id > 0)
                //  user.Etat = Model.UserState.Fonctionnel;

                return id;

            }
            catch (Exception)
            {
                return -1;
            }

        }

        public int SetPasswd(User user, string newPasswd)
        {
            try
            {
                var hash = PasswordStorage.CreateHash(newPasswd);
                var split = hash.Split(':');
                var salt = split[0];
                var pwd = string.Format("{0}:{1}", split[1], split[2]);

                Request.CommandText = "update user " +
                    "set passwd = @v_passwd," +
                    "m_salt = @v_m_salt, " +
                    "last_update_time = now() " +
                    "where id = @v_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_passwd", DbType.String, pwd));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_m_salt", DbType.String, salt));
                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, user.Id));

                int feedback = Request.ExecuteNonQuery();

                if (feedback > 0)
                    user.PassWord = newPasswd;

                return feedback;

            }
            catch (Exception)
            {
                return -1;
            }

        }

        public bool CheckPassword(User user, string passwd)
        {
            try
            {
                Request.CommandText = "select passwd, m_salt " +
                    "from user " +
                    "where id = @v_id";

                Request.Parameters.Add(DbUtil.CreateParameter(Request, "@v_id", DbType.String, user.Id));

                Reader = Request.ExecuteReader();

                if (Reader.HasRows && Reader.Read())
                {
                    var uPwd = Reader["passwd"].ToString();
                    var uSalt = Reader["m_salt"].ToString();

                    Reader.Close();

                    return PasswordStorage.VerifyPassword(passwd, uSalt, uPwd);
                }

                Reader.Close();
            }
            catch (Exception)
            {
                if (Reader != null && !Reader.IsClosed)
                    Reader.Close();
            }

            return false;
        }

        public List<User> GetAll()
        {
            var intances = new List<User>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from user ";

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

        public async Task<List<User>> GetAllAsync()
        {
            var intances = new List<User>();
            var _instances = new List<Dictionary<string, object>>();

            try
            {
                Request.CommandText = "select * from user where username <>'sysadmin'";

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
                    var user = Create(item);
                    user.Number = i;

                    intances.Add(user);
                }
            }
            catch (Exception e)
            {
                if (Reader != null)
                    Reader.Close();

                System.Windows.Forms.MessageBox.Show(e.Message);
            }

            return intances;
        }

    }
}
