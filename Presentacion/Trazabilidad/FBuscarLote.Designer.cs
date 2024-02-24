
namespace _3mpacador4.Presentacion.Trazabilidad
{
    partial class FBuscarLote
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
            this.gbbuscar_por = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.nudanio = new System.Windows.Forms.NumericUpDown();
            this.dgvlista = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbbuscar_por.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudanio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlista)).BeginInit();
            this.SuspendLayout();
            // 
            // gbbuscar_por
            // 
            this.gbbuscar_por.Controls.Add(this.nudanio);
            this.gbbuscar_por.Controls.Add(this.label20);
            this.gbbuscar_por.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbbuscar_por.Location = new System.Drawing.Point(0, 0);
            this.gbbuscar_por.Name = "gbbuscar_por";
            this.gbbuscar_por.Size = new System.Drawing.Size(226, 53);
            this.gbbuscar_por.TabIndex = 131;
            this.gbbuscar_por.TabStop = false;
            this.gbbuscar_por.Text = "BUSCAR POR :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(6, 22);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(45, 17);
            this.label20.TabIndex = 126;
            this.label20.Text = "AÑO :";
            // 
            // nudanio
            // 
            this.nudanio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudanio.Location = new System.Drawing.Point(57, 17);
            this.nudanio.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudanio.Minimum = new decimal(new int[] {
            1990,
            0,
            0,
            0});
            this.nudanio.Name = "nudanio";
            this.nudanio.Size = new System.Drawing.Size(92, 26);
            this.nudanio.TabIndex = 127;
            this.nudanio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudanio.Value = new decimal(new int[] {
            1990,
            0,
            0,
            0});
            this.nudanio.ValueChanged += new System.EventHandler(this.nudanio_ValueChanged);
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
            this.Column8,
            this.Column9});
            this.dgvlista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvlista.Location = new System.Drawing.Point(0, 53);
            this.dgvlista.Name = "dgvlista";
            this.dgvlista.ReadOnly = true;
            this.dgvlista.RowHeadersVisible = false;
            this.dgvlista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvlista.Size = new System.Drawing.Size(226, 380);
            this.dgvlista.TabIndex = 132;
            this.dgvlista.DoubleClick += new System.EventHandler(this.dgvlista_DoubleClick);
            // 
            // Column8
            // 
            this.Column8.HeaderText = "ID";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 45;
            // 
            // Column9
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column9.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column9.HeaderText = "N° LOTE";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 160;
            // 
            // FBuscarLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 433);
            this.Controls.Add(this.dgvlista);
            this.Controls.Add(this.gbbuscar_por);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FBuscarLote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOTES POR AÑO";
            this.Load += new System.EventHandler(this.FBuscarLote_Load);
            this.gbbuscar_por.ResumeLayout(false);
            this.gbbuscar_por.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudanio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbbuscar_por;
        private System.Windows.Forms.NumericUpDown nudanio;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridView dgvlista;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}