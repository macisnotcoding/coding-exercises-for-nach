using RetosMoureDev.Models;

namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea un programa que dibuje un cuadrado o un triángulo con asteriscos "*".
    /// - Indicaremos el tamaño del lado y si la figura a dibujar es una u otra.
    /// - EXTRA: ¿Eres capaz de dibujar más figuras?
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Fácil
    /// </remarks>
    public static class Ejercicio0027
    {
        public static void Run()
        {
            ExecuteLogic(10, TipoFigura.CUADRADO);
            ExecuteLogic(10, TipoFigura.TRIANGULO);
            ExecuteLogic(5, TipoFigura.CIRCULO);
        }

        private static void ExecuteLogic(int size, TipoFigura tipoFigura)
        {
            switch (tipoFigura)
            {
                case TipoFigura.CUADRADO:
                    DibujarCuadrado(size);
                    break;
                case TipoFigura.TRIANGULO:
                    DibujarTriangulo(size);
                    break;
                case TipoFigura.CIRCULO:
                    DibujarCirculo(size);
                    break;
                default:
                    Console.WriteLine("Figura desconocida");
                    break;
            }
        }

        private static void DibujarCuadrado(int size)
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(new string('*', size));
            }
        }

        private static void DibujarTriangulo(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                Console.WriteLine(new string('*', i));
            }
        }

        private static void DibujarCirculo(int radio) // EXTRA
        {
            double r_in = radio - 0.4;
            double r_out = radio + 0.4;
            for (int y = radio; y >= -radio; --y)
            {
                for (int x = -radio; x < r_out; x++)
                {
                    double value = x * x + y * y;
                    if (value >= r_in * r_in && value <= r_out * r_out)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }
    }
}