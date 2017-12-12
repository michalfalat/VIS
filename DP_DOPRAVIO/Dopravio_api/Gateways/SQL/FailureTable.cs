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
    public class FailureTable<T> : FailureGatewayInterface<T> where T : Failure
    {

        public String TABLE_NAME = "Failure";

        public String SQL_SELECT = "SELECT * FROM failure";
        public String SQL_DRIVERS = "select* from failure where timetable_id IN(select id from timetable where driver_id = @id_driver)";
        public String SQL_SELECT_ID = "SELECT * FROM failure WHERE id=@id";
        public String SQL_INSERT = "INSERT INTO failure VALUES (@created, @type,  @place, @severity, @message, @resolved, @timetableId)";
        public String SQL_INSERT1 = "INSERT INTO failure VALUES (@created, @type,  @place, @severity, @message, @timetableId)";
        public String SQL_DELETE_ID = "DELETE FROM failure WHERE id=@id";
        public String SQL_UPDATE = "UPDATE Failure SET created=@created, type = @type, place=@place , message = @message, timetable_Id = @timetableId, resolved = @resolved WHERE id=@id";


        private static FailureTable<Failure> instance;
        private FailureTable() { }

        public static FailureTable<Failure> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FailureTable<Failure>();
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
        /// <param name="Failure"></param>
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

            Collection<T> failures = Read(reader);
            reader.Close();
            db.Close();
            return failures;
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

            Collection<T> failures = Read(reader);
            T r = null;
            if (failures.Count == 1)
            {
                r = failures[0];
            }
            reader.Close();
            db.Close();
            return r;
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

            Collection<T> failures = Read(reader);
            reader.Close();
            db.Close();
            return failures;
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
        private void PrepareCommand(SqlCommand command, Failure r)
        {
            command.Parameters.AddWithValue("@id", r.id);
            command.Parameters.AddWithValue("@created", r.created);
            command.Parameters.AddWithValue("@type", (int)r.type);
            command.Parameters.AddWithValue("@place", r.place);
            command.Parameters.AddWithValue("@severity", r.severity);
            command.Parameters.AddWithValue("@message", r.message);
            if (r.resolved.HasValue)
            {

                command.Parameters.AddWithValue("@resolved", r.resolved);
            }
            else
            {
                command.Parameters.AddWithValue("@resolved", DBNull.Value);
            }
            command.Parameters.AddWithValue("@timetableId", r.timetable.id);

        }

        /// <summary>
        /// Select the record for a name.
        /// </summary>
        //public  Failure SelectForName(string pName, Database pDb = null)
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

        //    Collection<Failure> failures = Read(reader);
        //    Failure v = null;
        //    if (failures.Count == 1)
        //    {
        //        v = failures[0];
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
            TimetableFactory timetableFactory = new TimetableFactory();
            TimetableTable<Timetable> instance = (TimetableTable<Timetable>)timetableFactory.GetTimetableInstance();
            Collection<T> failures = new Collection<T>();

            while (reader.Read())
            {
                Failure failure = new Failure();
                int i = -1;
                failure.id = reader.GetInt32(++i);
                failure.created = reader.GetDateTime(++i);
                failure.type = (FailureType)reader.GetInt32(++i);
                failure.place = reader.GetString(++i);
                failure.severity = reader.GetInt32(++i);
                failure.message = reader.GetString(++i);
                failure.resolved = reader.IsDBNull(++i) == true ? (DateTime?)null : reader.GetDateTime(i);
                failure.timetable = instance.Select(reader.GetInt32(++i));


                failures.Add((T)failure);
            }
            return failures;
        }

    }
}