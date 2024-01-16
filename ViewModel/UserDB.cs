using model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserDB : BaseDB
    {
        static private UserList list = new UserList();
        protected override Base NewEntity()
        {
            return new User();
        }
        protected override Base CreateModel(Base entity)
        {
            User c = entity as User;
            c.Name = reader["UserName"].ToString();
            c.Code = reader["code"].ToString();

            base.CreateModel(entity);
            return c;
        }
        public UserList SelectAll()
        {
            command.CommandText = $"SELECT * FROM [User]";
            UserList cList = new UserList(base.Select());
            return cList;
        }
        protected override void CreateInsertSQL(Base entity, OleDbCommand command)
        {
            User user = entity as User;
            if (user != null)
            {
                string sqlStr = $"INSERT INTO [User] (UserName,code ) " +
                                $" VALUES ('{user.Name}','{user.Code}')";
              

                command.CommandText = sqlStr;
         
            }
        }
        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            User user = entity as User;

            string sqlStr = $"UPDATE [User] SET UserName='{user.Name}',code='{user.Code}' " +
                $"WHERE ID =@cId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@cId", user.Id));
        }
        protected override void CreateDeletedSQL(Base entity, OleDbCommand command)
        {
            User user = entity as User;
            string sqlStr = $"DELETE FROM [User] WHERE ID = @cId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@cId", user.Id));
        }
        public async Task<UserList> SelectAllAsync()
        {
            command.CommandText = $"SELECT * FROM [User]";
            UserList cList = new UserList((IEnumerable<User>)base.SelectAsync());
            return cList;

        }
        public User SelectById(int id)
        {
            if (list.Count == 0)
            {
                UserDB db = new UserDB();
                list = db.SelectAll();
            }
            User user = list.Find(item => item.Id == id);
            return user;
        }
    }

}
