
namespace GoldenE.maestros
{
    partial class cargaravance
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxKardexAlumno = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxMaterno = new System.Windows.Forms.TextBox();
            this.textBoxPaterno = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(12, 79);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(776, 359);
            this.reportViewer1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Kardex del alumno";
            // 
            // textBoxKardexAlumno
            // 
            this.textBoxKardexAlumno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxKardexAlumno.Location = new System.Drawing.Point(154, 31);
            this.textBoxKardexAlumno.Name = "textBoxKardexAlumno";
            this.textBoxKardexAlumno.Size = new System.Drawing.Size(100, 13);
            this.textBoxKardexAlumno.TabIndex = 9;
            this.textBoxKardexAlumno.Leave += new System.EventHandler(this.textBoxKardexAlumno_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxMaterno);
            this.groupBox2.Controls.Add(this.textBoxPaterno);
            this.groupBox2.Controls.Add(this.textBoxNombre);
            this.groupBox2.Location = new System.Drawing.Point(309, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(458, 69);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Del Alumno";
            // 
            // textBoxMaterno
            // 
            this.textBoxMaterno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMaterno.Enabled = false;
            this.textBoxMaterno.Location = new System.Drawing.Point(338, 31);
            this.textBoxMaterno.Name = "textBoxMaterno";
            this.textBoxMaterno.Size = new System.Drawing.Size(100, 13);
            this.textBoxMaterno.TabIndex = 37;
            // 
            // textBoxPaterno
            // 
            this.textBoxPaterno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPaterno.Enabled = false;
            this.textBoxPaterno.Location = new System.Drawing.Point(185, 31);
            this.textBoxPaterno.Name = "textBoxPaterno";
            this.textBoxPaterno.Size = new System.Drawing.Size(100, 13);
            this.textBoxPaterno.TabIndex = 36;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNombre.Enabled = false;
            this.textBoxNombre.Location = new System.Drawing.Point(59, 31);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(100, 13);
            this.textBoxNombre.TabIndex = 35;
            // 
            // cargaravance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxKardexAlumno);
            this.Controls.Add(this.reportViewer1);
            this.Name = "cargaravance";
            this.Text = "cargaravance";
            this.Load += new System.EventHandler(this.cargaravance_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxKardexAlumno;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxMaterno;
        private System.Windows.Forms.TextBox textBoxPaterno;
        private System.Windows.Forms.TextBox textBoxNombre;
    }
}