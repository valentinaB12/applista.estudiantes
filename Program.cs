using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

namespace notasAprendiz
{
    class Program
    {

        static validacionesBase validar = new validacionesBase();

        static List<datosAprendiz> ListaEstudiantes = new List<datosAprendiz>();

        static void Main(string[] args)
        {
            string mantener;
            bool entrada = false;


            int opcionMenu;
            do
            {
                Console.Clear();
                Console.WriteLine(" -------menu principal------- ");

                Console.WriteLine("1. --agregar estudiante---");
                Console.WriteLine("2. --listar estudiante--");
                Console.WriteLine("3. --buscar estudiante--");
                Console.WriteLine("-------------------------");
                Console.WriteLine("8. --Guardar archivo--");
                Console.WriteLine("9. --Cargar archivo--");
                Console.WriteLine("----------------------");
                Console.WriteLine("0. --salir--");

                do
                {
                    Console.WriteLine("Digite una opcion");

                    mantener = Console.ReadLine();
                    if (!validar.Vacio(mantener))
                        if (validar.numero(mantener))
                            entrada = true;

                } while (!entrada);





                opcionMenu = Convert.ToInt32(mantener);

                switch (opcionMenu)
                {
                    case 1:
                        AgregarEstudiante();
                        break;
                    case 2:
                        ListarEstudiante();
                        break;
                    case 3:
                        BuscarEstudiante();
                        break;
                    case 8:
                        Escribirxml();
                        break;
                    case 9:
                        Leerxml();
                        break;
                    case 0:
                        Console.WriteLine("saliendo del programa");
                        break;
                    default:
                        Console.WriteLine("opcion no valida ");
                        break;
                        Console.WriteLine("digite una tecla para continuar");
                        break;
                        Console.ReadKey();
                }

            } while (opcionMenu > 0);






        }

        static void AgregarEstudiante()
        {
            string codi, nom, cor, not1, not2, not3, prom;
            
            
            bool CodigoCorrecto = false;
            bool nombreCorrecto = false;
            bool CorreoCorrecto = false;
            bool nota1Correcto = false;
            bool nota2Correcto = false; ;
            bool nota3Correcto = false;



            Console.Clear();
            Console.WriteLine(" inserta un estudiante");

            do
            {
                Console.WriteLine("digite el codigo del estudiante ");

                codi = Console.ReadLine();
                if (!validar.Vacio(codi))
                    if (validar.numero(codi))
                        CodigoCorrecto = true;

            } while (!CodigoCorrecto);


            if (Existe(Convert.ToInt32(codi)))
            {
                Console.WriteLine("el usuario.." + codi + ".." + "ya existe");
                Console.ReadLine();
            }
            else
            {
                do
                {
                    Console.WriteLine("digite el nombre del estudiante");
                    nom = Console.ReadLine();
                    if (!validar.Vacio(nom))
                        if (validar.TipoTexto(nom))
                            nombreCorrecto = true;

                } while (!nombreCorrecto);

                do
                {

                    Console.WriteLine("digite el correo estudiante");
                    cor = Console.ReadLine();
                    if (!validar.Vacio(cor))
                        if (validar.correo(cor))
                            CorreoCorrecto = true;
                } while (!CorreoCorrecto);

                do
                {
                    Console.WriteLine("digite la primera nota del estudiante");
                    not1 = Console.ReadLine();
                    if (!validar.Vacio(not1))
                        if (validar.NumeroDesimal(not1))
                            nota1Correcto = true;

                } while (!nota1Correcto);

                do
                {
                    Console.WriteLine("digite la segunda nota del estudiante");
                    not2 = Console.ReadLine();
                    if (!validar.Vacio(not2))
                        if (validar.NumeroDesimal(not2))
                            nota2Correcto = true;
                } while (!nota2Correcto);

                do
                {
                    Console.WriteLine("digite la tercera nota del estudiante");
                    not3 = Console.ReadLine();
                    if (!validar.Vacio(not3))
                        if (validar.NumeroDesimal(not3))
                            nota3Correcto = true;
                } while (!nota3Correcto);

                



                // -----------------------------------------------------------------------------//
                datosAprendiz ElEstudiante = new datosAprendiz();
                ElEstudiante.Codigo = Convert.ToInt32(codi);
                ElEstudiante.Nombre = nom;
                ElEstudiante.Correo = cor;
                ElEstudiante.Nota1 = Convert.ToDouble(not1);
                ElEstudiante.Nota2 = Convert.ToDouble(not2);
                ElEstudiante.Nota3 = Convert.ToDouble(not3);
                

                ListaEstudiantes.Add(ElEstudiante);
            }
        }

        static void ListarEstudiante()
        {
            double promedio = 0;
            double suma = 0;

            Console.WriteLine(" listar un estudiante");
            Console.WriteLine("-----------------------");
            foreach (datosAprendiz elemento in ListaEstudiantes)
            {
                suma = elemento.Nota1 + elemento.Nota2 + elemento.Nota3;
                promedio = suma / 3;

                if (promedio >= 3.5) 
                {
                    Console.WriteLine("EL ESTUDIANTE APROBO");
                    Console.ReadLine();
                }
                else 
                {
                    Console.WriteLine(" EL ESTUDIANTE NO APROBO");
                }
                Console.WriteLine("codigo:.." + elemento.Codigo + ".." + "nombre:..." + elemento.Nombre + ".." + "correo:..." + elemento.Correo + ".." + "nota1:...." + elemento.Nota1 + "..." + "nota2:...." + elemento.Nota2 + "..." + "nota3:....." + elemento.Nota3 + "..."+"promedio:"+promedio);
                Console.ReadLine();
            }

        }

        static void BuscarEstudiante()
        {
            string codi;
            bool CodigoCorrecto = false;
            Console.Clear();
            Console.WriteLine(" buscar un estudiante");
            Console.WriteLine("........................");
            do
            {
                Console.WriteLine("digite el codigo del estudiante que desea buscar:");

                codi = Console.ReadLine();
                if (!validar.Vacio(codi))
                    if (validar.numero(codi))
                        CodigoCorrecto = true;

            } while (!CodigoCorrecto);

            if (Existe(Convert.ToInt32(codi)))
            {
                datosAprendiz elemento = ObtenerDatos(Convert.ToInt32(codi));
                Console.WriteLine("codigo:.." + elemento.Codigo  + "\t nombre:..." + elemento.Nombre + ".." + "\tcorreo:..." + elemento.Correo +  "\tnota1:...." + elemento.Nota1 + "\tnota2:...." + elemento.Nota2 +  "\tnota3:." + elemento.Nota3 );
                Console.Read();
            }
            else
            {
                Console.WriteLine("el estudiante." + codi + ".." + "no existe en el sistema");
                Console.ReadLine();

            }


        }

        static bool Existe(int Cod)
        {
          bool aux = false;
          foreach (datosAprendiz objetoEstudiante in ListaEstudiantes)
          {

                if (objetoEstudiante.Codigo == Cod)
                    aux = true;

          }
            return aux;

        }
        static datosAprendiz ObtenerDatos(int codi)
        {
            foreach (datosAprendiz objetoEstudiante in ListaEstudiantes)
            {

                if (objetoEstudiante.Codigo == codi)
                    return objetoEstudiante; 

            }
            return null;



        }    
            
        static void Escribirxml()
        {
            XmlSerializer codificador = new XmlSerializer(typeof(List<datosAprendiz>));
            TextWriter escribirXml = new StreamWriter("C:/Datos net/listaEstudientes.xml");
            codificador.Serialize(escribirXml,ListaEstudiantes);
            escribirXml.Close();
        }
        static void Leerxml() 
        {
            ListaEstudiantes.Clear();
            if (File.Exists("C:/Datos net/listaEstudientes.xml"))
            {
                XmlSerializer codificador = new XmlSerializer(typeof(List<datosAprendiz>));
                FileStream Leerxml = File.OpenRead("C:/Datos net/listaEstudientes.xml");
                ListaEstudiantes = (List<datosAprendiz>)codificador.Deserialize(Leerxml);
                Leerxml.Close();
            }


        }
            
        
      




    }    
      
}        
