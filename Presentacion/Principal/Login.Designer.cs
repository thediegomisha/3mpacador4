namespace _3mpacador4.Presentacion
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.cmd_Aceptar = new System.Windows.Forms.Button();
            this.cmd_cerrar = new System.Windows.Forms.Button();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.txtlogin = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_clave = new System.Windows.Forms.Label();
            this.Lbl_Usuario = new System.Windows.Forms.Label();
            this.lblversion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBox2
            // 
            this.PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox2.Image")));
            this.PictureBox2.Location = new System.Drawing.Point(126, 68);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(208, 233);
            this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox2.TabIndex = 10;
            this.PictureBox2.TabStop = false;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Cambria", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(25, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(412, 84);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "Sistema Integral de Gestion de Pesaje";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Red;
            this.Label3.Location = new System.Drawing.Point(28, 494);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(60, 16);
            this.Label3.TabIndex = 15;
            this.Label3.Text = "Version";
            // 
            // cmd_Aceptar
            // 
            this.cmd_Aceptar.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_Aceptar.Location = new System.Drawing.Point(51, 443);
            this.cmd_Aceptar.Name = "cmd_Aceptar";
            this.cmd_Aceptar.Size = new System.Drawing.Size(89, 29);
            this.cmd_Aceptar.TabIndex = 13;
            this.cmd_Aceptar.Text = "Aceptar";
            this.cmd_Aceptar.UseVisualStyleBackColor = true;
            this.cmd_Aceptar.Click += new System.EventHandler(this.cmd_Aceptar_Click);
            // 
            // cmd_cerrar
            // 
            this.cmd_cerrar.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_cerrar.Location = new System.Drawing.Point(298, 443);
            this.cmd_cerrar.Name = "cmd_cerrar";
            this.cmd_cerrar.Size = new System.Drawing.Size(84, 29);
            this.cmd_cerrar.TabIndex = 14;
            this.cmd_cerrar.Text = "Cerrar";
            this.cmd_cerrar.UseVisualStyleBackColor = true;
            this.cmd_cerrar.Click += new System.EventHandler(this.cmd_cerrar_Click);
            // 
            // txtpassword
            // 
            this.txtpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.Location = new System.Drawing.Point(135, 66);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(197, 22);
            this.txtpassword.TabIndex = 2;
            this.txtpassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpassword_KeyDown);
            // 
            // txtlogin
            // 
            this.txtlogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlogin.Location = new System.Drawing.Point(135, 31);
            this.txtlogin.Name = "txtlogin";
            this.txtlogin.Size = new System.Drawing.Size(197, 22);
            this.txtlogin.TabIndex = 1;
            this.txtlogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtlogin_KeyDown);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtpassword);
            this.GroupBox1.Controls.Add(this.lbl_clave);
            this.GroupBox1.Controls.Add(this.txtlogin);
            this.GroupBox1.Controls.Add(this.Lbl_Usuario);
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(31, 307);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(351, 114);
            this.GroupBox1.TabIndex = 12;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Acceso al Sistema";
            // 
            // lbl_clave
            // 
            this.lbl_clave.AutoSize = true;
            this.lbl_clave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_clave.Location = new System.Drawing.Point(17, 70);
            this.lbl_clave.Name = "lbl_clave";
            this.lbl_clave.Size = new System.Drawing.Size(111, 16);
            this.lbl_clave.TabIndex = 3;
            this.lbl_clave.Text = "CONTRASEÑA";
            // 
            // Lbl_Usuario
            // 
            this.Lbl_Usuario.AutoSize = true;
            this.Lbl_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Usuario.Location = new System.Drawing.Point(17, 31);
            this.Lbl_Usuario.Name = "Lbl_Usuario";
            this.Lbl_Usuario.Size = new System.Drawing.Size(75, 16);
            this.Lbl_Usuario.TabIndex = 1;
            this.Lbl_Usuario.Text = "USUARIO";
            // 
            // lblversion
            // 
            this.lblversion.AutoSize = true;
            this.lblversion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblversion.ForeColor = System.Drawing.Color.Red;
            this.lblversion.Location = new System.Drawing.Point(123, 494);
            this.lblversion.Name = "lblversion";
            this.lblversion.Size = new System.Drawing.Size(39, 16);
            this.lblversion.TabIndex = 16;
            this.lblversion.Text = "0.0.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(89, 494);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = ":";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 519);
            this.Controls.Add(this.PictureBox2);
            this.Controls.Add(this.lblversion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.cmd_Aceptar);
            this.Controls.Add(this.cmd_cerrar);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox PictureBox2;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button cmd_Aceptar;
        internal System.Windows.Forms.Button cmd_cerrar;
        internal System.Windows.Forms.TextBox txtpassword;
        internal System.Windows.Forms.TextBox txtlogin;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label lbl_clave;
        internal System.Windows.Forms.Label Lbl_Usuario;
        internal System.Windows.Forms.Label lblversion;
        internal System.Windows.Forms.Label label1;
    }
}