using RetosMoureDev.Models.Poligonos;

namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea una única función (importante que sólo sea una) que sea capaz
    /// de calcular y retornar el área de un polígono.
    /// - La función recibirá por parámetro sólo UN polígono a la vez.
    /// - Los polígonos soportados serán Triángulo, Cuadrado y Rectángulo.
    /// - Imprime el cálculo del área de un polígono de cada tipo.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Facil
    /// </remarks>
    public class Ejercicio0005
    {
        public static void Run()
        {
            ExecuteLogic(new Triangulo(2, 5));
            ExecuteLogic(new Cuadrado(2));
            ExecuteLogic(new Rectangulo(2, 5));
        }

        private static void ExecuteLogic(Poligono poligono)
        {
            Console.WriteLine("El área del {0} es {1}", poligono.GetType().Name ,poligono.CalcularArea());
        }
    }
}