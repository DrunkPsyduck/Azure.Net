﻿
namespace MigracionTablasAzure
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
            this.btnmigrar = new System.Windows.Forms.Button();
            this.lblmensaje = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnmigrar
            // 
            this.btnmigrar.Location = new System.Drawing.Point(69, 78);
            this.btnmigrar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnmigrar.Name = "btnmigrar";
            this.btnmigrar.Size = new System.Drawing.Size(267, 68);
            this.btnmigrar.TabIndex = 0;
            this.btnmigrar.Text = "migrardatos";
            this.btnmigrar.UseVisualStyleBackColor = true;
            this.btnmigrar.Click += new System.EventHandler(this.btnmigrar_Click);
            // 
            // lblmensaje
            // 
            this.lblmensaje.AutoSize = true;
            this.lblmensaje.Location = new System.Drawing.Point(45, 327);
            this.lblmensaje.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblmensaje.Name = "lblmensaje";
            this.lblmensaje.Size = new System.Drawing.Size(64, 25);
            this.lblmensaje.TabIndex = 1;
            this.lblmensaje.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 449);
            this.Controls.Add(this.lblmensaje);
            this.Controls.Add(this.btnmigrar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnmigrar;
        private System.Windows.Forms.Label lblmensaje;
    }
}
