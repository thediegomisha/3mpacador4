namespace _3mpacador4.Presentacion.Mantenimiento
{
    partial class frmAltaDNI
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
            this.Panel = new System.Windows.Forms.Panel();
            this.lbltitulo = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtdni = new System.Windows.Forms.TextBox();
            this.txtnombres = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
         //   this.btnActualizar = new System.Windows.Forms.Button();
         // this.txtapel_paterno = new MetroFramework.Controls.MetroTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtapel_materno = new System.Windows.Forms.TextBox();
            this.txtapel_paterno = new System.Windows.Forms.TextBox();
            this.cbxreniec = new System.Windows.Forms.CheckBox();
            this.pbreniec = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxestado = new System.Windows.Forms.CheckBox();
        //  this.txtapel_materno = new MetroFramework.Controls.MetroTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnActualizar = new Glass.GlassButton();
            this.btnCancelar = new Glass.GlassButton();
            this.btnGuardar = new Glass.GlassButton();
       //   this.Panel1.SuspendLayout();
            this.Panel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbreniec)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Panel.Controls.Add(this.lbltitulo);
            this.Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(718, 41);
            this.Panel.TabIndex = 32;
            // 
            // lbltitulo
            // 
            this.lbltitulo.AutoSize = true;
            this.lbltitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitulo.ForeColor = System.Drawing.Color.White;
            this.lbltitulo.Location = new System.Drawing.Point(12, 9);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(189, 21);
            this.lbltitulo.TabIndex = 0;
            this.lbltitulo.Text = "Ingreso de Colaborador";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(45, 142);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(158, 21);
            this.Label4.TabIndex = 41;
            this.Label4.Text = "APELLIDO PATERNO :";
            // 
            // txtdni
            // 
            this.txtdni.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdni.Location = new System.Drawing.Point(220, 42);
            this.txtdni.MaxLength = 10;
            this.txtdni.Name = "txtdni";
            this.txtdni.Size = new System.Drawing.Size(189, 29);
            this.txtdni.TabIndex = 1;
            this.txtdni.TextChanged += new System.EventHandler(this.txtdni_TextChanged);
            // 
            // txtnombres
            // 
            this.txtnombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtnombres.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombres.Location = new System.Drawing.Point(48, 107);
            this.txtnombres.Name = "txtnombres";
            this.txtnombres.Size = new System.Drawing.Size(635, 29);
            this.txtnombres.TabIndex = 1;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(216, 18);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(44, 21);
            this.Label3.TabIndex = 33;
            this.Label3.Text = "DNI :";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(45, 83);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(91, 21);
            this.Label2.TabIndex = 34;
            this.Label2.Text = "NOMBRES :";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(449, 321);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(82, 29);
            this.btnActualizar.TabIndex = 38;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // txtapel_paterno
            // 
            this.txtapel_paterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // 
            // 
            //this.txtapel_paterno.CustomButton.Image = null;
            //this.txtapel_paterno.CustomButton.Location = new System.Drawing.Point(278, 1);
            //this.txtapel_paterno.CustomButton.Name = "";
            //this.txtapel_paterno.CustomButton.Size = new System.Drawing.Size(27, 27);
            //this.txtapel_paterno.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            //this.txtapel_paterno.CustomButton.TabIndex = 1;
            //this.txtapel_paterno.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            //this.txtapel_paterno.CustomButton.UseSelectable = true;
            //this.txtapel_paterno.CustomButton.Visible = false;
            //this.txtapel_paterno.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            //this.txtapel_paterno.Lines = new string[0];
            //this.txtapel_paterno.Location = new System.Drawing.Point(49, 167);
            //this.txtapel_paterno.MaxLength = 32767;
            //this.txtapel_paterno.Name = "txtapel_paterno";
            //this.txtapel_paterno.PasswordChar = '\0';
            //this.txtapel_paterno.ScrollBars = System.Windows.Forms.ScrollBars.None;
            //this.txtapel_paterno.SelectedText = "";
            //this.txtapel_paterno.SelectionLength = 0;
            //this.txtapel_paterno.SelectionStart = 0;
            //this.txtapel_paterno.ShortcutsEnabled = true;
            //this.txtapel_paterno.Size = new System.Drawing.Size(306, 29);
            //this.txtapel_paterno.TabIndex = 49;
            //this.txtapel_paterno.UseSelectable = true;
            //this.txtapel_paterno.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            //this.txtapel_paterno.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //// 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbxreniec);
            this.panel2.Controls.Add(this.pbreniec);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cbxestado);
            this.panel2.Controls.Add(this.txtapel_materno);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtapel_paterno);
            this.panel2.Controls.Add(this.Label4);
            this.panel2.Controls.Add(this.txtdni);
            this.panel2.Controls.Add(this.txtnombres);
            this.panel2.Controls.Add(this.Label3);
            this.panel2.Controls.Add(this.Label2);
            this.panel2.Location = new System.Drawing.Point(-1, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(718, 242);
            this.panel2.TabIndex = 0;
            // 
            // txtapel_materno
            // 
            this.txtapel_materno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtapel_materno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtapel_materno.Location = new System.Drawing.Point(374, 167);
            this.txtapel_materno.Name = "txtapel_materno";
            this.txtapel_materno.Size = new System.Drawing.Size(309, 29);
            this.txtapel_materno.TabIndex = 50;
            // 
            // txtapel_paterno
            // 
            this.txtapel_paterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtapel_paterno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtapel_paterno.Location = new System.Drawing.Point(49, 167);
            this.txtapel_paterno.Name = "txtapel_paterno";
            this.txtapel_paterno.Size = new System.Drawing.Size(306, 29);
            this.txtapel_paterno.TabIndex = 49;
            // 
            // cbxreniec
            // 
            this.cbxreniec.AutoSize = true;
            this.cbxreniec.Checked = true;
            this.cbxreniec.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxreniec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxreniec.Location = new System.Drawing.Point(123, 51);
            this.cbxreniec.Name = "cbxreniec";
            this.cbxreniec.Size = new System.Drawing.Size(82, 20);
            this.cbxreniec.TabIndex = 48;
            this.cbxreniec.Text = "RENIEC";
            this.cbxreniec.UseVisualStyleBackColor = true;
            this.cbxreniec.CheckedChanged += new System.EventHandler(this.cbxreniec_CheckedChanged);
            // 
            // pbreniec
            // 
            this.pbreniec.Image = global::_3mpacador4.Properties.Resources.reniec;
            this.pbreniec.Location = new System.Drawing.Point(48, 9);
            this.pbreniec.Name = "pbreniec";
            this.pbreniec.Size = new System.Drawing.Size(67, 62);
            this.pbreniec.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbreniec.TabIndex = 47;
            this.pbreniec.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(45, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 21);
            this.label6.TabIndex = 46;
            this.label6.Text = "ESTADO :";
            // 
            // cbxestado
            // 
            this.cbxestado.AutoSize = true;
            this.cbxestado.Checked = true;
            this.cbxestado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxestado.Location = new System.Drawing.Point(121, 210);
            this.cbxestado.Name = "cbxestado";
            this.cbxestado.Size = new System.Drawing.Size(15, 14);
            this.cbxestado.TabIndex = 4;
            this.cbxestado.UseVisualStyleBackColor = true;
            this.cbxestado.CheckedChanged += new System.EventHandler(this.cbxestado_CheckedChanged);
            // 
            // txtapel_materno
            // 
            this.txtapel_materno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // 
            // 
            //this.txtapel_materno.CustomButton.Image = null;
            //this.txtapel_materno.CustomButton.Location = new System.Drawing.Point(281, 1);
            //this.txtapel_materno.CustomButton.Name = "";
            //this.txtapel_materno.CustomButton.Size = new System.Drawing.Size(27, 27);
            //this.txtapel_materno.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            //this.txtapel_materno.CustomButton.TabIndex = 1;
            //this.txtapel_materno.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            //this.txtapel_materno.CustomButton.UseSelectable = true;
            //this.txtapel_materno.CustomButton.Visible = false;
            //this.txtapel_materno.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            //this.txtapel_materno.Lines = new string[0];
            //this.txtapel_materno.Location = new System.Drawing.Point(374, 167);
            //this.txtapel_materno.MaxLength = 32767;
            //this.txtapel_materno.Name = "txtapel_materno";
            //this.txtapel_materno.PasswordChar = '\0';
            //this.txtapel_materno.ScrollBars = System.Windows.Forms.ScrollBars.None;
            //this.txtapel_materno.SelectedText = "";
            //this.txtapel_materno.SelectionLength = 0;
            //this.txtapel_materno.SelectionStart = 0;
            //this.txtapel_materno.ShortcutsEnabled = true;
            //this.txtapel_materno.Size = new System.Drawing.Size(309, 29);
            //this.txtapel_materno.TabIndex = 50;
            //this.txtapel_materno.UseSelectable = true;
            //this.txtapel_materno.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            //this.txtapel_materno.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //// 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(370, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 21);
            this.label5.TabIndex = 43;
            this.label5.Text = "APELLIDO MATERNO :";
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.Blue;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.Image = global::_3mpacador4.Properties.Resources.update;
            this.btnActualizar.Location = new System.Drawing.Point(184, 310);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.OuterBorderColor = System.Drawing.Color.Blue;
            this.btnActualizar.ShineColor = System.Drawing.Color.Navy;
            this.btnActualizar.Size = new System.Drawing.Size(140, 40);
            this.btnActualizar.TabIndex = 95;
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
            this.btnCancelar.Location = new System.Drawing.Point(543, 310);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.OuterBorderColor = System.Drawing.Color.Red;
            this.btnCancelar.ShineColor = System.Drawing.Color.RoyalBlue;
            this.btnCancelar.Size = new System.Drawing.Size(139, 40);
            this.btnCancelar.TabIndex = 93;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Blue;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Image = global::_3mpacador4.Properties.Resources.save;
            this.btnGuardar.Location = new System.Drawing.Point(36, 310);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.OuterBorderColor = System.Drawing.Color.Blue;
            this.btnGuardar.ShineColor = System.Drawing.Color.Navy;
            this.btnGuardar.Size = new System.Drawing.Size(140, 40);
            this.btnGuardar.TabIndex = 94;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmColaborador2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 368);
            this.ControlBox = false;
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnActualizar);
            this.Name = "frmAltaDNI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmPersonaJuridica_Load);
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbreniec)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel;
        internal System.Windows.Forms.Label lbltitulo;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtdni;
        internal System.Windows.Forms.TextBox txtnombres;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
     //   internal System.Windows.Forms.Button btnActualizar;
   //   internal MetroFramework.Controls.MetroTextBox txtapel_paterno;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbxestado;
 //     internal MetroFramework.Controls.MetroTextBox txtapel_materno;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbxreniec;
        private System.Windows.Forms.PictureBox pbreniec;
        internal System.Windows.Forms.TextBox txtapel_paterno;
        internal System.Windows.Forms.TextBox txtapel_materno;
        private Glass.GlassButton btnActualizar;
        private Glass.GlassButton btnCancelar;
        private Glass.GlassButton btnGuardar;
        //internal System.Windows.Forms.TextBox txtapel_paterno;
        //internal System.Windows.Forms.TextBox txtapel_materno;
    }
}