using model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class BeitHabbadDB : PlacesDB
    {
        static private BeitHabbadList list = new BeitHabbadList();
        public override void Insert(Base entity)
        {
            Base reqEntity = this.NewEntity();
            if (entity != null && entity.GetType() == reqEntity.GetType())
            {
                inserted.Add(new ChangeEntity(base.CreateInsertSQL, entity));
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, entity));
            }
        }
        public override void Update(Base entity)
        {
            BeitHabbad bt = entity as BeitHabbad;
            if (bt != null)
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
                updated.Add(new ChangeEntity(base.CreateUpdateSQL, entity));
            }
        }
        public override void Delete(Base entity)
        {
            BeitHabbad bt = entity as BeitHabbad;
            if (bt != null)
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
                deleted.Add(new ChangeEntity(base.CreateDeletedSQL, entity));
            }
        }
        protected override BeitHabbad NewEntity()
        {
            return new BeitHabbad();
        }
        protected override Base CreateModel(Base entity)
        {
            BeitHabbad c = entity as BeitHabbad;
            c.Telephone = reader["Telephone"].ToString();
            c.Email = reader["Email"].ToString();
            base.CreateModel(entity);
            return c;
        }
        public BeitHabbadList SelectAll()
        {
            command.CommandText = $"SELECT Places.*, BeitHabbad.Telephone, BeitHabbad.Email FROM (BeitHabbad INNER JOIN Places ON BeitHabbad.Id = Places.Id)";
            BeitHabbadList bList = new BeitHabbadList(base.Select());
            return bList;
        }
        protected override void CreateInsertSQL(Base entity, OleDbCommand command)
        {
            BeitHabbad b = entity as BeitHabbad;
            if (b != null)
            {
                string sqlStr = $"INSERT INTO BeitHabbad (Id,Telephone,Email) " +
                                $" Values (@Id,@Telephone,@Email)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@Id", b.Id));
                command.Parameters.Add(new OleDbParameter("@Telephone", b.Telephone));
                command.Parameters.Add(new OleDbParameter("@Email", b.Email));
            }
        }
        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            BeitHabbad b = entity as BeitHabbad;

            string sqlStr = $"UPDATE BeitHabbad SET Telephone='{b.Telephone}',Email='{b.Email}' " +
                $"WHERE ID =@bId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@bId", b.Id));
        }
        protected override void CreateDeletedSQL(Base entity, OleDbCommand command)
        {
            BeitHabbad b = entity as BeitHabbad;
            string sqlStr = $"DELETE FROM BeitHabbad WHERE ID = @bId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@bId", b.Id));
        }
        public async Task<BeitHabbadList> SelectAllAsync()
        {
            command.CommandText = $"SELECT * FROM BeitHabbad";
            BeitHabbadList bList = new BeitHabbadList((IEnumerable<BeitHabbad>)base.SelectAsync());
            return bList;

        }
        public BeitHabbad SelectById(int id)
        {
            if (list.Count == 0)
            {
                BeitHabbadDB db = new BeitHabbadDB();
                list = db.SelectAll();
            }
            BeitHabbad b = list.Find(item => item.Id == id);
            return b;
        }
    }

}
