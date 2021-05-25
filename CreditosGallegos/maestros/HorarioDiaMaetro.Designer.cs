
namespace GoldenE.maestros
{
    partial class HorarioDiaMaetro
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
            this.rHoraDiaMaestroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.rHoraDiaMaestroBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rHoraDiaMaestroBindingSource
            // 
            this.rHoraDiaMaestroBindingSource.DataSource = typeof(GoldenE.reporte.rHoraDiaMaestro);
            // 
            // reportViewer2
            // 
            this.reportViewer2.Location = new System.Drawing.Point(127, 66);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(557, 246);
            this.reportViewer2.TabIndex = 1;
            // 
            // HorarioDiaMaetro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer2);
            this.Name = "HorarioDiaMaetro";
            this.Text = "HorarioDiaMaetro";
            this.Load += new System.EventHandler(this.HorarioDiaMaetro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rHoraDiaMaestroBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource rHoraDiaMaestroBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
    }
}