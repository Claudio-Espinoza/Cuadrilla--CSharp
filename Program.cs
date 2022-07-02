using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuadrilla
{
    internal class Program
    {
        //-|Contadores|-----------------------------------------------------------------------------------------------------------//
        private static int numeroGrupos = 0, dimension = 0, contador = 2;

        static private int[,] cuadrilla ={ //Si se le agrega unos o se les quitan el programa sigue funcionando O.O
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
            {0, 0, 0, 1, 1, 0, 0, 0, 0, 1 },
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 1, 0, 0, 1, 0, 0 },
            {0, 0, 0, 1, 0, 0, 0, 1, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 1, 1, 0 },
            {0, 0, 0, 0, 1, 1, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }};

        static void Main(string[] args)
        {
            EncontrarGrupos(cuadrilla);
            CalcularTamanoGrupos(cuadrilla, numeroGrupos);
            MostrarCuadrilla();
            
        }
        //-|Mostrar matriz|-------------------------------------------------------------------------------------------------------//
        public static void MostrarCuadrilla()
        {
            Console.WriteLine("---------------------------------------");
            for (int filas = 0; filas < cuadrilla.GetLength(0); filas++)
            {
                for (int columnas = 0; columnas < cuadrilla.GetLength(1); columnas++)
                {
                    Console.Write($"|{cuadrilla[filas, columnas]}| ");
                }
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------");
            }
        }

        //-|Deteccion de grupos|--------------------------------------------------------------------------------------------------//
        public static void EncontrarGrupos(int[,] matriz)
        {
            Console.WriteLine("Cuantificacion de grupos dentro de la matriz");
            for (int i = 0; i < matriz.GetLength(0); i++) 
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (matriz[i, j] == 1)
                    {
                        CantidadGrupo(matriz, i, j, 2 + numeroGrupos);
                        numeroGrupos++;
                        Console.WriteLine("Grupo N°{0} encontrado",numeroGrupos);
                    }
                }
            }
            Console.WriteLine("La totalidad de los grupos encontrados: " + numeroGrupos);
        }
        public static void CantidadGrupo(int[,] matriz, int x, int y, int numGrupos)
        {
            if (x < 0 || y < 0 || x >= matriz.GetLength(0) || y >= matriz.GetLength(1) || matriz[x, y] != 1)
            {
                return;
            }
            matriz[x, y] = numGrupos;

            CantidadGrupo(matriz, x + 1, y, numGrupos);// Verifica hacia arriba 
            CantidadGrupo(matriz, x - 1, y, numGrupos);// Verifica hacia abajo
            CantidadGrupo(matriz, x, y - 1, numGrupos);// Verifica hacia izquierda
            CantidadGrupo(matriz, x, y + 1, numGrupos);// Verifica hacia derecha 

        }

        //-|Creacion de grupos|---------------------------------------------------------------------------------------------------//
        public static void CalcularTamanoGrupos(int[,] matriz, int numeroGrupos)
        {
            for (int a = 0; a < numeroGrupos; a++)
            {
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                        if (matriz[i, j] == contador)
                        {
                            dimension++;
                        }
                    }
                }
                Console.WriteLine("Tamaño del grupo N°{0}: {1}",contador, dimension);
                contador++;
                dimension = 0;
            }
        }
    }
}