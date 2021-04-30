
namespace GoldenE.alumnos
{
    partial class SeleccionAlumnos
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewCargaAlumno = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMaterno = new System.Windows.Forms.TextBox();
            this.textBoxPaterno = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxSidAlumno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btncbuscar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCargaAlumno)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Buscar Alumno por Kardex o por nombre";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dataGridViewCargaAlumno);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.btncbuscar);
            this.panel1.Location = new System.Drawing.Point(57, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(641, 377);
            this.panel1.TabIndex = 18;
            // 
            // dataGridViewCargaAlumno
            // 
            this.dataGridViewCargaAlumno.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewCargaAlumno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCargaAlumno.Location = new System.Drawing.Point(118, 178);
            this.dataGridViewCargaAlumno.Name = "dataGridViewCargaAlumno";
            this.dataGridViewCargaAlumno.Size = new System.Drawing.Size(399, 150);
            this.dataGridViewCargaAlumno.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxMaterno);
            this.groupBox2.Controls.Add(this.textBoxPaterno);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(315, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 133);
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
            // textBoxMaterno
            // 
            this.textBoxMaterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMaterno.Location = new System.Drawing.Point(34, 83);
            this.textBoxMaterno.Name = "textBoxMaterno";
            this.textBoxMaterno.Size = new System.Drawing.Size(100, 20);
            this.textBoxMaterno.TabIndex = 7;
            this.textBoxMaterno.TextChanged += new System.EventHandler(this.textBoxMaterno_TextChanged);
            // 
            // textBoxPaterno
            // 
            this.textBoxPaterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPaterno.Location = new System.Drawing.Point(34, 55);
            this.textBoxPaterno.Name = "textBoxPaterno";
            this.textBoxPaterno.Size = new System.Drawing.Size(100, 20);
            this.textBoxPaterno.TabIndex = 6;
            this.textBoxPaterno.TextChanged += new System.EventHandler(this.textBoxPaterno_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(35, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
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
            // btncbuscar
            // 
            this.btncbuscar.Location = new System.Drawing.Point(265, 334);
            this.btncbuscar.Name = "btncbuscar";
            this.btncbuscar.Size = new System.Drawing.Size(75, 23);
            this.btncbuscar.TabIndex = 8;
            this.btncbuscar.Text = "Buscar";
            this.btncbuscar.UseVisualStyleBackColor = true;
            this.btncbuscar.Click += new System.EventHandler(this.btncbuscar_Click);
            // 
            // SeleccionAlumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(770, 417);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Name = "SeleccionAlumnos";
            this.Text = "SeleccionAlumnos";
            this.Load += new System.EventHandler(this.SeleccionAlumnos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCargaAlumno)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewCargaAlumno;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMaterno;
        private System.Windows.Forms.TextBox textBoxPaterno;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxSidAlumno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btncbuscar;
    }
}