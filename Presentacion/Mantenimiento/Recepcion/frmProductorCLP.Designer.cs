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
            this.txtCLP = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblpais1 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkrazonsocial = new System.Windows.Forms.CheckBox();
            this.chkclp = new System.Windows.Forms.CheckBox();
            this.datalistado = new System.Windows.Forms.DataGridView();
            this.LBLCONTAR = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblclptotal = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
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
            this.Panel1.Size = new System.Drawing.Size(939, 41);
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
            // txtCLP
            // 
            this.txtCLP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCLP.Location = new System.Drawing.Point(31, 28);
            this.txtCLP.Name = "txtCLP";
            this.txtCLP.Size = new System.Drawing.Size(168, 25);
            this.txtCLP.TabIndex = 35;
            this.txtCLP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCLP_KeyPress);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(27, 4);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(163, 21);
            this.Label2.TabIndex = 34;
            this.Label2.Text = "Ingrese un CLP valido.";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblpais1);
            this.panel2.Controls.Add(this.label34);
            this.panel2.Controls.Add(this.txtRazonSocial);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.chkrazonsocial);
            this.panel2.Controls.Add(this.chkclp);
            this.panel2.Controls.Add(this.datalistado);
            this.panel2.Controls.Add(this.txtCLP);
            this.panel2.Controls.Add(this.Label2);
            this.panel2.Location = new System.Drawing.Point(0, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(939, 329);
            this.panel2.TabIndex = 59;
            // 
            // lblpais1
            // 
            this.lblpais1.AutoSize = true;
            this.lblpais1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpais1.ForeColor = System.Drawing.Color.Blue;
            this.lblpais1.Location = new System.Drawing.Point(554, 20);
            this.lblpais1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblpais1.Name = "lblpais1";
            this.lblpais1.Size = new System.Drawing.Size(86, 37);
            this.lblpais1.TabIndex = 117;
            this.lblpais1.Text = "PERU";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(558, 4);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(132, 17);
            this.label34.TabIndex = 116;
            this.label34.Text = "PAIS AUTORIZADO :";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(246, 30);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(278, 25);
            this.txtRazonSocial.TabIndex = 111;
            this.txtRazonSocial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRazonSocial_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(242, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 21);
            this.label4.TabIndex = 110;
            this.label4.Text = "Ingrese un Nombre a Buscar";
            // 
            // chkrazonsocial
            // 
            this.chkrazonsocial.AutoSize = true;
            this.chkrazonsocial.Location = new System.Drawing.Point(221, 10);
            this.chkrazonsocial.Name = "chkrazonsocial";
            this.chkrazonsocial.Size = new System.Drawing.Size(15, 14);
            this.chkrazonsocial.TabIndex = 109;
            this.chkrazonsocial.UseVisualStyleBackColor = true;
            this.chkrazonsocial.CheckedChanged += new System.EventHandler(this.chkrazonsocial_CheckedChanged);
            // 
            // chkclp
            // 
            this.chkclp.AutoSize = true;
            this.chkclp.Location = new System.Drawing.Point(7, 10);
            this.chkclp.Name = "chkclp";
            this.chkclp.Size = new System.Drawing.Size(15, 14);
            this.chkclp.TabIndex = 108;
            this.chkclp.UseVisualStyleBackColor = true;
            this.chkclp.CheckedChanged += new System.EventHandler(this.chkclp_CheckedChanged);
            // 
            // datalistado
            // 
            this.datalistado.AllowUserToAddRows = false;
            this.datalistado.AllowUserToDeleteRows = false;
            this.datalistado.AllowUserToResizeColumns = false;
            this.datalistado.AllowUserToResizeRows = false;
            this.datalistado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.datalistado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datalistado.Location = new System.Drawing.Point(3, 61);
            this.datalistado.Name = "datalistado";
            this.datalistado.RowHeadersVisible = false;
            this.datalistado.Size = new System.Drawing.Size(924, 261);
            this.datalistado.TabIndex = 107;
            this.datalistado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datalistado_CellDoubleClick);
            // 
            // LBLCONTAR
            // 
            this.LBLCONTAR.AutoSize = true;
            this.LBLCONTAR.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.LBLCONTAR.Location = new System.Drawing.Point(12, 387);
            this.LBLCONTAR.Name = "LBLCONTAR";
            this.LBLCONTAR.Size = new System.Drawing.Size(20, 21);
            this.LBLCONTAR.TabIndex = 112;
            this.LBLCONTAR.Text = "0";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(8, 373);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(84, 15);
            this.label22.TabIndex = 113;
            this.label22.Text = "Resultado : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(77, 389);
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
            this.lblclptotal.Location = new System.Drawing.Point(134, 386);
            this.lblclptotal.Name = "lblclptotal";
            this.lblclptotal.Size = new System.Drawing.Size(20, 21);
            this.lblclptotal.TabIndex = 115;
            this.lblclptotal.Text = "0";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Teal;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(396, 369);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 38);
            this.btnBuscar.TabIndex = 116;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(820, 369);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 38);
            this.btnCancelar.TabIndex = 117;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // frmProductorCLP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 420);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblclptotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LBLCONTAR);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Panel1);
            this.KeyPreview = true;
            this.Name = "frmProductorCLP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.frmProductorCLP_Activated);
            this.Load += new System.EventHandler(this.frmPersonaJuridica_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProductorCLP_KeyDown);
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
        private System.Windows.Forms.Label lblpais1;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCancelar;
    }
}