namespace _3mpacador4.Presentacion.Mantenimiento
{
    partial class frmEditProductor
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
            this.Label4 = new System.Windows.Forms.Label();
            this.txtnombreLugar = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtregion = new MetroFramework.Controls.MetroTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(48)))));
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(718, 41);
            this.Panel1.TabIndex = 32;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(12, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(186, 21);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Ingreso de Productores";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(27, 106);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(67, 21);
            this.Label4.TabIndex = 41;
            this.Label4.Text = "REGION";
            // 
            // txtnombreLugar
            // 
            this.txtnombreLugar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombreLugar.Location = new System.Drawing.Point(366, 48);
            this.txtnombreLugar.Name = "txtnombreLugar";
            this.txtnombreLugar.Size = new System.Drawing.Size(311, 29);
            this.txtnombreLugar.TabIndex = 40;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(610, 258);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(98, 29);
            this.btnCancelar.TabIndex = 36;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(439, 258);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(82, 29);
            this.btnEditar.TabIndex = 37;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(31, 48);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(311, 29);
            this.txtRazonSocial.TabIndex = 35;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(362, 24);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(160, 21);
            this.Label3.TabIndex = 33;
            this.Label3.Text = "NOMBRE DEL LUGAR";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(27, 24);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(120, 21);
            this.Label2.TabIndex = 34;
            this.Label2.Text = "RAZON SOCIAL";
            // 
            // txtregion
            // 
            // 
            // 
            // 
            this.txtregion.CustomButton.Image = null;
            this.txtregion.CustomButton.Location = new System.Drawing.Point(282, 2);
            this.txtregion.CustomButton.Name = "";
            this.txtregion.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtregion.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtregion.CustomButton.TabIndex = 1;
            this.txtregion.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtregion.CustomButton.UseSelectable = true;
            this.txtregion.CustomButton.Visible = false;
            this.txtregion.Lines = new string[0];
            this.txtregion.Location = new System.Drawing.Point(30, 130);
            this.txtregion.MaxLength = 32767;
            this.txtregion.Name = "txtregion";
            this.txtregion.PasswordChar = '\0';
            this.txtregion.PromptText = "Ej: Jiron Santa Rosa 711";
            this.txtregion.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtregion.SelectedText = "";
            this.txtregion.SelectionLength = 0;
            this.txtregion.SelectionStart = 0;
            this.txtregion.ShortcutsEnabled = true;
            this.txtregion.Size = new System.Drawing.Size(310, 30);
            this.txtregion.TabIndex = 42;
            this.txtregion.UseSelectable = true;
            this.txtregion.WaterMark = "Ej: Jiron Santa Rosa 711";
            this.txtregion.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtregion.WaterMarkFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtregion);
            this.panel2.Controls.Add(this.Label4);
            this.panel2.Controls.Add(this.txtnombreLugar);
            this.panel2.Controls.Add(this.txtRazonSocial);
            this.panel2.Controls.Add(this.Label3);
            this.panel2.Controls.Add(this.Label2);
            this.panel2.Location = new System.Drawing.Point(-1, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(718, 204);
            this.panel2.TabIndex = 59;
            // 
            // frmEditProductor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 293);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Name = "frmEditProductor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Button btnEditar;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox txtnombreLugar;
        public System.Windows.Forms.TextBox txtRazonSocial;
        public MetroFramework.Controls.MetroTextBox txtregion;
    }
}