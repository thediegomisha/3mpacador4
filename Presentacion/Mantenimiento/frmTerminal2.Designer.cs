namespace _3mpacador4.Presentacion.Mantenimiento
{
    partial class frmTerminal2
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
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxestado = new System.Windows.Forms.CheckBox();
            this.btnActualizar = new Glass.GlassButton();
            this.btnCancelar = new Glass.GlassButton();
            this.btnGuardar = new Glass.GlassButton();
            this.Panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(633, 41);
            this.Panel1.TabIndex = 32;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(211, 10);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(194, 21);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "REGISTRO DE TERMINAL";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(31, 47);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(575, 29);
            this.txtDescripcion.TabIndex = 35;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(27, 23);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(109, 21);
            this.Label2.TabIndex = 34;
            this.Label2.Text = "DESCRIPCION";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cbxestado);
            this.panel2.Controls.Add(this.txtDescripcion);
            this.panel2.Controls.Add(this.Label2);
            this.panel2.Location = new System.Drawing.Point(-1, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(634, 164);
            this.panel2.TabIndex = 59;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(29, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 21);
            this.label6.TabIndex = 48;
            this.label6.Text = "ESTADO :";
            // 
            // cbxestado
            // 
            this.cbxestado.AutoSize = true;
            this.cbxestado.Checked = true;
            this.cbxestado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxestado.Location = new System.Drawing.Point(105, 98);
            this.cbxestado.Name = "cbxestado";
            this.cbxestado.Size = new System.Drawing.Size(15, 14);
            this.cbxestado.TabIndex = 47;
            this.cbxestado.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.Blue;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.Image = global::_3mpacador4.Properties.Resources.update;
            this.btnActualizar.Location = new System.Drawing.Point(178, 226);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.OuterBorderColor = System.Drawing.Color.Blue;
            this.btnActualizar.ShineColor = System.Drawing.Color.Navy;
            this.btnActualizar.Size = new System.Drawing.Size(140, 40);
            this.btnActualizar.TabIndex = 92;
            this.btnActualizar.Text = "ACTUALIZAR";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Red;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.GlowColor = System.Drawing.Color.Empty;
            this.btnCancelar.Image = global::_3mpacador4.Properties.Resources.cancel;
            this.btnCancelar.Location = new System.Drawing.Point(466, 226);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.OuterBorderColor = System.Drawing.Color.Red;
            this.btnCancelar.ShineColor = System.Drawing.Color.RoyalBlue;
            this.btnCancelar.Size = new System.Drawing.Size(139, 40);
            this.btnCancelar.TabIndex = 90;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Blue;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Image = global::_3mpacador4.Properties.Resources.save;
            this.btnGuardar.Location = new System.Drawing.Point(30, 226);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.OuterBorderColor = System.Drawing.Color.Blue;
            this.btnGuardar.ShineColor = System.Drawing.Color.Navy;
            this.btnGuardar.Size = new System.Drawing.Size(140, 40);
            this.btnGuardar.TabIndex = 91;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmTerminal2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 279);
            this.ControlBox = false;
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Panel1);
            this.Name = "frmTerminal2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmTerminal2_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtDescripcion;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbxestado;
        private Glass.GlassButton btnGuardar;
        private Glass.GlassButton btnCancelar;
        private Glass.GlassButton btnActualizar;
    }
}