using System;
using System.Collections.Generic;
using System.Data;
using model;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
   public abstract class BaseDB
    {
        //+		$exception	{"'C:\\Users\\student\\source\\repos\\Project\\ViewModel\\JewishWorldAccess.accdb' אינו נתיב חוקי. ודא כי שם הנתיב מאוית כראוי ושאתה מחובר אל השרת שבו נמצא הקובץ."}	System.Data.OleDb.OleDbException

        protected static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= "+Path()+"\\JewishWorldAccess.accdb";
        protected OleDbConnection connection;
        protected OleDbCommand command;
        protected OleDbDataReader reader;

        public static List<ChangeEntity> inserted = new List<ChangeEntity>();
        public static List<ChangeEntity> deleted = new List<ChangeEntity>();
        public static List<ChangeEntity> updated = new List<ChangeEntity>();

        protected abstract void CreateInsertSQL(Base entity, OleDbCommand cmd);
        protected abstract void CreateUpdateSQL(Base entity, OleDbCommand cmd);
        protected abstract void CreateDeletedSQL(Base entity, OleDbCommand cmd);

        public BaseDB()
        {
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;
        }
        protected virtual Base CreateModel(Base entity)
        {
            entity.Id = (int)reader["Id"];
            return entity;
        }

        protected abstract Base NewEntity();

        protected List<Base> Select()
        {
            List<Base> list = new List<Base>();

            try
            {
                command.Connection = connection;
                // command.CommandTGext = sqlStr;
                connection.Open();
                reader = command.ExecuteReader();


                while (reader.Read())
                {
                    Base entity = NewEntity();
                    list.Add(CreateModel(entity));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(
                    e.Message + " SQL:" + command.CommandText);
            }
            finally
            {
                if (reader != null) reader.Close();
                if (connection.State == ConnectionState.Open) connection.Close();
            }

            return list;
        }

        public virtual void Insert(Base entity)
        {
            Base reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, entity)); 
            }
        }
        public virtual void Update(Base entity)
        {
            Base reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
            }
        }

        public virtual void Delete(Base entity)
        {
            Base reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
            }
        }


        private static string Path()
        {
            String[] arguments = Environment.GetCommandLineArgs();
            string s;
            if (arguments.Length == 1)
                s = arguments[0];
            else
            {
                s = arguments[1];
                s = s.Replace("/service:", "");
            }
            string[] st = s.Split('\\');
            int x = st.Length - 5;
            st[x] = "ViewModel";
            Array.Resize(ref st, x + 1);
            string str = String.Join("\\", st);

            return str;
        }

        public int SaveChanges()
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbTransaction trans = null;

            int records_affected = 0;
            OleDbCommand command = new OleDbCommand();

            try
            {
                command.Connection = connection;
                connection.Open();
                trans = connection.BeginTransaction();
                command.Transaction = trans;

                foreach (var entity in inserted)
                {
                    command.Parameters.Clear();
                    entity.CreateSql(entity.Entity, command); //cmd.CommandText = CreateInsertSQL(entity.Entity);
                    records_affected += command.ExecuteNonQuery();

                    command.CommandText = "Select @@Identity";
                    entity.Entity.Id = (int)command.ExecuteScalar();
                }

                foreach (var entity in updated)
                {
                    command.Parameters.Clear();
                    entity.CreateSql(entity.Entity, command); //cmd.CommandText = CreateUpdateSQL(entity.Entity);
                    records_affected += command.ExecuteNonQuery();
                }

                foreach (var entity in deleted)
                {
                    command.Parameters.Clear();
                    entity.CreateSql(entity.Entity, command);

                    records_affected += command.ExecuteNonQuery();
                }

                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                System.Diagnostics.Debug.WriteLine(ex.Message + "  SQL:" + command.CommandText);
            }
            finally
            {
                inserted.Clear();
                updated.Clear();
                deleted.Clear();

                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }

            return records_affected;
        }
        protected async Task<List<Base>> SelectAsync()
        {
            List<Base> list = new List<Base>();

            try
            {
                command.Connection = connection;
                connection.Open();
                this.reader = (OleDbDataReader)await command.ExecuteReaderAsync();


                while (reader.Read())
                {
                    Base entity = NewEntity();
                    list.Add(CreateModel(entity));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\nSQL:" + command.CommandText);
            }
            finally
            {
                if (reader != null) reader.Close();
                if (connection.State == ConnectionState.Open) connection.Close();
            }

            return list;
        }
        public async Task<int> SaveChangesAsync()
        {
            int records_affected = 0;
            OleDbCommand command = new OleDbCommand();
            try
            {
                command.Connection = this.connection;
                this.connection.Open();

                foreach (var item in inserted)
                {
                    command.Parameters.Clear();
                    item.CreateSql(item.Entity, command);
                    records_affected += await command.ExecuteNonQueryAsync();

                    command.CommandText = "Select @@Identity";
                    item.Entity.Id = (int)command.ExecuteScalarAsync().Result;
                }

                foreach (var item in updated)
                {
                    command.Parameters.Clear();
                    item.CreateSql(item.Entity, command);
                    records_affected += await command.ExecuteNonQueryAsync();
                }

                foreach (var item in deleted)
                {
                    command.Parameters.Clear();
                    item.CreateSql(item.Entity, command);
                    records_affected += await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\nSQL:" + command.CommandText);
            }
            finally
            {
                inserted.Clear();
                updated.Clear();
                deleted.Clear();

                if (connection.State == ConnectionState.Open) connection.Close();
            }

            return records_affected;
        }
    }
}

    

