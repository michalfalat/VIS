using Dopravio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dopravio
{
    public partial class FormDriverEdit : Form
    {
        public int id { get; set; }
        public FormDriverEdit(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void FormEmployeeEdit_Load(object sender, EventArgs e)
        {

            //Employee emp = EmployeeTable.Select(id);
            //this.textBoxName.Text = emp.name;
            //this.textBoxSurname.Text = emp.surname;
            //this.textBoxEmail.Text = emp.email;
            //this.textBoxDate.Text = emp.date_of_birth.ToShortDateString();
            //this.textBoxPhone.Text = emp.phone_number;
            //this.textBoxAddress.Text = emp.address;
            //this.textBoxSalary.Text = emp.salary.ToString();
            //this.textBoxDailyMileage.Text = DriverTable.DennyNajazdVodica(id).ToString();
            //this.textBoxAccidents.Text = DriverTable.Select().Where(d => d.employee.id_employee == id).Select(dd => dd.accident_count.ToString()).FirstOrDefault();
            //this.textBoxPractise.Text = DriverTable.Select().Where(d => d.employee.id_employee == id).Select(dd => dd.years_drived.ToString()).FirstOrDefault();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ////edit / save
            //if (this.button4.Text == "Editovať")
            //{
            //    this.textBoxName.Enabled = true;
            //    this.textBoxSurname.Enabled = true;
            //    this.textBoxEmail.Enabled = true;
            //    this.textBoxDate.Enabled = true;
            //    this.textBoxPhone.Enabled = true;
            //    this.textBoxAddress.Enabled = true;
            //    this.textBoxSalary.Enabled = true;
            //    // this.textBoxPractise.Enabled = true;// Text = ServicemanTable.Select().Where(s => s.employee.id_employee == id).Select(ss => ss.qualification).FirstOrDefault();
            //    this.textBoxAccidents.Enabled = true;
            //    this.textBoxPractise.Enabled = true;
            //    this.button4.Text = "Uložiť";
            //}
            //else if (this.button4.Text == "Uložiť")
            //{

                //Employee emp = EmployeeTable.Select(id);
                //emp.name = this.textBoxName.Text;
                //emp.surname = this.textBoxSurname.Text;
                //emp.email = this.textBoxEmail.Text;
                //emp.date_of_birth = DateTime.Parse(this.textBoxDate.Text);
                //emp.phone_number = this.textBoxPhone.Text;
                //emp.address = this.textBoxAddress.Text;
                //emp.salary = decimal.Parse(this.textBoxSalary.Text);
                //EmployeeTable.Update(emp);


                //Driver dr = DriverTable.Select().Where(s => s.employee.id_employee == id).FirstOrDefault();
                //dr.accident_count = int.Parse(this.textBoxAccidents.Text);
                //dr.years_drived = int.Parse(this.textBoxPractise.Text);
                //DriverTable.Update(dr);

                //this.textBoxName.Enabled = false;
                //this.textBoxSurname.Enabled = false;
                //this.textBoxEmail.Enabled = false;
                //this.textBoxDate.Enabled = false;
                //this.textBoxPhone.Enabled = false;
                //this.textBoxAddress.Enabled = false;
                //this.textBoxSalary.Enabled = false;
                //this.textBoxAccidents.Enabled = false;
                //this.textBoxPractise.Enabled = false;
                //this.button4.Text = "Editovať";
            
        }
    }
}
