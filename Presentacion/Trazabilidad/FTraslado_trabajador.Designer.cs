
namespace _3mpacador4.Presentacion.Trazabilidad
{
    partial class FTraslado_trabajador
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvlista1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblnrotrab1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbxfildni = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnpasar = new Glass.GlassButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvlista2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblnrotrab2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblidgrupo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblgrupo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btntrasladar = new Glass.GlassButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlista1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlista2)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvlista1);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 516);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LISTA TRABAJADORES";
            // 
            // dgvlista1
            // 
            this.dgvlista1.AllowUserToAddRows = false;
            this.dgvlista1.AllowUserToDeleteRows = false;
            this.dgvlista1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlista1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvlista1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvlista1.Location = new System.Drawing.Point(3, 87);
            this.dgvlista1.Name = "dgvlista1";
            this.dgvlista1.ReadOnly = true;
            this.dgvlista1.RowHeadersVisible = false;
            this.dgvlista1.Size = new System.Drawing.Size(340, 400);
            this.dgvlista1.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "DNI";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "TRABAJADOR";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 220;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "SEL";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column3.Width = 35;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblnrotrab1);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.Location = new System.Drawing.Point(3, 487);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(340, 26);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            // 
            // lblnrotrab1
            // 
            this.lblnrotrab1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnrotrab1.Location = new System.Drawing.Point(255, 10);
            this.lblnrotrab1.Name = "lblnrotrab1";
            this.lblnrotrab1.Size = new System.Drawing.Size(68, 13);
            this.lblnrotrab1.TabIndex = 1;
            this.lblnrotrab1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "N° TRABAJADORES :";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbxfildni);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(340, 71);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "BUSCAR POR :";
            // 
            // tbxfildni
            // 
            this.tbxfildni.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxfildni.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxfildni.Location = new System.Drawing.Point(59, 28);
            this.tbxfildni.MaxLength = 10;
            this.tbxfildni.Name = "tbxfildni";
            this.tbxfildni.Size = new System.Drawing.Size(173, 29);
            this.tbxfildni.TabIndex = 78;
            this.tbxfildni.TextChanged += new System.EventHandler(this.tbxfildni_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 21);
            this.label3.TabIndex = 77;
            this.label3.Text = "DNI :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnpasar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(346, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(91, 516);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnpasar
            // 
            this.btnpasar.BackColor = System.Drawing.Color.Blue;
            this.btnpasar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnpasar.Location = new System.Drawing.Point(4, 237);
            this.btnpasar.Margin = new System.Windows.Forms.Padding(4);
            this.btnpasar.Name = "btnpasar";
            this.btnpasar.OuterBorderColor = System.Drawing.Color.Blue;
            this.btnpasar.ShineColor = System.Drawing.Color.Navy;
            this.btnpasar.Size = new System.Drawing.Size(74, 40);
            this.btnpasar.TabIndex = 88;
            this.btnpasar.Text = ">>";
            this.btnpasar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnpasar.Click += new System.EventHandler(this.btnpasar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvlista2);
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(437, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(379, 516);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "GRUPO X TRABAJADORES";
            // 
            // dgvlista2
            // 
            this.dgvlista2.AllowUserToAddRows = false;
            this.dgvlista2.AllowUserToDeleteRows = false;
            this.dgvlista2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlista2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvlista2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvlista2.Location = new System.Drawing.Point(3, 87);
            this.dgvlista2.Name = "dgvlista2";
            this.dgvlista2.ReadOnly = true;
            this.dgvlista2.RowHeadersVisible = false;
            this.dgvlista2.Size = new System.Drawing.Size(373, 400);
            this.dgvlista2.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "DNI";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "TRABAJADOR";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 220;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lblnrotrab2);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox7.Location = new System.Drawing.Point(3, 487);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(373, 26);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            // 
            // lblnrotrab2
            // 
            this.lblnrotrab2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnrotrab2.Location = new System.Drawing.Point(275, 10);
            this.lblnrotrab2.Name = "lblnrotrab2";
            this.lblnrotrab2.Size = new System.Drawing.Size(68, 13);
            this.lblnrotrab2.TabIndex = 3;
            this.lblnrotrab2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(140, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "N° TRABAJADORES :";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblidgrupo);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.lblgrupo);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.btntrasladar);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(3, 16);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(373, 71);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "DATOS :";
            // 
            // lblidgrupo
            // 
            this.lblidgrupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblidgrupo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblidgrupo.Location = new System.Drawing.Point(192, 16);
            this.lblidgrupo.Name = "lblidgrupo";
            this.lblidgrupo.Size = new System.Drawing.Size(53, 21);
            this.lblidgrupo.TabIndex = 93;
            this.lblidgrupo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(156, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 21);
            this.label6.TabIndex = 92;
            this.label6.Text = "ID :";
            // 
            // lblgrupo
            // 
            this.lblgrupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblgrupo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblgrupo.Location = new System.Drawing.Point(10, 42);
            this.lblgrupo.Name = "lblgrupo";
            this.lblgrupo.Size = new System.Drawing.Size(235, 21);
            this.lblgrupo.TabIndex = 91;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 21);
            this.label2.TabIndex = 90;
            this.label2.Text = "GRUPO :";
            // 
            // btntrasladar
            // 
            this.btntrasladar.BackColor = System.Drawing.Color.Blue;
            this.btntrasladar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btntrasladar.Location = new System.Drawing.Point(259, 16);
            this.btntrasladar.Margin = new System.Windows.Forms.Padding(4);
            this.btntrasladar.Name = "btntrasladar";
            this.btntrasladar.OuterBorderColor = System.Drawing.Color.Blue;
            this.btntrasladar.ShineColor = System.Drawing.Color.Navy;
            this.btntrasladar.Size = new System.Drawing.Size(104, 47);
            this.btntrasladar.TabIndex = 89;
            this.btntrasladar.Text = "TRASLADAR ";
            this.btntrasladar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btntrasladar.Click += new System.EventHandler(this.btntrasladar_Click);
            // 
            // FTraslado_trabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 516);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FTraslado_trabajador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASIGNAR TRABAJADORES";
            this.Load += new System.EventHandler(this.FTraslado_trabajador_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvlista1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvlista2)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvlista1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private Glass.GlassButton btnpasar;
        private System.Windows.Forms.DataGridView dgvlista2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox6;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox tbxfildni;
        private System.Windows.Forms.Label lblnrotrab1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblnrotrab2;
        private System.Windows.Forms.Label label5;
        private Glass.GlassButton btntrasladar;
        internal System.Windows.Forms.Label lblidgrupo;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label lblgrupo;
        internal System.Windows.Forms.Label label2;
    }
}