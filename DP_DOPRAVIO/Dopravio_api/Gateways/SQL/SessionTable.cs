using Dopravio.Models;
using Dopravio_api.Factories;
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
    public class SessionsTable<T> : SessionGatewayInterface<T> where T : Session
    {
        private static SessionsTable<Session> instance;
        private SessionsTable() { }

        public static SessionsTable<Session> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SessionsTable<Session>();
                }
                return instance;
            }
        }
        public String SQL_SELECT = "SELECT * FROM sessions WHERE token=@token";
        public String SQL_INSERT = "INSERT INTO sessions VALUES (@token, @type, @user_id)";
        public String SQL_DELETE = "DELETE FROM sessions WHERE token=@token";


        /// <summary>
        /// Insert the record.
        /// </summary>
        public int CreateSession(Session s)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, s);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }




        /// <summary>
        /// Select records for category.
        /// </summary>
        public Driver SelectDriverSession(string token)
        {
            DriverFactory driverFactory = new DriverFactory();
            DriverTable<Driver> instanceDriver = (DriverTable<Driver>)driverFactory.GetDriverInstance();
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT);

            command.Parameters.AddWithValue("@token", token);
            SqlDataReader reader = db.Select(command);

            Collection<T> sessions = Read(reader);
            if (sessions.Count == 1)
            {
                if (sessions[0].type == "DRIVER")
                {
                    return instanceDriver.Select(sessions[0].user_id);
                }

            }
            reader.Close();
            db.Close();
            return null;
        }

        public Dispatcher SelectDispatcherSession(string token)
        {
            DispatcherFactory dispatcherFactory = new DispatcherFactory();
            DispatcherTable<Dispatcher> instanceDispatcher = (DispatcherTable<Dispatcher>)dispatcherFactory.GetDispatcherInstance();

            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT);

            command.Parameters.AddWithValue("@token", token);
            SqlDataReader reader = db.Select(command);

            Collection<T> sessions = Read(reader);
            if (sessions.Count == 1)
            {
                if (sessions[0].type == "DISPATCHER")
                {
                    return instanceDispatcher.Select(sessions[0].user_id);
                }

            }
            reader.Close();
            db.Close();
            return null;
        }

        public Manager SelectManagerSession(string token)
        {
            ManagerFactory managerFactory = new ManagerFactory();
            ManagerTable<Manager> instanceManager = (ManagerTable<Manager>)managerFactory.GetManagerInstance();

            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT);

            command.Parameters.AddWithValue("@token", token);
            SqlDataReader reader = db.Select(command);

            Collection<T> sessions = Read(reader);
            if (sessions.Count == 1)
            {
                if (sessions[0].type == "MANAGER")
                {
                    return instanceManager.Select(sessions[0].user_id);
                }

            }
            reader.Close();
            db.Close();
            return null;
        }

        /// <summary>
        /// Delete the record.
        /// </summary>
        public int Delete(string token)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE);

            command.Parameters.AddWithValue("@token", token);
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }




        /// <summary>
        /// Prepare a command.
        /// </summary>
        private void PrepareCommand(SqlCommand command, Session s)
        {
            command.Parameters.AddWithValue("@token", s.token);
            command.Parameters.AddWithValue("@type", s.type);
            command.Parameters.AddWithValue("@user_id", s.user_id);


        }



        private Collection<T> Read(SqlDataReader reader)
        {
            Collection<T> sessions = new Collection<T>();

            while (reader.Read())
            {
                Session s = new Session();
                int i = -1;
                s.token = reader.GetString(++i);
                s.type = reader.GetString(++i);
                s.user_id = reader.GetInt32(++i);



                sessions.Add((T)s);
            }
            return sessions;
        }

        public int Insert(T obj)
        {
            throw new NotImplementedException();
        }

        public int Update(T obj)
        {
            throw new NotImplementedException();
        }

        public Collection<T> Select()
        {
            throw new NotImplementedException();
        }

        public T Select(int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }


    public class Session
    {
        public Session()
        {

        }
        public string token { get; set; }
        public string type { get; set; }
        public int user_id { get; set; }
    }
}