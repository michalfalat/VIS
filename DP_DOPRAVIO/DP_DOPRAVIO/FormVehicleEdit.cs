
using Dopravio.Helpers;
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
    public partial class FormVehicleEdit : Form
    {
        public int vehicleID { get; set; }
        public Vehicle vehicle { get; set; }
        public FormVehicleEdit(int id)
        {
            VehiclesConnector vc = new VehiclesConnector();
            InitializeComponent();
            //this.vehicleID = id;
            this.vehicle = vc.get(id);
          textBox7.Text = vehicle.name;
            textBox2.Text = vehicle.year.ToString();
           textBox3.Text = vehicle.capacity.ToString();
           textBox4.Text = vehicle.consumption.ToString();
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
            //    this.textBox7.Enabled = true;
            //    this.textBox2.Enabled = true;
            //    this.textBox3.Enabled = true;
            //    this.textBox4.Enabled = true;
            //    this.textBox6.Enabled = true;
            //    this.checkBox1.Enabled = true;
            //    this.comboBox1.Enabled = true;
            //    this.button4.Text = "Uložiť";
            //}
            //else if (this.button4.Text == "Uložiť")
            //{

            //    Vehicle veh = VehicleTable.Select(vehicleID);
            //    veh.name = this.textBox7.Text;
            //    veh.status = (VehicleStatus)Enum.Parse(typeof(VehicleStatus), this.comboBox1.SelectedItem.ToString(), true);
            //    veh.wheelchair_accessible = this.checkBox1.Checked;
            //    veh.year_of_manufacture = int.Parse(this.textBox2.Text);
            //    veh.capacity = int.Parse(this.textBox3.Text);
            //    veh.consumption = double.Parse(this.textBox4.Text);
            //    veh.cost_price = decimal.Parse(this.textBox6.Text);
            //    VehicleTable.Update(veh);



            //    this.textBox7.Enabled = false;
            //    this.comboBox1.Enabled = false;
            //    this.textBox2.Enabled = false;
            //    this.textBox3.Enabled = false;
            //    this.textBox4.Enabled = false;
            //    this.textBox6.Enabled = false;
            //    this.checkBox1.Enabled = false;
            //    this.button4.Text = "Editovať";
            //}
        }
    }

  
}
