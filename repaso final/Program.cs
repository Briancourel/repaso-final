using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repaso_final
{
    internal class Program
    {
        struct Alumno
        {
            public string Nombre;
            public int Materia1;
            public int Materia2;
            public int Materia3;
            public int Materia4;

            public Alumno (string nombre, int materia1, int materia2, int materia3, int materia4)
            {
                Nombre = nombre;
                Materia1 = materia1;
                Materia2 = materia2;
                Materia3 = materia3;
                Materia4 = materia4;
            }
            public double CalcularPromedio()
            {
                return (Materia1 + Materia2 + Materia3 + Materia4) / 4.0;
            }

        }



        static Alumno[] nombres = new Alumno[6];
        static string[] materias = { "programacion", "matematica", "sistemas operativos", "base de datos" };
        static int[,] notas = new int[materias.Length, 6];
        static int opcion;

        static void MenuyManejo()
        {
            do
            {


                Console.WriteLine("\n--- Menú ---");
                Console.WriteLine("1. Cargar nombres");
                Console.WriteLine("2. Mostrar nombres  ordenados");
                Console.WriteLine("3. Ingresar notas");
                Console.WriteLine("4. Mostrar notas");
                Console.WriteLine("5. Convertir a lista dinámica");
                Console.WriteLine("6. Calcular y mostrar promedios");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");

              
                if (int.TryParse(Console.ReadLine(), out opcion) && opcion >= 1 && opcion <= 7)
                {
                   break;
                }
                Console.WriteLine("Opción inválida. Por favor, ingrese un número entre 1 y 7.");

                switch (opcion)
                {
                    case 1: CargarNombres(nombres); break;
                    case 2: OrdenarNombres(nombres); break;
                    case 3: IngresarNotas(nombres); break;
                    case 4: MostrarNotas(nombres); break;
                    case 5: ConvertirAListaDinamica(nombres); break;
                    case 6: CalcularPromedios(nombres); break;
                    case 7: Console.WriteLine("saliste del programa"); break;
                   
                }
            }while(opcion != 7);
        }

        static void CargarNombres(Alumno[] nombres)
        {
            for (int i = 0; i < nombres.Length; i++)
            {
                Console.WriteLine($" ingrese el nombre del alumno {i + 1} : ");
                string nombre = Console.ReadLine();

                nombres[i] = new Alumno { Nombre = nombre };

            }
        }

        static void OrdenarNombres(Alumno[] nombres)
        {


            for (int i = 0; i < nombres.Length - 1; i++)
            {
                for (int j = 0; j < nombres.Length - i - 1; j++)
                {
                    if (string.Compare(nombres[j].Nombre, nombres[j + 1].Nombre) > 0)
                    {
                        var temp = nombres[j];
                        nombres[j] = nombres[j + 1];
                        nombres[j + 1] = temp;

                    }
                }

            }
            Console.WriteLine("Los alumnos  son: :");

            foreach (var datos in nombres)
            {
                Console.WriteLine(datos.Nombre);
            }
        }

            static void IngresarNotas(Alumno[] nombres)
            {
                for (int i = 0; i < nombres.Length; i++)
                {
                    Console.WriteLine($"Ingresar notas para el alumno: {nombres[i].Nombre}");

                    // Ingresar notas para cada materia
                    for (int j = 0; j < materias.Length; j++)
                    { 
                        Console.Write($"Ingrese la nota para {materias[j]}: ");
                        int nota = int.Parse(Console.ReadLine());
                    if (nota < 0 || nota > 10)
                    {
                        Console.WriteLine("nota ingresada invalida se tomara como 0");
                        nota = 0;
                    }

                        // Asignar notas según el índice de la materia
                        switch (j)
                        {
                            case 0: nombres[i].Materia1 = nota; break;
                            case 1: nombres[i].Materia2 = nota; break;
                            case 2: nombres[i].Materia3 = nota; break;
                            case 3: nombres[i].Materia4 = nota; break;
                        }
                    }
                }
            }
        static void MostrarNotas(Alumno[] nombres)
        {
            Console.WriteLine("\nNotas de los alumnos:");
            foreach (var alumno in nombres)
            {
                Console.WriteLine($"Alumno: {alumno.Nombre}");
                Console.WriteLine($"Programación: {alumno.Materia1}");
                Console.WriteLine($"Matemática: {alumno.Materia2}");
                Console.WriteLine($"Sistemas Operativos: {alumno.Materia3}");
                Console.WriteLine($"Base de Datos: {alumno.Materia4}");
                Console.WriteLine();
            }
        }
        static void ConvertirAListaDinamica(Alumno[] nombres)
        {
            var listaAlumnos = new System.Collections.Generic.List<Alumno>(nombres);
            Console.WriteLine("Los alumnos han sido convertidos a una lista dinámica.");
        }

        static void CalcularPromedios(Alumno[] nombres)
        {
            Console.WriteLine("\nPromedios de los alumnos:");
            foreach (var alumno in nombres)
            {
                double promedio = alumno.CalcularPromedio();
                Console.WriteLine($"Alumno: {alumno.Nombre}, Promedio: {promedio:F2}");
            }
        }
       




        static void Main(string[] args)
        {
            MenuyManejo();
        }
    }
}
