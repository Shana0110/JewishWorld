using model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CityDB : BaseDB
    {
        static private CityList list = new CityList();
        protected override Base NewEntity()
        {
            return new City();
        }
        protected override Base CreateModel(Base entity)
        {
            City c = entity as City;
            c.CityName = reader["CityName"].ToString();
            int x =int.Parse(  reader["CountryCode"].ToString());
            CountryDB countryDB = new CountryDB();
            c.CountryCode=countryDB.SelectById(x);
           
            base.CreateModel(entity);
            return c;
        }
        public CityList SelectAll()
        {
            command.CommandText = $"SELECT * FROM City";
            CityList cList = new CityList(base.Select());
            return cList;
        }
        protected override void CreateInsertSQL(Base entity, OleDbCommand command)
        {
            City city = entity as City;
            if (city != null)
            {
                string sqlStr = $"INSERT INTO City (CityName,CountryCode ) " +
                                $" Values (@CityName,@CountryCode)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@CityName", city.CityName));
                command.Parameters.Add(new OleDbParameter("@CountryCode", city.CountryCode.Id));
                
            }
        }
        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            City city = entity as City;

            string sqlStr = $"UPDATE City SET CityName='{city.CityName}',CountryCode='{city.CountryCode.Id}' " +
                $"WHERE ID =@cId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@cId", city.Id));
        }
        protected override void CreateDeletedSQL(Base entity, OleDbCommand command)
        {
            City city = entity as City;
            string sqlStr = $"DELETE FROM City WHERE ID = @cId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@cId",city.Id));
        }
        public async Task<CityList> SelectAllAsync()
        {
            command.CommandText = $"SELECT * FROM City";
            CityList cList = new CityList((IEnumerable<City>)base.SelectAsync());
            return cList;

        }
        public City SelectById(int id)
        {
            if (list.Count == 0)
            {
                CityDB db = new CityDB();
                list = db.SelectAll();
            }
            City city = list.Find(item => item.Id == id);
            return city;
        }
    }
}

