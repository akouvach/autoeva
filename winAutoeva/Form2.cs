using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using winAutoeva.Autoevaluaciones;
using System.IO;


namespace winAutoeva
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        private Autoevaluacion LoadJson()
        {
            Autoevaluacion preguntas = new Autoevaluacion();

            try
            {
                using StreamReader r = new StreamReader("autoeva.json");
                string json = r.ReadToEnd();

                //dynamic array = JsonConvert.DeserializeObject(json);

                preguntas = JsonConvert.DeserializeObject<Autoevaluacion>(json);


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return preguntas;

        }


        private Autoevaluacion miAutoeva;

        private int preguntaActual = 0;

    private void button1_Click(object sender, EventArgs e)
        {
            this.btn_inicio.Enabled = false;
            this.cmb_alumnos.Enabled = false;

            this.btn_izq.Enabled = true;
            this.btn_der.Enabled = true;
            this.btn_fin.Enabled = true;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Cargando el archivo Json de configuración de la autoevaluación
            
            this.miAutoeva = this.LoadJson();

            this.Text = this.miAutoeva.Nombre;
            this.lbl_nro.Text = this.preguntaActual.ToString();

            this.btn_izq.Enabled = false;
            this.btn_der.Enabled = false;
            this.btn_fin.Enabled = false;


            //Cargo los alumnos
            this.cmb_alumnos.DataSource = this.miAutoeva.Alumnos.ToArray();



        }
    }
}
