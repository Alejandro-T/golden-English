
namespace GoldenE.niveles
{
    partial class SeleccionarSalon
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
            this.dataGridViewCargaSalon = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxSalonName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxSidSalon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btncbuscar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCargaSalon)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(309, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Seleccionar Salón";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.dataGridViewCargaSalon);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.btncbuscar);
            this.panel1.Location = new System.Drawing.Point(59, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 349);
            this.panel1.TabIndex = 20;
            // 
            // dataGridViewCargaSalon
            // 
            this.dataGridViewCargaSalon.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewCargaSalon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCargaSalon.Location = new System.Drawing.Point(110, 140);
            this.dataGridViewCargaSalon.Name = "dataGridViewCargaSalon";
            this.dataGridViewCargaSalon.Size = new System.Drawing.Size(399, 150);
            this.dataGridViewCargaSalon.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxSalonName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(307, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 78);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            // 
            // textBoxSalonName
            // 
            this.textBoxSalonName.BackColor = System.Drawing.Color.White;
            this.textBoxSalonName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSalonName.Location = new System.Drawing.Point(35, 28);
            this.textBoxSalonName.Name = "textBoxSalonName";
            this.textBoxSalonName.Size = new System.Drawing.Size(100, 20);
            this.textBoxSalonName.TabIndex = 5;
            this.textBoxSalonName.TextChanged += new System.EventHandler(this.textBoxSalonName_TextChanged);
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
            this.groupBox1.Controls.Add(this.textBoxSidSalon);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(29, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 56);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // textBoxSidSalon
            // 
            this.textBoxSidSalon.BackColor = System.Drawing.Color.White;
            this.textBoxSidSalon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSidSalon.Location = new System.Drawing.Point(14, 21);
            this.textBoxSidSalon.Name = "textBoxSidSalon";
            this.textBoxSidSalon.Size = new System.Drawing.Size(100, 20);
            this.textBoxSidSalon.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "id_salon";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(367, 16);
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
            this.checkBox1.Location = new System.Drawing.Point(51, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(66, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Id_salon";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btncbuscar
            // 
            this.btncbuscar.Location = new System.Drawing.Point(257, 296);
            this.btncbuscar.Name = "btncbuscar";
            this.btncbuscar.Size = new System.Drawing.Size(75, 23);
            this.btncbuscar.TabIndex = 8;
            this.btncbuscar.Text = "Buscar";
            this.btncbuscar.UseVisualStyleBackColor = true;
            this.btncbuscar.Click += new System.EventHandler(this.btncbuscar_Click);
            // 
            // SeleccionarSalon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(726, 423);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SeleccionarSalon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeleccionarSalon";
            this.Load += new System.EventHandler(this.SeleccionarSalon_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCargaSalon)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridViewCargaSalon;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxSalonName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxSidSalon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btncbuscar;
    }
}