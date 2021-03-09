
namespace EjemploStorageBLOB
{
    partial class Form1
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
            this.lblcontenedor = new System.Windows.Forms.Label();
            this.txtcontenedor = new System.Windows.Forms.TextBox();
            this.btncrear = new System.Windows.Forms.Button();
            this.btnsubir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lsvblobs = new System.Windows.Forms.ListView();
            this.Uri = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstcontenedores = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btndelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblcontenedor
            // 
            this.lblcontenedor.AutoSize = true;
            this.lblcontenedor.Location = new System.Drawing.Point(104, 48);
            this.lblcontenedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblcontenedor.Name = "lblcontenedor";
            this.lblcontenedor.Size = new System.Drawing.Size(110, 25);
            this.lblcontenedor.TabIndex = 0;
            this.lblcontenedor.Text = "contenedor";
            // 
            // txtcontenedor
            // 
            this.txtcontenedor.Location = new System.Drawing.Point(233, 48);
            this.txtcontenedor.Margin = new System.Windows.Forms.Padding(4);
            this.txtcontenedor.Name = "txtcontenedor";
            this.txtcontenedor.Size = new System.Drawing.Size(196, 30);
            this.txtcontenedor.TabIndex = 1;
            // 
            // btncrear
            // 
            this.btncrear.Location = new System.Drawing.Point(109, 121);
            this.btncrear.Margin = new System.Windows.Forms.Padding(4);
            this.btncrear.Name = "btncrear";
            this.btncrear.Size = new System.Drawing.Size(212, 50);
            this.btncrear.TabIndex = 2;
            this.btncrear.Text = "Crear contenedor";
            this.btncrear.UseVisualStyleBackColor = true;
            this.btncrear.Click += new System.EventHandler(this.btncrear_ClickAsync);
            // 
            // btnsubir
            // 
            this.btnsubir.Location = new System.Drawing.Point(109, 179);
            this.btnsubir.Margin = new System.Windows.Forms.Padding(4);
            this.btnsubir.Name = "btnsubir";
            this.btnsubir.Size = new System.Drawing.Size(212, 50);
            this.btnsubir.TabIndex = 3;
            this.btnsubir.Text = "Subir Blob";
            this.btnsubir.UseVisualStyleBackColor = true;
            this.btnsubir.Click += new System.EventHandler(this.btnsubir_ClickAsync);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(523, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // lsvblobs
            // 
            this.lsvblobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Uri,
            this.Size});
            this.lsvblobs.HideSelection = false;
            this.lsvblobs.Location = new System.Drawing.Point(85, 310);
            this.lsvblobs.Name = "lsvblobs";
            this.lsvblobs.Size = new System.Drawing.Size(662, 216);
            this.lsvblobs.TabIndex = 7;
            this.lsvblobs.UseCompatibleStateImageBehavior = false;
            this.lsvblobs.SelectedIndexChanged += new System.EventHandler(this.lsvblobs_SelectedIndexChanged);
            // 
            // Uri
            // 
            this.Uri.Text = "URI";
            // 
            // Size
            // 
            this.Size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lstcontenedores
            // 
            this.lstcontenedores.FormattingEnabled = true;
            this.lstcontenedores.ItemHeight = 25;
            this.lstcontenedores.Location = new System.Drawing.Point(528, 86);
            this.lstcontenedores.Name = "lstcontenedores";
            this.lstcontenedores.Size = new System.Drawing.Size(219, 204);
            this.lstcontenedores.TabIndex = 8;
            this.lstcontenedores.SelectedIndexChanged += new System.EventHandler(this.lstcontenedores_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(753, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(281, 488);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btndelete
            // 
            this.btndelete.ForeColor = System.Drawing.Color.Red;
            this.btndelete.Location = new System.Drawing.Point(109, 236);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(212, 50);
            this.btndelete.TabIndex = 10;
            this.btndelete.Text = "Eliminar blob";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 538);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lstcontenedores);
            this.Controls.Add(this.lsvblobs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnsubir);
            this.Controls.Add(this.btncrear);
            this.Controls.Add(this.txtcontenedor);
            this.Controls.Add(this.lblcontenedor);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblcontenedor;
        private System.Windows.Forms.TextBox txtcontenedor;
        private System.Windows.Forms.Button btncrear;
        private System.Windows.Forms.Button btnsubir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lsvblobs;
        private System.Windows.Forms.ColumnHeader Size;
        private System.Windows.Forms.ListBox lstcontenedores;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btndelete;
        public System.Windows.Forms.ColumnHeader Uri;
    }
}

