using Dopravio.Models;
using Dopravio_api.Factories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dopravio.Database
{
    public class TimetableTable<T> : TimetableGatewayInterface<T> where T : Timetable
    {
        public String TABLE_NAME = "timetable";

        public String SQL_SELECT = "SELECT * FROM timetable";
        public String SQL_SELECT_ID = "SELECT * FROM timetable WHERE id=@id";
        public String SQL_SELECT_NAME = "SELECT * FROM timetable WHERE name=@name";
        public String SQL_INSERT = "INSERT INTO timetable VALUES (@link_name, @departure, @arrival, @id_route, @id_vehicle, @id_driver)";
        public String SQL_DELETE_ID = "DELETE FROM timetable WHERE id=@id";
        public String SQL_UPDATE = "UPDATE timetable SET name=@name, departure = @departure, arrival=@arrival, Route_id=@id_route, Vehicle_id=@id_vehicle, Driver_id=@id_driver WHERE id=@id";
        public String SQL_DRIVERS ="SELECT * FROM timetable WHERE Driver_id=@id_driver";


        private static TimetableTable<Timetable> instance;
        private TimetableTable() { }

        public static TimetableTable<Timetable> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TimetableTable<Timetable>();
                }
                return instance;
            }
        }

        /// <summary>
        /// Insert the record.
        /// </summary>
        public int Insert(T t)
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
        public int Update(T t)
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
        public Collection<T> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<T> timeTables = Read(reader);
            reader.Close();
            db.Close();
            return timeTables;
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

            Collection<T> timeTables = Read(reader);
            T t = null;
            if (timeTables.Count == 1)
            {
                t = timeTables[0];
            }
            reader.Close();
            db.Close();
            return t;
        }

        /// Select records for category.
        /// </summary>
        public Collection<T> SelectDrivers(int driverId)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DRIVERS);

            command.Parameters.AddWithValue("@id_driver", driverId);
            SqlDataReader reader = db.Select(command);

            Collection<T> timeTables = Read(reader);
            reader.Close();
            db.Close();
            return timeTables;
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
        private void PrepareCommand(SqlCommand command, Timetable v)
        {
            command.Parameters.AddWithValue("@id", v.id);
            command.Parameters.AddWithValue("@name", v.name);
            command.Parameters.AddWithValue("@departure", v.departure);
            command.Parameters.AddWithValue("@arrival", v.arrival);
            command.Parameters.AddWithValue("@id_route ", v.route.id);
            command.Parameters.AddWithValue("@id_vehicle", v.vehicle.id);
            command.Parameters.AddWithValue("@id_driver", v.driver.id);
        }

        /// <summary>
        /// Select the record for a name.
        /// </summary>
        //public  Timetable SelectForName(string pName, Database pDb = null)
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


        private Collection<T> Read(SqlDataReader reader)
        {
            RouteFactory routeFactory = new RouteFactory();
            RouteTable<Route> instanceRoute = (RouteTable<Route>)routeFactory.GetRouteInstance();

            VehicleFactory vehicleFactory = new VehicleFactory();
            var instanceVehicle = vehicleFactory.GetVehicleInstance();

            DriverFactory driverFactory = new DriverFactory();
            DriverTable<Driver> instanceDriver = (DriverTable<Driver>)driverFactory.GetDriverInstance();

            Collection<T> timeTables = new Collection<T>();

            while (reader.Read())
            {
                Timetable timeTable = new Timetable();
                int i = -1;
                timeTable.id = reader.GetInt32(++i);
                timeTable.name = reader.GetString(++i);
                timeTable.departure = reader.GetDateTime(++i);
                timeTable.arrival = reader.GetDateTime(++i);
                var idRoute = reader.GetInt32(++i);
                var idDriver = reader.GetInt32(++i);
                var idVehicle = reader.GetInt32(++i);
                timeTable.route = instanceRoute.Select(idRoute);
                timeTable.vehicle = instanceVehicle.Select(idVehicle);
                timeTable.driver = instanceDriver.Select(idDriver);


                timeTables.Add((T)timeTable);
            }
            return timeTables;
        }

    }
}