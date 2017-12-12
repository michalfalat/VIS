namespace Dopravio
{
    partial class FormAddJourney
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
            this.dateTimePickerOdchod = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.dateTimePickerPrichod = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.Príchod = new System.Windows.Forms.Label();
            this.comboBoxDriver = new System.Windows.Forms.ComboBox();
            this.comboBoxVehicle = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxRoute = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePickerOdchod
            // 
            this.dateTimePickerOdchod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePickerOdchod.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerOdchod.Location = new System.Drawing.Point(198, 121);
            this.dateTimePickerOdchod.Name = "dateTimePickerOdchod";
            this.dateTimePickerOdchod.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerOdchod.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(51, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Názov:";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxName.Location = new System.Drawing.Point(197, 66);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(201, 26);
            this.textBoxName.TabIndex = 2;
            // 
            // dateTimePickerPrichod
            // 
            this.dateTimePickerPrichod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePickerPrichod.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerPrichod.Location = new System.Drawing.Point(198, 171);
            this.dateTimePickerPrichod.Name = "dateTimePickerPrichod";
            this.dateTimePickerPrichod.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerPrichod.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(51, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Odchod:";
            // 
            // Príchod
            // 
            this.Príchod.AutoSize = true;
            this.Príchod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Príchod.Location = new System.Drawing.Point(51, 171);
            this.Príchod.Name = "Príchod";
            this.Príchod.Size = new System.Drawing.Size(61, 20);
            this.Príchod.TabIndex = 1;
            this.Príchod.Text = "Píchod:";
            this.Príchod.Click += new System.EventHandler(this.Príchod_Click);
            // 
            // comboBoxDriver
            // 
            this.comboBoxDriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxDriver.FormattingEnabled = true;
            this.comboBoxDriver.Location = new System.Drawing.Point(198, 219);
            this.comboBoxDriver.Name = "comboBoxDriver";
            this.comboBoxDriver.Size = new System.Drawing.Size(200, 28);
            this.comboBoxDriver.TabIndex = 3;
            // 
            // comboBoxVehicle
            // 
            this.comboBoxVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxVehicle.FormattingEnabled = true;
            this.comboBoxVehicle.Location = new System.Drawing.Point(198, 273);
            this.comboBoxVehicle.Name = "comboBoxVehicle";
            this.comboBoxVehicle.Size = new System.Drawing.Size(200, 28);
            this.comboBoxVehicle.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(51, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Vodič:";
            this.label3.Click += new System.EventHandler(this.Príchod_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(51, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Vozidlo:";
            this.label4.Click += new System.EventHandler(this.Príchod_Click);
            // 
            // comboBoxRoute
            // 
            this.comboBoxRoute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxRoute.FormattingEnabled = true;
            this.comboBoxRoute.Location = new System.Drawing.Point(197, 323);
            this.comboBoxRoute.Name = "comboBoxRoute";
            this.comboBoxRoute.Size = new System.Drawing.Size(200, 28);
            this.comboBoxRoute.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(51, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Trasa:";
            this.label5.Click += new System.EventHandler(this.Príchod_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(307, 425);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "Pridať";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormAddJourney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 508);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxRoute);
            this.Controls.Add(this.comboBoxVehicle);
            this.Controls.Add(this.comboBoxDriver);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Príchod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerPrichod);
            this.Controls.Add(this.dateTimePickerOdchod);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddJourney";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pridať jazdu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerOdchod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.DateTimePicker dateTimePickerPrichod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Príchod;
        private System.Windows.Forms.ComboBox comboBoxDriver;
        private System.Windows.Forms.ComboBox comboBoxVehicle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxRoute;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}