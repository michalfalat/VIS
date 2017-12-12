using Dopravio.Helpers;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {

            labelMessage.Visible = false;
            this.pictureBox1.Visible = true;
            this.pictureBox1.Refresh();
            Application.DoEvents();
            Task<LoginResponse> task = Task.Run(() => Authorization.Login(tbEmail.Text, tbPassword.Text));
            var result = await task;
            if (result.token != null)
            {
                this.Hide();
                var form2 = new Form1();
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
            else
            {
                this.pictureBox1.Visible = false;
                labelMessage.Visible = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
