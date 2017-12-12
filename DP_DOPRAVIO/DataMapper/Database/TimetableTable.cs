using Dopravio.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dopravio.Database
{
    public class TimetableTable
    {
        public static String TABLE_NAME = "timetable";

        public static String SQL_SELECT = "SELECT * FROM timetable";
        public static String SQL_SELECT_ID = "SELECT * FROM timetable WHERE id_journey=@id_journey";
        public static String SQL_SELECT_NAME = "SELECT * FROM timetable WHERE name=@name";
        public static String SQL_INSERT = "INSERT INTO timetable VALUES (@link_name, @departure, @arrival, @id_route, @id_vehicle, @id_driver)";
        public static String SQL_DELETE_ID = "DELETE FROM timetable WHERE id_journey=@id_journey";
        public static String SQL_UPDATE = "UPDATE timetable SET link_name=@link_name, departure = @departure, arrival=@arrival, id_route=@id_route, id_vehicle=@id_vehicle, id_driver=@id_driver WHERE id_journey=@id_journey";

        /// <summary>
        /// Insert the record.
        /// </summary>
        public static int Insert(Timetable t)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, t);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        /// <summary>
        /// Update the record.
        /// </summary>
        /// <param name="Timetable"></param>
        /// <returns></returns>
        public static int Update(Timetable t)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, t);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }


        /// <summary>
        /// Select records.
        /// </summary>
        public static Collection<Timetable> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Timetable> timeTables = Read(reader);
            reader.Close();
            db.Close();
            return timeTables;
        }

        /// <summary>
        /// Select records for category.
        /// </summary>
        public static Timetable Select(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@id_journey", id);
            SqlDataReader reader = db.Select(command);

            Collection<Timetable> timeTables = Read(reader);
            Timetable t = null;
            if (timeTables.Count == 1)
            {
                t = timeTables[0];
            }
            reader.Close();
            db.Close();
            return t;
        }

        /// <summary>
        /// Delete the record.
        /// </summary>
        public static int Delete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@id_journey", id);
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }

        /// <summary>
        /// Prepare a command.
        /// </summary>
        private static void PrepareCommand(SqlCommand command, Timetable v)
        {
            command.Parameters.AddWithValue("@id_journey", v.id_journey);
            command.Parameters.AddWithValue("@link_name", v.link_name);
            command.Parameters.AddWithValue("@departure", v.departure);
            command.Parameters.AddWithValue("@arrival", v.arrival);
            command.Parameters.AddWithValue("@id_route ", v.route.id_route);
            command.Parameters.AddWithValue("@id_vehicle", v.vehicle.id_vehicle);
            command.Parameters.AddWithValue("@id_driver", v.driver.id_driver);
        }

        /// <summary>
        /// Select the record for a name.
        /// </summary>
        //public static Timetable SelectForName(string pName, Database pDb = null)
        //{
        //    Database db;
        //    if (pDb == null)
        //    {
        //        db = new Database();
        //        db.Connect();
        //    }
        //    else
        //    {
        //        db = pDb;
        //    }

        //    SqlCommand command = db.CreateCommand(SQL_SELECT_NAME);

        //    command.Parameters.AddWithValue("@name", pName);
        //    SqlDataReader reader = db.Select(command);

        //    Collection<Timetable> timeTables = Read(reader);
        //    Timetable v = null;
        //    if (timeTables.Count == 1)
        //    {
        //        v = timeTables[0];
        //    }
        //    reader.Close();

        //    if (pDb == null)
        //    {
        //        db.Close();
        //    }

        //    return v;
        //}


        private static Collection<Timetable> Read(SqlDataReader reader)
        {
            Collection<Timetable> timeTables = new Collection<Timetable>();
            var routes = RouteTable.Select();
            var vehicles = VehicleTable.Select();
            var drivers = DriverTable.Select();

            while (reader.Read())
            {
                Timetable timeTable = new Timetable();
                int i = -1;
                timeTable.id_journey = reader.GetInt32(++i);
                timeTable.link_name = reader.GetString(++i);
                timeTable.departure = reader.GetDateTime(++i);
                timeTable.arrival = reader.GetDateTime(++i);
                var idRoute = reader.GetInt32(++i);
                var idVehicle = reader.GetInt32(++i);
                var idDriver = reader.GetInt32(++i);
                timeTable.route = routes.Where(r=>r.id_route== idRoute).FirstOrDefault();
                timeTable.vehicle = vehicles.Where(v=>v.id_vehicle== idVehicle).FirstOrDefault();
                timeTable.driver= drivers.Where(d=>d.id_driver== idDriver).FirstOrDefault();
                

                timeTables.Add(timeTable);
            }
            return timeTables;
        }

    }
}