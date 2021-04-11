using System;
using System.Text.RegularExpressions;

namespace notasAprendiz
{
    internal class validacionesBase
    { string texto;
        public Boolean numero(string texto)
        {
            Regex formato = new Regex("^[0-9,$]*$");

            if (formato.IsMatch(texto))
            {
                return true;


            }

            else;
            {
                Console.WriteLine("el valor debe ser numerico");
                return false;

            }
        }







        public Boolean Vacio(string texto)
        {
            if (texto.Equals(" "))
            {

                Console.WriteLine(" el espacio no debe ser vacio");
                return true;
            }
            else

            {

                return false;


            }

        }
        public Boolean TipoTexto(string texto)
        {
            Regex formato = new Regex("^[a-zA-Z]*$");

            if (formato.IsMatch(texto))
            {
                return true;
            }
            else
            {

                Console.WriteLine("el valor debe ser de texto");
                return false;
            }

        }
        public Boolean correo(string texto)
        {
            Regex formato = new Regex(@"\A(\w+\.?\w*\@\w+\.)(com)\Z");
             
              if (formato.IsMatch(texto))
              {
                return true;
              }
            else
            {
                Console.WriteLine(" el valor debe tener @");
                return false;
            }
         }

        public Boolean NumeroDesimal(string texto)
        {
            Regex formato = new Regex("^[0-9]([.,][0-9]{1,3})?$");

            if (formato.IsMatch(texto))
            {
                return true;
            }
            else
            {
                Console.WriteLine(" el valor debe ser decimal");
                return false;
            }
        }











    }
}