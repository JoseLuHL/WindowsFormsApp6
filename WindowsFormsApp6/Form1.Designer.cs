namespace WindowsFormsApp6
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnUbicacion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnUbicacion
            // 
            this.BtnUbicacion.BackColor = System.Drawing.Color.White;
            this.BtnUbicacion.Location = new System.Drawing.Point(53, 27);
            this.BtnUbicacion.Name = "BtnUbicacion";
            this.BtnUbicacion.Size = new System.Drawing.Size(123, 41);
            this.BtnUbicacion.TabIndex = 0;
            this.BtnUbicacion.Text = "Ubicacion...";
            this.BtnUbicacion.UseVisualStyleBackColor = false;
            this.BtnUbicacion.Click += new System.EventHandler(this.BtnUbicacion_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(229, 94);
            this.Controls.Add(this.BtnUbicacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnUbicacion;
    }
}

