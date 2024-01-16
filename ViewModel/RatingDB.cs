using model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ViewModel
{
    public class RatingDB : BaseDB
    {
        static private RatingList list = new RatingList();
        protected override Base NewEntity()
        {
            return new Rating();
        }
        protected override Base CreateModel(Base entity)
        {
            Rating r = entity as Rating;
            int x = int.Parse(reader["Rate"].ToString());
            RatingDB ratingDB = new RatingDB();
            r.Rate = x;

            int y = int.Parse(reader["IdPopularPlaces"].ToString());
            PopularPlacesDB popularPlacesDB = new PopularPlacesDB();
            r.IdPopularPlace = popularPlacesDB.SelectById(y);
            base.CreateModel(entity);
            return r;
        }
        public RatingList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Rating";
            RatingList rList = new RatingList(base.Select());
            return rList;
        }
        protected override void CreateInsertSQL(Base entity, OleDbCommand command)
        {
            Rating r = entity as Rating;
            if (r != null)
            {
                string sqlStr = $"INSERT INTO Rating (IdPopularPlaces, Rate) Values (@IdPopularPlace, @Rate)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@IdPopularPlace", r.IdPopularPlace.Id));
                command.Parameters.Add(new OleDbParameter("@Rate", r.Rate));

            }
        }
        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            Rating r = entity as Rating;

            string sqlStr = $"UPDATE Rating SET IdPopularPlaces='{r.IdPopularPlace.Id}',Rate='{r.Rate}' " +
                $"WHERE ID =@rId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@cId", r.Id));
        }
        protected override void CreateDeletedSQL(Base entity, OleDbCommand command)
        {
            Rating r = entity as Rating;
            string sqlStr = $"DELETE FROM Rating WHERE ID = @rId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@rId", r.Id));
        }
        public async Task<RatingList> SelectAllAsync()
        {
            command.CommandText = $"SELECT * FROM Rating";
            RatingList rList = new RatingList((IEnumerable<Rating>)base.SelectAsync());
            return rList;

        }
        public Rating SelectById(int id)
        {
            if (list.Count == 0)
            {
                RatingDB db = new RatingDB();
                list = db.SelectAll();
            }
            Rating r = list.Find(item => item.Id == id);
            return r;
        }
    }
}



