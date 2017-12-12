using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Dopravio.Helpers;

namespace Dopravio
{
    public partial class Form1 : Form
    {

        public int selectedIndex { get; set; }
        private ColumnHeader SortingColumn = null;

        //0 - zoznam zamestnancov
        //1 - zoznam vozidiel
        //2 - zoznam kategorii
        //3 - zoznam jazd
        //4 - zoznam tras
        //5 - zoznam 

       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //testing connection
        private void button1_Click(object sender, EventArgs e)
        {

            //this.label1.Text = "Pripájam..";
            //this.Cursor = Cursors.WaitCursor;
            //try
            //{
            //    db = new Dopravio.Database.Database();
            //    db.Connect();
            //    MessageBox.Show("Úspešne pripojenie do databázy!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.label1.Text = "Posledné pripojenie: " + DateTime.Now.ToLongTimeString();
            //    this.Cursor = Cursors.Default;
            //}
            //catch (Exception exp)
            //{

            //    this.label1.Text = "Problém s pripojením";
            //    MessageBox.Show(exp.Message, "Nepodarilo sa pripojiť k DB", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    this.Cursor = Cursors.Default;
            //}
            //db.Close();


        }

        #region MENUCLICKS

        private void zoznamZamestnancovToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadEmployees();
        }

        private void zoznamVozidielToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadVehicles();
        }

        private void zoznamJázdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadTimetable();
        }

        private void zoznamTrásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadRoutes();
        }

        private void zoznamKategóriiVozidielToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.LoadCategories();
        }
        #endregion


        //OPEN DETAIL
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
           // this.button2_Click_1(sender, e);           
        }

        //OPEN DETAIL
        private void editovaťToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.button2_Click_1(sender, e);
        }


        //OPEN DELETE PROMPT
        private void vymazaťToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.button3_Click(sender, e);
        }



        //SELECT OR OPEN CONTEXTMENU
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
            else
            {
                if (this.listView1.SelectedItems.Count == 1 )
                {
                    this.button2.Enabled = true;
                    this.button3.Enabled = true;
                }

            }
        }



        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            this.listView1.SelectedItems.Clear();
            

                this.button2.Enabled = false;
                this.button3.Enabled = false;
            

        }


        //DETAIL CLICK
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                switch (this.selectedIndex)
                {
                    case 0://employee
                        //ListViewItem item = listView1.SelectedItems[0];
                        //var id = int.Parse(item.SubItems[0].Text);
                        //if (DriverTable.Select().Where(d => d.employee.id_employee == id).FirstOrDefault() != null)
                        //{
                        //    FormDriverEdit fd = new FormDriverEdit(id);
                        //    fd.Text = "Detail vodiča";
                        //    fd.AccessibleDescription = item.SubItems[0].Text;
                        //    fd.FormClosed += this.zoznamZamestnancovToolStripMenuItem_Click;
                        //    // fd.bu
                        //    fd.Show();
                        //}
                        //else
                        //{
                        //    FormServicemanEdit fs = new FormServicemanEdit(id);
                        //    fs.Text = "Detail opravára";
                        //    fs.AccessibleDescription = item.SubItems[0].Text;
                        //    fs.FormClosed += this.zoznamZamestnancovToolStripMenuItem_Click;
                        //    fs.Show();
                        //}

                        break;
                    case 1://vehicle
                        ListViewItem itemVehicle = listView1.SelectedItems[0];
                        FormVehicleEdit fve = new FormVehicleEdit(int.Parse(itemVehicle.SubItems[0].Text));
                        fve.Text = "Detail vozidla";
                        fve.AccessibleDescription = itemVehicle.SubItems[0].Text;
                        fve.FormClosed += this.zoznamVozidielToolStripMenuItem_Click;
                        fve.Show();
                        break;
                    case 3://timetable
                        ListViewItem itemJourney = listView1.SelectedItems[0];
                        FormTimetableEdit fte = new FormTimetableEdit(int.Parse(itemJourney.SubItems[0].Text));

                        fte.AccessibleDescription = itemJourney.SubItems[0].Text;
                        fte.FormClosed += this.zoznamJázdToolStripMenuItem_Click;
                        fte.Show();
                        break;
                    default:
                        break;
                }
            }
        }


        //DELETE CLICK
        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                ListViewItem item = listView1.SelectedItems[0];
                var id = int.Parse(item.SubItems[0].Text);
                switch (this.selectedIndex)
                {
                    //case 0://employee
                    //    var driver = DriverTable.Select().Where(d => d.employee.id_employee == id).FirstOrDefault();
                    //    if (driver != null)
                    //    {
                    //        DialogResult dialogResult1 = MessageBox.Show("Naozaj chcete vymazať záznam?", "Vymazať", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    //        if (dialogResult1 == DialogResult.Yes)
                    //        {
                    //            if (TimetableTable.Select().Where(tt => tt.driver.id_driver == driver.id_driver).Any())
                    //            {
                    //                MessageBox.Show("Nemožno vymazať vodiča, pretože sa nachádza v aktualnom cestovnom poriadku.", "Nepodarilo sa vymazať záznam", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //            }
                    //            else
                    //            {
                    //                try
                    //                {
                    //                    SalaryChangesTable.DeleteByEmployee(id);
                    //                    DriverTable.Delete(driver.id_driver);
                    //                    EmployeeTable.Delete(id);
                    //                    MessageBox.Show("Záznam bol vymazaný!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //                }
                    //                catch (Exception ex)
                    //                {
                    //                    MessageBox.Show(ex.Message, "Vyskytla sa chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //                }
                    //                LoadEmployees();
                    //            }
                    //        }
                    //        else if (dialogResult1 == DialogResult.No)
                    //        {
                    //            //do something else
                    //        }
                    //    }
                    //    else
                    //    {
                    //        var serviceman = ServicemanTable.Select().Where(d => d.employee.id_employee == id).FirstOrDefault();
                    //        DialogResult dialogResult = MessageBox.Show("Naozaj chcete vymazať záznam?", "Vymazať", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    //        if (dialogResult == DialogResult.Yes)
                    //        {
                    //            if (RepairsTable.Select().Where(tt => tt.serviceman.id_serviceman == serviceman.id_serviceman && tt.date_end == null).Any())
                    //            {
                    //                MessageBox.Show("Nemožno vymazať opravára, pretože je priradený ku neskončenej oprave", "Nepodarilo sa vymazať záznam", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //            }
                    //            else
                    //            {
                    //                try
                    //                {
                    //                    SalaryChangesTable.DeleteByEmployee(id);
                    //                    RepairsTable.DeleteByServiceman(serviceman.id_serviceman);
                    //                    ServicemanTable.DeleteByEmployee(id);
                    //                    EmployeeTable.Delete(id);
                    //                    MessageBox.Show("Záznam bol vymazaný!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    //                }
                    //                catch (Exception ex)
                    //                {
                    //                    MessageBox.Show(ex.Message, "Vyskytla sa chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    //                }
                    //                this.LoadEmployees();
                    //            }
                    //        }
                    //        else if (dialogResult == DialogResult.No)
                    //        {
                    //            //do something else
                    //        }
                    //    }

                    //    break;
                    //case 1://vehicle
                    //    DialogResult dialogResult3 = MessageBox.Show("Naozaj chcete vymazať záznam?", "Vymazať", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    //    if (dialogResult3 == DialogResult.Yes)
                    //    {
                    //        RepairsTable.DeleteByVehicle(id);
                    //        VehicleTable.Delete(id);
                    //        LoadVehicles();
                    //    }
                    //    else if (dialogResult3 == DialogResult.No)
                    //    {
                    //        //do something else
                    //    }
                    //    break;
                    //case 2: //vehicle categry
                    //    DialogResult dialogResult4 = MessageBox.Show("Naozaj chcete vymazať záznam?", "Vymazať", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    //    if (dialogResult4 == DialogResult.Yes)
                    //    {
                    //        var cat = VehicleCategoryTable.Select(id);
                    //        if (VehicleTable.Select().Where(v => v.category.id_category == cat.id_category).Any())
                    //        {
                    //            MessageBox.Show("Nemožno vymazať kategóriu, ktorá je priradená!", "Nepodarilo sa vymazať záznam", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        }
                    //        else
                    //        {
                    //            try
                    //            {
                    //                VehicleCategoryTable.Delete(id);
                    //                MessageBox.Show("Záznam bol vymazaný!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //                LoadCategories();

                    //            }
                    //            catch (Exception ex)
                    //            {
                    //                MessageBox.Show(ex.Message, "Vyskytla sa chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    //            }
                    //        }
                    //    }
                    //    else if (dialogResult4 == DialogResult.No)
                    //    {
                    //        //do something else
                    //    }
                    //    break;
                    //case 3:// timetable
                    //    DialogResult dialogResult5 = MessageBox.Show("Naozaj chcete vymazať záznam?", "Vymazať", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    //    if (dialogResult5 == DialogResult.Yes)
                    //    {

                    //        try
                    //        {
                    //            TimetableTable.Delete(id);
                    //            MessageBox.Show("Záznam bol vymazaný!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //            LoadTimetable();

                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            MessageBox.Show(ex.Message, "Vyskytla sa chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    //        }

                    //    }
                    //    else if (dialogResult5 == DialogResult.No)
                    //    {
                    //        //do something else
                    //    }
                    //    break;
                    case 6://message
                        DialogResult dialogResult6 = MessageBox.Show("Naozaj chcete vymazať záznam?", "Vymazať", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (dialogResult6 == DialogResult.Yes)
                        {
                            MessagesConnector mc = new MessagesConnector();
                            var result = mc.delete(id);
                            if (result == "\"OK\"")
                            {

                                MessageBox.Show("Záznam bol vymazaný!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadMessages();
                            }
                          
                        }
                        else if (dialogResult6 == DialogResult.No)
                        {
                            //do something else
                        }
                        break;
                    default:
                        break;
                }
            }
        }


        //SORTING
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Get the new sorting column.
            ColumnHeader new_sorting_column = this.listView1.Columns[e.Column];

            // Figure out the new sorting order.
            System.Windows.Forms.SortOrder sort_order;
            if (SortingColumn == null)
            {
                // New column. Sort ascending.
                sort_order = SortOrder.Ascending;
            }
            else
            {
                // See if this is the same column.
                if (new_sorting_column == SortingColumn)
                {
                    // Same column. Switch the sort order.
                    if (SortingColumn.Text.StartsWith("> "))
                    {
                        sort_order = SortOrder.Descending;
                    }
                    else
                    {
                        sort_order = SortOrder.Ascending;
                    }
                }
                else
                {
                    // New column. Sort ascending.
                    sort_order = SortOrder.Ascending;
                }

                // Remove the old sort indicator.
                SortingColumn.Text = SortingColumn.Text.Substring(2);
            }

            // Display the new sort order.
            SortingColumn = new_sorting_column;
            if (sort_order == SortOrder.Ascending)
            {
                SortingColumn.Text = "> " + SortingColumn.Text;
            }
            else
            {
                SortingColumn.Text = "< " + SortingColumn.Text;
            }

            // Create a comparer.
            this.listView1.ListViewItemSorter =
                new ListViewComparer(e.Column, sort_order);

            // Sort.
            this.listView1.Sort();
        }

        public void LoadEmployees()
        {
            this.button2.Visible = false;
            this.button3.Visible = false;
            this.selectedIndex = 0;
            this.Text = "Zamestnanci - Dopravný podnik";
            this.Cursor = Cursors.WaitCursor;
            this.listView1.Clear();
            listView1.Columns.Add("Funkcia");
            listView1.Columns.Add("Meno");
            listView1.Columns.Add("Priezvisko");
            listView1.Columns.Add("Telefon");
            listView1.Columns.Add("Email");
            this.listView1.AccessibleName = "employees";
            listView1.Columns[0].Width = listView1.Width / 5 - 20;
            listView1.Columns[1].Width = listView1.Width / 5;
            listView1.Columns[2].Width = listView1.Width / 5;
            listView1.Columns[3].Width = listView1.Width / 5;
            listView1.Columns[4].Width = listView1.Width / 5;
            try
            {
                DriversConnector driConn = new DriversConnector();
                DispatchersConnector disConn = new DispatchersConnector();
                ManagersConnector manConn = new ManagersConnector();

                // var employees = EmployeeTable.Select();
                var drivers = driConn.get();
                var dispatchers = disConn.get();


                foreach (var u in drivers)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = "Vodič";
                    item.SubItems.Add(u.name.ToString());
                    item.SubItems.Add(u.surname.ToString());                   
                    item.SubItems.Add(u.phone);
                    item.SubItems.Add(u.email.ToString());
                    this.listView1.Items.Add(item);
                }

                foreach (var u in dispatchers)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = "Dispečer";
                    item.SubItems.Add(u.name.ToString());
                    item.SubItems.Add(u.surname.ToString());
                    item.SubItems.Add(u.phone);
                    item.SubItems.Add(u.email.ToString());
                    this.listView1.Items.Add(item);
                }
                var datum = DateTime.Now.ToLongTimeString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Vyskytla sa chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        public void LoadVehicles()
        {

            this.button2.Enabled = false;
            this.button3.Enabled = false;
            this.button2.Visible = true;
            this.button3.Visible = false;
            this.selectedIndex = 1;
            this.Text = "Vozidlá - Dopravný podnik";
            this.Cursor = Cursors.WaitCursor;
            this.listView1.Clear();
            listView1.Columns.Add("Id");
            listView1.Columns.Add("Názov");
            listView1.Columns.Add("Rok výroby");
            listView1.Columns.Add("Kapacita");

            listView1.Columns[0].Width = listView1.Width / 4 - 20;
            listView1.Columns[1].Width = listView1.Width / 4;
            listView1.Columns[2].Width = listView1.Width / 4;
            listView1.Columns[3].Width = listView1.Width / 4;

            try
            {
                VehiclesConnector vc = new VehiclesConnector();
                var vehicles = vc.get();

                foreach (var v in vehicles)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = v.id.ToString();
                    item.SubItems.Add(v.name.ToString());
                    item.SubItems.Add(v.year.ToString());
                    item.SubItems.Add(v.capacity.ToString());

                    this.listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Vyskytla sa chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            this.Cursor = Cursors.Default;
        }

        

        public void LoadRoutes()
        {
            this.button2.Visible = false;
            this.button3.Visible = false;
            this.selectedIndex = 4;
            this.Text = "Cestovný poriadok - Dopravný podnik";
            this.Cursor = Cursors.WaitCursor;
            this.listView1.Clear();
            listView1.Columns.Add("Id");
            listView1.Columns.Add("Štart");
            listView1.Columns.Add("Ciel");
            listView1.Columns.Add("Vzdialenost");

            listView1.Columns[0].Width = listView1.Width / 4 - 20;
            listView1.Columns[1].Width = listView1.Width / 4;
            listView1.Columns[2].Width = listView1.Width / 4;
            listView1.Columns[3].Width = listView1.Width / 4;
            try
            {
                RoutesConnector rc = new RoutesConnector();
                var routes = rc.get();

                foreach (var r in routes)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = r.id.ToString();
                    item.SubItems.Add(r.start);
                    item.SubItems.Add(r.finish);
                    item.SubItems.Add(r.distance.ToString());

                    this.listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Vyskytla sa chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        public void LoadTimetable()
        {

            this.button2.Enabled = false;
            this.button3.Enabled = false;
            this.button2.Visible = true;
            this.button3.Visible = false;
            this.selectedIndex = 3;
            this.Text = "Cestovný poriadok - Dopravný podnik";
            this.Cursor = Cursors.WaitCursor;
            this.listView1.Clear();
            listView1.Columns.Add("Id");
            listView1.Columns.Add("Názov linky");
            listView1.Columns.Add("Trasa");
            listView1.Columns.Add("Vozidlo");
            listView1.Columns.Add("Vodič");
            listView1.Columns.Add("Odchod");
            listView1.Columns.Add("Príchod");

            listView1.Columns[0].Width = listView1.Width / 6 - 50;
            listView1.Columns[1].Width = listView1.Width / 6;
            listView1.Columns[2].Width = listView1.Width / 6;
            listView1.Columns[3].Width = listView1.Width / 6;
            listView1.Columns[4].Width = listView1.Width / 6;
            listView1.Columns[5].Width = listView1.Width / 6 -40;
            listView1.Columns[6].Width = listView1.Width / 6 - 40;
            try
            {
                TimetablesConnector tc = new TimetablesConnector();
                var journeys = tc.get();

                foreach (var j in journeys)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = j.id.ToString();
                    item.SubItems.Add(j.name.ToString());
                    item.SubItems.Add(j.route.start + " - " + j.route.finish);
                    item.SubItems.Add(j.vehicle.name);
                    item.SubItems.Add(j.driver.fullName);
                    item.SubItems.Add(j.departure.ToLongTimeString());
                    item.SubItems.Add(j.arrival.ToLongTimeString());

                    this.listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Vyskytla sa chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        public void LoadMessages()
        {

            this.button2.Enabled = false;
            this.button3.Enabled = false;
            this.button2.Visible = false;
            this.button3.Visible = true;
            this.selectedIndex = 6;
            this.Text = "Správy - Dopravný podnik";
            this.Cursor = Cursors.WaitCursor;
            this.listView1.Clear();
            listView1.Columns.Add("Id");
            listView1.Columns.Add("Čas");
            listView1.Columns.Add("Príjemca");
            listView1.Columns.Add("Text");
            listView1.Columns.Add("Stav");

            listView1.Columns[0].Width = listView1.Width / 5 - 40;
            listView1.Columns[1].Width = listView1.Width / 5 - 40;
            listView1.Columns[2].Width = listView1.Width / 5- 50;
            listView1.Columns[3].Width = listView1.Width / 5 + 170;
            listView1.Columns[4].Width = listView1.Width / 5 -80;
            try
            {
                MessagesConnector mc = new MessagesConnector();
                var messages = mc.get().OrderByDescending(m => m.created) ;

                foreach (var r in messages)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = r.id.ToString();
                    item.SubItems.Add(r.created.ToShortDateString() + " " + r.created.ToShortTimeString());
                    item.SubItems.Add(r.manager.fullName);
                    item.SubItems.Add(r.text);
                    item.SubItems.Add(r.isRead.HasValue && r.isRead.Value ? "Prečítaná" : "Odoslaná");

                    this.listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Vyskytla sa chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }


        public void LoadRequests()
        {

            this.button2.Enabled = false;
            this.button3.Enabled = false;
            this.button2.Visible = false;
            this.button3.Visible = false;
            this.selectedIndex = 6;
            this.Text = "Žiadosti - Dopravný podnik";
            this.Cursor = Cursors.WaitCursor;
            this.listView1.Clear();
            listView1.Columns.Add("Čas");
            listView1.Columns.Add("Stav");
            listView1.Columns.Add("Typ");
            listView1.Columns.Add("Priorita");
            listView1.Columns.Add("Text");
            listView1.Columns.Add("Odpoveď");

            listView1.Columns[0].Width = listView1.Width / 6 - 40;
            listView1.Columns[1].Width = listView1.Width / 6 - 50;
            listView1.Columns[2].Width = listView1.Width / 6 - 50;
            listView1.Columns[3].Width = listView1.Width / 6 - 50;
            listView1.Columns[4].Width = listView1.Width / 6 + 170;
            listView1.Columns[5].Width = listView1.Width / 6 - 150;
            try
            {
                RequestsConnector rc = new RequestsConnector();
                var requests = rc.get().OrderByDescending(m => m.created);

                foreach (var r in requests)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = r.created.ToShortDateString() + " " + r.created.ToShortTimeString();
                    item.SubItems.Add(r.state.ToString());
                    item.SubItems.Add(r.type.ToString());
                    item.SubItems.Add(r.priority.ToString());
                    item.SubItems.Add(r.message);
                    item.SubItems.Add(r.resultMessage != null ? r.resultMessage : "-");

                    this.listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Vyskytla sa chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }




        private void pridaťKategóriuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FormAddCategory fac = new FormAddCategory();
            //fac.FormClosed += zoznamKategóriiVozidielToolStripMenuItem_Click;
            //fac.Show();
        }

        private void pridaťVozidloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddVehicle fav = new FormAddVehicle();
            fav.FormClosed += zoznamVozidielToolStripMenuItem_Click;
            fav.Show();
        }

        private void pridanieJazdyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddJourney faj = new FormAddJourney();
            faj.FormClosed += zoznamJázdToolStripMenuItem_Click;
            faj.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //DriverTable.OdmenyPreVodicov();
            //MessageBox.Show("Platy pre vodičov boli zmenené!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //LoadEmployees();
        }

        private void históriaZmienPlatuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Authorization.Logout();
            System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
            this.Close();
        }

        private void zobraziťSprávyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadMessages();

        }

        private void vytvoriťSprávuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddMessage faj = new FormAddMessage();
            faj.FormClosed += zobraziťSprávyToolStripMenuItem_Click;
            faj.Show();

        }

        private void zobraziťŽiadostiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadRequests();
        }

        private void vytvoriťŽiadosťToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddRequest faj = new FormAddRequest();
            faj.FormClosed += zobraziťŽiadostiToolStripMenuItem_Click;
            faj.Show();
        }
    }


}
