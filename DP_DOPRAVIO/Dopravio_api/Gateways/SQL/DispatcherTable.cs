using Dopravio.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dopravio.Database
{
    public class DispatcherTable<T> : DispatcherGatewayInterface<T> where T : Dispatcher
    {
        public String TABLE_NAME = "Dispatcher";

        public String SQL_SELECT = "SELECT * FROM dispatcher";
        public String SQL_SELECT_ID = "SELECT * FROM dispatcher WHERE id=@id";
        public String SQL_SELECT_LOGIN = "SELECT * FROM dispatcher WHERE email=@email and password=@password";
        public String SQL_INSERT = "INSERT INTO dispatcher VALUES (@name, @surname, @dateOfBirth, @phone, @email,  @password, @address, @salary, @skills)";
        public String SQL_DELETE_ID = "DELETE FROM Dispatcher WHERE id=@id";
        public String SQL_UPDATE = "UPDATE Dispatcher SET name=@name, surname=@surname, dateOfBirth=@dateOfBirth, phone=@phone, email=@email,  password=@password, address=@address, salary=@salary, skills=@skills WHERE id=@id";



        private static DispatcherTable<Dispatcher> instance;
        private DispatcherTable() { }


        public static DispatcherTable<Dispatcher> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DispatcherTable<Dispatcher>();
                }
                return instance;
            }
        }


        /// <summary>
        /// Insert the record.
        /// </summary>
        public int Insert(T emp)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, emp);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        /// <summary>
        /// Update the record.
        /// </summary>
        /// <param name="Dispatcher"></param>
        /// <returns></returns>
        public int Update(T emp)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, emp);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }


        /// <summary>
        /// Select records.
        /// </summary>
        public Collection<T> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<T> dispatchers = Read(reader);
            reader.Close();
            db.Close();
            return dispatchers;
        }

        /// <summary>
        /// Select records for category.
        /// </summary>
        public T Select(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = db.Select(command);

            Collection<T> categories = Read(reader);
            T category = null;
            if (categories.Count == 1)
            {
                category = categories[0];
            }
            reader.Close();
            db.Close();
            return category;
        }

        public T Login(string email, string password)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_LOGIN);

            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);
            SqlDataReader reader = db.Select(command);

            if (reader == null) return null;
            Collection<T> categories = Read(reader);
            T category = null;
            if (categories.Count == 1)
            {
                category = categories[0];
            }
            reader.Close();
            db.Close();
            return category;
        }

        /// <summary>
        /// Delete the record.
        /// </summary>
        public int Delete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@id", id);
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }




        /// <summary>
        /// Prepare a command.
        /// </summary>
        private void PrepareCommand(SqlCommand command, Dispatcher d)
        {
            command.Parameters.AddWithValue("@id", d.id);
            command.Parameters.AddWithValue("@address", d.address);
            command.Parameters.AddWithValue("@dateOfBirth", d.dateOfBirth);
            command.Parameters.AddWithValue("@email", d.email);
            command.Parameters.AddWithValue("@name", d.name);
            command.Parameters.AddWithValue("@surname", d.surname);
            command.Parameters.AddWithValue("@salary", d.salary);
            command.Parameters.AddWithValue("@phone", d.phone);
            command.Parameters.AddWithValue("@password", d.password);
            command.Parameters.AddWithValue("@skills", d.skills);

        }



        private Collection<T> Read(SqlDataReader reader)
        {
            Collection<T> dispatchers = new Collection<T>();
            if (reader == null) return null;

            while (reader.Read())
            {
                Dispatcher dispatcher = new Dispatcher();
                int i = -1;
                dispatcher.id = reader.GetInt32(++i);
                dispatcher.name = reader.GetString(++i);
                dispatcher.surname = reader.GetString(++i);

                dispatcher.dateOfBirth = reader.GetDateTime(++i);
                dispatcher.phone = reader.GetString(++i);
                dispatcher.email = reader.GetString(++i);
                dispatcher.password = reader.GetString(++i);
                dispatcher.address = reader.GetString(++i);
                dispatcher.salary = reader.GetDecimal(++i);
                dispatcher.skills = reader.GetInt32(++i);


                dispatchers.Add((T)dispatcher);
            }
            return dispatchers;
        }



    }
}