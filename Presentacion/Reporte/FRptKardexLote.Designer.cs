
namespace _3mpacador4.Presentacion.Reporte
{
    partial class FRptKardexLote
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvkardex = new System.Windows.Forms.DataGridView();
            this.btnmostrar = new Glass.GlassButton();
            this.cbxmes = new System.Windows.Forms.ComboBox();
            this.nudanio = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnverpdf = new Glass.GlassButton();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvkardex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudanio)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnverpdf);
            this.groupBox1.Controls.Add(this.btnmostrar);
            this.groupBox1.Controls.Add(this.cbxmes);
            this.groupBox1.Controls.Add(this.nudanio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 567);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BUSCAR POR";
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(267, 529);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(702, 38);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TOTALES";
            // 
            // dgvkardex
            // 
            this.dgvkardex.AllowUserToAddRows = false;
            this.dgvkardex.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvkardex.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvkardex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvkardex.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvkardex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvkardex.Location = new System.Drawing.Point(267, 0);
            this.dgvkardex.Name = "dgvkardex";
            this.dgvkardex.ReadOnly = true;
            this.dgvkardex.RowHeadersVisible = false;
            this.dgvkardex.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvkardex.Size = new System.Drawing.Size(702, 529);
            this.dgvkardex.TabIndex = 2;
            // 
            // btnmostrar
            // 
            this.btnmostrar.BackColor = System.Drawing.Color.Blue;
            this.btnmostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnmostrar.Image = global::_3mpacador4.Properties.Resources.buscar;
            this.btnmostrar.Location = new System.Drawing.Point(46, 136);
            this.btnmostrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnmostrar.Name = "btnmostrar";
            this.btnmostrar.OuterBorderColor = System.Drawing.Color.Blue;
            this.btnmostrar.ShineColor = System.Drawing.Color.Navy;
            this.btnmostrar.Size = new System.Drawing.Size(177, 40);
            this.btnmostrar.TabIndex = 150;
            this.btnmostrar.Text = "MOSTRAR KARDEX";
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
            this.cbxmes.Location = new System.Drawing.Point(74, 80);
            this.cbxmes.Margin = new System.Windows.Forms.Padding(4);
            this.cbxmes.Name = "cbxmes";
            this.cbxmes.Size = new System.Drawing.Size(177, 25);
            this.cbxmes.TabIndex = 148;
            // 
            // nudanio
            // 
            this.nudanio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudanio.Location = new System.Drawing.Point(74, 44);
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
            this.label1.Location = new System.Drawing.Point(29, 84);
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
            this.label18.Location = new System.Drawing.Point(26, 51);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 17);
            this.label18.TabIndex = 146;
            this.label18.Text = "AÑO :";
            // 
            // btnverpdf
            // 
            this.btnverpdf.BackColor = System.Drawing.Color.Blue;
            this.btnverpdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnverpdf.Image = global::_3mpacador4.Properties.Resources.Pdf;
            this.btnverpdf.Location = new System.Drawing.Point(46, 184);
            this.btnverpdf.Margin = new System.Windows.Forms.Padding(4);
            this.btnverpdf.Name = "btnverpdf";
            this.btnverpdf.OuterBorderColor = System.Drawing.Color.Blue;
            this.btnverpdf.ShineColor = System.Drawing.Color.Navy;
            this.btnverpdf.Size = new System.Drawing.Size(177, 45);
            this.btnverpdf.TabIndex = 151;
            this.btnverpdf.Text = "VER KARDEX PDF";
            this.btnverpdf.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnverpdf.Click += new System.EventHandler(this.btnverpdf_Click);
            // 
            // Column1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "FECHA PRODUCCION";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "LOTE";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column3.HeaderText = "TIPO MOVIMIENTO";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Green;
            dataGridViewCellStyle5.Format = "N3";
            dataGridViewCellStyle5.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column4.HeaderText = "INGRESO";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle6.Format = "N3";
            dataGridViewCellStyle6.NullValue = null;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column5.HeaderText = "SALIDA";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.Format = "N3";
            dataGridViewCellStyle7.NullValue = null;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column6.HeaderText = "SALDO";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // FRptKardexLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 567);
            this.Controls.Add(this.dgvkardex);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FRptKardexLote";
            this.Text = "FRptKardexLote";
            this.Load += new System.EventHandler(this.FRptKardexLote_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvkardex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudanio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvkardex;
        private Glass.GlassButton btnmostrar;
        internal System.Windows.Forms.ComboBox cbxmes;
        private System.Windows.Forms.NumericUpDown nudanio;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label18;
        private Glass.GlassButton btnverpdf;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}