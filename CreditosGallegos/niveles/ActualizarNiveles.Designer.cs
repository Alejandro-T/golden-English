
namespace GoldenE.alumnos
{
    partial class ActualizarNiveles
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
            this.textBoxIdNivel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxBdescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxNid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAdescripcion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.dataGridViewCargaNivel = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCargaNivel)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Buscar nivel por Id o por descripcion";
            // 
            // btncActu
            // 
            this.btncActu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(226)))), ((int)(((byte)(238)))));
            this.btncActu.Location = new System.Drawing.Point(631, 320);
            this.btncActu.Name = "btncActu";
            this.btncActu.Size = new System.Drawing.Size(78, 28);
            this.btncActu.TabIndex = 8;
            this.btncActu.Text = "Actualizar";
            this.btncActu.UseVisualStyleBackColor = false;
            this.btncActu.Click += new System.EventHandler(this.btncActu_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(30, 7);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(35, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Id";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(454, 7);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(82, 17);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "Descripción";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxIdNivel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(8, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 56);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // textBoxIdNivel
            // 
            this.textBoxIdNivel.BackColor = System.Drawing.Color.White;
            this.textBoxIdNivel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxIdNivel.Location = new System.Drawing.Point(15, 21);
            this.textBoxIdNivel.Name = "textBoxIdNivel";
            this.textBoxIdNivel.Size = new System.Drawing.Size(100, 20);
            this.textBoxIdNivel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Id";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxBdescripcion);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(431, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 78);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            // 
            // textBoxBdescripcion
            // 
            this.textBoxBdescripcion.BackColor = System.Drawing.Color.White;
            this.textBoxBdescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxBdescripcion.Location = new System.Drawing.Point(22, 29);
            this.textBoxBdescripcion.Name = "textBoxBdescripcion";
            this.textBoxBdescripcion.Size = new System.Drawing.Size(100, 20);
            this.textBoxBdescripcion.TabIndex = 5;
            this.textBoxBdescripcion.TextChanged += new System.EventHandler(this.textBoxBdescripcion_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Descripción";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxNid);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBoxAdescripcion);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(8, 85);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(341, 284);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            // 
            // textBoxNid
            // 
            this.textBoxNid.BackColor = System.Drawing.Color.White;
            this.textBoxNid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNid.Enabled = false;
            this.textBoxNid.Location = new System.Drawing.Point(62, 33);
            this.textBoxNid.Name = "textBoxNid";
            this.textBoxNid.Size = new System.Drawing.Size(100, 20);
            this.textBoxNid.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Id";
            // 
            // textBoxAdescripcion
            // 
            this.textBoxAdescripcion.BackColor = System.Drawing.Color.White;
            this.textBoxAdescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAdescripcion.Location = new System.Drawing.Point(62, 72);
            this.textBoxAdescripcion.Name = "textBoxAdescripcion";
            this.textBoxAdescripcion.Size = new System.Drawing.Size(100, 20);
            this.textBoxAdescripcion.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(170, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Descripción";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.buttonBuscar);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.dataGridViewCargaNivel);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.btncActu);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(7, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 387);
            this.panel1.TabIndex = 20;
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(226)))), ((int)(((byte)(238)))));
            this.buttonBuscar.Location = new System.Drawing.Point(409, 321);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(78, 28);
            this.buttonBuscar.TabIndex = 22;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = false;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // dataGridViewCargaNivel
            // 
            this.dataGridViewCargaNivel.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewCargaNivel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCargaNivel.Location = new System.Drawing.Point(379, 162);
            this.dataGridViewCargaNivel.Name = "dataGridViewCargaNivel";
            this.dataGridViewCargaNivel.Size = new System.Drawing.Size(362, 150);
            this.dataGridViewCargaNivel.TabIndex = 10;
            this.dataGridViewCargaNivel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCargaAlumno_CellContentClick);
            // 
            // ActualizarNiveles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(852, 446);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ActualizarNiveles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizar Niveles";
            this.Load += new System.EventHandler(this.ActualizarNiveles_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCargaNivel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btncActu;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxIdNivel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxBdescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxAdescripcion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewCargaNivel;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.TextBox textBoxNid;
        private System.Windows.Forms.Label label4;
    }
}