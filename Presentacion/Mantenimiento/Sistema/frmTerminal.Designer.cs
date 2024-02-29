namespace _3mpacador4.Presentacion.Mantenimiento
{
    partial class frmTerminal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTerminal));
            this.Panel2 = new System.Windows.Forms.Panel();
            this.btnCerrar = new Glass.GlassButton();
            this.btnNuevo = new Glass.GlassButton();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel5 = new System.Windows.Forms.Panel();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.datalistado = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Panel2.Size = new System.Drawing.Size(678, 48);
            this.Panel2.TabIndex = 20;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.Red;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.GlowColor = System.Drawing.Color.Empty;
            this.btnCerrar.Image = global::_3mpacador4.Properties.Resources.close;
            this.btnCerrar.Location = new System.Drawing.Point(529, 3);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.OuterBorderColor = System.Drawing.Color.Red;
            this.btnCerrar.ShineColor = System.Drawing.Color.RoyalBlue;
            this.btnCerrar.Size = new System.Drawing.Size(139, 40);
            this.btnCerrar.TabIndex = 92;
            this.btnCerrar.Text = "CERRAR";
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.Blue;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.Image = global::_3mpacador4.Properties.Resources._new;
            this.btnNuevo.Location = new System.Drawing.Point(4, 3);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.OuterBorderColor = System.Drawing.Color.Blue;
            this.btnNuevo.ShineColor = System.Drawing.Color.Navy;
            this.btnNuevo.Size = new System.Drawing.Size(164, 40);
            this.btnNuevo.TabIndex = 93;
            this.btnNuevo.Text = "NUEVO TERMINAL";
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
            this.Panel1.Size = new System.Drawing.Size(678, 53);
            this.Panel1.TabIndex = 19;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(197, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(231, 34);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "LISTA DE TERMINALES";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel5
            // 
            this.Panel5.BackColor = System.Drawing.Color.White;
            this.Panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel5.Location = new System.Drawing.Point(668, 0);
            this.Panel5.Name = "Panel5";
            this.Panel5.Size = new System.Drawing.Size(10, 349);
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
            this.Panel3.Size = new System.Drawing.Size(678, 349);
            this.Panel3.TabIndex = 21;
            // 
            // datalistado
            // 
            this.datalistado.AllowUserToAddRows = false;
            this.datalistado.AllowUserToDeleteRows = false;
            this.datalistado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datalistado.BackgroundColor = System.Drawing.Color.White;
            this.datalistado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datalistado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.datalistado.ColumnHeadersHeight = 30;
            this.datalistado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Eliminar,
            this.Column1,
            this.Column3,
            this.Column6});
            this.datalistado.Location = new System.Drawing.Point(10, 103);
            this.datalistado.Name = "datalistado";
            this.datalistado.ReadOnly = true;
            this.datalistado.RowHeadersVisible = false;
            this.datalistado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datalistado.Size = new System.Drawing.Size(658, 218);
            this.datalistado.TabIndex = 4;
            this.datalistado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datalistado_CellClick);
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "";
            this.Column2.Image = global::_3mpacador4.Properties.Resources.Editar;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 5;
            // 
            // Eliminar
            // 
            this.Eliminar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Eliminar.HeaderText = "";
            this.Eliminar.Image = global::_3mpacador4.Properties.Resources.Eliminar;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Eliminar.Width = 5;
            // 
            // Column1
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "DESCRIPCION DEL TERMINAL";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 250;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "EST";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 50;
            // 
            // Panel6
            // 
            this.Panel6.BackColor = System.Drawing.Color.White;
            this.Panel6.Controls.Add(this.lblnro_reg);
            this.Panel6.Controls.Add(this.lblContar);
            this.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel6.Location = new System.Drawing.Point(10, 318);
            this.Panel6.Name = "Panel6";
            this.Panel6.Size = new System.Drawing.Size(658, 31);
            this.Panel6.TabIndex = 3;
            // 
            // lblnro_reg
            // 
            this.lblnro_reg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblnro_reg.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnro_reg.Location = new System.Drawing.Point(153, 6);
            this.lblnro_reg.Name = "lblnro_reg";
            this.lblnro_reg.Size = new System.Drawing.Size(78, 17);
            this.lblnro_reg.TabIndex = 3;
            this.lblnro_reg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblContar
            // 
            this.lblContar.AutoSize = true;
            this.lblContar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContar.Location = new System.Drawing.Point(6, 6);
            this.lblContar.Name = "lblContar";
            this.lblContar.Size = new System.Drawing.Size(141, 17);
            this.lblContar.TabIndex = 2;
            this.lblContar.Text = "NRO DE REGISTROS : ";
            // 
            // Panel4
            // 
            this.Panel4.BackColor = System.Drawing.Color.White;
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel4.Location = new System.Drawing.Point(0, 0);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(10, 349);
            this.Panel4.TabIndex = 1;
            // 
            // DataGridViewImageColumn1
            // 
            this.DataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DataGridViewImageColumn1.HeaderText = "";
            this.DataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("DataGridViewImageColumn1.Image")));
            this.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1";
            this.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DataGridViewImageColumn2
            // 
            this.DataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DataGridViewImageColumn2.HeaderText = "";
            this.DataGridViewImageColumn2.Image = ((System.Drawing.Image)(resources.GetObject("DataGridViewImageColumn2.Image")));
            this.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2";
            this.DataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // frmTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 349);
            this.ControlBox = false;
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Panel3);
            this.KeyPreview = true;
            this.Name = "frmTerminal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.DataGridViewImageColumn DataGridViewImageColumn1;
        internal System.Windows.Forms.Label lblnro_reg;
        internal System.Windows.Forms.Label lblContar;
        private Glass.GlassButton btnCerrar;
        private Glass.GlassButton btnNuevo;
        public System.Windows.Forms.DataGridView datalistado;
        private System.Windows.Forms.DataGridViewImageColumn Column2;
        private System.Windows.Forms.DataGridViewImageColumn Eliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column6;
    }
}