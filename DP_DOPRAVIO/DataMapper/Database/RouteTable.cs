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
    public class RouteTable
    {
        public static String TABLE_NAME = "Route";

        public static String SQL_SELECT = "SELECT * FROM route";
        public static String SQL_SELECT_ID = "SELECT * FROM route WHERE id_route=@id_route";
        public static String SQL_INSERT = "INSERT INTO route VALUES (@start, @finish, @stops_count, @distance)";
        public static String SQL_DELETE_ID = "DELETE FROM route WHERE id_route=@id_route";
        public static String SQL_UPDATE = "UPDATE Route SET start=@start, finish = @finish, stops_count=@stops_count, distance=@distance WHERE id_route=@id_route";

        /// <summary>
        /// Insert the record.
        /// </summary>
        public static int Insert(Route r)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, r);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        /// <summary>
        /// Update the record.
        /// </summary>
        /// <param name="Route"></param>
        /// <returns></returns>
        public static int Update(Route r)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, r);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }


        /// <summary>
        /// Select records.
        /// </summary>
        public static Collection<Route> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Route> routes = Read(reader);
            reader.Close();
            db.Close();
            return routes;
        }

        /// <summary>
        /// Select records for category.
        /// </summary>
        public static Route Select(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@id_route", id);
            SqlDataReader reader = db.Select(command);

            Collection<Route> routes = Read(reader);
            Route r = null;
            if (routes.Count == 1)
            {
                r = routes[0];
            }
            reader.Close();
            db.Close();
            return r;
        }

        /// <summary>
        /// Delete the record.
        /// </summary>
        public static int Delete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@id_route", id);
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }

        /// <summary>
        /// Prepare a command.
        /// </summary>
        private static void PrepareCommand(SqlCommand command, Route r)
        {
            command.Parameters.AddWithValue("@id_route", r.id_route);
            command.Parameters.AddWithValue("@start", r.start);
            command.Parameters.AddWithValue("@finish", r.finish);
            command.Parameters.AddWithValue("@stops_count", r.stops_count);
            command.Parameters.AddWithValue("@distance ", r.distance);
           
        }

        /// <summary>
        /// Select the record for a name.
        /// </summary>
        //public static Route SelectForName(string pName, Database pDb = null)
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

        //    Collection<Route> routes = Read(reader);
        //    Route v = null;
        //    if (routes.Count == 1)
        //    {
        //        v = routes[0];
        //    }
        //    reader.Close();

        //    if (pDb == null)
        //    {
        //        db.Close();
        //    }

        //    return v;
        //}


        private static Collection<Route> Read(SqlDataReader reader)
        {
            Collection<Route> routes = new Collection<Route>();

            while (reader.Read())
            {
                Route route = new Route();
                int i = -1;
                route.id_route = reader.GetInt32(++i);
                route.start = reader.GetString(++i);
                route.finish = reader.GetString(++i);
                route.stops_count = reader.GetInt32(++i);// reader.GetDateTime(++i);
                route.distance = reader.GetDouble(++i);// route.email = reader.IsDBNull(++i) ? null : reader.GetString(++i);
                
                routes.Add(route);
            }
            return routes;
        }

    }
}