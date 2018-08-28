namespace Final_Labotarorio_I
{
    partial class FormularioAutenticacion
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
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lbContraseña = new System.Windows.Forms.Label();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.pnlDetalle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDetalle.Controls.Add(this.btnAceptar);
            this.pnlDetalle.Controls.Add(this.txtContraseña);
            this.pnlDetalle.Controls.Add(this.txtUsuario);
            this.pnlDetalle.Controls.Add(this.lbContraseña);
            this.pnlDetalle.Controls.Add(this.lbUsuario);
            this.pnlDetalle.Location = new System.Drawing.Point(2, 1);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(479, 226);
            this.pnlDetalle.TabIndex = 5;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAceptar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(275, 168);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(134, 31);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.Location = new System.Drawing.Point(189, 100);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size = new System.Drawing.Size(155, 23);
            this.txtContraseña.TabIndex = 3;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(189, 54);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(155, 20);
            this.txtUsuario.TabIndex = 2;
            // 
            // lbContraseña
            // 
            this.lbContraseña.AutoSize = true;
            this.lbContraseña.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContraseña.Location = new System.Drawing.Point(65, 95);
            this.lbContraseña.Name = "lbContraseña";
            this.lbContraseña.Size = new System.Drawing.Size(118, 23);
            this.lbContraseña.TabIndex = 1;
            this.lbContraseña.Text = "Contraseña";
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsuario.Location = new System.Drawing.Point(100, 51);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(83, 23);
            this.lbUsuario.TabIndex = 0;
            this.lbUsuario.Text = "Usuario";
            // 
            // FormularioAutenticacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 229);
            this.Controls.Add(this.pnlDetalle);
            this.Name = "FormularioAutenticacion";
            this.Text = "Autenticación";
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lbContraseña;
        private System.Windows.Forms.Label lbUsuario;
    }
}