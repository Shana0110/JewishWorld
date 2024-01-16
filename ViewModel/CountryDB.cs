using model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CountryDB:BaseDB
    {
        static private CountryList list = new CountryList();
      
        protected override Base NewEntity()
        {
            return new Country();
        }
        protected override Base CreateModel(Base entity)
        {
            Country c = entity as Country;
            c.CountryName = reader["CountryName"].ToString();
            base.CreateModel(entity);
            return c;
        }
        public CountryList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Country";
            CountryList cList = new CountryList(base.Select());
            return cList;
        }
        protected override void CreateInsertSQL(Base entity, OleDbCommand command)
        {
            Country country = entity as Country;
            if (country != null)
            {
                string sqlStr = $"INSERT INTO Country (CountryName ) " +
                                $" Values (@CountryName)" +
                                $"";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@CountryName", country.CountryName));
               

            }
        }
        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            Country country = entity as Country;

            string sqlStr = $"UPDATE Country SET CountryName='{country.CountryName}' " +
                $"WHERE ID =@cId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@cId", country.Id));
        }
        protected override void CreateDeletedSQL(Base entity, OleDbCommand command)
        {
            Country country= entity as Country;
            string sqlStr = $"DELETE FROM Country WHERE Id = @cId";

            command.CommandText = sqlStr;
            command.Parameters.Add(new OleDbParameter("@cId", country.Id));
        }
        public async Task<CountryList> SelectAllAsync()
        {
            command.CommandText = $"SELECT * FROM Country";
            CountryList cList = new CountryList((IEnumerable<Country>)base.SelectAsync());
            return cList;

        }
    
        public Country SelectById(int id)
        {
            if (list.Count == 0)
            {
                CountryDB db = new CountryDB();
                list = db.SelectAll();
            }
            Country country= list.Find(item => item.Id == id);
            return country;
        }
    }
}
