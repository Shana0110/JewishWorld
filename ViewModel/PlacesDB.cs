using model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ViewModel
{
    public class PlacesDB:BaseDB
    {
        static private PlacesList list = new PlacesList();
        protected override Base NewEntity()
        {
            return new Places();
        }
        protected override Base CreateModel(Base entity)
        {
            Places p = entity as Places;
            p.Adress = reader["Adresse"].ToString();
            int x = int.Parse(reader["CityCode"].ToString());
            CityDB cityDB = new CityDB();
            p.CityCode = cityDB.SelectById(int.Parse(reader["CityCode"].ToString()));

            base.CreateModel(entity);
            return p;
        }
        public PlacesList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Places";
            PlacesList pList = new PlacesList(base.Select());
            return pList;
        }
        protected override void CreateInsertSQL(Base entity, OleDbCommand command)
        {
            Places places = entity as Places;
            if (places != null)
            {
                string sqlStr = $"INSERT INTO Places (Adresse ,CityCode ) " +
                                $" Values (@Adresse, @CityCode)";
                //string sqlStr = $"INSERT INTO Places (Adresse ,CityCode ) " +
                //                              $" Values ('{places.Adress.ToString()}', {places.CityCode.Id})";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@Adresse", places.Adress.ToString()));
                command.Parameters.Add(new OleDbParameter("@CityCode", places.CityCode.Id));


            }
        }
        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            Places places = entity as Places;

            string sqlStr = $"UPDATE Places SET Adresse='{places.Adress}',CityCode= {places.CityCode.Id} " +
                $"WHERE ID =@pId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@pId", places.Id));
        }
        protected override void CreateDeletedSQL(Base entity, OleDbCommand command)
        {
            Places places = entity as Places;
            string sqlStr = $"DELETE FROM Places WHERE Id = @pId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@pId", places.Id));
        }
        public async Task<PlacesList> SelectAllAsync()
        {
            command.CommandText = $"SELECT * FROM Places";
            PlacesList pList = new PlacesList((IEnumerable<Places>)base.SelectAsync());
            return pList;

        }
        public Places SelectById(int id)
        {
            if (list.Count == 0)
            {
                PlacesDB db = new PlacesDB();
                list = db.SelectAll();
            }
            Places places = list.Find(item => item.Id == id);
            return places;
        }
    }
    
}
