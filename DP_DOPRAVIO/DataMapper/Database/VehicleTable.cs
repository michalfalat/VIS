using Dopravio.Models;
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
    class VehicleTable
    {
        public static String TABLE_NAME = "Vehicle";

        public static String SQL_SELECT = "SELECT * FROM vehicle";
        public static String SQL_SELECT_ID = "SELECT * FROM vehicle WHERE id_vehicle=@id_vehicle";
        public static String SQL_SELECT_NAME = "SELECT * FROM vehicle WHERE name=@name";
        public static String SQL_INSERT = "INSERT INTO vehicle VALUES (@name, @year_of_manufacture, @capacity, @status, @consumption, @cost_price, @wheelchair_accessible, @id_category)";
        public static String SQL_DELETE_ID = "DELETE FROM vehicle WHERE id_vehicle=@id_vehicle";
        public static String SQL_UPDATE = "UPDATE Vehicle SET name=@name, year_of_manufacture = @year_of_manufacture, capacity=@capacity, status=@status, consumption=@consumption, cost_price=@cost_price, wheelchair_accessible=@wheelchair_accessible, id_category= @id_category WHERE id_vehicle=@id_vehicle";
        public static string SQL_REPAIRHISTORY = @"SELECT r.date, r.fault,  r.cost , e.name, e.surname, e.phone_number 
                                                    FROM repairs  r 
                                                    JOIN serviceman s on s.id_serviceman = r.id_serviceman 
                                                    JOIN employee e ON s.id_employee = e.id_employee 
                                                    WHERE r.id_vehicle = @id_vehicle
                                                    ORDER BY r.date DESC;";

        /// <summary>
        /// Insert the record.
        /// </summary>
        public static int Insert(Vehicle v)
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
        public static int Update(Vehicle v)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, v);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }


        /// <summary>
        /// Select records.
        /// </summary>
        public static Collection<Vehicle> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Vehicle> vehicles = Read(reader);
            reader.Close();
            db.Close();
            return vehicles;
        }

        /// <summary>
        /// Select records for category.
        /// </summary>
        public static Vehicle Select(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@id_vehicle", id);
            SqlDataReader reader = db.Select(command);

            Collection<Vehicle> vehicles = Read(reader);
            Vehicle v = null;
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
        public static int Delete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@id_vehicle", id);
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }

        public static string KontrolaVozidiel(int years)
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


        public static Collection<RepairHistoryItem> HistoriaOprav(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_REPAIRHISTORY);
            command.Parameters.AddWithValue("@id_vehicle", id);
            SqlDataReader reader = db.Select(command);
            var item = ReadRepairHistory(reader);
            reader.Close();
            db.Close();
            return item;

        }
        /// <summary>
        /// Prepare a command.
        /// </summary>
        private static void PrepareCommand(SqlCommand command, Vehicle v)
        {
            command.Parameters.AddWithValue("@id_vehicle", v.id_vehicle);
            command.Parameters.AddWithValue("@name", v.name);
            command.Parameters.AddWithValue("@year_of_manufacture", v.year_of_manufacture);
            command.Parameters.AddWithValue("@capacity", v.capacity);
            command.Parameters.AddWithValue("@status ", v.status);
            command.Parameters.AddWithValue("@consumption", v.consumption);
            command.Parameters.AddWithValue("@cost_price", v.cost_price);
            command.Parameters.AddWithValue("@wheelchair_accessible", v.wheelchair_accessible);
            command.Parameters.AddWithValue("@id_category", v.category.id_category);
        }

        /// <summary>
        /// Select the record for a name.
        /// </summary>
        public static Vehicle SelectForName(string pName, Database pDb = null)
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

            Collection<Vehicle> vehicles = Read(reader);
            Vehicle v = null;
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


        private static Collection<Vehicle> Read(SqlDataReader reader)
        {
            Collection<Vehicle> vehicles = new Collection<Vehicle>();

            while (reader.Read())
            {
                Vehicle vehicle = new Vehicle();
                int i = -1;
                vehicle.id_vehicle = reader.GetInt32(++i);
                vehicle.name = reader.GetString(++i);
                vehicle.year_of_manufacture = reader.GetInt32(++i);
                vehicle.capacity = reader.GetInt32(++i);
                vehicle.status = (VehicleStatus) Enum.Parse(typeof(VehicleStatus), reader.GetString(++i));
                vehicle.consumption = reader.GetDouble(++i);
                vehicle.cost_price = reader.GetDecimal(++i);
                vehicle.wheelchair_accessible = reader.GetBoolean(++i);
                vehicle.category.id_category = reader.GetInt32(++i);

                vehicles.Add(vehicle);
            }
            return vehicles;
        }

        private static Collection<RepairHistoryItem> ReadRepairHistory(SqlDataReader reader)
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