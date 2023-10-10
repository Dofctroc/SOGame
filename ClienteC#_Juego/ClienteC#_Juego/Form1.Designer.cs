namespace ClienteC__Juego
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textbox_altura = new System.Windows.Forms.MaskedTextBox();
            this.textbox_nombre = new System.Windows.Forms.MaskedTextBox();
            this.command_alto = new System.Windows.Forms.RadioButton();
            this.command_longitud = new System.Windows.Forms.RadioButton();
            this.command_bonito = new System.Windows.Forms.RadioButton();
            this.button_enviar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Conectar = new System.Windows.Forms.Button();
            this.button_Desconectar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox1.Controls.Add(this.textbox_altura);
            this.groupBox1.Controls.Add(this.textbox_nombre);
            this.groupBox1.Controls.Add(this.command_alto);
            this.groupBox1.Controls.Add(this.command_longitud);
            this.groupBox1.Controls.Add(this.command_bonito);
            this.groupBox1.Controls.Add(this.button_enviar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 223);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // textbox_altura
            // 
            this.textbox_altura.Location = new System.Drawing.Point(130, 63);
            this.textbox_altura.Name = "textbox_altura";
            this.textbox_altura.Size = new System.Drawing.Size(100, 22);
            this.textbox_altura.TabIndex = 7;
            // 
            // textbox_nombre
            // 
            this.textbox_nombre.Location = new System.Drawing.Point(130, 35);
            this.textbox_nombre.Name = "textbox_nombre";
            this.textbox_nombre.Size = new System.Drawing.Size(100, 22);
            this.textbox_nombre.TabIndex = 6;
            // 
            // command_alto
            // 
            this.command_alto.AutoSize = true;
            this.command_alto.Location = new System.Drawing.Point(35, 162);
            this.command_alto.Name = "command_alto";
            this.command_alto.Size = new System.Drawing.Size(123, 20);
            this.command_alto.TabIndex = 5;
            this.command_alto.TabStop = true;
            this.command_alto.Text = "Dime si soy alto";
            this.command_alto.UseVisualStyleBackColor = true;
            // 
            // command_longitud
            // 
            this.command_longitud.AutoSize = true;
            this.command_longitud.Location = new System.Drawing.Point(35, 110);
            this.command_longitud.Name = "command_longitud";
            this.command_longitud.Size = new System.Drawing.Size(159, 20);
            this.command_longitud.TabIndex = 4;
            this.command_longitud.TabStop = true;
            this.command_longitud.Text = "Dime longitud nombre";
            this.command_longitud.UseVisualStyleBackColor = true;
            // 
            // command_bonito
            // 
            this.command_bonito.AutoSize = true;
            this.command_bonito.Location = new System.Drawing.Point(35, 136);
            this.command_bonito.Name = "command_bonito";
            this.command_bonito.Size = new System.Drawing.Size(162, 20);
            this.command_bonito.TabIndex = 3;
            this.command_bonito.TabStop = true;
            this.command_bonito.Text = "Dime si nombre bonito";
            this.command_bonito.UseVisualStyleBackColor = true;
            // 
            // button_enviar
            // 
            this.button_enviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_enviar.AutoSize = true;
            this.button_enviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_enviar.Location = new System.Drawing.Point(257, 185);
            this.button_enviar.Name = "button_enviar";
            this.button_enviar.Size = new System.Drawing.Size(80, 35);
            this.button_enviar.TabIndex = 2;
            this.button_enviar.Text = "Solicitar";
            this.button_enviar.UseVisualStyleBackColor = true;
            this.button_enviar.Click += new System.EventHandler(this.button_enviar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Altura:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // button_Conectar
            // 
            this.button_Conectar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Conectar.AutoSize = true;
            this.button_Conectar.Location = new System.Drawing.Point(12, 273);
            this.button_Conectar.Name = "button_Conectar";
            this.button_Conectar.Size = new System.Drawing.Size(75, 26);
            this.button_Conectar.TabIndex = 1;
            this.button_Conectar.Text = "Conectar";
            this.button_Conectar.UseVisualStyleBackColor = true;
            this.button_Conectar.Click += new System.EventHandler(this.button_Conectar_Click);
            // 
            // button_Desconectar
            // 
            this.button_Desconectar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Desconectar.AutoSize = true;
            this.button_Desconectar.Location = new System.Drawing.Point(12, 302);
            this.button_Desconectar.Name = "button_Desconectar";
            this.button_Desconectar.Size = new System.Drawing.Size(102, 26);
            this.button_Desconectar.TabIndex = 2;
            this.button_Desconectar.Text = "Desconectar";
            this.button_Desconectar.UseVisualStyleBackColor = true;
            this.button_Desconectar.Click += new System.EventHandler(this.button_Desconectar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 340);
            this.Controls.Add(this.button_Desconectar);
            this.Controls.Add(this.button_Conectar);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox textbox_altura;
        private System.Windows.Forms.MaskedTextBox textbox_nombre;
        private System.Windows.Forms.RadioButton command_alto;
        private System.Windows.Forms.RadioButton command_longitud;
        private System.Windows.Forms.RadioButton command_bonito;
        private System.Windows.Forms.Button button_enviar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Conectar;
        private System.Windows.Forms.Button button_Desconectar;
    }
}

