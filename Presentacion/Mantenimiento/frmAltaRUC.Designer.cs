namespace _3mpacador4.Presentacion.Mantenimiento
{
    partial class frmAltaRUC
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
            this.lbltitulo = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtdireccion = new MetroFramework.Controls.MetroTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtruc = new MetroFramework.Controls.MetroTextBox();
            this.txtRazonSocial = new MetroFramework.Controls.MetroTextBox();
            this.pbreniec = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbreniec)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.Blue;
            this.Panel1.Controls.Add(this.lbltitulo);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(612, 41);
            this.Panel1.TabIndex = 32;
            // 
            // lbltitulo
            // 
            this.lbltitulo.AutoSize = true;
            this.lbltitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitulo.ForeColor = System.Drawing.Color.White;
            this.lbltitulo.Location = new System.Drawing.Point(12, 9);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(126, 21);
            this.lbltitulo.TabIndex = 0;
            this.lbltitulo.Text = "Ingreso de RUC";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(14, 138);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(91, 21);
            this.Label4.TabIndex = 41;
            this.Label4.Text = "DIRECCION";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(504, 258);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(98, 29);
            this.btnCancelar.TabIndex = 36;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(289, 258);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(82, 29);
            this.btnGuardar.TabIndex = 37;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(192, 11);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(50, 21);
            this.Label3.TabIndex = 33;
            this.Label3.Text = "R.U.C.";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(15, 79);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(120, 21);
            this.Label2.TabIndex = 34;
            this.Label2.Text = "RAZON SOCIAL";
            // 
            // txtdireccion
            // 
            // 
            // 
            // 
            this.txtdireccion.CustomButton.Image = null;
            this.txtdireccion.CustomButton.Location = new System.Drawing.Point(461, 2);
            this.txtdireccion.CustomButton.Name = "";
            this.txtdireccion.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtdireccion.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtdireccion.CustomButton.TabIndex = 1;
            this.txtdireccion.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtdireccion.CustomButton.UseSelectable = true;
            this.txtdireccion.CustomButton.Visible = false;
            this.txtdireccion.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtdireccion.Lines = new string[0];
            this.txtdireccion.Location = new System.Drawing.Point(17, 162);
            this.txtdireccion.MaxLength = 32767;
            this.txtdireccion.Multiline = true;
            this.txtdireccion.Name = "txtdireccion";
            this.txtdireccion.PasswordChar = '\0';
            this.txtdireccion.WaterMark = "Ej: Jiron Santa Rosa 711";
            this.txtdireccion.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtdireccion.SelectedText = "";
            this.txtdireccion.SelectionLength = 0;
            this.txtdireccion.SelectionStart = 0;
            this.txtdireccion.ShortcutsEnabled = true;
            this.txtdireccion.Size = new System.Drawing.Size(489, 30);
            this.txtdireccion.TabIndex = 42;
            this.txtdireccion.UseSelectable = true;
            this.txtdireccion.WaterMark = "Ej: Jiron Santa Rosa 711";
            this.txtdireccion.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtdireccion.WaterMarkFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtruc);
            this.panel2.Controls.Add(this.txtRazonSocial);
            this.panel2.Controls.Add(this.pbreniec);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.txtdireccion);
            this.panel2.Controls.Add(this.Label4);
            this.panel2.Controls.Add(this.Label3);
            this.panel2.Controls.Add(this.Label2);
            this.panel2.Location = new System.Drawing.Point(-1, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(603, 204);
            this.panel2.TabIndex = 59;
            // 
            // txtruc
            // 
            // 
            // 
            // 
            this.txtruc.CustomButton.Image = null;
            this.txtruc.CustomButton.Location = new System.Drawing.Point(282, 2);
            this.txtruc.CustomButton.Name = "";
            this.txtruc.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtruc.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtruc.CustomButton.TabIndex = 1;
            this.txtruc.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtruc.CustomButton.UseSelectable = true;
            this.txtruc.CustomButton.Visible = false;
            this.txtruc.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtruc.Lines = new string[0];
            this.txtruc.Location = new System.Drawing.Point(196, 35);
            this.txtruc.MaxLength = 32767;
            this.txtruc.Name = "txtruc";
            this.txtruc.PasswordChar = '\0';
            this.txtruc.WaterMark = "Ej. 20552167466";
            this.txtruc.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtruc.SelectedText = "";
            this.txtruc.SelectionLength = 0;
            this.txtruc.SelectionStart = 0;
            this.txtruc.ShortcutsEnabled = true;
            this.txtruc.Size = new System.Drawing.Size(310, 30);
            this.txtruc.TabIndex = 63;
            this.txtruc.UseSelectable = true;
            this.txtruc.WaterMark = "Ej. 20552167466";
            this.txtruc.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtruc.WaterMarkFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtruc.TextChanged += new System.EventHandler(this.txtruc_TextChanged);
            // 
            // txtRazonSocial
            // 
            // 
            // 
            // 
            this.txtRazonSocial.CustomButton.Image = null;
            this.txtRazonSocial.CustomButton.Location = new System.Drawing.Point(282, 2);
            this.txtRazonSocial.CustomButton.Name = "";
            this.txtRazonSocial.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtRazonSocial.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRazonSocial.CustomButton.TabIndex = 1;
            this.txtRazonSocial.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRazonSocial.CustomButton.UseSelectable = true;
            this.txtRazonSocial.CustomButton.Visible = false;
            this.txtRazonSocial.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtRazonSocial.Lines = new string[0];
            this.txtRazonSocial.Location = new System.Drawing.Point(17, 103);
            this.txtRazonSocial.MaxLength = 32767;
            this.txtRazonSocial.Multiline = true;
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.PasswordChar = '\0';
            this.txtRazonSocial.WaterMark = "Ej. ALMIK SAC";
            this.txtRazonSocial.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRazonSocial.SelectedText = "";
            this.txtRazonSocial.SelectionLength = 0;
            this.txtRazonSocial.SelectionStart = 0;
            this.txtRazonSocial.ShortcutsEnabled = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(310, 30);
            this.txtRazonSocial.TabIndex = 62;
            this.txtRazonSocial.UseSelectable = true;
            this.txtRazonSocial.WaterMark = "Ej. ALMIK SAC";
            this.txtRazonSocial.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRazonSocial.WaterMarkFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // pbreniec
            // 
      //      this.pbreniec.Image = global::_3mpacador4.Properties.Resources.Sunat_Logo_Vector;
            this.pbreniec.Location = new System.Drawing.Point(12, 3);
            this.pbreniec.Name = "pbreniec";
            this.pbreniec.Size = new System.Drawing.Size(163, 62);
            this.pbreniec.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbreniec.TabIndex = 61;
            this.pbreniec.TabStop = false;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(512, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 29);
            this.button1.TabIndex = 60;
            this.button1.Text = "Validar RUC";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmAltaRUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 293);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.KeyPreview = true;
            this.Name = "frmAltaRUC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmPersonaJuridica_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbreniec)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label lbltitulo;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Button btnGuardar;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal MetroFramework.Controls.MetroTextBox txtdireccion;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pbreniec;
        internal MetroFramework.Controls.MetroTextBox txtRazonSocial;
        internal MetroFramework.Controls.MetroTextBox txtruc;
    }
}