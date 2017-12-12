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
    public class RouteTable<T> : RouteGatewayInterface<T> where T : Route
    {
        public String TABLE_NAME = "Route";

        public String SQL_SELECT = "SELECT * FROM route";
        public String SQL_SELECT_ID = "SELECT * FROM route WHERE id=@id";
        public String SQL_INSERT = "INSERT INTO route VALUES (@start, @finish,  @distance)";
        public String SQL_DELETE_ID = "DELETE FROM route WHERE id=@id";
        public String SQL_UPDATE = "UPDATE Route SET start=@start, finish = @finish, distance=@distance WHERE id=@id";


        private static RouteTable<Route> instance;
        private RouteTable() { }

        public static RouteTable<Route> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RouteTable<Route>();
                }
                return instance;
            }
        }
        /// <summary>
        /// Insert the record.
        /// </summary>
        public int Insert(T r)
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
        public int Update(T r)
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
        public Collection<T> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<T> routes = Read(reader);
            reader.Close();
            db.Close();
            return routes;
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

            Collection<T> routes = Read(reader);
            T r = null;
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
        private void PrepareCommand(SqlCommand command, Route r)
        {
            command.Parameters.AddWithValue("@id", r.id);
            command.Parameters.AddWithValue("@start", r.start);
            command.Parameters.AddWithValue("@finish", r.finish);
            command.Parameters.AddWithValue("@distance ", r.distance);

        }

        /// <summary>
        /// Select the record for a name.
        /// </summary>
        //public  Route SelectForName(string pName, Database pDb = null)
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


        private Collection<T> Read(SqlDataReader reader)
        {
            Collection<T> routes = new Collection<T>();

            while (reader.Read())
            {
                Route route = new Route();
                int i = -1;
                route.id = reader.GetInt32(++i);
                route.start = reader.GetString(++i);
                route.finish = reader.GetString(++i);
                route.distance = reader.GetDecimal(++i);// route.email = reader.IsDBNull(++i) ? null : reader.GetString(++i);

                routes.Add((T)route);
            }
            return routes;
        }

    }
}