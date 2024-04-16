using RetosMoureDev.Models;

namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Simula el funcionamiento de una máquina expendedora creando una operación
    /// que reciba dinero (array de monedas) y un número que indique la selección
    /// del producto.
    /// - El programa retornará el nombre del producto y un array con el dinero
    ///   de vuelta (con el menor número de monedas).
    /// - Si el dinero es insuficiente o el número de producto no existe,
    ///   deberá indicarse con un mensaje y retornar todas las monedas.
    /// - Si no hay dinero de vuelta, el array se retornará vacío.
    /// - Para que resulte más simple, trabajaremos en céntimos con monedas
    ///   de 5, 10, 50, 100 y 200.
    /// - Debemos controlar que las monedas enviadas estén dentro de las soportadas.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Medio
    /// </remarks>
    public static class Ejercicio0029
    {
        public static void Run()
        {
            ExecuteLogic(new(){ Monedas.CINCO, Monedas.CINCO, Monedas.DIEZ, Monedas.DIEZ, Monedas.DIEZ, Monedas.CINCO }, 1);
            ExecuteLogic(new() { Monedas.CINCO, Monedas.CINCO, Monedas.DIEZ, Monedas.DIEZ, Monedas.DIEZ, Monedas.CINCO }, 3);
            ExecuteLogic(new() { Monedas.CINCO, Monedas.CINCO, Monedas.DIEZ, Monedas.DIEZ, Monedas.DIEZ, Monedas.CINCO, Monedas.CINCUENTA }, 1);
            ExecuteLogic(new() { Monedas.DOSCIENTOS }, 5);
        }

        private static void ExecuteLogic(List<Monedas> monedas, int codigo)
        {
            Dictionary<int, Tuple<string, int>> productos = new()
            {
                {1, Tuple.Create("Agua", 50)},
                {2, Tuple.Create("Coca-Cola", 100)},
                {4, Tuple.Create("Cerveza", 155)},
                {5, Tuple.Create("Pizza", 200)},
                {10, Tuple.Create("Donut", 75)}
            };

            //Comprobamos si el producto existe
            if (!productos.TryGetValue(codigo, out var producto))
            {
                Console.WriteLine($"Error: Has introducido un codigo de producto ({codigo}) que no existe");
                return;
            }

            int dineroTotalIntroducido = monedas.Sum(x => (int)x);

            //Comprobamos si el dinero introducido es suficiente
            if (dineroTotalIntroducido < producto.Item2)
            {
                Console.WriteLine($"Error: Has introducido {dineroTotalIntroducido} centimos y el producto {producto.Item1} vale {producto.Item2}. Te falta dinero");
                return;
            }

            int dineroPendiente = dineroTotalIntroducido - producto.Item2;
            List<Monedas> monedasADevolver = CalcularMonedasADevolver(dineroPendiente)
                .OrderBy(x => (int)x)
                .ToList();

            Console.WriteLine($"¡Aquí tienes tu {producto.Item1}!");
            if (dineroPendiente != 0)
            {
                Console.WriteLine($"Te devuelvo {dineroPendiente} en monedas de {string.Join(", ", monedasADevolver.Select(x => (int)x).ToList())} centimos");
            }
        }

        private static List<Monedas> CalcularMonedasADevolver(int dineroPendiente, List<Monedas>? monedas = null)
        {
            //Si no se ha pasado la lista de monedas, la inicializamos
            monedas ??= new List<Monedas>();
            //Creamos una variable auxiliar para no modificar el dinero pendiente original
            int dineroPendienteActualizado = dineroPendiente;

            //Caso base
            //Si el dinero pendiente es 0, devolvemos la lista de monedas
            if (dineroPendiente == 0)
            {
                return monedas.ToList();
            }

            //Caso recursivo
            //Vamos a buscar la moneda mas grande que sea menor o igual al dinero pendiente
            foreach (Monedas moneda in Enum.GetValues(typeof(Monedas)).Cast<Monedas>().OrderByDescending(x => x))
            {
                //Si la moneda es menor o igual al dinero pendiente, la añadimos a la lista de monedas y actualizamos el dinero pendiente
                if ((int)moneda <= dineroPendiente)
                {
                    dineroPendienteActualizado -= (int)moneda;
                    monedas.Add(moneda);
                    break;
                }
            }

            //Llamada recursiva
            return CalcularMonedasADevolver(dineroPendienteActualizado, monedas);
        }
    }
}