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

        private Autoevaluacion miAutoeva;

        private int preguntaActual = 0;

        List<Control> controles = new List<Control>();

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



        private void cargarRespuestasPredeterminadas() {

            Contestacion c = new Contestacion();
            c.Alumno = this.cmb_alumnos.Text;
            c.Contestaciones = new List<ContestacionDetalle>();

            foreach (Pregunta p in this.miAutoeva.Preguntas) {

               
                ContestacionDetalle cd = new ContestacionDetalle();
                cd.Pregunta = p.Nro;
                cd.Respuesta = 1;
             
                c.Contestaciones.Add(cd);
                             
            }

            this.miAutoeva.Contestaciones.Add(c);
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.lbl_mensajes.Visible = true;

            if (this.cmb_alumnos.Text != "")
            {
                this.btn_inicio.Enabled = false;
                this.cmb_alumnos.Enabled = false;

                this.btn_izq.Enabled = true;
                this.btn_der.Enabled = true;
                this.btn_fin.Enabled = true;
            }
            else {
                this.lbl_mensajes.Visible = true;
                this.lbl_mensajes.Text = "Debe seleccionar su nombre";

            }
            this.cargarRespuestasPredeterminadas();
            this.cargarPregunta();
            this.verificarControles();

        }

        private void verificarControles() {
            this.btn_izq.Enabled = (this.preguntaActual == 0 ? false : true);
            this.btn_der.Enabled = (this.preguntaActual == this.miAutoeva.Preguntas.Count - 1 ? false : true);
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
            foreach (Alumno alu in this.miAutoeva.Alumnos) {
                this.cmb_alumnos.Items.Add(alu.Nombre + ", " + alu.Apellido);
            }

            
        }
         
        private void eliminarControles(String prefijo) {

            try
            {
                foreach (Control con in this.controles)
                {
                    this.Controls.Remove(con);
                }
                this.controles.Clear();


            }
            catch (Exception e) {

                this.lbl_mensajes.Text = e.ToString();
            }
            
        }
        private void cargarPregunta() {
            String prefijo = "din_";
            int i = 0;

            int y = 50;
            int x = 50;

            this.eliminarControles(prefijo);

            this.lbl_nro.Text = this.preguntaActual.ToString();

            Label enunciado = new Label();
            enunciado.Name = prefijo + "enunciado" + i.ToString();
            enunciado.Text = this.miAutoeva.Preguntas[this.preguntaActual].Enunciado;
            enunciado.AutoSize = true;
            enunciado.Location = new Point(y,x);
            enunciado.Font = new Font("Calibri", 20);

            this.Controls.Add(enunciado);
            this.controles.Add(enunciado);

            // agrego todas las respuestas



            foreach (Respuesta r in this.miAutoeva.Preguntas[this.preguntaActual].Respuestas) {
                
                Label pregunta = new Label();
                RadioButton radio = new RadioButton();
                
                x = x + 50;
                i++;

                pregunta.Name = prefijo + "pregunta" + i.ToString();
                pregunta.Text = r.Enunciado;
                pregunta.AutoSize = true;
                pregunta.Location = new Point(y+20,x);
                pregunta.Font = new Font("Calibri", 16);


                // busco si el control debe estar chequeado o no
                Boolean seleccionado = false;

                foreach (ContestacionDetalle cd in this.miAutoeva.Contestaciones[0].Contestaciones) {

                    if (cd.Pregunta== this.miAutoeva.Preguntas[this.preguntaActual].Nro) {
                        // estoy en la pregunta que quiero mostrar
                        if (cd.Respuesta == r.Nro) {
                            seleccionado = true;
                        }
                    }
                   
                }

                radio.Name = prefijo + "enunciado_radio" ;
                radio.Checked = seleccionado;
                radio.Location = new Point(y, x);
                radio.Tag = r.Nro;
                radio.CheckedChanged += (Object s, EventArgs e) =>
                {
                    RadioButton r = (RadioButton) s;

                    this.lbl_mensajes.Text = r.Tag.ToString();

                    // voy a actualizar el valor de la respuesta
                    foreach (ContestacionDetalle cd in miAutoeva.Contestaciones[0].Contestaciones) {
                        if (cd.Pregunta == this.miAutoeva.Preguntas[this.preguntaActual].Nro) {

                            //Estoy en la pregunta a modificar
                            cd.Respuesta = int.Parse(r.Tag.ToString());
                        }

                    }

                };



                this.Controls.Add(pregunta);
                this.Controls.Add(radio);
                

                this.controles.Add(pregunta);
                this.controles.Add(radio);
                
            }

        }

        private void btn_izq_Click(object sender, EventArgs e)
        {
            this.preguntaActual--;
            this.verificarControles();
            this.cargarPregunta();
        }

        private void btn_der_Click(object sender, EventArgs e)
        {
            this.preguntaActual++;
            this.verificarControles();
            this.cargarPregunta();
        }

        private void almacenarResultados() {

            try {

                DateTime hoy = DateTime.Now;

                String archivo = miAutoeva.Contestaciones[0].Alumno.Replace(", ", "_") +
                    "_" +
                    hoy.Year.ToString() + "_" + 
                    hoy.Month.ToString() + "_" +
                    hoy.Day.ToString() + "_" +
                    hoy.Hour.ToString() + "_" + 
                    hoy.Minute.ToString() + "_" +
                    hoy.Second.ToString() +
                    ".json";
                using (StreamWriter file = File.CreateText(archivo))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serialize object directly into file stream
                    serializer.Serialize(file, miAutoeva.Contestaciones[0]);
                }

                this.lbl_mensajes.Text = miAutoeva.Contestaciones[0].ToString();

            }
            catch (Exception e)
            {
                this.lbl_mensajes.Text = e.ToString();
            }

        }
        private void btn_fin_Click(object sender, EventArgs e)
        {
            this.almacenarResultados();
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.lbl_mensajes.Text = sender.ToString();
        }
    }
}
