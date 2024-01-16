using model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class KosherRestaurantDB : PlacesDB
    {
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
            KosherRestaurant kr = entity as KosherRestaurant;
            if (kr != null)
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
                updated.Add(new ChangeEntity(base.CreateUpdateSQL, entity));
            }
        }
        public override void Delete(Base entity)
        {
            KosherRestaurant kr = entity as KosherRestaurant;
            if (kr != null)
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
                deleted.Add(new ChangeEntity(base.CreateDeletedSQL, entity));
            }
        }

        static private KosherRestaurantList list = new KosherRestaurantList();
        protected override KosherRestaurant NewEntity()
        {
            return new KosherRestaurant();
        }
        protected override Base CreateModel(Base entity)
        {
            KosherRestaurant c = entity as KosherRestaurant;
            c.Telephone = reader["Telephone"].ToString();
            c.Name = reader["Name"].ToString();
            c.TypeOfFood = reader["RestType"].ToString();

            base.CreateModel(entity);
            return c;
        }
        public KosherRestaurantList SelectAll()
        {
            command.CommandText = $"SELECT  KosherRestaurant.*, Places.CityCode, Places.Adresse FROM (KosherRestaurant INNER JOIN Places ON KosherRestaurant.Id = Places.Id)";
            KosherRestaurantList kList = new KosherRestaurantList(base.Select());
            return kList;
        }
        protected override void CreateInsertSQL(Base entity, OleDbCommand command)
        {
            KosherRestaurant kosher = entity as KosherRestaurant;
            if (kosher != null)
            {
                string sqlStr = $"INSERT INTO KosherRestaurant (Id , Telephone,RestType,Name ) " +
                                $" Values (@id, @Telephone,@RestType,@Name)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@id", kosher.Id));
                command.Parameters.Add(new OleDbParameter("@Telephone", kosher.Telephone));
                command.Parameters.Add(new OleDbParameter("@RestType", kosher.TypeOfFood));
                command.Parameters.Add(new OleDbParameter("@Name", kosher.Name));

            }
        }
        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            KosherRestaurant kosher = entity as KosherRestaurant;

            string sqlStr = $"UPDATE KosherRestaurant SET Telephone='{kosher.Telephone}',RestType='{kosher.TypeOfFood}', Name='{kosher.Name}' " +
                $"WHERE ID =@kId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@kId", kosher.Id));
        }
        protected override void CreateDeletedSQL(Base entity, OleDbCommand command)
        {
            KosherRestaurant kosher = entity as KosherRestaurant;
            string sqlStr = $"DELETE FROM KosherRestaurant WHERE ID = @kId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@kId", kosher.Id));
        }
        public async Task<KosherRestaurantList> SelectAllAsync()
        {
            command.CommandText = $"SELECT * FROM KosherRestaurant";
            KosherRestaurantList kList = new KosherRestaurantList((IEnumerable<KosherRestaurant>)base.SelectAsync());
            return kList;

        }
        public KosherRestaurant SelectById(int id)
        {
            if (list.Count == 0)
            {
                KosherRestaurantDB db = new KosherRestaurantDB();
                list = db.SelectAll();
            }
            KosherRestaurant kosher = list.Find(item => item.Id == id);
            return kosher;
        }
    }
}
