namespace _3mpacador4.Presentacion.R00t
{
    partial class FrmMod
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
            this.btnExaminar = new System.Windows.Forms.Button();
            this.btnSubirDoc = new System.Windows.Forms.Button();
            this.datalistado = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chklote = new System.Windows.Forms.CheckBox();
            this.chknumguia = new System.Windows.Forms.CheckBox();
            this.chknumdoc = new System.Windows.Forms.CheckBox();
            this.chkexportador = new System.Windows.Forms.CheckBox();
            this.chkproductor = new System.Windows.Forms.CheckBox();
            this.chkclp = new System.Windows.Forms.CheckBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lbllote = new System.Windows.Forms.Label();
            this.lblnum_guia = new System.Windows.Forms.Label();
            this.lblnumdoc = new System.Windows.Forms.Label();
            this.lblexportador = new System.Windows.Forms.Label();
            this.lblproductor = new System.Windows.Forms.Label();
            this.lblclp = new System.Windows.Forms.Label();
            this.cbcliente = new System.Windows.Forms.ComboBox();
            this.txtnumdoc = new System.Windows.Forms.TextBox();
            this.txtnumguia = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.datalistado)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExaminar
            // 
            this.btnExaminar.BackColor = System.Drawing.Color.Teal;
            this.btnExaminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExaminar.ForeColor = System.Drawing.Color.White;
            this.btnExaminar.Location = new System.Drawing.Point(288, 5);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(91, 31);
            this.btnExaminar.TabIndex = 6;
            this.btnExaminar.Text = "ACEPTAR";
            this.btnExaminar.UseVisualStyleBackColor = false;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // btnSubirDoc
            // 
            this.btnSubirDoc.BackColor = System.Drawing.Color.Teal;
            this.btnSubirDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubirDoc.ForeColor = System.Drawing.Color.White;
            this.btnSubirDoc.Location = new System.Drawing.Point(421, 326);
            this.btnSubirDoc.Name = "btnSubirDoc";
            this.btnSubirDoc.Size = new System.Drawing.Size(122, 38);
            this.btnSubirDoc.TabIndex = 8;
            this.btnSubirDoc.Text = "SUBIR DOCUMENTOS";
            this.btnSubirDoc.UseVisualStyleBackColor = false;
            this.btnSubirDoc.Click += new System.EventHandler(this.btnSubirDoc_Click);
            // 
            // datalistado
            // 
            this.datalistado.AllowUserToAddRows = false;
            this.datalistado.AllowUserToDeleteRows = false;
            this.datalistado.BackgroundColor = System.Drawing.Color.White;
            this.datalistado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datalistado.DefaultCellStyle = dataGridViewCellStyle1;
            this.datalistado.Location = new System.Drawing.Point(12, 326);
            this.datalistado.Name = "datalistado";
            this.datalistado.ReadOnly = true;
            this.datalistado.RowHeadersVisible = false;
            this.datalistado.Size = new System.Drawing.Size(403, 159);
            this.datalistado.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ingrese N° de lote";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(171, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "N° LOTE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "NUM GUIA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(12, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "NUMDOC";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(12, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "EXPORTADOR";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Yellow;
            this.label6.Location = new System.Drawing.Point(12, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "PRODUCTOR";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Yellow;
            this.label7.Location = new System.Drawing.Point(12, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "CLP";
            // 
            // chklote
            // 
            this.chklote.AutoSize = true;
            this.chklote.Location = new System.Drawing.Point(562, 45);
            this.chklote.Name = "chklote";
            this.chklote.Size = new System.Drawing.Size(15, 14);
            this.chklote.TabIndex = 18;
            this.chklote.UseVisualStyleBackColor = true;
            // 
            // chknumguia
            // 
            this.chknumguia.AutoSize = true;
            this.chknumguia.Location = new System.Drawing.Point(562, 72);
            this.chknumguia.Name = "chknumguia";
            this.chknumguia.Size = new System.Drawing.Size(15, 14);
            this.chknumguia.TabIndex = 19;
            this.chknumguia.UseVisualStyleBackColor = true;
            // 
            // chknumdoc
            // 
            this.chknumdoc.AutoSize = true;
            this.chknumdoc.Location = new System.Drawing.Point(562, 104);
            this.chknumdoc.Name = "chknumdoc";
            this.chknumdoc.Size = new System.Drawing.Size(15, 14);
            this.chknumdoc.TabIndex = 20;
            this.chknumdoc.UseVisualStyleBackColor = true;
            // 
            // chkexportador
            // 
            this.chkexportador.AutoSize = true;
            this.chkexportador.Location = new System.Drawing.Point(562, 135);
            this.chkexportador.Name = "chkexportador";
            this.chkexportador.Size = new System.Drawing.Size(15, 14);
            this.chkexportador.TabIndex = 21;
            this.chkexportador.UseVisualStyleBackColor = true;
            // 
            // chkproductor
            // 
            this.chkproductor.AutoSize = true;
            this.chkproductor.Location = new System.Drawing.Point(562, 162);
            this.chkproductor.Name = "chkproductor";
            this.chkproductor.Size = new System.Drawing.Size(15, 14);
            this.chkproductor.TabIndex = 22;
            this.chkproductor.UseVisualStyleBackColor = true;
            // 
            // chkclp
            // 
            this.chkclp.AutoSize = true;
            this.chkclp.Location = new System.Drawing.Point(562, 193);
            this.chkclp.Name = "chkclp";
            this.chkclp.Size = new System.Drawing.Size(15, 14);
            this.chkclp.TabIndex = 23;
            this.chkclp.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Black;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Yellow;
            this.btnCancelar.Location = new System.Drawing.Point(385, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 31);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lbllote
            // 
            this.lbllote.AutoSize = true;
            this.lbllote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllote.ForeColor = System.Drawing.Color.Lime;
            this.lbllote.Location = new System.Drawing.Point(137, 45);
            this.lbllote.Name = "lbllote";
            this.lbllote.Size = new System.Drawing.Size(46, 16);
            this.lbllote.TabIndex = 25;
            this.lbllote.Text = "LOTE";
            // 
            // lblnum_guia
            // 
            this.lblnum_guia.AutoSize = true;
            this.lblnum_guia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnum_guia.ForeColor = System.Drawing.Color.Lime;
            this.lblnum_guia.Location = new System.Drawing.Point(137, 75);
            this.lblnum_guia.Name = "lblnum_guia";
            this.lblnum_guia.Size = new System.Drawing.Size(81, 16);
            this.lblnum_guia.TabIndex = 26;
            this.lblnum_guia.Text = "NUM GUIA";
            // 
            // lblnumdoc
            // 
            this.lblnumdoc.AutoSize = true;
            this.lblnumdoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnumdoc.ForeColor = System.Drawing.Color.Lime;
            this.lblnumdoc.Location = new System.Drawing.Point(137, 106);
            this.lblnumdoc.Name = "lblnumdoc";
            this.lblnumdoc.Size = new System.Drawing.Size(73, 16);
            this.lblnumdoc.TabIndex = 27;
            this.lblnumdoc.Text = "NUMDOC";
            // 
            // lblexportador
            // 
            this.lblexportador.AutoSize = true;
            this.lblexportador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblexportador.ForeColor = System.Drawing.Color.Lime;
            this.lblexportador.Location = new System.Drawing.Point(137, 133);
            this.lblexportador.Name = "lblexportador";
            this.lblexportador.Size = new System.Drawing.Size(111, 16);
            this.lblexportador.TabIndex = 28;
            this.lblexportador.Text = "EXPORTADOR";
            // 
            // lblproductor
            // 
            this.lblproductor.AutoSize = true;
            this.lblproductor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblproductor.ForeColor = System.Drawing.Color.Lime;
            this.lblproductor.Location = new System.Drawing.Point(137, 162);
            this.lblproductor.Name = "lblproductor";
            this.lblproductor.Size = new System.Drawing.Size(103, 16);
            this.lblproductor.TabIndex = 29;
            this.lblproductor.Text = "PRODUCTOR";
            // 
            // lblclp
            // 
            this.lblclp.AutoSize = true;
            this.lblclp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblclp.ForeColor = System.Drawing.Color.Lime;
            this.lblclp.Location = new System.Drawing.Point(137, 193);
            this.lblclp.Name = "lblclp";
            this.lblclp.Size = new System.Drawing.Size(35, 16);
            this.lblclp.TabIndex = 30;
            this.lblclp.Text = "CLP";
            // 
            // cbcliente
            // 
            this.cbcliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbcliente.FormattingEnabled = true;
            this.cbcliente.Location = new System.Drawing.Point(584, 132);
            this.cbcliente.Margin = new System.Windows.Forms.Padding(4);
            this.cbcliente.Name = "cbcliente";
            this.cbcliente.Size = new System.Drawing.Size(231, 21);
            this.cbcliente.TabIndex = 59;
            // 
            // txtnumdoc
            // 
            this.txtnumdoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnumdoc.Location = new System.Drawing.Point(584, 99);
            this.txtnumdoc.Name = "txtnumdoc";
            this.txtnumdoc.Size = new System.Drawing.Size(91, 22);
            this.txtnumdoc.TabIndex = 60;
            // 
            // txtnumguia
            // 
            this.txtnumguia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnumguia.Location = new System.Drawing.Point(584, 67);
            this.txtnumguia.Name = "txtnumguia";
            this.txtnumguia.Size = new System.Drawing.Size(152, 22);
            this.txtnumguia.TabIndex = 61;
            // 
            // FrmMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(923, 497);
            this.Controls.Add(this.txtnumguia);
            this.Controls.Add(this.txtnumdoc);
            this.Controls.Add(this.cbcliente);
            this.Controls.Add(this.lblclp);
            this.Controls.Add(this.lblproductor);
            this.Controls.Add(this.lblexportador);
            this.Controls.Add(this.lblnumdoc);
            this.Controls.Add(this.lblnum_guia);
            this.Controls.Add(this.lbllote);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.chkclp);
            this.Controls.Add(this.chkproductor);
            this.Controls.Add(this.chkexportador);
            this.Controls.Add(this.chknumdoc);
            this.Controls.Add(this.chknumguia);
            this.Controls.Add(this.chklote);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datalistado);
            this.Controls.Add(this.btnSubirDoc);
            this.Controls.Add(this.btnExaminar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmMod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMod";
            ((System.ComponentModel.ISupportInitialize)(this.datalistado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.Button btnSubirDoc;
        private System.Windows.Forms.DataGridView datalistado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chklote;
        private System.Windows.Forms.CheckBox chknumguia;
        private System.Windows.Forms.CheckBox chknumdoc;
        private System.Windows.Forms.CheckBox chkexportador;
        private System.Windows.Forms.CheckBox chkproductor;
        private System.Windows.Forms.CheckBox chkclp;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lbllote;
        private System.Windows.Forms.Label lblnum_guia;
        private System.Windows.Forms.Label lblnumdoc;
        private System.Windows.Forms.Label lblexportador;
        private System.Windows.Forms.Label lblproductor;
        private System.Windows.Forms.Label lblclp;
        public System.Windows.Forms.ComboBox cbcliente;
        private System.Windows.Forms.TextBox txtnumdoc;
        private System.Windows.Forms.TextBox txtnumguia;
    }
}