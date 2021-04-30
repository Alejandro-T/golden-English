
namespace GoldenE.alumnos
{
    partial class ActualizarAlumnos
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
            this.label3 = new System.Windows.Forms.Label();
            this.btncActu = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxSidAlumno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxBMaterno = new System.Windows.Forms.TextBox();
            this.textBoxBPaterno = new System.Windows.Forms.TextBox();
            this.textBoxBnombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBoxGeneros = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxAdireccion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxAtelefono = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxAmaterno = new System.Windows.Forms.TextBox();
            this.textBoxApaterno = new System.Windows.Forms.TextBox();
            this.textBoxAnombre = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.dataGridViewCargaAlumno = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCargaAlumno)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Buscar Alumno por Kardex o por nombre";
            // 
            // btncActu
            // 
            this.btncActu.Location = new System.Drawing.Point(557, 323);
            this.btncActu.Name = "btncActu";
            this.btncActu.Size = new System.Drawing.Size(75, 23);
            this.btncActu.TabIndex = 8;
            this.btncActu.Text = "Actualizar";
            this.btncActu.UseVisualStyleBackColor = true;
            this.btncActu.Click += new System.EventHandler(this.btncActu_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(59, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(58, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "kardex";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(375, 16);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(63, 17);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "Nombre";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxSidAlumno);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(37, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 56);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // textBoxSidAlumno
            // 
            this.textBoxSidAlumno.BackColor = System.Drawing.Color.White;
            this.textBoxSidAlumno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSidAlumno.Location = new System.Drawing.Point(14, 21);
            this.textBoxSidAlumno.Name = "textBoxSidAlumno";
            this.textBoxSidAlumno.Size = new System.Drawing.Size(100, 20);
            this.textBoxSidAlumno.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Kardex";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxBMaterno);
            this.groupBox2.Controls.Add(this.textBoxBPaterno);
            this.groupBox2.Controls.Add(this.textBoxBnombre);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(315, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 115);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(143, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Materno";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(143, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Paterno";
            // 
            // textBoxBMaterno
            // 
            this.textBoxBMaterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxBMaterno.Location = new System.Drawing.Point(34, 83);
            this.textBoxBMaterno.Name = "textBoxBMaterno";
            this.textBoxBMaterno.Size = new System.Drawing.Size(100, 20);
            this.textBoxBMaterno.TabIndex = 7;
            this.textBoxBMaterno.TextChanged += new System.EventHandler(this.textBoxBMaterno_TextChanged);
            // 
            // textBoxBPaterno
            // 
            this.textBoxBPaterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxBPaterno.Location = new System.Drawing.Point(34, 55);
            this.textBoxBPaterno.Name = "textBoxBPaterno";
            this.textBoxBPaterno.Size = new System.Drawing.Size(100, 20);
            this.textBoxBPaterno.TabIndex = 6;
            this.textBoxBPaterno.TextChanged += new System.EventHandler(this.textBoxBPaterno_TextChanged);
            // 
            // textBoxBnombre
            // 
            this.textBoxBnombre.BackColor = System.Drawing.Color.White;
            this.textBoxBnombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxBnombre.Location = new System.Drawing.Point(35, 28);
            this.textBoxBnombre.Name = "textBoxBnombre";
            this.textBoxBnombre.Size = new System.Drawing.Size(100, 20);
            this.textBoxBnombre.TabIndex = 5;
            this.textBoxBnombre.TextChanged += new System.EventHandler(this.textBoxBnombre_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Nombre";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.comboBoxGeneros);
            this.groupBox3.Controls.Add(this.dateTimePicker1);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.textBoxAdireccion);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.textBoxAtelefono);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBoxAmaterno);
            this.groupBox3.Controls.Add(this.textBoxApaterno);
            this.groupBox3.Controls.Add(this.textBoxAnombre);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(37, 111);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(257, 251);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(178, 222);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Genero";
            // 
            // comboBoxGeneros
            // 
            this.comboBoxGeneros.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxGeneros.FormattingEnabled = true;
            this.comboBoxGeneros.Location = new System.Drawing.Point(41, 214);
            this.comboBoxGeneros.Name = "comboBoxGeneros";
            this.comboBoxGeneros.Size = new System.Drawing.Size(121, 21);
            this.comboBoxGeneros.TabIndex = 26;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(54, 176);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(108, 20);
            this.dateTimePicker1.TabIndex = 25;
            this.dateTimePicker1.Value = new System.DateTime(2020, 12, 9, 0, 0, 0, 0);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(170, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Direccion";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(170, 192);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Nacimiento";
            // 
            // textBoxAdireccion
            // 
            this.textBoxAdireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAdireccion.Location = new System.Drawing.Point(61, 141);
            this.textBoxAdireccion.Name = "textBoxAdireccion";
            this.textBoxAdireccion.Size = new System.Drawing.Size(100, 20);
            this.textBoxAdireccion.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(170, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Telefono";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(170, 171);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Fecha de";
            // 
            // textBoxAtelefono
            // 
            this.textBoxAtelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAtelefono.Location = new System.Drawing.Point(61, 106);
            this.textBoxAtelefono.Name = "textBoxAtelefono";
            this.textBoxAtelefono.Size = new System.Drawing.Size(100, 20);
            this.textBoxAtelefono.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(170, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Materno";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(170, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Paterno";
            // 
            // textBoxAmaterno
            // 
            this.textBoxAmaterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAmaterno.Location = new System.Drawing.Point(61, 80);
            this.textBoxAmaterno.Name = "textBoxAmaterno";
            this.textBoxAmaterno.Size = new System.Drawing.Size(100, 20);
            this.textBoxAmaterno.TabIndex = 7;
            // 
            // textBoxApaterno
            // 
            this.textBoxApaterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxApaterno.Location = new System.Drawing.Point(62, 52);
            this.textBoxApaterno.Name = "textBoxApaterno";
            this.textBoxApaterno.Size = new System.Drawing.Size(100, 20);
            this.textBoxApaterno.TabIndex = 6;
            // 
            // textBoxAnombre
            // 
            this.textBoxAnombre.BackColor = System.Drawing.Color.White;
            this.textBoxAnombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAnombre.Location = new System.Drawing.Point(62, 25);
            this.textBoxAnombre.Name = "textBoxAnombre";
            this.textBoxAnombre.Size = new System.Drawing.Size(100, 20);
            this.textBoxAnombre.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(170, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Nombre";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.buttonBuscar);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.dataGridViewCargaAlumno);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.btncActu);
            this.panel1.Location = new System.Drawing.Point(58, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 457);
            this.panel1.TabIndex = 20;
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(384, 323);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(75, 23);
            this.buttonBuscar.TabIndex = 22;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // dataGridViewCargaAlumno
            // 
            this.dataGridViewCargaAlumno.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewCargaAlumno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCargaAlumno.Location = new System.Drawing.Point(311, 160);
            this.dataGridViewCargaAlumno.Name = "dataGridViewCargaAlumno";
            this.dataGridViewCargaAlumno.Size = new System.Drawing.Size(376, 150);
            this.dataGridViewCargaAlumno.TabIndex = 10;
            this.dataGridViewCargaAlumno.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCargaAlumno_CellContentClick);
            // 
            // ActualizarAlumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(806, 491);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Name = "ActualizarAlumnos";
            this.Text = "ActualizarAlumnos";
            this.Load += new System.EventHandler(this.ActualizarAlumnos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCargaAlumno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btncActu;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxSidAlumno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxBMaterno;
        private System.Windows.Forms.TextBox textBoxBPaterno;
        private System.Windows.Forms.TextBox textBoxBnombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxAdireccion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxAtelefono;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxAmaterno;
        private System.Windows.Forms.TextBox textBoxApaterno;
        private System.Windows.Forms.TextBox textBoxAnombre;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewCargaAlumno;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBoxGeneros;
        private System.Windows.Forms.Button buttonBuscar;
    }
}