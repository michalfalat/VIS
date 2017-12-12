using Dopravio.Helpers;
using Dopravio.Models;
using Dopravio_api.Models;
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
    public partial class FormAddMessage : Form
    {
        public FormAddMessage()
        {
            ManagersConnector mc = new ManagersConnector();
            InitializeComponent();
            cbManager.DataSource = mc.get();
            cbManager.DisplayMember = "fullName";
            cbManager.ValueMember = "id";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var manager = (Manager)cbManager.SelectedItem;
            var m = new Dopravio_api.Models.Message();
            m.created = DateTime.Now;
            m.text = tbText.Text;
            m.isRead = false;
            m.manager = manager;
            m.dispatcher = null;

            MessagesConnector mc = new MessagesConnector();
            var result = mc.send(m);

            if (result == "\"OK\"")
            {
                this.Close();
            }


        }
    }
}
