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
    public class ManagerTable<T> : ManagerGatewayInterface<T> where T : Manager
    {

        public String TABLE_NAME = "Manager";


        public String SQL_SELECT_LOGIN = "SELECT * FROM manager WHERE email=@email and password=@password";
        public String SQL_SELECT = "SELECT * FROM manager";
        public String SQL_SELECT_ID = "SELECT * FROM manager WHERE id=@id";
        public String SQL_INSERT = "INSERT INTO manager VALUES (@name, @surname, @dateOfBirth, @phone, @email,  @password, @address, @salary)";
        public String SQL_DELETE_ID = "DELETE FROM Manager WHERE id=@id";
        public String SQL_UPDATE = "UPDATE Manager SET name=@name, surname=@surname, dateOfBirth=@dateOfBirth, phone=@phone, email=@email,  password=@password, address=@address, salary=@salary WHERE id=@id";


        private static ManagerTable<Manager> instance;
        private ManagerTable() { }

        public static ManagerTable<Manager> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ManagerTable<Manager>();
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
        /// <param name="Manager"></param>
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
        /// Select records.
        /// </summary>
        public Collection<T> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<T> managers = Read(reader);
            reader.Close();
            db.Close();
            return managers;
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
        private void PrepareCommand(SqlCommand command, Manager d)
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

        }




        private Collection<T> Read(SqlDataReader reader)
        {
            Collection<T> managers = new Collection<T>();

            while (reader.Read())
            {
                Manager manager = new Manager();
                int i = -1;
                manager.id = reader.GetInt32(++i);
                manager.name = reader.GetString(++i);
                manager.surname = reader.GetString(++i);

                manager.dateOfBirth = reader.GetDateTime(++i);
                manager.phone = reader.GetString(++i);
                manager.email = reader.GetString(++i);
                manager.password = reader.GetString(++i);
                manager.address = reader.GetString(++i);
                manager.salary = reader.GetDecimal(++i);


                managers.Add((T)manager);
            }
            return managers;
        }



    }
}