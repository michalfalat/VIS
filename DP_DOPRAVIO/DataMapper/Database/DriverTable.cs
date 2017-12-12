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
    public class DriverTable
    {
        public static String TABLE_NAME = "Driver";

        public static String SQL_SELECT = "SELECT * FROM driver";
        public static String SQL_SELECT_ID = "SELECT * FROM driver WHERE id_driver=@id_driver";
        public static String SQL_INSERT = "INSERT INTO driver VALUES (@years_drived, @accident_count, @id_employee)";
        public static String SQL_DELETE_ID = "DELETE FROM Driver WHERE id_driver=@id_driver";
        public static String SQL_UPDATE = "UPDATE Driver SET years_drived = @years_drived, accident_count= @accident_count, id_employee= @id_employee WHERE id_driver=@id_driver";
        public static string SQL_DENNYNAJAZD = @"SELECT id_driver, SUM(r.distance) AS pocet_km 
                                            FROM timetable t join route r ON t.id_route=r.id_route
                                        WHERE t.id_driver= @id_driver
                                        GROUP BY (id_driver);";

        /// <summary>
        /// Insert the record.
        /// </summary>
        public static int Insert(Driver emp)
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
        public static int Update(Driver emp)
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
        public static Collection<Driver> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Driver> drivers = Read(reader);
            reader.Close();
            db.Close();
            return drivers;
        }

        /// <summary>
        /// Select records for category.
        /// </summary>
        public static Driver Select(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@id_driver", id);
            SqlDataReader reader = db.Select(command);

            Collection<Driver> categories = Read(reader);
            Driver category = null;
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
        public static int Delete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@id_driver", id);
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }


        public static double DennyNajazdVodica(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DENNYNAJAZD);

            command.Parameters.AddWithValue("@id_driver", id);
            SqlDataReader reader = db.Select(command);

           var item =  ReadPocetKilometrov(reader);
           
            reader.Close();
            db.Close();
            return item[id]; 
        }

        public static void OdmenyPreVodicov()
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand("OdmenaVodicov");            
            command.CommandType = CommandType.StoredProcedure;
            int ret = db.ExecuteNonQuery(command);
            db.Close();

        }

        /// <summary>
        /// Prepare a command.
        /// </summary>
        private static void PrepareCommand(SqlCommand command, Driver d)
        {
            command.Parameters.AddWithValue("@id_driver", d.id_driver);
            command.Parameters.AddWithValue("@accident_count", d.accident_count);
            command.Parameters.AddWithValue("@years_drived", d.years_drived);
            command.Parameters.AddWithValue("@id_employee", d.employee.id_employee);
           
        }



        private static Dictionary<int, double> ReadPocetKilometrov(SqlDataReader reader)
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

        private static Collection<Driver> Read(SqlDataReader reader)
        {
            Collection<Driver> drivers = new Collection<Driver>();

            while (reader.Read())
            {
                Driver driver = new Driver();
                int i = -1;
                driver.id_driver = reader.GetInt32(++i);
                driver.years_drived = reader.GetInt32(++i);
                driver.accident_count = reader.GetInt32(++i);
                driver.employee = EmployeeTable.Select(reader.GetInt32(++i));// reader.GetDateTime(++i);
                

                drivers.Add(driver);
            }
            return drivers;
        }

       

    }
}