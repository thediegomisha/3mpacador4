namespace _3mpacador4.Presentacion.Mantenimiento
{
    partial class frmProductorCLP
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
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCLP = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.datalistado = new System.Windows.Forms.DataGridView();
            this.LBLCONTAR = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblclptotal = new System.Windows.Forms.Label();
            this.chkclp = new System.Windows.Forms.CheckBox();
            this.chkrazonsocial = new System.Windows.Forms.CheckBox();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datalistado)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1156, 41);
            this.Panel1.TabIndex = 32;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(12, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(250, 21);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Busqueda de Productor por CLP";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(621, 402);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(98, 29);
            this.btnCancelar.TabIndex = 36;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(323, 402);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(82, 29);
            this.btnBuscar.TabIndex = 37;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtCLP
            // 
            this.txtCLP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCLP.Location = new System.Drawing.Point(31, 35);
            this.txtCLP.Name = "txtCLP";
            this.txtCLP.Size = new System.Drawing.Size(168, 29);
            this.txtCLP.TabIndex = 35;
            this.txtCLP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCLP_KeyPress);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(27, 11);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(163, 21);
            this.Label2.TabIndex = 34;
            this.Label2.Text = "Ingrese un CLP valido.";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtRazonSocial);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.chkrazonsocial);
            this.panel2.Controls.Add(this.chkclp);
            this.panel2.Controls.Add(this.datalistado);
            this.panel2.Controls.Add(this.txtCLP);
            this.panel2.Controls.Add(this.Label2);
            this.panel2.Location = new System.Drawing.Point(-1, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1157, 348);
            this.panel2.TabIndex = 59;
            // 
            // datalistado
            // 
            this.datalistado.AllowUserToAddRows = false;
            this.datalistado.AllowUserToDeleteRows = false;
            this.datalistado.AllowUserToResizeColumns = false;
            this.datalistado.AllowUserToResizeRows = false;
            this.datalistado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.datalistado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datalistado.Location = new System.Drawing.Point(3, 84);
            this.datalistado.Name = "datalistado";
            this.datalistado.RowHeadersVisible = false;
            this.datalistado.Size = new System.Drawing.Size(1154, 261);
            this.datalistado.TabIndex = 107;
            this.datalistado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datalistado_CellDoubleClick);
            // 
            // LBLCONTAR
            // 
            this.LBLCONTAR.AutoSize = true;
            this.LBLCONTAR.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.LBLCONTAR.Location = new System.Drawing.Point(75, 417);
            this.LBLCONTAR.Name = "LBLCONTAR";
            this.LBLCONTAR.Size = new System.Drawing.Size(20, 21);
            this.LBLCONTAR.TabIndex = 112;
            this.LBLCONTAR.Text = "0";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(76, 403);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(84, 15);
            this.label22.TabIndex = 113;
            this.label22.Text = "Resultado : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(145, 419);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 18);
            this.label3.TabIndex = 114;
            this.label3.Text = "de ";
            // 
            // lblclptotal
            // 
            this.lblclptotal.AutoSize = true;
            this.lblclptotal.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblclptotal.ForeColor = System.Drawing.Color.Blue;
            this.lblclptotal.Location = new System.Drawing.Point(196, 417);
            this.lblclptotal.Name = "lblclptotal";
            this.lblclptotal.Size = new System.Drawing.Size(20, 21);
            this.lblclptotal.TabIndex = 115;
            this.lblclptotal.Text = "0";
            // 
            // chkclp
            // 
            this.chkclp.AutoSize = true;
            this.chkclp.Location = new System.Drawing.Point(7, 17);
            this.chkclp.Name = "chkclp";
            this.chkclp.Size = new System.Drawing.Size(15, 14);
            this.chkclp.TabIndex = 108;
            this.chkclp.UseVisualStyleBackColor = true;
            this.chkclp.CheckedChanged += new System.EventHandler(this.chkclp_CheckedChanged);
            // 
            // chkrazonsocial
            // 
            this.chkrazonsocial.AutoSize = true;
            this.chkrazonsocial.Location = new System.Drawing.Point(367, 17);
            this.chkrazonsocial.Name = "chkrazonsocial";
            this.chkrazonsocial.Size = new System.Drawing.Size(15, 14);
            this.chkrazonsocial.TabIndex = 109;
            this.chkrazonsocial.UseVisualStyleBackColor = true;
            this.chkrazonsocial.CheckedChanged += new System.EventHandler(this.chkrazonsocial_CheckedChanged);
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(392, 35);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(278, 29);
            this.txtRazonSocial.TabIndex = 111;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(388, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 21);
            this.label4.TabIndex = 110;
            this.label4.Text = "Ingrese un Nombre a Buscar";
            // 
            // frmProductorCLP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 441);
            this.ControlBox = false;
            this.Controls.Add(this.lblclptotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LBLCONTAR);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnBuscar);
            this.KeyPreview = true;
            this.Name = "frmProductorCLP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.frmProductorCLP_Activated);
            this.Load += new System.EventHandler(this.frmPersonaJuridica_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datalistado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Button btnBuscar;
        internal System.Windows.Forms.TextBox txtCLP;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView datalistado;
        internal System.Windows.Forms.Label LBLCONTAR;
        internal System.Windows.Forms.Label label22;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label lblclptotal;
        internal System.Windows.Forms.TextBox txtRazonSocial;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkrazonsocial;
        private System.Windows.Forms.CheckBox chkclp;
    }
}