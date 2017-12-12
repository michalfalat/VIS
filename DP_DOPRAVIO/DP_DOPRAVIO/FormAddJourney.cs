
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
    public partial class FormAddJourney : Form
    {
        public FormAddJourney()
        {
            //InitializeComponent();
            //this.comboBoxDriver.DropDownStyle = ComboBoxStyle.DropDownList;
            //this.comboBoxRoute.DropDownStyle = ComboBoxStyle.DropDownList;
            //this.comboBoxVehicle.DropDownStyle = ComboBoxStyle.DropDownList;
            //var drivers = DriverTable.Select();
            //this.comboBoxDriver.Items.Clear();
            //SortedDictionary<int, string> driversDic = new SortedDictionary<int, string>();
            //foreach (var item in drivers)
            //{
            //    // this.comboBoxDriver.Items.Add(item.employee.name + " " + item.employee.surname);
            //    driversDic.Add(item.id_driver, item.employee.name + " " + item.employee.surname);

            //}
            //comboBoxDriver.DataSource = new BindingSource(driversDic, null);
            //comboBoxDriver.DisplayMember = "Value";
            //comboBoxDriver.ValueMember = "Key";

            //var vehicles = VehicleTable.Select();
            //SortedDictionary<int, string> vehiclesDic = new SortedDictionary<int, string>();
            //foreach (var item in vehicles)
            //{
            //    vehiclesDic.Add(item.id_vehicle, item.name);
            //}
            //comboBoxVehicle.DataSource = new BindingSource(vehiclesDic, null);
            //comboBoxVehicle.DisplayMember = "Value";
            //comboBoxVehicle.ValueMember = "Key";

            //SortedDictionary<int, string> routesDic = new SortedDictionary<int, string>();
            //var routes = RouteTable.Select();
            //foreach (var item in routes)
            //{
            //    routesDic.Add(item.id_route, item.start + "-" + item.finish);
            //}

            //comboBoxRoute.DataSource = new BindingSource(routesDic, null);
            //comboBoxRoute.DisplayMember = "Value";
            //comboBoxRoute.ValueMember = "Key";
        }

        private void Príchod_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Timetable t = new Timetable();
            //// t.arrival = this.dateTimePickerPrichod.Value;
            //t.link_name = this.textBoxName.Text;
            //t.departure = default(DateTime).Add(this.dateTimePickerOdchod.Value.TimeOfDay);
            //t.departure = t.departure.AddYears(1900);
            //t.arrival = default(DateTime).Add(this.dateTimePickerPrichod.Value.TimeOfDay);
            //t.arrival = t.arrival.AddYears(1900);

            //KeyValuePair<int, string> driver = new KeyValuePair<int, string>();
            //KeyValuePair<int, string> vehicle = new KeyValuePair<int, string>();
            //KeyValuePair<int, string> route = new KeyValuePair<int, string>();

            //driver = (KeyValuePair<int, string>)this.comboBoxDriver.SelectedItem;
            //route = (KeyValuePair<int, string>)this.comboBoxRoute.SelectedItem;
            //vehicle = (KeyValuePair<int, string>)this.comboBoxVehicle.SelectedItem;

            //t.driver = DriverTable.Select().Where(dt => dt.id_driver == driver.Key).FirstOrDefault();
            //t.route = RouteTable.Select().Where(r => r.id_route == route.Key).FirstOrDefault();
            //t.vehicle = VehicleTable.Select().Where(v => v.id_vehicle == vehicle.Key).FirstOrDefault();

            //TimetableTable.Insert(t);
            //var dialogResult = MessageBox.Show("Záznam vložený!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //if (dialogResult == DialogResult.OK)
            //{
            //    this.Close();
            //}

        }
    }
}
