using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace notasAprendiz
{
    public class datosAprendiz
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
        public double Nota3 { get; set; }
        
        public double promedio { get; set; }
        public double suma { get; set; }
        public decimal division { get; set; }


    }
}
