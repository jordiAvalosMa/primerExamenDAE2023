using System;

namespace primerExamenPracticoADS2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool seguir = true;
            byte opcion;

            while (seguir)
            {
                Menu();
                opcion = byte.Parse(Console.ReadLine());
                Console.Clear();
                if (opcion == 1)
                {
                    Console.WriteLine("Ejercicio 1: Calcular Costo de Llamadas.");
                    Ejercicio1();
                    Console.Write("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (opcion == 2)
                {
                    Console.WriteLine("Ejercicio 2: Gestionar Libros de Bibliteca.");
                    Ejercicio2();
                    Console.Write("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (opcion == 3)
                {
                    seguir = false;
                    Console.WriteLine("Saliendo de programa......");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Opción no válida.");
                }

            }
        }

        // Menu de Ejercicios.
        static void Menu()
        {
            Console.WriteLine("Primer Examen Práctico de ADS 2023");
            Console.WriteLine("Alumno: Jorge Alberto Avalos Hernande Carnet: 186322");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Menú de Ejercicios: ");
            Console.WriteLine("1- Ejercicio 1: Calcular Costo de Llamadas.");
            Console.WriteLine("2- Ejercicio 2: Gestionar Libros de Biblioteca.");
            Console.WriteLine("3- Salir:");
            Console.WriteLine("----------------------------------------------------");
            Console.Write("Opción: ");

        }

        // Codigo Ejercicio 1: Calcular Costo de Llamadas.
        static void Ejercicio1()
        {
            int[] claveZona = { 12, 15, 18, 19, 23 };
            string[] nombreZona = { "America del Norte", "America Central", "America del Sur", "Europa", "Asia" };
            double[] costoMinuto = { 2, 2.2, 4.5, 3.5, 6 };
            int clave, indeceLLamada = -1;
            double duracion;
            bool operacionCorecta = true;
            ZonaCostoLlmada(claveZona, nombreZona, costoMinuto);
            while (operacionCorecta)
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.Write("Ingrese la clave de la zona a la que desea llamar: ");
                clave = int.Parse(Console.ReadLine());
                Console.Write("Ingrese la duración de la llamada en minutos: ");
                duracion = double.Parse(Console.ReadLine());
                Console.WriteLine("-----------------------------------------------------");

                for (int j = 0; j < claveZona.Length; j++)
                {
                    if (clave == claveZona[j])
                    {
                        indeceLLamada = j;
                        break;
                    }
                }
                if ((indeceLLamada != -1) && (duracion >= 0))
                {
                    Console.WriteLine("Usted ha llamado a: {0}", nombreZona[indeceLLamada]);
                    double costoTotal = costoMinuto[indeceLLamada] * duracion;
                    Console.WriteLine($"El costo de la llamada es de: {costoTotal:C}");
                    operacionCorecta = false;
                }
                else
                {
                    Console.WriteLine("La clave ingresada o la duracion no son correctas. \n Vuelva Interlo");
                    Console.ReadKey();
                    Console.Clear();
                    ZonaCostoLlmada(claveZona, nombreZona, costoMinuto);
                }
            }
        }

        static void ZonaCostoLlmada(int[] claveZona, string[] nombreZona, double[] costoMinuto)
        {
            //Tabla de Costos de Clave, Zonas y Costos por Minuto.
            Console.WriteLine("Tabla de Costos de Clave, Zonas y Costos por Minuto.");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("{0,-10} | {1,-20} | {2,-15} |", "Clave", "Zonas", "Costos");
            for (int i = 0; i < claveZona.Length; i++)
            {
                Console.WriteLine("{0,-10} | {1,-20} | {2,-15} |", claveZona[i], nombreZona[i],
                    costoMinuto[i]);
            }

        }

        // Codigo Ejercicio 2: Gestionar Libros de Biblioteca.

        static void Ejercicio2()
        {
            string[] codigoLibro = new string[100];
            string[] tituloLibro = new string[100];
            string[] isbnLibro = new string[100];
            string[] edicionLibro = new string[100];
            string[] autorLibro = new string[100];
            int libros = 0;

            bool operacionCorrecta = true;
            string opcionLibros;
            while (operacionCorrecta)
            {
                Console.WriteLine("Menú de Gestión de Libros:");
                Console.WriteLine("1- Agregar libro");
                Console.WriteLine("2- Mostrar listado de libros");
                Console.WriteLine("3- Buscar libro por código");
                Console.WriteLine("4- Editar información de un libro");
                Console.WriteLine("5- Ir al menu principal");
                Console.Write("Seleccione una opción: ");
                opcionLibros = Console.ReadLine();

                if (opcionLibros == "1")
                {
                    Console.WriteLine("Agregar Libro: ");
                    libros = AgregarLibro(libros, codigoLibro, tituloLibro, isbnLibro, edicionLibro, autorLibro);
                    Console.WriteLine("Libro agregado con éxito.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (opcionLibros == "2")
                {
                    Console.WriteLine("Mostrar listado de libros");
                    MostrarLibro(libros, codigoLibro, tituloLibro, isbnLibro, edicionLibro, autorLibro);
                    Console.WriteLine("1- Editar precione 1 \n2- Vuelva a las opciones de libros, cualquier tecle");
                    Console.Write("Opcion:");
                    string editar = Console.ReadLine();
                    if (editar == "1")
                    {
                        Console.WriteLine("Buscar libro por código");
                        EditarLibro(libros, codigoLibro, tituloLibro, isbnLibro, edicionLibro, autorLibro);
                        Console.ReadKey();
                        Console.Clear();
                    }
                    Console.Clear();
                }
                else if (opcionLibros == "3")
                {
                    Console.WriteLine("Buscar libro por código");
                    BuscarLibro(libros, codigoLibro, tituloLibro, isbnLibro, edicionLibro, autorLibro);
                    Console.WriteLine("1- Editar precione 1 \n2- Vuelva a las opciones de libros, cualquier tecle");
                    Console.Write("Opcion:");
                    string editar = Console.ReadLine();
                    if (editar == "1")
                    {
                        Console.WriteLine("Buscar libro por código");
                        EditarLibro(libros, codigoLibro, tituloLibro, isbnLibro, edicionLibro, autorLibro);
                        Console.ReadKey();
                        Console.Clear();
                    }
                    Console.Clear();
                }
                else if (opcionLibros == "4")
                {
                    Console.WriteLine("Buscar libro por código");
                    EditarLibro(libros, codigoLibro, tituloLibro, isbnLibro, edicionLibro, autorLibro);
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (opcionLibros == "5")
                {
                    operacionCorrecta = false;
                }
                else
                {
                    Console.WriteLine("-----------------------------------------------------------------------------");
                    Console.WriteLine("Opción no válida.");
                    Console.WriteLine("Vuelve a intertalos");
                    operacionCorrecta = true;
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        static int AgregarLibro(int libros, string[] codigoLibro, string[] tituloLibro, string[] isbnLibro, string[] edicionLibro, string[] autorLibro)
        {
            Console.Clear();
            string codigo, titulo, isbn, edicion, autor;
            Console.WriteLine("Ingrese los Datos del libro");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.Write("Codigo: ");
            codigo = Console.ReadLine();
            Console.Write("Titulo: ");
            titulo = Console.ReadLine();
            Console.Write("ISBN: ");
            isbn = Console.ReadLine();
            Console.Write("Edicion: ");
            edicion = Console.ReadLine();
            Console.Write("Autor :");
            autor = Console.ReadLine();
            codigoLibro[libros] = codigo;
            tituloLibro[libros] = titulo;
            isbnLibro[libros] = isbn;
            edicionLibro[libros] = edicion;
            autorLibro[libros] = autor;
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("Libro N: {0} Codigo: {1} Titulo: {2} ISBN: {3} Edicion: {4} Autor: {5}", libros + 1, codigoLibro[libros], tituloLibro[libros], isbnLibro[libros], edicionLibro[libros], autorLibro[libros]);
            Console.WriteLine("-----------------------------------------------------------------------------");
            libros++;
            return libros;
        }

        static void MostrarLibro(int libros, string[] codigoLibro, string[] tituloLibro, string[] isbnLibro, string[] edicionLibro, string[] autorLibro)
        {
            Console.WriteLine("Listado de Libros");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("{0,-10} | {1,-20} | {2,-15} | {3,-10} | {4,-20}", "Código", "Título", "ISBN", "Edición", "Autor");
            for (int i = 0; i < libros; i++)
            {
                Console.WriteLine("{0,-10} | {1,-20} | {2,-15} | {3,-10} | {4,-20}", codigoLibro[i], tituloLibro[i], isbnLibro[i], edicionLibro[i], autorLibro[i]);
            }
            Console.WriteLine("-----------------------------------------------------------------------------");
        }

        static void BuscarLibro(int libros, string[] codigoLibro, string[] tituloLibro, string[] isbnLibro, string[] edicionLibro, string[] autorLibro)
        {
            string buscarCodigo;
            int indeceBuscarCodigo = -1;
            Console.Write("Ingrese el codigo del libro que Busca: ");
            buscarCodigo = Console.ReadLine();

            for (int i = 0; i < libros; i++)
            {
                if (codigoLibro[i] == buscarCodigo)
                {
                    indeceBuscarCodigo = i;
                    break;
                }
            }

            if (indeceBuscarCodigo != -1)
            {
                Console.WriteLine("{0,-10} | {1,-20} | {2,-15} | {3,-10} | {4,-20}", "Código", "Título", "ISBN", "Edición", "Autor");
                Console.WriteLine("-----------------------------------------------------------------------------");
                Console.WriteLine("{0,-10} | {1,-20} | {2,-15} | {3,-10} | {4,-20}", codigoLibro[indeceBuscarCodigo], tituloLibro[indeceBuscarCodigo], isbnLibro[indeceBuscarCodigo], edicionLibro[indeceBuscarCodigo], autorLibro[indeceBuscarCodigo]);
                Console.WriteLine("-----------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("El libro no se encontro..\nVerefica el codigo..");
            }
        }

        static void EditarLibro(int libros, string[] codigoLibro, string[] tituloLibro, string[] isbnLibro, string[] edicionLibro, string[] autorLibro)
        {
            string codigoEditar;
            int indeceCodigoEditar = -1;
            Console.Write("Ingrese el Codigo del libro a Editar: ");
            codigoEditar = Console.ReadLine();
            for (int i = 0; i < libros; i++)
            {
                if (codigoLibro[i] == codigoEditar)
                {
                    indeceCodigoEditar = i;
                    break;
                }
            }

            if (indeceCodigoEditar != -1)
            {
                Console.Clear();
                Console.WriteLine("Ingrese los Datos del libro");
                Console.WriteLine("-----------------------------------------------------------------------------");
                Console.Write("Codigo: ");
                codigoLibro[indeceCodigoEditar] = Console.ReadLine();
                Console.Write("Titulo: ");
                tituloLibro[indeceCodigoEditar] = Console.ReadLine();
                Console.Write("ISBN: ");
                isbnLibro[indeceCodigoEditar] = Console.ReadLine();
                Console.Write("Edicion: ");
                edicionLibro[indeceCodigoEditar] = Console.ReadLine();
                Console.Write("Autor :");
                autorLibro[indeceCodigoEditar] = Console.ReadLine();
                Console.WriteLine("-----------------------------------------------------------------------------");
                Console.WriteLine("Codigo: {0} Titulo: {1} ISBN: {2} Edicion: {3} Autor: {4}", codigoLibro[indeceCodigoEditar], tituloLibro[indeceCodigoEditar], isbnLibro[indeceCodigoEditar], edicionLibro[indeceCodigoEditar], autorLibro[indeceCodigoEditar]);
                Console.WriteLine("-----------------------------------------------------------------------------");

            }
            else
            {
                Console.WriteLine("Libro no encontrado.....");
            }

        }
    }
}