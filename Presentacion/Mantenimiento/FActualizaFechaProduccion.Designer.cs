
namespace _3mpacador4.Presentacion.Mantenimiento
{
    partial class FActualizaFechaProduccion
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnmostrar = new Glass.GlassButton();
            this.cbxmes = new System.Windows.Forms.ComboBox();
            this.nudanio = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dgvlista = new System.Windows.Forms.DataGridView();
            this.btncancelar = new Glass.GlassButton();
            this.lbltotal_lotes = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudanio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlista)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnmostrar);
            this.groupBox1.Controls.Add(this.cbxmes);
            this.groupBox1.Controls.Add(this.nudanio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 78);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BUSCAR POR :";
            // 
            // btnmostrar
            // 
            this.btnmostrar.BackColor = System.Drawing.Color.Blue;
            this.btnmostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnmostrar.Image = global::_3mpacador4.Properties.Resources.buscar;
            this.btnmostrar.Location = new System.Drawing.Point(394, 25);
            this.btnmostrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnmostrar.Name = "btnmostrar";
            this.btnmostrar.OuterBorderColor = System.Drawing.Color.Blue;
            this.btnmostrar.ShineColor = System.Drawing.Color.Navy;
            this.btnmostrar.Size = new System.Drawing.Size(116, 40);
            this.btnmostrar.TabIndex = 145;
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
            this.cbxmes.Location = new System.Drawing.Point(209, 36);
            this.cbxmes.Margin = new System.Windows.Forms.Padding(4);
            this.cbxmes.Name = "cbxmes";
            this.cbxmes.Size = new System.Drawing.Size(177, 25);
            this.cbxmes.TabIndex = 128;
            // 
            // nudanio
            // 
            this.nudanio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudanio.Location = new System.Drawing.Point(59, 36);
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
            this.nudanio.TabIndex = 138;
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
            this.label1.Location = new System.Drawing.Point(164, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 82;
            this.label1.Text = "MES :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(10, 43);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 17);
            this.label18.TabIndex = 81;
            this.label18.Text = "AÑO :";
            // 
            // dgvlista
            // 
            this.dgvlista.AllowUserToAddRows = false;
            this.dgvlista.AllowUserToDeleteRows = false;
            this.dgvlista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvlista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvlista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvlista.Location = new System.Drawing.Point(12, 96);
            this.dgvlista.Name = "dgvlista";
            this.dgvlista.RowHeadersVisible = false;
            this.dgvlista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvlista.Size = new System.Drawing.Size(523, 449);
            this.dgvlista.TabIndex = 1;
            this.dgvlista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvlista_CellClick);
            this.dgvlista.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvlista_CellFormatting);
            // 
            // btncancelar
            // 
            this.btncancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btncancelar.BackColor = System.Drawing.Color.Red;
            this.btncancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancelar.GlowColor = System.Drawing.Color.Empty;
            this.btncancelar.Image = global::_3mpacador4.Properties.Resources.cancel;
            this.btncancelar.Location = new System.Drawing.Point(375, 552);
            this.btncancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.OuterBorderColor = System.Drawing.Color.Red;
            this.btncancelar.ShineColor = System.Drawing.Color.RoyalBlue;
            this.btncancelar.Size = new System.Drawing.Size(160, 40);
            this.btncancelar.TabIndex = 89;
            this.btncancelar.Text = "CANCELAR";
            this.btncancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // lbltotal_lotes
            // 
            this.lbltotal_lotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbltotal_lotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbltotal_lotes.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotal_lotes.Location = new System.Drawing.Point(179, 557);
            this.lbltotal_lotes.Name = "lbltotal_lotes";
            this.lbltotal_lotes.Size = new System.Drawing.Size(132, 25);
            this.lbltotal_lotes.TabIndex = 128;
            this.lbltotal_lotes.Text = "0";
            this.lbltotal_lotes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(24, 557);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(149, 25);
            this.label10.TabIndex = 127;
            this.label10.Text = "TOTAL LOTES :";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "IDLOTE";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "N° LOTE";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "FECHA INGRESO";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column4.HeaderText = "FECHA PRODUCCION";
            this.Column4.Name = "Column4";
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column5.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column5.HeaderText = "";
            this.Column5.Name = "Column5";
            this.Column5.Text = "";
            // 
            // FActualizaFechaProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 605);
            this.Controls.Add(this.lbltotal_lotes);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btncancelar);
            this.Controls.Add(this.dgvlista);
            this.Controls.Add(this.groupBox1);
            this.Name = "FActualizaFechaProduccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACTUALIZAR FECHA DE PRODUCCION POR LOTE";
            this.Load += new System.EventHandler(this.FActualizaFechaProduccion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudanio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown nudanio;
        internal System.Windows.Forms.ComboBox cbxmes;
        private System.Windows.Forms.DataGridView dgvlista;
        private Glass.GlassButton btncancelar;
        private System.Windows.Forms.Label lbltotal_lotes;
        private System.Windows.Forms.Label label10;
        private Glass.GlassButton btnmostrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewButtonColumn Column5;
    }
}