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
    public partial class FormTimetableEdit : Form
    {
        private bool init = true;
        public Timetable timetable { get; set; }
        public List<Timetable> timetables { get; set; }
        public List<Vehicle> availibleVehicles { get; set; }
        public List<Driver> availibleDrivers { get; set; }

        public List<Vehicle> allVehicles { get; set; }
        public List<Driver> allDrivers { get; set; }
        public FormTimetableEdit( int timetable_id)
        {
           
            InitializeComponent();
            VehiclesConnector vc = new VehiclesConnector();
            DriversConnector dc = new DriversConnector();
            TimetablesConnector tc = new TimetablesConnector();
            allVehicles = vc.get();
            allDrivers = dc.get();
            availibleVehicles = new List<Vehicle>();
            availibleDrivers = new List<Driver>();
            timetables = tc.get();
          timetable = timetables.Where(t =>t.id == timetable_id).FirstOrDefault();
            tbName.Text = timetable.name;
            tbRoute.Text = timetable.route.start + " - " + timetable.route.finish;
            dtDeparture.Text = timetable.departure.ToString("HH:mm");
            drArrival.Text = timetable.arrival.ToString("HH:mm");

            availibleVehicles.Add(timetable.vehicle);
            availibleDrivers.Add(timetable.driver);
            cbVehicle.DataSource = availibleVehicles;
            cbVehicle.DisplayMember = "detail";
            cbVehicle.ValueMember = "id";

            cbDriver.DataSource = availibleDrivers;
            cbDriver.DisplayMember = "fullName";
            cbDriver.ValueMember = "id";
           calculateAvailableResources();
            cbVehicle.SelectedItem = timetable.vehicle;
            cbDriver.SelectedItem = timetable.driver;
            init = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtDeparture_ValueChanged(object sender, EventArgs e)
        {
           if (init== false)
                calculateAvailableResources();
        }

        private void drArrival_ValueChanged(object sender, EventArgs e)
        {
            if (init == false)
                calculateAvailableResources();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.tbName.Enabled = true;
            drArrival.Enabled = true;
            dtDeparture.Enabled = true;
            cbDriver.Enabled = true;
            cbVehicle.Enabled = true;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Driver d=  (Driver)cbDriver.SelectedItem;
            Vehicle v = (Vehicle)cbVehicle.SelectedItem;
            timetable.name = tbName.Text;
            timetable.arrival = drArrival.Value;
            timetable.departure = dtDeparture.Value;
            timetable.driver = d;
            timetable.vehicle = v;

            TimetablesConnector tc = new TimetablesConnector();
           var m =  tc.update(timetable);
            if(m == "\"OK\"")
            {
                this.Close();
            }
            else
            {
                label7.Visible = true;
                label7.Text = m;
            }
        }


        private void calculateAvailableResources()
        {
            var departure = dtDeparture.Value.TimeOfDay;
            var arrival = drArrival.Value.TimeOfDay;
            availibleDrivers.Clear();
            availibleVehicles.Clear();
            foreach (Driver d in allDrivers)
            {
                var isOK = true;
                var driversTimetables = timetables.Where(t => t.driver.id == d.id);
                foreach (var tim in driversTimetables)
                {
                    if( tim.id == timetable.id)
                    {
                        isOK = true;
                        break;
                    }
                    var timDeparture = tim.departure.TimeOfDay;
                    var timArrival = tim.arrival.TimeOfDay;
                    if ((timDeparture > departure && timDeparture < arrival) || (timArrival > departure && timArrival < arrival))
                    {
                        isOK = false;
                    }

                }

                if (isOK)
                {
                    availibleDrivers.Add(d);
                }
            }

            foreach (Vehicle d in allVehicles)
            {
                var isOK = true;
                var vehiclesTimetables = timetables.Where(t => t.vehicle.id == d.id);
                foreach (var tim in vehiclesTimetables)
                {
                    if (tim.id != timetable.id)
                    {

                        var timDeparture = tim.departure.TimeOfDay;
                        var timArrival = tim.arrival.TimeOfDay;
                        if ((timDeparture > departure && timDeparture < arrival) || (timArrival > departure && timArrival < arrival))
                        {
                            isOK = false;
                        }
                    }

                }

                if (isOK)
                {
                    availibleVehicles.Add(d);
                }
            }
            cbDriver.DataSource = null;
            cbDriver.Items.Clear();
            cbDriver.DataSource = availibleDrivers;
            cbDriver.DisplayMember = "fullName";
            cbDriver.ValueMember = "id";
            var item = availibleDrivers.Where(v => v.id == timetable.driver.id).FirstOrDefault();
            if (item != null)
            {

                cbDriver.SelectedItem = item;
            }


            cbVehicle.DataSource = null;
            cbVehicle.Items.Clear();
            cbVehicle.DataSource = availibleVehicles;
            cbVehicle.DisplayMember = "detail";
            cbVehicle.ValueMember = "id";
            var itemV = availibleVehicles.Where(v => v.id == timetable.vehicle.id).FirstOrDefault();
            if(itemV != null)
            {

                cbVehicle.SelectedItem = itemV;
            }
        }
    }
}
