namespace Dopravio
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listView1 = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cestovnýPoriadokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoznamJázdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pridanieJazdyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoznamTrásToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pridaťTrasuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vozidláToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoznamVozidielToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pridaťVozidloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamestnanciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoznamZamestnancovToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pridaťZamestnancaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.žiadostiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zobraziťŽiadostiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vytvoriťŽiadosťToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.správyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zobraziťSprávyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vytvoriťSprávuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.osobnýProfilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editovaťToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vymazaťToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(40, 186);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(741, 401);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cestovnýPoriadokToolStripMenuItem,
            this.vozidláToolStripMenuItem,
            this.zamestnanciToolStripMenuItem,
            this.žiadostiToolStripMenuItem,
            this.správyToolStripMenuItem,
            this.profilToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(818, 29);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cestovnýPoriadokToolStripMenuItem
            // 
            this.cestovnýPoriadokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoznamJázdToolStripMenuItem,
            this.pridanieJazdyToolStripMenuItem,
            this.zoznamTrásToolStripMenuItem,
            this.pridaťTrasuToolStripMenuItem});
            this.cestovnýPoriadokToolStripMenuItem.Name = "cestovnýPoriadokToolStripMenuItem";
            this.cestovnýPoriadokToolStripMenuItem.Size = new System.Drawing.Size(152, 25);
            this.cestovnýPoriadokToolStripMenuItem.Text = "Cestovný poriadok";
            // 
            // zoznamJázdToolStripMenuItem
            // 
            this.zoznamJázdToolStripMenuItem.Name = "zoznamJázdToolStripMenuItem";
            this.zoznamJázdToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.zoznamJázdToolStripMenuItem.Text = "Zoznam spojov";
            this.zoznamJázdToolStripMenuItem.Click += new System.EventHandler(this.zoznamJázdToolStripMenuItem_Click);
            // 
            // pridanieJazdyToolStripMenuItem
            // 
            this.pridanieJazdyToolStripMenuItem.Enabled = false;
            this.pridanieJazdyToolStripMenuItem.Name = "pridanieJazdyToolStripMenuItem";
            this.pridanieJazdyToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.pridanieJazdyToolStripMenuItem.Text = "Pridať spoj";
            this.pridanieJazdyToolStripMenuItem.Click += new System.EventHandler(this.pridanieJazdyToolStripMenuItem_Click);
            // 
            // zoznamTrásToolStripMenuItem
            // 
            this.zoznamTrásToolStripMenuItem.Name = "zoznamTrásToolStripMenuItem";
            this.zoznamTrásToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.zoznamTrásToolStripMenuItem.Text = "Zoznam trás";
            this.zoznamTrásToolStripMenuItem.Click += new System.EventHandler(this.zoznamTrásToolStripMenuItem_Click);
            // 
            // pridaťTrasuToolStripMenuItem
            // 
            this.pridaťTrasuToolStripMenuItem.Enabled = false;
            this.pridaťTrasuToolStripMenuItem.Name = "pridaťTrasuToolStripMenuItem";
            this.pridaťTrasuToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.pridaťTrasuToolStripMenuItem.Text = "Pridať trasu";
            // 
            // vozidláToolStripMenuItem
            // 
            this.vozidláToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoznamVozidielToolStripMenuItem,
            this.pridaťVozidloToolStripMenuItem});
            this.vozidláToolStripMenuItem.Name = "vozidláToolStripMenuItem";
            this.vozidláToolStripMenuItem.Size = new System.Drawing.Size(72, 25);
            this.vozidláToolStripMenuItem.Text = "Vozidlá";
            // 
            // zoznamVozidielToolStripMenuItem
            // 
            this.zoznamVozidielToolStripMenuItem.Name = "zoznamVozidielToolStripMenuItem";
            this.zoznamVozidielToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.zoznamVozidielToolStripMenuItem.Text = "Zoznam vozidiel";
            this.zoznamVozidielToolStripMenuItem.Click += new System.EventHandler(this.zoznamVozidielToolStripMenuItem_Click);
            // 
            // pridaťVozidloToolStripMenuItem
            // 
            this.pridaťVozidloToolStripMenuItem.Name = "pridaťVozidloToolStripMenuItem";
            this.pridaťVozidloToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.pridaťVozidloToolStripMenuItem.Text = "Pridať vozidlo";
            this.pridaťVozidloToolStripMenuItem.Click += new System.EventHandler(this.pridaťVozidloToolStripMenuItem_Click);
            // 
            // zamestnanciToolStripMenuItem
            // 
            this.zamestnanciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoznamZamestnancovToolStripMenuItem,
            this.pridaťZamestnancaToolStripMenuItem});
            this.zamestnanciToolStripMenuItem.Name = "zamestnanciToolStripMenuItem";
            this.zamestnanciToolStripMenuItem.Size = new System.Drawing.Size(110, 25);
            this.zamestnanciToolStripMenuItem.Text = "Zamestnanci";
            // 
            // zoznamZamestnancovToolStripMenuItem
            // 
            this.zoznamZamestnancovToolStripMenuItem.Name = "zoznamZamestnancovToolStripMenuItem";
            this.zoznamZamestnancovToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
            this.zoznamZamestnancovToolStripMenuItem.Text = "Zoznam zamestnancov";
            this.zoznamZamestnancovToolStripMenuItem.Click += new System.EventHandler(this.zoznamZamestnancovToolStripMenuItem_Click);
            // 
            // pridaťZamestnancaToolStripMenuItem
            // 
            this.pridaťZamestnancaToolStripMenuItem.Enabled = false;
            this.pridaťZamestnancaToolStripMenuItem.Name = "pridaťZamestnancaToolStripMenuItem";
            this.pridaťZamestnancaToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
            this.pridaťZamestnancaToolStripMenuItem.Text = "Pridať zamestnanca";
            // 
            // žiadostiToolStripMenuItem
            // 
            this.žiadostiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zobraziťŽiadostiToolStripMenuItem,
            this.vytvoriťŽiadosťToolStripMenuItem});
            this.žiadostiToolStripMenuItem.Name = "žiadostiToolStripMenuItem";
            this.žiadostiToolStripMenuItem.Size = new System.Drawing.Size(77, 25);
            this.žiadostiToolStripMenuItem.Text = "Žiadosti";
            // 
            // zobraziťŽiadostiToolStripMenuItem
            // 
            this.zobraziťŽiadostiToolStripMenuItem.Name = "zobraziťŽiadostiToolStripMenuItem";
            this.zobraziťŽiadostiToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.zobraziťŽiadostiToolStripMenuItem.Text = "Zobraziť žiadosti";
            this.zobraziťŽiadostiToolStripMenuItem.Click += new System.EventHandler(this.zobraziťŽiadostiToolStripMenuItem_Click);
            // 
            // vytvoriťŽiadosťToolStripMenuItem
            // 
            this.vytvoriťŽiadosťToolStripMenuItem.Name = "vytvoriťŽiadosťToolStripMenuItem";
            this.vytvoriťŽiadosťToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.vytvoriťŽiadosťToolStripMenuItem.Text = "Vytvoriť žiadosť";
            this.vytvoriťŽiadosťToolStripMenuItem.Click += new System.EventHandler(this.vytvoriťŽiadosťToolStripMenuItem_Click);
            // 
            // správyToolStripMenuItem
            // 
            this.správyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zobraziťSprávyToolStripMenuItem,
            this.vytvoriťSprávuToolStripMenuItem});
            this.správyToolStripMenuItem.Name = "správyToolStripMenuItem";
            this.správyToolStripMenuItem.Size = new System.Drawing.Size(70, 25);
            this.správyToolStripMenuItem.Text = "Správy";
            // 
            // zobraziťSprávyToolStripMenuItem
            // 
            this.zobraziťSprávyToolStripMenuItem.Name = "zobraziťSprávyToolStripMenuItem";
            this.zobraziťSprávyToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.zobraziťSprávyToolStripMenuItem.Text = "Zobraziť správy";
            this.zobraziťSprávyToolStripMenuItem.Click += new System.EventHandler(this.zobraziťSprávyToolStripMenuItem_Click);
            // 
            // vytvoriťSprávuToolStripMenuItem
            // 
            this.vytvoriťSprávuToolStripMenuItem.Name = "vytvoriťSprávuToolStripMenuItem";
            this.vytvoriťSprávuToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.vytvoriťSprávuToolStripMenuItem.Text = "Vytvoriť správu";
            this.vytvoriťSprávuToolStripMenuItem.Click += new System.EventHandler(this.vytvoriťSprávuToolStripMenuItem_Click);
            // 
            // profilToolStripMenuItem
            // 
            this.profilToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.profilToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.osobnýProfilToolStripMenuItem,
            this.LogoutToolStripMenuItem});
            this.profilToolStripMenuItem.Name = "profilToolStripMenuItem";
            this.profilToolStripMenuItem.Size = new System.Drawing.Size(59, 25);
            this.profilToolStripMenuItem.Text = "Profil";
            // 
            // osobnýProfilToolStripMenuItem
            // 
            this.osobnýProfilToolStripMenuItem.Enabled = false;
            this.osobnýProfilToolStripMenuItem.Name = "osobnýProfilToolStripMenuItem";
            this.osobnýProfilToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.osobnýProfilToolStripMenuItem.Text = "Osobný profil";
            // 
            // LogoutToolStripMenuItem
            // 
            this.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem";
            this.LogoutToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.LogoutToolStripMenuItem.Text = "Odhlásiť";
            this.LogoutToolStripMenuItem.Click += new System.EventHandler(this.históriaZmienPlatuToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editovaťToolStripMenuItem,
            this.vymazaťToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(121, 48);
            // 
            // editovaťToolStripMenuItem
            // 
            this.editovaťToolStripMenuItem.Name = "editovaťToolStripMenuItem";
            this.editovaťToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.editovaťToolStripMenuItem.Text = "Detail";
            this.editovaťToolStripMenuItem.Click += new System.EventHandler(this.editovaťToolStripMenuItem_Click);
            // 
            // vymazaťToolStripMenuItem
            // 
            this.vymazaťToolStripMenuItem.Name = "vymazaťToolStripMenuItem";
            this.vymazaťToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.vymazaťToolStripMenuItem.Text = "Vymazať";
            this.vymazaťToolStripMenuItem.Click += new System.EventHandler(this.vymazaťToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(661, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 46);
            this.button2.TabIndex = 7;
            this.button2.Text = "Detail";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button3.Location = new System.Drawing.Point(661, 107);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 46);
            this.button3.TabIndex = 7;
            this.button3.Text = "Vymazať";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 611);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dopravný podnik";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem zamestnanciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoznamZamestnancovToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pridaťZamestnancaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vozidláToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoznamVozidielToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pridaťVozidloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cestovnýPoriadokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoznamJázdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pridanieJazdyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoznamTrásToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem osobnýProfilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LogoutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editovaťToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vymazaťToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem žiadostiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem správyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pridaťTrasuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zobraziťŽiadostiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vytvoriťŽiadosťToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zobraziťSprávyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vytvoriťSprávuToolStripMenuItem;
    }
}

