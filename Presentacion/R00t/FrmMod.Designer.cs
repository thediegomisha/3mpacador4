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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datalistado.DefaultCellStyle = dataGridViewCellStyle2;
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
            this.label2.Location = new System.Drawing.Point(12, 56);
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
            this.label3.Location = new System.Drawing.Point(12, 86);
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
            this.label4.Location = new System.Drawing.Point(12, 115);
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
            this.label5.Location = new System.Drawing.Point(12, 144);
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
            this.label6.Location = new System.Drawing.Point(12, 173);
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
            this.label7.Location = new System.Drawing.Point(12, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "CLP";
            // 
            // chklote
            // 
            this.chklote.AutoSize = true;
            this.chklote.Location = new System.Drawing.Point(364, 58);
            this.chklote.Name = "chklote";
            this.chklote.Size = new System.Drawing.Size(15, 14);
            this.chklote.TabIndex = 18;
            this.chklote.UseVisualStyleBackColor = true;
            // 
            // chknumguia
            // 
            this.chknumguia.AutoSize = true;
            this.chknumguia.Location = new System.Drawing.Point(364, 85);
            this.chknumguia.Name = "chknumguia";
            this.chknumguia.Size = new System.Drawing.Size(15, 14);
            this.chknumguia.TabIndex = 19;
            this.chknumguia.UseVisualStyleBackColor = true;
            // 
            // chknumdoc
            // 
            this.chknumdoc.AutoSize = true;
            this.chknumdoc.Location = new System.Drawing.Point(364, 117);
            this.chknumdoc.Name = "chknumdoc";
            this.chknumdoc.Size = new System.Drawing.Size(15, 14);
            this.chknumdoc.TabIndex = 20;
            this.chknumdoc.UseVisualStyleBackColor = true;
            // 
            // chkexportador
            // 
            this.chkexportador.AutoSize = true;
            this.chkexportador.Location = new System.Drawing.Point(364, 148);
            this.chkexportador.Name = "chkexportador";
            this.chkexportador.Size = new System.Drawing.Size(15, 14);
            this.chkexportador.TabIndex = 21;
            this.chkexportador.UseVisualStyleBackColor = true;
            // 
            // chkproductor
            // 
            this.chkproductor.AutoSize = true;
            this.chkproductor.Location = new System.Drawing.Point(364, 175);
            this.chkproductor.Name = "chkproductor";
            this.chkproductor.Size = new System.Drawing.Size(15, 14);
            this.chkproductor.TabIndex = 22;
            this.chkproductor.UseVisualStyleBackColor = true;
            // 
            // chkclp
            // 
            this.chkclp.AutoSize = true;
            this.chkclp.Location = new System.Drawing.Point(364, 206);
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
            // FrmMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(616, 497);
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
    }
}