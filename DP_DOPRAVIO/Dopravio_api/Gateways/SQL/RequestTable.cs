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
    public class RequestTable<T> : RequestGatewayInterface<T> where T : Request
    {
        public String TABLE_NAME = "Request";

        public String SQL_SELECT = "SELECT * FROM request";
        public String SQL_SELECT_ID = "SELECT * FROM request WHERE id=@id";
        public String SQL_INSERT = "INSERT INTO request VALUES (@state, @type, @priority, @created, @message, @resultMessage, @dispatcher_id)";
        public String SQL_DELETE_ID = "DELETE FROM Request WHERE id=@id";
        public String SQL_UPDATE = "UPDATE Request SET  state=@state, type=@type, priority=@priority, created=@created, message=@message, resultMessage=@resultMessage, dispatcher_id=@dispatcher_id WHERE id=@id";


        private static RequestTable<Request> instance;
        private RequestTable() { }

        public static RequestTable<Request> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RequestTable<Request>();
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
        /// <param name="Request"></param>
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

            Collection<T> requests = Read(reader);
            reader.Close();
            db.Close();
            return requests;
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
        private void PrepareCommand(SqlCommand command, Request d)
        {
            command.Parameters.AddWithValue("@id", d.id);
            command.Parameters.AddWithValue("@state", (int)d.state);
            command.Parameters.AddWithValue("@type", (int)d.type);
            command.Parameters.AddWithValue("@priority", d.priority);
            command.Parameters.AddWithValue("@created", d.created);
            command.Parameters.AddWithValue("@message", d.message);
            command.Parameters.AddWithValue("@resultMessage", d.resultMessage);
            command.Parameters.AddWithValue("@dispatcher_id", d.dispatcher.id);

        }




        private Collection<T> Read(SqlDataReader reader)
        {
            DispatcherFactory dispatcherFactory = new DispatcherFactory();
            DispatcherTable<Dispatcher> instanceDispatcher = (DispatcherTable<Dispatcher>)dispatcherFactory.GetDispatcherInstance();

            Collection<T> requests = new Collection<T>();

            while (reader.Read())
            {
                Request request = new Request();
                int i = -1;
                request.id = reader.GetInt32(++i);
                request.state = (RequestState)reader.GetInt32(++i);
                request.type = (RequestType)reader.GetInt32(++i);
                request.priority = reader.GetInt32(++i);
                request.created = reader.GetDateTime(++i);
                request.message = reader.GetString(++i);
                request.resultMessage = reader.IsDBNull(++i) ? null : reader.GetString(i);
                request.dispatcher = instanceDispatcher.Select(reader.GetInt32(++i));



                requests.Add((T)request);
            }
            return requests;
        }



    }
}