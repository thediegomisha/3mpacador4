
namespace _3mpacador4.Presentacion.Trazabilidad
{
    partial class FMuestreo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btncancelar = new Glass.GlassButton();
            this.btnmostrar = new Glass.GlassButton();
            this.cbxmes = new System.Windows.Forms.ComboBox();
            this.nudanio = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dgvlista = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column47 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column48 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column49 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudanio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlista)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btncancelar);
            this.groupBox1.Controls.Add(this.btnmostrar);
            this.groupBox1.Controls.Add(this.cbxmes);
            this.groupBox1.Controls.Add(this.nudanio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(971, 78);
            this.groupBox1.TabIndex = 131;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATOS";
            // 
            // btncancelar
            // 
            this.btncancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btncancelar.BackColor = System.Drawing.Color.Red;
            this.btncancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancelar.GlowColor = System.Drawing.Color.Empty;
            this.btncancelar.Image = global::_3mpacador4.Properties.Resources.cancel;
            this.btncancelar.Location = new System.Drawing.Point(536, 19);
            this.btncancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.OuterBorderColor = System.Drawing.Color.Red;
            this.btncancelar.ShineColor = System.Drawing.Color.RoyalBlue;
            this.btncancelar.Size = new System.Drawing.Size(124, 40);
            this.btncancelar.TabIndex = 151;
            this.btncancelar.Text = "CANCELAR";
            this.btncancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // btnmostrar
            // 
            this.btnmostrar.BackColor = System.Drawing.Color.Blue;
            this.btnmostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnmostrar.Image = global::_3mpacador4.Properties.Resources.buscar;
            this.btnmostrar.Location = new System.Drawing.Point(404, 19);
            this.btnmostrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnmostrar.Name = "btnmostrar";
            this.btnmostrar.OuterBorderColor = System.Drawing.Color.Blue;
            this.btnmostrar.ShineColor = System.Drawing.Color.Navy;
            this.btnmostrar.Size = new System.Drawing.Size(124, 40);
            this.btnmostrar.TabIndex = 150;
            this.btnmostrar.Text = "MOSTRAR ";
            this.btnmostrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnmostrar.Click += new System.EventHandler(this.btnmostrar_Click);
            // 
            // cbxmes
            // 
            this.cbxmes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxmes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxmes.FormattingEnabled = true;
            this.cbxmes.Items.AddRange(new object[] {
            "<< Todos los Meses >>",
            "01 - Enero",
            "02 - Febrero",
            "03 - Marzo",
            "04 - Abril",
            "05 - Mayo ",
            "06 - Junio",
            "07 - Julio",
            "08 - Agosto",
            "09 - Setiembre",
            "10 - Octubre",
            "11 - Noviembre",
            "12 - Diciembre "});
            this.cbxmes.Location = new System.Drawing.Point(217, 30);
            this.cbxmes.Margin = new System.Windows.Forms.Padding(4);
            this.cbxmes.Name = "cbxmes";
            this.cbxmes.Size = new System.Drawing.Size(177, 25);
            this.cbxmes.TabIndex = 148;
            // 
            // nudanio
            // 
            this.nudanio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudanio.Location = new System.Drawing.Point(67, 30);
            this.nudanio.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudanio.Minimum = new decimal(new int[] {
            1999,
            0,
            0,
            0});
            this.nudanio.Name = "nudanio";
            this.nudanio.Size = new System.Drawing.Size(76, 29);
            this.nudanio.TabIndex = 149;
            this.nudanio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudanio.Value = new decimal(new int[] {
            1999,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(172, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 147;
            this.label1.Text = "MES :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(18, 37);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 17);
            this.label18.TabIndex = 146;
            this.label18.Text = "AÑO :";
            // 
            // dgvlista
            // 
            this.dgvlista.AllowUserToAddRows = false;
            this.dgvlista.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvlista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvlista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column40,
            this.Column47,
            this.Column4,
            this.Column1,
            this.Column2,
            this.Column48,
            this.Column45,
            this.Column49,
            this.Column5,
            this.Column6});
            this.dgvlista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvlista.Location = new System.Drawing.Point(0, 78);
            this.dgvlista.Name = "dgvlista";
            this.dgvlista.RowHeadersVisible = false;
            this.dgvlista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvlista.Size = new System.Drawing.Size(971, 463);
            this.dgvlista.TabIndex = 132;
            this.dgvlista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvlista_CellClick);
            this.dgvlista.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvlista_CellFormatting);
            // 
            // Column3
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "F. PRODUCCION";
            this.Column3.Name = "Column3";
            // 
            // Column40
            // 
            this.Column40.HeaderText = "IDLOTE";
            this.Column40.Name = "Column40";
            this.Column40.Visible = false;
            this.Column40.Width = 30;
            // 
            // Column47
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column47.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column47.HeaderText = "LOTE";
            this.Column47.Name = "Column47";
            this.Column47.ReadOnly = true;
            this.Column47.Width = 75;
            // 
            // Column4
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column4.HeaderText = "N° GUIA";
            this.Column4.Name = "Column4";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "IDCLIENTE";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "CLIENTE";
            this.Column2.Name = "Column2";
            this.Column2.Width = 255;
            // 
            // Column48
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column48.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column48.HeaderText = "CANTIDAD JABAS";
            this.Column48.Name = "Column48";
            this.Column48.ReadOnly = true;
            this.Column48.Width = 80;
            // 
            // Column45
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N3";
            dataGridViewCellStyle6.NullValue = null;
            this.Column45.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column45.HeaderText = "PESO BRUTO";
            this.Column45.Name = "Column45";
            this.Column45.ReadOnly = true;
            this.Column45.Width = 85;
            // 
            // Column49
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N3";
            dataGridViewCellStyle7.NullValue = null;
            this.Column49.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column49.HeaderText = "PESO NETO";
            this.Column49.Name = "Column49";
            this.Column49.ReadOnly = true;
            this.Column49.Width = 85;
            // 
            // Column5
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N3";
            dataGridViewCellStyle8.NullValue = null;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column5.HeaderText = "MUESTREO KG";
            this.Column5.Name = "Column5";
            this.Column5.Width = 85;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "";
            this.Column6.Name = "Column6";
            this.Column6.Width = 80;
            // 
            // FMuestreo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 541);
            this.Controls.Add(this.dgvlista);
            this.Controls.Add(this.groupBox1);
            this.Name = "FMuestreo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MUESTREO";
            this.Load += new System.EventHandler(this.FMuestreo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudanio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvlista;
        private Glass.GlassButton btnmostrar;
        internal System.Windows.Forms.ComboBox cbxmes;
        private System.Windows.Forms.NumericUpDown nudanio;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label18;
        private Glass.GlassButton btncancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column40;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column47;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column48;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column45;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column49;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewButtonColumn Column6;
    }
}