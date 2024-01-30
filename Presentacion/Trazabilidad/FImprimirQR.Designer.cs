
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
            this.lbltrabajador = new System.Windows.Forms.Label();
            this.pbQR = new System.Windows.Forms.PictureBox();
            this.cbximpresora = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblcantidad_tikects = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblcolumnas = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudacantidad_filas = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbQR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudacantidad_filas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btngenerar
            // 
            this.btngenerar.BackColor = System.Drawing.Color.Blue;
            this.btngenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btngenerar.Location = new System.Drawing.Point(46, 342);
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
            // lbltrabajador
            // 
            this.lbltrabajador.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltrabajador.Location = new System.Drawing.Point(13, 106);
            this.lbltrabajador.Name = "lbltrabajador";
            this.lbltrabajador.Size = new System.Drawing.Size(240, 30);
            this.lbltrabajador.TabIndex = 96;
            this.lbltrabajador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbQR
            // 
            this.pbQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbQR.Image = global::_3mpacador4.Properties.Resources.qr;
            this.pbQR.Location = new System.Drawing.Point(79, 13);
            this.pbQR.Name = "pbQR";
            this.pbQR.Size = new System.Drawing.Size(114, 90);
            this.pbQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbQR.TabIndex = 94;
            this.pbQR.TabStop = false;
            // 
            // cbximpresora
            // 
            this.cbximpresora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbximpresora.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbximpresora.FormattingEnabled = true;
            this.cbximpresora.Location = new System.Drawing.Point(13, 169);
            this.cbximpresora.Margin = new System.Windows.Forms.Padding(4);
            this.cbximpresora.Name = "cbximpresora";
            this.cbximpresora.Size = new System.Drawing.Size(240, 25);
            this.cbximpresora.TabIndex = 115;
            this.cbximpresora.SelectedValueChanged += new System.EventHandler(this.cbximpresora_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 116;
            this.label1.Text = "IMPRESORA :";
            // 
            // lblcantidad_tikects
            // 
            this.lblcantidad_tikects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblcantidad_tikects.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcantidad_tikects.Location = new System.Drawing.Point(164, 82);
            this.lblcantidad_tikects.Name = "lblcantidad_tikects";
            this.lblcantidad_tikects.Size = new System.Drawing.Size(67, 26);
            this.lblcantidad_tikects.TabIndex = 130;
            this.lblcantidad_tikects.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 17);
            this.label6.TabIndex = 129;
            this.label6.Text = "COLUMNAS POR FILA :";
            // 
            // lblcolumnas
            // 
            this.lblcolumnas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblcolumnas.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcolumnas.Location = new System.Drawing.Point(164, 54);
            this.lblcolumnas.Name = "lblcolumnas";
            this.lblcolumnas.Size = new System.Drawing.Size(67, 26);
            this.lblcolumnas.TabIndex = 128;
            this.lblcolumnas.Text = "4";
            this.lblcolumnas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 17);
            this.label4.TabIndex = 127;
            this.label4.Text = "CANTIDA ETIQUETAS :";
            // 
            // nudacantidad_filas
            // 
            this.nudacantidad_filas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudacantidad_filas.Location = new System.Drawing.Point(164, 22);
            this.nudacantidad_filas.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.nudacantidad_filas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudacantidad_filas.Name = "nudacantidad_filas";
            this.nudacantidad_filas.Size = new System.Drawing.Size(67, 29);
            this.nudacantidad_filas.TabIndex = 126;
            this.nudacantidad_filas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudacantidad_filas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudacantidad_filas.ValueChanged += new System.EventHandler(this.nudacantidad_filas_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 17);
            this.label3.TabIndex = 125;
            this.label3.Text = "FILAS A IMPRIMIR :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudacantidad_filas);
            this.groupBox1.Controls.Add(this.lblcantidad_tikects);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblcolumnas);
            this.groupBox1.Location = new System.Drawing.Point(12, 201);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 121);
            this.groupBox1.TabIndex = 131;
            this.groupBox1.TabStop = false;
            // 
            // FImprimirQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(274, 394);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbximpresora);
            this.Controls.Add(this.pbQR);
            this.Controls.Add(this.lbltrabajador);
            this.Controls.Add(this.btngenerar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FImprimirQR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CODIGO QR";
            this.Load += new System.EventHandler(this.FImprimirQR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbQR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudacantidad_filas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Glass.GlassButton btngenerar;
        private System.Windows.Forms.PictureBox pbQR;
        internal System.Windows.Forms.Label lbltrabajador;
        internal System.Windows.Forms.ComboBox cbximpresora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblcantidad_tikects;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblcolumnas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudacantidad_filas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}