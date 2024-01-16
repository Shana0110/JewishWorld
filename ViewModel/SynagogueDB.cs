using model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class SynagogueDB : PlacesDB
    {
        static private SynagogueList list = new SynagogueList();
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
            Synagogue s = entity as Synagogue;
            if (s != null)
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
                updated.Add(new ChangeEntity(base.CreateUpdateSQL, entity));
            }
        }
        public override void Delete(Base entity)
        {
            Synagogue s = entity as Synagogue;
            if (s != null)
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
                deleted.Add(new ChangeEntity(base.CreateDeletedSQL, entity));
            }
        }

        protected override Synagogue NewEntity()
        {
            return new Synagogue();
        }
        protected override Base CreateModel(Base entity)
        {
            Synagogue c = entity as Synagogue;
            TimeOnly myTime=new TimeOnly();
            bool flag =TimeOnly.TryParseExact(reader["OpenHour"].ToString(), "HH:mm:ss", out TimeOnly time);
            c.OpenHour = time;
            bool flag1 = TimeOnly.TryParseExact(reader["CloseHour"].ToString(), "HH:mm:ss", out TimeOnly time1);
            c.CloseHour = time1;

            base.CreateModel(entity);
            return c;
        }
        public SynagogueList SelectAll()
        {
            command.CommandText = $"SELECT Places.*, Synagogue.OpenHour, Synagogue.CloseHour FROM (Synagogue INNER JOIN Places ON Synagogue.Id = Places.Id)";
            SynagogueList kList = new SynagogueList(base.Select());
            return kList;
        }
        protected override void CreateInsertSQL(Base entity, OleDbCommand command)
        {
            Synagogue s = entity as Synagogue;
            if (s != null)
            {
                string sqlStr = $"INSERT INTO Synagogue (Id,OpenHour,CloseHour ) " +
                                $" Values (@Id,#{s.OpenHour}#,#{s.CloseHour}#)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@Id", s.Id));
               
            }
        }
        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            Synagogue s = entity as Synagogue;

            string sqlStr = $"UPDATE Synagogue SET OpenHour='{s.OpenHour}',CloseHour='{s.CloseHour}' " +
                $"WHERE ID =@sId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@sId", s.Id));
        }
        protected override void CreateDeletedSQL(Base entity, OleDbCommand command)
        {
            Synagogue s = entity as Synagogue;
            string sqlStr = $"DELETE FROM Synagogue WHERE ID = @sId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@sId", s.Id));
        }
        public async Task<SynagogueList> SelectAllAsync()
        {
            command.CommandText = $"SELECT * FROM Synagogue";
            SynagogueList sList = new SynagogueList((IEnumerable<Synagogue>)base.SelectAsync());
            return sList;

        }
        public Synagogue SelectById(int id)
        {
            if (list.Count == 0)
            {
                SynagogueDB db = new SynagogueDB();
                list = db.SelectAll();
            }
            Synagogue b = list.Find(item => item.Id == id);
            return b;
        }
    }
}


