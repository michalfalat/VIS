using Dopravio.Models;
using Dopravio_api.Gateways.XML;
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
    class VehicleTable<T> : VehicleGatewayInterface<T> where T : Vehicle
    {

        public String TABLE_NAME = "Vehicle";

        public String SQL_SELECT = "SELECT * FROM vehicle";
        public String SQL_SELECT_ID = "SELECT * FROM vehicle WHERE id=@id";
        public String SQL_SELECT_NAME = "SELECT * FROM vehicle WHERE name=@name";
        public String SQL_INSERT = "INSERT INTO vehicle VALUES (@name, @year, @capacity, @consumption)";
        public String SQL_DELETE_ID = "DELETE FROM vehicle WHERE id=@id";
       // public String SQL_UPDATE = "UPDATE Vehicle SET name=@name, year_of_manufacture = @year_of_manufacture, capacity=@capacity, status=@status, consumption=@consumption, cost_price=@cost_price, wheelchair_accessible=@wheelchair_accessible, id_category= @id_category WHERE id=@id";
     


        private static VehicleTable<Vehicle> instance;
        private VehicleTable() { }

        public static VehicleTable<Vehicle> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VehicleTable<Vehicle>();
                }
                return instance;
            }
        }

        /// <summary>
        /// Insert the record.
        /// </summary>
        public int Insert(T v)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, v);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        /// <summary>
        /// Update the record.
        /// </summary>
        /// <param name="Vehicle"></param>
        /// <returns></returns>
        public int Update(T v)
        {
            throw new NotImplementedException();
            //Database db = new Database();
            //db.Connect();
            //SqlCommand command = db.CreateCommand(SQL_UPDATE);
            //PrepareCommand(command, v);
            //int ret = db.ExecuteNonQuery(command);
            //db.Close();
            //return ret;
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

            Collection<T> vehicles = Read(reader);
            reader.Close();
            db.Close();
            return vehicles;
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

            Collection<T> vehicles = Read(reader);
            T v = null;
            if (vehicles.Count == 1)
            {
                v = vehicles[0];
            }
            reader.Close();
            db.Close();
            return v;
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

        public string KontrolaVozidiel(int years)
        {
            Database db = new Database();
            db.Connect();
            // 1.  create a command object identifying the stored procedure
            SqlCommand command = db.CreateCommand("CheckVehicles");

            // 2. set the command object so it knows to execute a stored procedure
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter input = new SqlParameter();
            input.ParameterName = "@pocetRokov";
            input.DbType = DbType.Int32;
            input.Value = years;
            input.Direction = ParameterDirection.Input;
            command.Parameters.Add(input);

            SqlParameter retval = command.Parameters.Add("@text", SqlDbType.VarChar, 8000);
            retval.Direction = ParameterDirection.Output;
            command.ExecuteNonQuery(); // MISSING
            var retunvalue = (string)command.Parameters["@text"].Value;
            // 4. execute procedure
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return retunvalue;

        }


        //public Collection<RepairHistoryItem> HistoriaOprav(int id)
        //{
        //    Database db = new Database();
        //    db.Connect();
        //    SqlCommand command = db.CreateCommand(SQL_REPAIRHISTORY);
        //    command.Parameters.AddWithValue("@id", id);
        //    SqlDataReader reader = db.Select(command);
        //    var item = ReadRepairHistory(reader);
        //    reader.Close();
        //    db.Close();
        //    return item;

        //}
        /// <summary>
        /// Prepare a command.
        /// </summary>
        private void PrepareCommand(SqlCommand command, Vehicle v)
        {
            command.Parameters.AddWithValue("@id", v.id);
            command.Parameters.AddWithValue("@name", v.name);
            command.Parameters.AddWithValue("@year", v.year);
            command.Parameters.AddWithValue("@capacity", v.capacity);
            command.Parameters.AddWithValue("@consumption", v.consumption);
        }

        /// <summary>
        /// Select the record for a name.
        /// </summary>
        public T SelectForName(string pName, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_SELECT_NAME);

            command.Parameters.AddWithValue("@name", pName);
            SqlDataReader reader = db.Select(command);

            Collection<T> vehicles = Read(reader);
            T v = null;
            if (vehicles.Count == 1)
            {
                v = vehicles[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return v;
        }


        private Collection<T> Read(SqlDataReader reader)
        {
            Collection<T> vehicles = new Collection<T>();

            while (reader.Read())
            {
                Vehicle vehicle = new Vehicle();
                int i = -1;
                vehicle.id = reader.GetInt32(++i);
                vehicle.name = reader.GetString(++i);
                vehicle.year = reader.GetInt32(++i);
                vehicle.capacity = reader.GetInt32(++i);
                vehicle.consumption = reader.GetDecimal(++i);

               // VehicleXMLTable<Vehicle>.Instance.Insert(vehicle);
                vehicles.Add((T)vehicle);
            }
            return vehicles;
        }

        private Collection<RepairHistoryItem> ReadRepairHistory(SqlDataReader reader)
        {
            Collection<RepairHistoryItem> repairs = new Collection<RepairHistoryItem>();

            while (reader.Read())
            {
                RepairHistoryItem item = new RepairHistoryItem();
                int i = -1;
                item.date = reader.GetDateTime(++i);
                item.fault = reader.GetString(++i);
                item.cost = reader.GetDecimal(++i);
                item.servicemanName = reader.GetString(++i);
                item.servicemanSurname = reader.GetString(++i);
                item.servicemanNumber = reader.GetString(++i);


                repairs.Add(item);
            }
            return repairs;
        }



    }

    class RepairHistoryItem
    {
        public DateTime date { get; set; }
        public string fault { get; set; }
        public decimal cost { get; set; }
        public string servicemanName { get; set; }
        public string servicemanSurname { get; set; }
        public string servicemanNumber { get; set; }


    }
}