﻿namespace _3mpacador4.Presentacion.Mantenimiento
{
    partial class frmColaborador
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.btnCerrar = new Glass.GlassButton();
            this.btnNuevo = new Glass.GlassButton();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel5 = new System.Windows.Forms.Panel();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.datalistado = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Panel6 = new System.Windows.Forms.Panel();
            this.lblnro_reg = new System.Windows.Forms.Label();
            this.lblContar = new System.Windows.Forms.Label();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.DataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.DataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Panel2.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datalistado)).BeginInit();
            this.Panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.btnCerrar);
            this.Panel2.Controls.Add(this.btnNuevo);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(0, 53);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(894, 48);
            this.Panel2.TabIndex = 20;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.Red;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.GlowColor = System.Drawing.Color.Empty;
            this.btnCerrar.Image = global::_3mpacador4.Properties.Resources.close;
            this.btnCerrar.Location = new System.Drawing.Point(742, 4);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.OuterBorderColor = System.Drawing.Color.Red;
            this.btnCerrar.ShineColor = System.Drawing.Color.RoyalBlue;
            this.btnCerrar.Size = new System.Drawing.Size(139, 40);
            this.btnCerrar.TabIndex = 95;
            this.btnCerrar.Text = "CERRAR";
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.Blue;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.Image = global::_3mpacador4.Properties.Resources._new;
            this.btnNuevo.Location = new System.Drawing.Point(4, 4);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.OuterBorderColor = System.Drawing.Color.Blue;
            this.btnNuevo.ShineColor = System.Drawing.Color.Navy;
            this.btnNuevo.Size = new System.Drawing.Size(207, 40);
            this.btnNuevo.TabIndex = 94;
            this.btnNuevo.Text = "NUEVO COLABORADOR";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(894, 53);
            this.Panel1.TabIndex = 19;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(363, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(308, 21);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "LISTA DE COLABORADORES";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel5
            // 
            this.Panel5.BackColor = System.Drawing.Color.White;
            this.Panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel5.Location = new System.Drawing.Point(884, 0);
            this.Panel5.Name = "Panel5";
            this.Panel5.Size = new System.Drawing.Size(10, 504);
            this.Panel5.TabIndex = 2;
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.datalistado);
            this.Panel3.Controls.Add(this.Panel6);
            this.Panel3.Controls.Add(this.Panel5);
            this.Panel3.Controls.Add(this.Panel4);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3.Location = new System.Drawing.Point(0, 0);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(894, 504);
            this.Panel3.TabIndex = 21;
            // 
            // datalistado
            // 
            this.datalistado.AllowUserToAddRows = false;
            this.datalistado.AllowUserToDeleteRows = false;
            this.datalistado.BackgroundColor = System.Drawing.Color.White;
            this.datalistado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datalistado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.datalistado.ColumnHeadersHeight = 30;
            this.datalistado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column8,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.datalistado.Location = new System.Drawing.Point(10, 101);
            this.datalistado.Name = "datalistado";
            this.datalistado.ReadOnly = true;
            this.datalistado.RowHeadersVisible = false;
            this.datalistado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datalistado.Size = new System.Drawing.Size(874, 369);
            this.datalistado.TabIndex = 0;
            this.datalistado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datalistado_CellClick);
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column7.HeaderText = "";
            this.Column7.Image = global::_3mpacador4.Properties.Resources.Editar;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 5;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column8.HeaderText = "";
            this.Column8.Image = global::_3mpacador4.Properties.Resources.Eliminar;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 5;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "DNI";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "NOMBRES";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "APELLIDO PATERNO";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "APELLIDO MATERNO";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 200;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.HeaderText = "EST";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 37;
            // 
            // Panel6
            // 
            this.Panel6.BackColor = System.Drawing.Color.White;
            this.Panel6.Controls.Add(this.lblnro_reg);
            this.Panel6.Controls.Add(this.lblContar);
            this.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel6.Location = new System.Drawing.Point(10, 473);
            this.Panel6.Name = "Panel6";
            this.Panel6.Size = new System.Drawing.Size(874, 31);
            this.Panel6.TabIndex = 3;
            // 
            // lblnro_reg
            // 
            this.lblnro_reg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblnro_reg.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnro_reg.Location = new System.Drawing.Point(153, 6);
            this.lblnro_reg.Name = "lblnro_reg";
            this.lblnro_reg.Size = new System.Drawing.Size(78, 17);
            this.lblnro_reg.TabIndex = 1;
            this.lblnro_reg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblContar
            // 
            this.lblContar.AutoSize = true;
            this.lblContar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContar.Location = new System.Drawing.Point(6, 6);
            this.lblContar.Name = "lblContar";
            this.lblContar.Size = new System.Drawing.Size(141, 17);
            this.lblContar.TabIndex = 0;
            this.lblContar.Text = "NRO DE REGISTROS : ";
            // 
            // Panel4
            // 
            this.Panel4.BackColor = System.Drawing.Color.White;
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel4.Location = new System.Drawing.Point(0, 0);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(10, 504);
            this.Panel4.TabIndex = 1;
            // 
            // DataGridViewImageColumn1
            // 
            this.DataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DataGridViewImageColumn1.HeaderText = "";
            this.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1";
            this.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DataGridViewImageColumn2
            // 
            this.DataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DataGridViewImageColumn2.HeaderText = "";
            this.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2";
            this.DataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // frmColaborador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 504);
            this.ControlBox = false;
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Panel3);
            this.Name = "frmColaborador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmColaborador_Load);
            this.Panel2.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datalistado)).EndInit();
            this.Panel6.ResumeLayout(false);
            this.Panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridViewImageColumn DataGridViewImageColumn2;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel Panel5;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Panel Panel6;
        internal System.Windows.Forms.Label lblContar;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.DataGridViewImageColumn DataGridViewImageColumn1;
        public System.Windows.Forms.DataGridView datalistado;
        internal System.Windows.Forms.Label lblnro_reg;
        private Glass.GlassButton btnNuevo;
        private Glass.GlassButton btnCerrar;
        private System.Windows.Forms.DataGridViewImageColumn Column7;
        private System.Windows.Forms.DataGridViewImageColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column6;
    }
}