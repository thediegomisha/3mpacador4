namespace _3mpacador4.Presentacion.Sistema
{
    partial class FrmReniec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReniec));
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnprobar = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtservidor = new System.Windows.Forms.TextBox();
            this.txttoken = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
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
            this.PictureBox1.Location = new System.Drawing.Point(199, 25);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(186, 111);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 21;
            this.PictureBox1.TabStop = false;
            // 
            // btnprobar
            // 
            this.btnprobar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprobar.Location = new System.Drawing.Point(177, 249);
            this.btnprobar.Name = "btnprobar";
            this.btnprobar.Size = new System.Drawing.Size(137, 24);
            this.btnprobar.TabIndex = 6;
            this.btnprobar.Text = "&Probar Conexion";
            this.btnprobar.UseVisualStyleBackColor = true;
           // this.btnprobar.Click += new System.EventHandler(this.btnprobar_Click);
            this.btnprobar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnprobar_KeyPress);
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Red;
            this.Label5.Location = new System.Drawing.Point(6, 6);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(296, 33);
            this.Label5.TabIndex = 6;
            this.Label5.Text = "Cambiar la configuracion del Servidor de la RENIEC";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.PictureBox1);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Location = new System.Drawing.Point(12, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(391, 142);
            this.GroupBox1.TabIndex = 17;
            this.GroupBox1.TabStop = false;
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(6, 39);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(201, 100);
            this.Label6.TabIndex = 6;
            this.Label6.Text = "Advertencia! :  La modificacion de la configuracion del Servidor de Acceso a la R" +
    "ENIEC, puede hacer que la aplicacion no funcione correctamente. Utilizar con cui" +
    "dado.";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(10, 51);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(54, 15);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "Token :";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(6, 28);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(68, 15);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Servidor :";
            // 
            // txtservidor
            // 
            this.txtservidor.Location = new System.Drawing.Point(84, 24);
            this.txtservidor.Name = "txtservidor";
            this.txtservidor.Size = new System.Drawing.Size(292, 22);
            this.txtservidor.TabIndex = 0;
            this.txtservidor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtservidor_KeyPress);
            // 
            // txttoken
            // 
            this.txttoken.Location = new System.Drawing.Point(84, 52);
            this.txttoken.Name = "txttoken";
            this.txttoken.Size = new System.Drawing.Size(292, 22);
            this.txttoken.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(21, 249);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(121, 24);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "&Guardar Conexion";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.Label2);
            this.GroupBox2.Controls.Add(this.Label1);
            this.GroupBox2.Controls.Add(this.txtservidor);
            this.GroupBox2.Controls.Add(this.txttoken);
            this.GroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox2.Location = new System.Drawing.Point(21, 151);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(383, 92);
            this.GroupBox2.TabIndex = 18;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Configuracion Actual";
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cerrar.Location = new System.Drawing.Point(340, 249);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(57, 24);
            this.btn_cerrar.TabIndex = 1;
            this.btn_cerrar.Text = "&Salir";
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // FrmReniec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 289);
            this.Controls.Add(this.btnprobar);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.btn_cerrar);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReniec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtservidor;
        internal System.Windows.Forms.TextBox txttoken;
        internal System.Windows.Forms.Button btnGuardar;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button btn_cerrar;
    }
}