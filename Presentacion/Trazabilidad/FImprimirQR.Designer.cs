
namespace _3mpacador4.Presentacion.Trazabilidad
{
    partial class FImprimirQR
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
            this.btngenerar = new Glass.GlassButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudcantidad = new System.Windows.Forms.NumericUpDown();
            this.lbltrabajador = new System.Windows.Forms.Label();
            this.pbQR = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudcantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQR)).BeginInit();
            this.SuspendLayout();
            // 
            // btngenerar
            // 
            this.btngenerar.BackColor = System.Drawing.Color.Blue;
            this.btngenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btngenerar.Location = new System.Drawing.Point(13, 208);
            this.btngenerar.Margin = new System.Windows.Forms.Padding(4);
            this.btngenerar.Name = "btngenerar";
            this.btngenerar.OuterBorderColor = System.Drawing.Color.Blue;
            this.btngenerar.ShineColor = System.Drawing.Color.Navy;
            this.btngenerar.Size = new System.Drawing.Size(160, 40);
            this.btngenerar.TabIndex = 89;
            this.btngenerar.Text = "GENERAR QR";
            this.btngenerar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btngenerar.Click += new System.EventHandler(this.btngenerar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudcantidad);
            this.groupBox1.Location = new System.Drawing.Point(13, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 62);
            this.groupBox1.TabIndex = 93;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "N° ETIQUETAS";
            // 
            // nudcantidad
            // 
            this.nudcantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudcantidad.Location = new System.Drawing.Point(24, 18);
            this.nudcantidad.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudcantidad.Name = "nudcantidad";
            this.nudcantidad.Size = new System.Drawing.Size(114, 35);
            this.nudcantidad.TabIndex = 0;
            this.nudcantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbltrabajador
            // 
            this.lbltrabajador.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltrabajador.Location = new System.Drawing.Point(13, 106);
            this.lbltrabajador.Name = "lbltrabajador";
            this.lbltrabajador.Size = new System.Drawing.Size(160, 30);
            this.lbltrabajador.TabIndex = 96;
            this.lbltrabajador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbQR
            // 
            this.pbQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbQR.Image = global::_3mpacador4.Properties.Resources.qr;
            this.pbQR.Location = new System.Drawing.Point(37, 12);
            this.pbQR.Name = "pbQR";
            this.pbQR.Size = new System.Drawing.Size(114, 90);
            this.pbQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbQR.TabIndex = 94;
            this.pbQR.TabStop = false;
            // 
            // FImprimirQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(187, 257);
            this.Controls.Add(this.pbQR);
            this.Controls.Add(this.lbltrabajador);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btngenerar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FImprimirQR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CODIGO QR";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudcantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Glass.GlassButton btngenerar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudcantidad;
        private System.Windows.Forms.PictureBox pbQR;
        internal System.Windows.Forms.Label lbltrabajador;
    }
}