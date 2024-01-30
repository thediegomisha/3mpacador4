
namespace _3mpacador4.Presentacion.Trazabilidad
{
    partial class FVisorPDF
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
            this.pvvisor = new Spire.PdfViewer.Forms.PdfViewer();
            this.SuspendLayout();
            // 
            // pvvisor
            // 
            this.pvvisor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pvvisor.FindTextHighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(153)))), ((int)(((byte)(193)))), ((int)(((byte)(218)))));
            this.pvvisor.FormFillEnabled = false;
            this.pvvisor.IgnoreCase = false;
            this.pvvisor.IsToolBarVisible = true;
            this.pvvisor.Location = new System.Drawing.Point(0, 0);
            this.pvvisor.MultiPagesThreshold = 60;
            this.pvvisor.Name = "pvvisor";
            this.pvvisor.OnRenderPageExceptionEvent = null;
            this.pvvisor.Size = new System.Drawing.Size(1073, 612);
            this.pvvisor.TabIndex = 0;
            this.pvvisor.Text = "pdfViewer1";
            this.pvvisor.Threshold = 60;
            this.pvvisor.ViewerBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            // 
            // FVisorPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 612);
            this.Controls.Add(this.pvvisor);
            this.Name = "FVisorPDF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VISOR PDF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FVisorPDF_FormClosing);
            this.Load += new System.EventHandler(this.FVisorPDF_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Spire.PdfViewer.Forms.PdfViewer pvvisor;
    }
}