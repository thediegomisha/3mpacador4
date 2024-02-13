namespace _3mpacador4.Presentacion.Mantenimiento
{
    partial class FrmPrinter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrinter));
            this.List_Printer = new System.Windows.Forms.ListBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.lblprinter_choose = new System.Windows.Forms.Label();
            this.btn_selecciona = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // List_Printer
            // 
            this.List_Printer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.List_Printer.FormattingEnabled = true;
            this.List_Printer.ItemHeight = 15;
            this.List_Printer.Location = new System.Drawing.Point(12, 30);
            this.List_Printer.Name = "List_Printer";
            this.List_Printer.Size = new System.Drawing.Size(255, 94);
            this.List_Printer.TabIndex = 1;
            this.List_Printer.DoubleClick += new System.EventHandler(this.List_Printer_DoubleClick);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(12, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(255, 15);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Lista de Impresoras  Instaladas en el Sistema";
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(342, 12);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(100, 55);
            this.Label3.TabIndex = 5;
            this.Label3.Text = "Impresora elegida para imprimir";
            // 
            // lblprinter_choose
            // 
            this.lblprinter_choose.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprinter_choose.ForeColor = System.Drawing.Color.Blue;
            this.lblprinter_choose.Location = new System.Drawing.Point(273, 82);
            this.lblprinter_choose.Name = "lblprinter_choose";
            this.lblprinter_choose.Size = new System.Drawing.Size(160, 42);
            this.lblprinter_choose.TabIndex = 6;
            this.lblprinter_choose.Text = "Label2";
            // 
            // btn_selecciona
            // 
            this.btn_selecciona.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_selecciona.Location = new System.Drawing.Point(32, 141);
            this.btn_selecciona.Name = "btn_selecciona";
            this.btn_selecciona.Size = new System.Drawing.Size(150, 34);
            this.btn_selecciona.TabIndex = 7;
            this.btn_selecciona.Text = "Seleccionar &Impresora";
            this.btn_selecciona.UseVisualStyleBackColor = true;
            this.btn_selecciona.Click += new System.EventHandler(this.btn_selecciona_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salir.Image = global::_3mpacador4.Properties.Resources.Button_Close_24x24_;
            this.btn_salir.Location = new System.Drawing.Point(264, 141);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(85, 34);
            this.btn_salir.TabIndex = 8;
            this.btn_salir.Text = "&Salir";
            this.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(273, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // FrmPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 182);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.btn_selecciona);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.lblprinter_choose);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.List_Printer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrinter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmPrinter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ListBox List_Printer;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label lblprinter_choose;
        internal System.Windows.Forms.Button btn_salir;
        internal System.Windows.Forms.Button btn_selecciona;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}