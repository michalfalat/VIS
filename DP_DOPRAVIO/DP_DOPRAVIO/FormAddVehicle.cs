using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dopravio.Models;
using Dopravio.Helpers;

namespace Dopravio
{
    public partial class FormAddVehicle : Form
    {
        public FormAddVehicle()
        {
            InitializeComponent();
        }

        private void FormAddVehicle_Load(object sender, EventArgs e)
       {
    //        var categories = VehicleCategoryTable.Select();
    //        this.comboBox2.Items.Clear();

    //        foreach (var cat in categories)
    //        {
    //            this.comboBox2.Items.Add(cat.type.ToString());
    //        }
    //        this.comboBox1.SelectedItem = "FREE";
       }

        private void button1_Click(object sender, EventArgs e)
        {

            VehiclesConnector vc = new VehiclesConnector();
            Vehicle v = new Vehicle();
            v.name = this.textBoxNazov.Text;
            v.year = int.Parse(this.textBoxRok.Text);
            v.consumption = decimal.Parse(this.textBoxSpotreba.Text);
            v.capacity = int.Parse(this.textBoxKapacita.Text);

            var str = vc.send(v);
            if (str == "\"OK\"")
            {
                var dialogResult = MessageBox.Show("Záznam vložený!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }
    }
}
