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
    public class DriverTable<T> : DriverGatewayInterface<T> where T : Driver
    {
        private static DriverTable<Driver> instance;
        private DriverTable() { }

        public static DriverTable<Driver> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DriverTable<Driver>();
                }
                return instance;
            }
        }
        public String TABLE_NAME = "Driver";

        public String SQL_SELECT = "SELECT * FROM driver";

        public String SQL_SELECT_LOGIN = "SELECT * FROM driver WHERE email=@email and password=@password";
        public String SQL_SELECT_ID = "SELECT * FROM driver WHERE id=@id";
        public String SQL_INSERT = "INSERT INTO driver VALUES (@name, @surname, @dateOfBirth, @phone, @email,  @password, @address, @salary, @accidentCount)";
        public String SQL_DELETE_ID = "DELETE FROM Driver WHERE id=@id";
        public String SQL_UPDATE = "UPDATE Driver SET name=@name, surname=@surname, dateOfBirth=@dateOfBirth, phone=@phone, email=@email,  password=@password, address=@address, salary=@salary, accidentCount=@accidentCount WHERE id=@id";
        public string SQL_DENNYNAJAZD = @"SELECT id, SUM(r.distance) AS pocet_km 
                                            FROM timetable t join route r ON t.route_id=r.id
                                        WHERE t.Driver_id= @id
                                        GROUP BY (id);";

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
        /// <param name="Driver"></param>
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

            Collection<T> drivers = Read(reader);
            reader.Close();
            db.Close();
            return drivers;
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
        private void PrepareCommand(SqlCommand command, Driver d)
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
            command.Parameters.AddWithValue("@accidentCount", d.accidentCount);

        }



        private Dictionary<int, double> ReadPocetKilometrov(SqlDataReader reader)
        {
            Dictionary<int, double> value = new Dictionary<int, double>();
            while (reader.Read())
            {
                int i = -1;
                var id_driver = reader.GetInt32(++i);
                var pocet = reader.GetDouble(++i);

                value.Add(id_driver, pocet);
            }
            return value;
        }

        private Collection<T> Read(SqlDataReader reader)
        {
            Collection<T> drivers = new Collection<T>();

            while (reader.Read())
            {
                Driver driver = new Driver();
                int i = -1;
                driver.id = reader.GetInt32(++i);
                driver.name = reader.GetString(++i);
                driver.surname = reader.GetString(++i);

                driver.dateOfBirth = reader.GetDateTime(++i);
                driver.phone = reader.GetString(++i);
                driver.email = reader.GetString(++i);
                driver.password = reader.GetString(++i);
                driver.address = reader.GetString(++i);
                driver.salary = reader.GetDecimal(++i);
                driver.accidentCount = reader.GetInt32(++i);


                drivers.Add((T)driver);
            }
            return drivers;
        }



    }
}