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
    public partial class FormAddRequest : Form
    {
        public FormAddRequest()
        {
            InitializeComponent();
            cbType.DataSource = Enum.GetValues(typeof(RequestType));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Request r = new Request();
            r.created = DateTime.Now;
            r.message = tbText.Text;
            r.priority = (int)nmPriority.Value;
            r.state = RequestState.NEW;
            r.type = (RequestType)cbType.SelectedItem;
            RequestsConnector rc = new RequestsConnector();
            var result = rc.send(r);

            if(result == "\"OK\"")
            {
                this.Close();
            }

        }
    }
}
