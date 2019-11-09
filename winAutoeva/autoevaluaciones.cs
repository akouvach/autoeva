using System;
using System.Collections.Generic;
using System.Text;

namespace winAutoeva.Autoevaluaciones
{

    class Alumno
    {

        public String Nombre { get; set; }
        public String Apellido { get; set; }
    }

    class Respuesta
    {
        public int Nro { get; set; }

        public String Enunciado { get; set; }

        public Boolean Correcta { get; set; }

    }
    class Pregunta
    {

        public int Nro { get; set; }

        public String Enunciado { get; set; }

        public List<Respuesta> Respuestas { get; set; }


    }

    class ContestacionDetalle
    {

        public int Pregunta { get; set; }

        public int Respuesta { get; set; }

    }



    class Contestacion
    {

        public string Alumno { get; set; }

        public List<ContestacionDetalle> Contestaciones { get; set; }

    }

    class Autoevaluacion
    {

        public String Nombre { get; set; }
        public List<Pregunta> Preguntas { get; set; }
        //public List<Contestacion> Contestaciones { get; set; }

        public List<Alumno> Alumnos { get; set; }


    }


}







