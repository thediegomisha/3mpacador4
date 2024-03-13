namespace _3mpacador4.Presentacion.Sistema
{
    partial class FrmConexion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConexion));
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnprobar = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.lbl_Port = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.txttime = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblDataBase = new System.Windows.Forms.Label();
            this.txtservidor = new System.Windows.Forms.TextBox();
            this.txtusuario = new System.Windows.Forms.TextBox();
            this.txtBd = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtunicode = new System.Windows.Forms.TextBox();
            this.btn_cerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBox1
            // 
            this.PictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("PictureBox1.ErrorImage")));
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(9, 12);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(88, 116);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 21;
            this.PictureBox1.TabStop = false;
            // 
            // btnprobar
            // 
            this.btnprobar.BackColor = System.Drawing.Color.Teal;
            this.btnprobar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprobar.ForeColor = System.Drawing.Color.White;
            this.btnprobar.Location = new System.Drawing.Point(161, 217);
            this.btnprobar.Name = "btnprobar";
            this.btnprobar.Size = new System.Drawing.Size(137, 33);
            this.btnprobar.TabIndex = 6;
            this.btnprobar.Text = "&Probar Conexion";
            this.btnprobar.UseVisualStyleBackColor = false;
            this.btnprobar.Click += new System.EventHandler(this.btnprobar_Click);
            this.btnprobar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnprobar_KeyPress);
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Red;
            this.Label5.Location = new System.Drawing.Point(8, 9);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(212, 33);
            this.Label5.TabIndex = 6;
            this.Label5.Text = "Cambiar la configuracion del Servidor MySQL";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Location = new System.Drawing.Point(103, 4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(220, 124);
            this.GroupBox1.TabIndex = 17;
            this.GroupBox1.TabStop = false;
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(6, 41);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(231, 80);
            this.Label6.TabIndex = 6;
            this.Label6.Text = "Advertencia! :  La modificacion de la configuracion del Servidor MySQL, puede hac" +
    "er que la aplicacion no funcione correctamente. Utilizar con cuidado.";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(16, 133);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(115, 15);
            this.Label7.TabIndex = 11;
            this.Label7.Text = "Time Conection :";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(38, 73);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(88, 15);
            this.Label3.TabIndex = 8;
            this.Label3.Text = "Contraseña :";
            // 
            // lbl_Port
            // 
            this.lbl_Port.AutoSize = true;
            this.lbl_Port.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Port.Location = new System.Drawing.Point(65, 165);
            this.lbl_Port.Name = "lbl_Port";
            this.lbl_Port.Size = new System.Drawing.Size(61, 15);
            this.lbl_Port.TabIndex = 9;
            this.lbl_Port.Text = "Puerto : ";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(59, 45);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(65, 15);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "Usuario :";
            // 
            // txttime
            // 
            this.txttime.Location = new System.Drawing.Point(133, 129);
            this.txttime.Name = "txttime";
            this.txttime.Size = new System.Drawing.Size(165, 22);
            this.txttime.TabIndex = 4;
            this.txttime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttime_KeyPress);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(55, 22);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(68, 15);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Servidor :";
            // 
            // txtpass
            // 
            this.txtpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpass.Location = new System.Drawing.Point(133, 74);
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '*';
            this.txtpass.Size = new System.Drawing.Size(165, 21);
            this.txtpass.TabIndex = 2;
            this.txtpass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpass_KeyPress);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(133, 161);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(165, 22);
            this.txtPort.TabIndex = 5;
            this.txtPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPort_KeyPress);
            // 
            // lblDataBase
            // 
            this.lblDataBase.AutoSize = true;
            this.lblDataBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataBase.Location = new System.Drawing.Point(18, 103);
            this.lblDataBase.Name = "lblDataBase";
            this.lblDataBase.Size = new System.Drawing.Size(112, 15);
            this.lblDataBase.TabIndex = 9;
            this.lblDataBase.Text = "Base de Datos : ";
            // 
            // txtservidor
            // 
            this.txtservidor.Location = new System.Drawing.Point(133, 18);
            this.txtservidor.Name = "txtservidor";
            this.txtservidor.Size = new System.Drawing.Size(165, 22);
            this.txtservidor.TabIndex = 0;
            this.txtservidor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtservidor_KeyPress);
            // 
            // txtusuario
            // 
            this.txtusuario.Location = new System.Drawing.Point(133, 46);
            this.txtusuario.Name = "txtusuario";
            this.txtusuario.Size = new System.Drawing.Size(165, 22);
            this.txtusuario.TabIndex = 1;
            this.txtusuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtusuario_KeyPress);
            // 
            // txtBd
            // 
            this.txtBd.Location = new System.Drawing.Point(133, 101);
            this.txtBd.Name = "txtBd";
            this.txtBd.Size = new System.Drawing.Size(165, 22);
            this.txtBd.TabIndex = 3;
            this.txtBd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBd_KeyPress);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Teal;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(112, 390);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(121, 31);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "&Guardar Conexion";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.label4);
            this.GroupBox2.Controls.Add(this.txtunicode);
            this.GroupBox2.Controls.Add(this.Label7);
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.btnprobar);
            this.GroupBox2.Controls.Add(this.lbl_Port);
            this.GroupBox2.Controls.Add(this.Label2);
            this.GroupBox2.Controls.Add(this.txttime);
            this.GroupBox2.Controls.Add(this.Label1);
            this.GroupBox2.Controls.Add(this.txtpass);
            this.GroupBox2.Controls.Add(this.txtPort);
            this.GroupBox2.Controls.Add(this.lblDataBase);
            this.GroupBox2.Controls.Add(this.txtservidor);
            this.GroupBox2.Controls.Add(this.txtusuario);
            this.GroupBox2.Controls.Add(this.txtBd);
            this.GroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox2.Location = new System.Drawing.Point(9, 134);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(314, 250);
            this.GroupBox2.TabIndex = 18;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Configuracion Actual";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(58, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Unicode : ";
            // 
            // txtunicode
            // 
            this.txtunicode.Location = new System.Drawing.Point(133, 189);
            this.txtunicode.Name = "txtunicode";
            this.txtunicode.Size = new System.Drawing.Size(165, 22);
            this.txtunicode.TabIndex = 12;
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_cerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cerrar.ForeColor = System.Drawing.Color.White;
            this.btn_cerrar.Location = new System.Drawing.Point(250, 390);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(57, 31);
            this.btn_cerrar.TabIndex = 1;
            this.btn_cerrar.Text = "&Salir";
            this.btn_cerrar.UseVisualStyleBackColor = false;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // FrmConexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 424);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.btn_cerrar);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmConexion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConexion_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Button btnprobar;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label lbl_Port;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txttime;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtpass;
        internal System.Windows.Forms.TextBox txtPort;
        internal System.Windows.Forms.Label lblDataBase;
        internal System.Windows.Forms.TextBox txtservidor;
        internal System.Windows.Forms.TextBox txtusuario;
        internal System.Windows.Forms.TextBox txtBd;
        internal System.Windows.Forms.Button btnGuardar;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button btn_cerrar;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtunicode;
    }
}