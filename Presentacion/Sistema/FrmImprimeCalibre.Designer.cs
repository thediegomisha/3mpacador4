﻿
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbximpresora = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnimprimir = new Glass.GlassButton();
            this.btncancelar = new Glass.GlassButton();
            this.nudacantidad_filas = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvlista = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblidprogramacion = new System.Windows.Forms.Label();
            this.lbllote = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblfproduccion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btngenerar = new Glass.GlassButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.nudcalibre = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblcolumnas = new System.Windows.Forms.Label();
            this.lblcantidad_tikects = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudacantidad_filas)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlista)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudcalibre)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbximpresora
            // 
            this.cbximpresora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbximpresora.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbximpresora.FormattingEnabled = true;
            this.cbximpresora.Location = new System.Drawing.Point(169, 62);
            this.cbximpresora.Margin = new System.Windows.Forms.Padding(4);
            this.cbximpresora.Name = "cbximpresora";
            this.cbximpresora.Size = new System.Drawing.Size(354, 25);
            this.cbximpresora.TabIndex = 114;
            this.cbximpresora.SelectedValueChanged += new System.EventHandler(this.cbximpresora_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 113;
            this.label1.Text = "IMPRESORA :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnimprimir);
            this.groupBox2.Controls.Add(this.btncancelar);
            this.groupBox2.Location = new System.Drawing.Point(11, 603);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(564, 73);
            this.groupBox2.TabIndex = 115;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "OPERACIONES";
            // 
            // btnimprimir
            // 
            this.btnimprimir.BackColor = System.Drawing.Color.Blue;
            this.btnimprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnimprimir.Image = global::_3mpacador4.Properties.Resources.save;
            this.btnimprimir.Location = new System.Drawing.Point(7, 22);
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
            this.btncancelar.Location = new System.Drawing.Point(410, 22);
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
            // nudacantidad_filas
            // 
            this.nudacantidad_filas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudacantidad_filas.Location = new System.Drawing.Point(8, 22);
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
            this.nudacantidad_filas.Size = new System.Drawing.Size(73, 31);
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
            this.groupBox1.Controls.Add(this.dgvlista);
            this.groupBox1.Location = new System.Drawing.Point(8, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(567, 419);
            this.groupBox1.TabIndex = 121;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LISTADO DE ETIQUETAS";
            // 
            // dgvlista
            // 
            this.dgvlista.AllowUserToAddRows = false;
            this.dgvlista.AllowUserToDeleteRows = false;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvlista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvlista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvlista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvlista.Location = new System.Drawing.Point(3, 16);
            this.dgvlista.Name = "dgvlista";
            this.dgvlista.ReadOnly = true;
            this.dgvlista.RowHeadersVisible = false;
            this.dgvlista.Size = new System.Drawing.Size(561, 400);
            this.dgvlista.TabIndex = 123;
            // 
            // Column2
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle12;
            this.Column2.HeaderText = "COLUMNA 1";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 135;
            // 
            // Column4
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle13;
            this.Column4.HeaderText = "COLUMNA 2";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 135;
            // 
            // Column5
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle14;
            this.Column5.HeaderText = "COLUMNA 3";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 135;
            // 
            // Column6
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle15;
            this.Column6.HeaderText = "COLUMNA 4";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 135;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblidprogramacion);
            this.groupBox3.Controls.Add(this.lbllote);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.lblfproduccion);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btngenerar);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.cbximpresora);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(8, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(567, 160);
            this.groupBox3.TabIndex = 122;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DATOS";
            // 
            // lblidprogramacion
            // 
            this.lblidprogramacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblidprogramacion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblidprogramacion.Location = new System.Drawing.Point(140, 17);
            this.lblidprogramacion.Name = "lblidprogramacion";
            this.lblidprogramacion.Size = new System.Drawing.Size(113, 17);
            this.lblidprogramacion.TabIndex = 130;
            this.lblidprogramacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbllote
            // 
            this.lbllote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbllote.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllote.Location = new System.Drawing.Point(22, 38);
            this.lbllote.Name = "lbllote";
            this.lbllote.Size = new System.Drawing.Size(501, 20);
            this.lbllote.TabIndex = 129;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 17);
            this.label5.TabIndex = 128;
            this.label5.Text = "PROGRAMACIÓN :";
            // 
            // lblfproduccion
            // 
            this.lblfproduccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblfproduccion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfproduccion.Location = new System.Drawing.Point(419, 16);
            this.lblfproduccion.Name = "lblfproduccion";
            this.lblfproduccion.Size = new System.Drawing.Size(104, 17);
            this.lblfproduccion.TabIndex = 127;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(299, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 126;
            this.label2.Text = "F. PRODUCCION :";
            // 
            // btngenerar
            // 
            this.btngenerar.BackColor = System.Drawing.Color.Blue;
            this.btngenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btngenerar.Image = global::_3mpacador4.Properties.Resources.trasladar;
            this.btngenerar.Location = new System.Drawing.Point(406, 106);
            this.btngenerar.Margin = new System.Windows.Forms.Padding(4);
            this.btngenerar.Name = "btngenerar";
            this.btngenerar.OuterBorderColor = System.Drawing.Color.Blue;
            this.btngenerar.ShineColor = System.Drawing.Color.Navy;
            this.btngenerar.Size = new System.Drawing.Size(117, 42);
            this.btngenerar.TabIndex = 89;
            this.btngenerar.Text = "GENERAR";
            this.btngenerar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btngenerar.Click += new System.EventHandler(this.btngenerar_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.nudcalibre);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(39, 92);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(102, 63);
            this.groupBox5.TabIndex = 125;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "CALIBRE";
            // 
            // nudcalibre
            // 
            this.nudcalibre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudcalibre.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudcalibre.Location = new System.Drawing.Point(13, 22);
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
            this.nudcalibre.TabIndex = 125;
            this.nudcalibre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudcalibre.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblcolumnas);
            this.groupBox4.Controls.Add(this.lblcantidad_tikects);
            this.groupBox4.Controls.Add(this.nudacantidad_filas);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(148, 92);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(255, 63);
            this.groupBox4.TabIndex = 123;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "N° ETIQUETAS";
            // 
            // lblcolumnas
            // 
            this.lblcolumnas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblcolumnas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcolumnas.Location = new System.Drawing.Point(110, 25);
            this.lblcolumnas.Name = "lblcolumnas";
            this.lblcolumnas.Size = new System.Drawing.Size(35, 26);
            this.lblcolumnas.TabIndex = 122;
            this.lblcolumnas.Text = "4";
            this.lblcolumnas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblcantidad_tikects
            // 
            this.lblcantidad_tikects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblcantidad_tikects.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcantidad_tikects.Location = new System.Drawing.Point(182, 26);
            this.lblcantidad_tikects.Name = "lblcantidad_tikects";
            this.lblcantidad_tikects.Size = new System.Drawing.Size(65, 26);
            this.lblcantidad_tikects.TabIndex = 124;
            this.lblcantidad_tikects.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(88, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 17);
            this.label6.TabIndex = 123;
            this.label6.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(151, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 25);
            this.label4.TabIndex = 121;
            this.label4.Text = "=";
            // 
            // FrmImprimeCalibre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 683);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmImprimeCalibre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmImprimeCalibre_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudacantidad_filas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvlista)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudcalibre)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ComboBox cbximpresora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Glass.GlassButton btnimprimir;
        private Glass.GlassButton btncancelar;
        private System.Windows.Forms.NumericUpDown nudacantidad_filas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblcantidad_tikects;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblcolumnas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvlista;
        private Glass.GlassButton btngenerar;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbllote;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblfproduccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label lblidprogramacion;
        private System.Windows.Forms.NumericUpDown nudcalibre;
    }
}