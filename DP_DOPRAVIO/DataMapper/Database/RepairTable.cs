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
    class RepairsTable
    {
        public static String TABLE_NAME = "Repairs";

        public static String SQL_SELECT = "SELECT * FROM repairs";
        public static String SQL_SELECT_ID = "SELECT * FROM repairs WHERE id_repair=@id_repair";
        public static String SQL_INSERT = "INSERT INTO repairs VALUES (@fault @date, @date_end, @cost, @id_serviceman, @id_vehicle)";
        public static String SQL_DELETE_ID = "DELETE FROM repairs WHERE id_repair=@id_repair";
        public static String SQL_DELETE_BY_VEHICLE_ID = "DELETE FROM repairs WHERE id_vehicle=@id_vehicle";
        public static String SQL_DELETE_BY_SERVICEMAN_ID = "DELETE FROM repairs WHERE id_serviceman=@id_serviceman";
        public static String SQL_UPDATE = "UPDATE repairs SET fault=@fault, date = @date, date_end=@date_end, cost=@cost, id_serviceman=@id_serviceman, id_vehicle=@id_vehicle";

        /// <summary>
        /// Insert the record.
        /// </summary>
        public static int Insert(Repairs r)
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
        /// <param name="Repairs"></param>
        /// <returns></returns>
        public static int Update(Repairs r)
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
        public static Collection<Repairs> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Repairs> repairss = Read(reader);
            reader.Close();
            db.Close();
            return repairss;
        }

        /// <summary>
        /// Select records for category.
        /// </summary>
        public static Repairs Select(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@id_repair", id);
            SqlDataReader reader = db.Select(command);

            Collection<Repairs> repairs = Read(reader);
            Repairs r = null;
            if (repairs.Count == 1)
            {
                r = repairs[0];
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

            command.Parameters.AddWithValue("@id_repair", id);
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }

        public static int DeleteByVehicle(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_BY_VEHICLE_ID);

            command.Parameters.AddWithValue("@id_vehicle", id);
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }
        public static int DeleteByServiceman(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_BY_SERVICEMAN_ID);

            command.Parameters.AddWithValue("@id_serviceman", id);
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }

        /// <summary>
        /// Prepare a command.
        /// </summary>
        private static void PrepareCommand(SqlCommand command, Repairs r)
        {
            command.Parameters.AddWithValue("@id_repair", r.id_repair);
            command.Parameters.AddWithValue("@fault", r.fault);
            command.Parameters.AddWithValue("@date", r.date);
            command.Parameters.AddWithValue("@date_end", r.date_end);
            command.Parameters.AddWithValue("@cost ", r.cost);
            command.Parameters.AddWithValue("@id_serviceman", r.serviceman.id_serviceman);
            command.Parameters.AddWithValue("@id_vehicle", r.vehicle.id_vehicle);
        }

        /// <summary>
        /// Select the record for a name.
        /// </summary>
        //public static Repairs SelectForName(string pName, Database pDb = null)
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

        //    Collection<Repairs> repairss = Read(reader);
        //    Repairs v = null;
        //    if (repairss.Count == 1)
        //    {
        //        v = repairss[0];
        //    }
        //    reader.Close();

        //    if (pDb == null)
        //    {
        //        db.Close();
        //    }

        //    return v;
        //}


        private static Collection<Repairs> Read(SqlDataReader reader)
        {
            Collection<Repairs> repairss = new Collection<Repairs>();

            while (reader.Read())
            {
                Repairs repairs = new Repairs();
                int i = -1;
                repairs.id_repair = reader.GetInt32(++i);
                repairs.fault = reader.GetString(++i);
                repairs.date = reader.GetDateTime(++i);
                if (reader.IsDBNull(++i))
                {
                    repairs.date_end = null;
                }
                else
                {
                    repairs.date_end = reader.GetDateTime(i); 
                }
                   
                repairs.cost = reader.GetDecimal(++i);// repairs.email = reader.IsDBNull(++i) ? null : reader.GetString(++i);
                repairs.serviceman.id_serviceman = reader.GetInt32(++i);// reader.IsDBNull(++i) ? "" : reader.GetString(++i);
                repairs.vehicle.id_vehicle = reader.GetInt32(++i);
                

                repairss.Add(repairs);
            }
            return repairss;
        }

    }
}