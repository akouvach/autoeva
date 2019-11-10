namespace winAutoeva
{
    partial class Form2
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
            this.btn_inicio = new System.Windows.Forms.Button();
            this.lbl_Alumno = new System.Windows.Forms.Label();
            this.btn_izq = new System.Windows.Forms.Button();
            this.btn_der = new System.Windows.Forms.Button();
            this.cmb_alumnos = new System.Windows.Forms.ComboBox();
            this.lbl_nro = new System.Windows.Forms.Label();
            this.btn_fin = new System.Windows.Forms.Button();
            this.lbl_mensajes = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            // 
            // btn_inicio
            // 
            this.btn_inicio.Location = new System.Drawing.Point(396, 14);
            this.btn_inicio.Name = "btn_inicio";
            this.btn_inicio.Size = new System.Drawing.Size(112, 34);
            this.btn_inicio.TabIndex = 0;
            this.btn_inicio.Text = "Iniciar";
            this.btn_inicio.UseVisualStyleBackColor = true;
            this.btn_inicio.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_Alumno
            // 
            this.lbl_Alumno.AutoSize = true;
            this.lbl_Alumno.Location = new System.Drawing.Point(21, 19);
            this.lbl_Alumno.Name = "lbl_Alumno";
            this.lbl_Alumno.Size = new System.Drawing.Size(104, 25);
            this.lbl_Alumno.TabIndex = 1;
            this.lbl_Alumno.Text = "Su nombre:";
            // 
            // btn_izq
            // 
            this.btn_izq.Location = new System.Drawing.Point(725, 14);
            this.btn_izq.Name = "btn_izq";
            this.btn_izq.Size = new System.Drawing.Size(32, 34);
            this.btn_izq.TabIndex = 2;
            this.btn_izq.Text = "<";
            this.btn_izq.UseVisualStyleBackColor = true;
            this.btn_izq.Click += new System.EventHandler(this.btn_izq_Click);
            // 
            // btn_der
            // 
            this.btn_der.Location = new System.Drawing.Point(763, 14);
            this.btn_der.Name = "btn_der";
            this.btn_der.Size = new System.Drawing.Size(32, 34);
            this.btn_der.TabIndex = 2;
            this.btn_der.Text = ">";
            this.btn_der.UseVisualStyleBackColor = true;
            this.btn_der.Click += new System.EventHandler(this.btn_der_Click);
            // 
            // cmb_alumnos
            // 
            this.cmb_alumnos.FormattingEnabled = true;
            this.cmb_alumnos.Location = new System.Drawing.Point(139, 16);
            this.cmb_alumnos.Name = "cmb_alumnos";
            this.cmb_alumnos.Size = new System.Drawing.Size(251, 33);
            this.cmb_alumnos.TabIndex = 3;
            // 
            // lbl_nro
            // 
            this.lbl_nro.AutoSize = true;
            this.lbl_nro.Location = new System.Drawing.Point(601, 30);
            this.lbl_nro.Name = "lbl_nro";
            this.lbl_nro.Size = new System.Drawing.Size(0, 25);
            this.lbl_nro.TabIndex = 4;
            // 
            // btn_fin
            // 
            this.btn_fin.Location = new System.Drawing.Point(819, 14);
            this.btn_fin.Name = "btn_fin";
            this.btn_fin.Size = new System.Drawing.Size(69, 34);
            this.btn_fin.TabIndex = 5;
            this.btn_fin.Text = "Fin";
            this.btn_fin.UseVisualStyleBackColor = true;
            this.btn_fin.Click += new System.EventHandler(this.btn_fin_Click);
            // 
            // lbl_mensajes
            // 
            this.lbl_mensajes.AutoSize = true;
            this.lbl_mensajes.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbl_mensajes.Location = new System.Drawing.Point(514, 19);
            this.lbl_mensajes.Name = "lbl_mensajes";
            this.lbl_mensajes.Size = new System.Drawing.Size(0, 25);
            this.lbl_mensajes.TabIndex = 6;
            this.lbl_mensajes.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(-152, 21);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(121, 29);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(902, 428);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lbl_mensajes);
            this.Controls.Add(this.btn_fin);
            this.Controls.Add(this.lbl_nro);
            this.Controls.Add(this.cmb_alumnos);
            this.Controls.Add(this.btn_izq);
            this.Controls.Add(this.lbl_Alumno);
            this.Controls.Add(this.btn_inicio);
            this.Controls.Add(this.btn_der);
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);

        }

        #endregion

        private System.Windows.Forms.Button btn_inicio;
        private System.Windows.Forms.Label lbl_Alumno;
        private System.Windows.Forms.Button btn_izq;
        private System.Windows.Forms.Button btn_der;
        private System.Windows.Forms.ComboBox cmb_alumnos;
        private System.Windows.Forms.Label lbl_nro;
        private System.Windows.Forms.Button btn_fin;
        private System.Windows.Forms.Label lbl_mensajes;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}