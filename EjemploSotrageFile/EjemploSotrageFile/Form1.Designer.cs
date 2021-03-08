
namespace EjemploSotrageFile
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
            this.botonleerfile = new System.Windows.Forms.Button();
            this.txtcontenido = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // botonleerfile
            // 
            this.botonleerfile.Location = new System.Drawing.Point(44, 82);
            this.botonleerfile.Name = "botonleerfile";
            this.botonleerfile.Size = new System.Drawing.Size(265, 37);
            this.botonleerfile.TabIndex = 0;
            this.botonleerfile.Text = "Leer fichero Azure";
            this.botonleerfile.UseVisualStyleBackColor = true;
            this.botonleerfile.Click += new System.EventHandler(this.botonleerfile_Click);
            // 
            // txtcontenido
            // 
            this.txtcontenido.Location = new System.Drawing.Point(44, 125);
            this.txtcontenido.Name = "txtcontenido";
            this.txtcontenido.Size = new System.Drawing.Size(265, 184);
            this.txtcontenido.TabIndex = 1;
            this.txtcontenido.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 349);
            this.Controls.Add(this.txtcontenido);
            this.Controls.Add(this.botonleerfile);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botonleerfile;
        private System.Windows.Forms.RichTextBox txtcontenido;
    }
}

