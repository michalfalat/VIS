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
   public  class EmployeeTable
    {
        public static String TABLE_NAME = "Employee";

        public static String SQL_SELECT = "SELECT * FROM employee";
        public static String SQL_SELECT_ID = "SELECT * FROM employee WHERE id_employee=@id_employee";
        public static String SQL_SELECT_NAME = "SELECT * FROM employee WHERE name=@name";
        public static String SQL_INSERT = "INSERT INTO employee VALUES (@name, @surname, @date_of_birth, @phone_number, @email, @address, @salary)";
        public static String SQL_DELETE_ID = "DELETE FROM Employee WHERE id_employee=@id_employee";
        public static String SQL_UPDATE = "UPDATE Employee SET name=@name, surname=@surname,  salary=@salary, address=@address ,date_of_birth=@date_of_birth, email = @email, phone_number = @phone_number WHERE id_employee=@id_employee";

        /// <summary>
        /// Insert the record.
        /// </summary>
        public static int Insert(Employee emp)
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
        /// <param name="Employee"></param>
        /// <returns></returns>
        public static int Update(Employee emp)
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
        public static Collection<Employee> Select()
        {
            Database db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Employee> employees = Read(reader);
            reader.Close();
            db.Close();
            return employees;
        }

        /// <summary>
        /// Select records for category.
        /// </summary>
        public static Employee Select(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@id_employee", id);
            SqlDataReader reader = db.Select(command);

            Collection<Employee> categories = Read(reader);
            Employee category = null;
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
        public static int Delete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@id_employee", id);
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }


       

        /// <summary>
        /// Prepare a command.
        /// </summary>
        private static void PrepareCommand(SqlCommand command, Employee e)
        {
            command.Parameters.AddWithValue("@id_employee", e.id_employee);
            command.Parameters.AddWithValue("@name", e.name);
            command.Parameters.AddWithValue("@surname", e.surname);
            command.Parameters.AddWithValue("@date_of_birth", e.date_of_birth);
            command.Parameters.AddWithValue("@phone_number ", e.phone_number);
            command.Parameters.AddWithValue("@email", e.email);
            command.Parameters.AddWithValue("@address", e.address);
            command.Parameters.AddWithValue("@salary", e.salary);
        }

        /// <summary>
        /// Select the record for a name.
        /// </summary>
        public static Employee SelectForName(string pName, Database pDb = null)
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

            Collection<Employee> categories = Read(reader);
            Employee category = null;
            if (categories.Count == 1)
            {
                category = categories[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return category;
        }


        private static Collection<Employee> Read(SqlDataReader reader)
        {
            Collection<Employee> employees = new Collection<Employee>();

            while (reader.Read())
            {
                Employee employee = new Employee();
                int i = -1;
                employee.id_employee = reader.GetInt32(++i);
                employee.name = reader.GetString(++i);
                employee.surname = reader.GetString(++i);
                employee.date_of_birth = DateTime.Parse(reader["date_of_birth"].ToString()) ;// reader.GetDateTime(++i);
                employee.phone_number = reader["phone_number"].ToString();// employee.email = reader.IsDBNull(++i) ? null : reader.GetString(++i);
                employee.email = reader["email"].ToString();// reader.IsDBNull(++i) ? "" : reader.GetString(++i);
                employee.address = reader["address"].ToString();
                employee.salary = Decimal.Parse(reader["salary"].ToString());
                
                employees.Add(employee);
            }
            return employees;
        }

    }
}