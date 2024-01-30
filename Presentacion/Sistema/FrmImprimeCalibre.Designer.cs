
namespace _3mpacador4.Presentacion.Sistema
{
    partial class FrmImprimeCalibre
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbximpresora = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnimprimir = new Glass.GlassButton();
            this.btncancelar = new Glass.GlassButton();
            this.datalistado = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nudcalibre = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudacantidad_filas = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblcantidad_tikects = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblcolumnas = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datalistado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudcalibre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudacantidad_filas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbximpresora
            // 
            this.cbximpresora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbximpresora.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbximpresora.FormattingEnabled = true;
            this.cbximpresora.Location = new System.Drawing.Point(100, 32);
            this.cbximpresora.Margin = new System.Windows.Forms.Padding(4);
            this.cbximpresora.Name = "cbximpresora";
            this.cbximpresora.Size = new System.Drawing.Size(282, 25);
            this.cbximpresora.TabIndex = 114;
            this.cbximpresora.SelectedValueChanged += new System.EventHandler(this.cbximpresora_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 113;
            this.label1.Text = "IMPRESORA :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnimprimir);
            this.groupBox2.Controls.Add(this.btncancelar);
            this.groupBox2.Location = new System.Drawing.Point(8, 539);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 76);
            this.groupBox2.TabIndex = 115;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "OPERACIONES";
            // 
            // btnimprimir
            // 
            this.btnimprimir.BackColor = System.Drawing.Color.Blue;
            this.btnimprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnimprimir.Image = global::_3mpacador4.Properties.Resources.save;
            this.btnimprimir.Location = new System.Drawing.Point(9, 26);
            this.btnimprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnimprimir.Name = "btnimprimir";
            this.btnimprimir.OuterBorderColor = System.Drawing.Color.Blue;
            this.btnimprimir.ShineColor = System.Drawing.Color.Navy;
            this.btnimprimir.Size = new System.Drawing.Size(160, 40);
            this.btnimprimir.TabIndex = 87;
            this.btnimprimir.Text = "IMPRIMIR";
            this.btnimprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnimprimir.Click += new System.EventHandler(this.btnimprimir_Click);
            // 
            // btncancelar
            // 
            this.btncancelar.BackColor = System.Drawing.Color.Red;
            this.btncancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancelar.GlowColor = System.Drawing.Color.Empty;
            this.btncancelar.Image = global::_3mpacador4.Properties.Resources.cancel;
            this.btncancelar.Location = new System.Drawing.Point(242, 26);
            this.btncancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.OuterBorderColor = System.Drawing.Color.Red;
            this.btncancelar.ShineColor = System.Drawing.Color.RoyalBlue;
            this.btncancelar.Size = new System.Drawing.Size(136, 40);
            this.btncancelar.TabIndex = 88;
            this.btncancelar.Text = "CANCELAR";
            this.btncancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // datalistado
            // 
            this.datalistado.AllowUserToAddRows = false;
            this.datalistado.AllowUserToDeleteRows = false;
            this.datalistado.BackgroundColor = System.Drawing.Color.White;
            this.datalistado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datalistado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datalistado.ColumnHeadersHeight = 30;
            this.datalistado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3});
            this.datalistado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datalistado.Location = new System.Drawing.Point(3, 16);
            this.datalistado.Name = "datalistado";
            this.datalistado.ReadOnly = true;
            this.datalistado.RowHeadersVisible = false;
            this.datalistado.RowHeadersWidth = 51;
            this.datalistado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datalistado.Size = new System.Drawing.Size(383, 343);
            this.datalistado.TabIndex = 116;
            // 
            // Column1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "CALIBRE";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column3
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "ULTIMO N°";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // nudcalibre
            // 
            this.nudcalibre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudcalibre.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudcalibre.Location = new System.Drawing.Point(25, 25);
            this.nudcalibre.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nudcalibre.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudcalibre.Name = "nudcalibre";
            this.nudcalibre.Size = new System.Drawing.Size(73, 31);
            this.nudcalibre.TabIndex = 118;
            this.nudcalibre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudcalibre.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(182, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 17);
            this.label3.TabIndex = 119;
            this.label3.Text = "FILAS A IMPRIMIR :";
            // 
            // nudacantidad_filas
            // 
            this.nudacantidad_filas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudacantidad_filas.Location = new System.Drawing.Point(315, 64);
            this.nudacantidad_filas.Maximum = new decimal(new int[] {
            500,
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
            this.nudacantidad_filas.TabIndex = 120;
            this.nudacantidad_filas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudacantidad_filas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudacantidad_filas.ValueChanged += new System.EventHandler(this.nudacantidad_filas_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.datalistado);
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 362);
            this.groupBox1.TabIndex = 121;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LISTA DE CALIBRES";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.lblcantidad_tikects);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.lblcolumnas);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cbximpresora);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.nudacantidad_filas);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(8, 380);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(389, 153);
            this.groupBox3.TabIndex = 122;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DATOS";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.nudcalibre);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(7, 71);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(119, 74);
            this.groupBox4.TabIndex = 125;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "CALIBRE";
            // 
            // lblcantidad_tikects
            // 
            this.lblcantidad_tikects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblcantidad_tikects.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcantidad_tikects.Location = new System.Drawing.Point(315, 124);
            this.lblcantidad_tikects.Name = "lblcantidad_tikects";
            this.lblcantidad_tikects.Size = new System.Drawing.Size(67, 26);
            this.lblcantidad_tikects.TabIndex = 124;
            this.lblcantidad_tikects.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(160, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 17);
            this.label6.TabIndex = 123;
            this.label6.Text = "COLUMNAS POR FILA :";
            // 
            // lblcolumnas
            // 
            this.lblcolumnas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblcolumnas.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcolumnas.Location = new System.Drawing.Point(315, 96);
            this.lblcolumnas.Name = "lblcolumnas";
            this.lblcolumnas.Size = new System.Drawing.Size(67, 26);
            this.lblcolumnas.TabIndex = 122;
            this.lblcolumnas.Text = "4";
            this.lblcolumnas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(181, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 17);
            this.label4.TabIndex = 121;
            this.label4.Text = "CANTIDA TIKECTS :";
            // 
            // FrmImprimeCalibre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 627);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmImprimeCalibre";
            this.Load += new System.EventHandler(this.FrmImprimeCalibre_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datalistado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudcalibre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudacantidad_filas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ComboBox cbximpresora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Glass.GlassButton btnimprimir;
        private Glass.GlassButton btncancelar;
        public System.Windows.Forms.DataGridView datalistado;
        private System.Windows.Forms.NumericUpDown nudcalibre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudacantidad_filas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblcantidad_tikects;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblcolumnas;
        private System.Windows.Forms.Label label4;
    }
}