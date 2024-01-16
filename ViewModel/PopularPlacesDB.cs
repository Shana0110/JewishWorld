using model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PopularPlacesDB : PlacesDB
    {
        static private PopularPlacesList list = new PopularPlacesList();
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
            PopularPlace pl = entity as PopularPlace;
            if (pl != null)
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
                updated.Add(new ChangeEntity(base.CreateUpdateSQL, entity));
            }
        }
        public override void Delete(Base entity)
        {
           PopularPlace pl = entity as PopularPlace;
            if (pl != null)
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
                deleted.Add(new ChangeEntity(base.CreateDeletedSQL, entity));
            }
        }
        protected override PopularPlace NewEntity()
        {
            return new PopularPlace();
        }
        protected override Base CreateModel(Base entity)
        {
            PopularPlace c = entity as PopularPlace;
            c.Photo = reader["Photo"].ToString();

            base.CreateModel(entity);
            return c;
        }
        public PopularPlacesList SelectAll()
        {
            command.CommandText = $"SELECT PopularPlaces.Photo, Places.Adresse, Places.CityCode, Places.Id FROM (PopularPlaces INNER JOIN Places ON PopularPlaces.Id = Places.Id)";
            PopularPlacesList pList = new PopularPlacesList(base.Select());
            return pList;
        }
        protected override void CreateInsertSQL(Base entity, OleDbCommand command)
        {
            PopularPlace p = entity as PopularPlace;
            if (p != null)
            {
                string sqlStr = $"INSERT INTO PopularPlaces (Photo, Id ) " +
                                $" Values (@Photo,Id)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@Photo", p.Photo));
                command.Parameters.Add(new OleDbParameter("@Id", p.Id));
            }
        }
        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            PopularPlace p = entity as PopularPlace;

            string sqlStr = $"UPDATE PopularPlaces SET Photo='{p.Photo}' " +
                $"WHERE ID =@pId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@pId", p.Id));
        }
        protected override void CreateDeletedSQL(Base entity, OleDbCommand command)
        {
            PopularPlace p = entity as PopularPlace;
            string sqlStr = $"DELETE FROM PopularPlaces WHERE ID = @pId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@pId", p.Id));
        }
        public async Task<PopularPlacesList> SelectAllAsync()
        {
            command.CommandText = $"SELECT * FROM PopularPlace";
            PopularPlacesList pList = new PopularPlacesList((IEnumerable<PopularPlace>)base.SelectAsync());
            return pList;

        }
        public PopularPlace SelectById(int id)
        {
            if (list.Count == 0)
            {
                PopularPlacesDB db = new PopularPlacesDB();
                list = db.SelectAll();
            }
            PopularPlace p = list.Find(item => item.Id == id);
            return p;
        }
    }

}
