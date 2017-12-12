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
    public class MessageTable<T> : MessageGatewayInterface<T> where T : Message
    {


        public String TABLE_NAME = "Message";

        public String SQL_SELECT = "SELECT * FROM message";
        public String SQL_SELECT_ID = "SELECT * FROM message WHERE id=@id";

        public String SQL_SELECT_MANAGER = "SELECT * FROM message WHERE manager_id=@manager_id";
        public String SQL_INSERT = "INSERT INTO message VALUES (@created, @text, @isRead, @dispatcher_id, @manager_id)";
        public String SQL_DELETE_ID = "DELETE FROM Message WHERE id=@id";
        public String SQL_UPDATE = "UPDATE Message SET created=@created, text=@text, isRead=@isRead, dispatcher_id=@dispatcher_id, manager_id=@manager_id WHERE id=@id";


        private static MessageTable<Message> instance;
        private MessageTable() { }

        public static MessageTable<Message> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MessageTable<Message>();
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
        /// <param name="Message"></param>
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

            Collection<T> messages = Read(reader);
            reader.Close();
            db.Close();
            return messages;
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

        public Collection<T> SelectForManager(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_MANAGER);

            command.Parameters.AddWithValue("@manager_id", id);
            SqlDataReader reader = db.Select(command);

            Collection<T> messages = Read(reader);
           
            reader.Close();
            db.Close();
            return messages;
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
        private void PrepareCommand(SqlCommand command, Message d)
        {
            command.Parameters.AddWithValue("@id", d.id);
            command.Parameters.AddWithValue("@created", d.created);
            command.Parameters.AddWithValue("@text", d.text);
            command.Parameters.AddWithValue("@isRead", d.isRead);
            command.Parameters.AddWithValue("@dispatcher_id", d.dispatcher.id);
            command.Parameters.AddWithValue("@manager_id", d.manager.id);

        }




        private Collection<T> Read(SqlDataReader reader)
        {
            DispatcherFactory dispatcherFactory = new DispatcherFactory();
            DispatcherTable<Dispatcher> instanceDispatcher = (DispatcherTable<Dispatcher>)dispatcherFactory.GetDispatcherInstance();

            ManagerFactory managerFactory = new ManagerFactory();
            ManagerTable<Manager> instanceManager = (ManagerTable<Manager>)managerFactory.GetManagerInstance();


            Collection<T> messages = new Collection<T>();

            while (reader.Read())
            {
                Message message = new Message();
                int i = -1;
                message.id = reader.GetInt32(++i);
                message.created = reader.GetDateTime(++i);
                message.text = reader.GetString(++i);
                message.isRead = reader.GetBoolean(++i);
                message.dispatcher = instanceDispatcher.Select(reader.GetInt32(++i));
                message.manager = instanceManager.Select(reader.GetInt32(++i));



                messages.Add((T)message);
            }
            return messages;
        }



    }
}