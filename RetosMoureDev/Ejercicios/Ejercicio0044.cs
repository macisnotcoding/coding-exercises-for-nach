using RetosMoureDev.Models.TrucoTrato;
using System.Text;

namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Este es un reto especial por Halloween.
    /// Deberemos crear un programa al que le indiquemos si queremos realizar "Truco
    /// o Trato" y un listado (array) de personas con las siguientes propiedades:
    /// - Nombre de la niña o niño
    /// - Edad
    /// - Altura en centímetros
    ///
    /// Si las personas han pedido truco, el programa retornará sustos (aleatorios)
    /// siguiendo estos criterios:
    /// - Un susto por cada 2 letras del nombre por persona
    /// - Dos sustos por cada edad que sea un número par
    /// - Tres sustos por cada 100 cm de altura entre todas las personas
    /// - Sustos: 🎃 👻 💀 🕷 🕸 🦇
    ///
    /// Si las personas han pedido trato, el programa retornará dulces (aleatorios)
    /// siguiendo estos criterios:
    /// - Un dulce por cada letra de nombre
    /// - Un dulce por cada 3 años cumplidos hasta un máximo de 10 años por persona
    /// - Dos dulces por cada 50 cm de altura hasta un máximo de 150 cm por persona
    /// - Dulces: 🍰 🍬 🍡 🍭 🍪 🍫 🧁 🍩
    /// - En caso contrario, retornará un error.
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Medio
    /// </remarks>
    public static class Ejercicio0044
    {
        
        public static void Run()
        {
            ExecuteLogic(
                TrucoTrato.Truco,
                [
                    new("Brais", 35, 177),
                    new("Sara", 9, 122),
                    new("Pedro", 5, 80),
                    new("Roswell", 3, 54)
                ]
            );
            ExecuteLogic(
                TrucoTrato.Trato,
                [
                    new("Brais", 35, 177),
                    new("Sara", 9, 122),
                    new("Pedro", 5, 80),
                    new("Roswell", 3, 54)
                ]
            );
        }

        private static void ExecuteLogic(TrucoTrato trucoTrato, List<TrucoTratoPersona> personas)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("¡TRUCO O TRATO!");
            Console.WriteLine("Estos son los niños que han llamado a tu puerta:");
            personas.ForEach(persona => Console.WriteLine($"- {persona}"));

            Console.WriteLine($"Han escogido {trucoTrato} y se han llevado todos estos {(trucoTrato == TrucoTrato.Truco ? "sustos" : "dulces")}:");
            Console.WriteLine(TrucoOTrato(trucoTrato, personas));
            Console.OutputEncoding = Encoding.Default;
        }

        private static string TrucoOTrato(TrucoTrato trucoTrato, List<TrucoTratoPersona> personas)
        {
            List<string> Sustos =
            [
                "\U0001F383", // Calabaza
                "\U0001F47B", // Fantasma
                "\U0001F480", // Calavera
                "\U0001F577", // Araña
                "\U0001F578", // Telaraña
                "\U0001F987"  // Murciélago
            ];
            List<string> Dulces =
            [
                "\U0001F370", // Pastel
                "\U0001F36C", // Caramelo
                "\U0001F361", // Dango
                "\U0001F36D", // Piruleta
                "\U0001F36A", // Galleta
                "\U0001F36B", // Barra de chocolate
                "\U0001F9C1", // Cupcake
                "\U0001F369"  // Donut
            ];
            StringBuilder result = new();
            Random random = new();
            int totalHeight = 0;

            foreach (var persona in personas)
            {
                if (trucoTrato == TrucoTrato.Truco)
                {
                    // Un susto por cada dos letras del nombre
                    result.Append(string.Concat(Enumerable.Repeat(Sustos[random.Next(Sustos.Count)], persona.Nombre.Replace(" ", "").Length / 2)));

                    // Dos sustos por cada edad par
                    if (persona.Edad % 2 == 0)
                    {
                        result.Append(Sustos[random.Next(Sustos.Count)]);
                        result.Append(Sustos[random.Next(Sustos.Count)]);
                    }

                    // Acumula altura y procesa cada 100 cm
                    totalHeight += persona.Altura;
                    while (totalHeight >= 100)
                    {
                        result.Append(Sustos[random.Next(Sustos.Count)]);
                        result.Append(Sustos[random.Next(Sustos.Count)]);
                        result.Append(Sustos[random.Next(Sustos.Count)]);
                        totalHeight -= 100;
                    }
                }
                else if (trucoTrato == TrucoTrato.Trato)
                {
                    // Un dulce por cada letra del nombre
                    foreach (char c in persona.Nombre.Replace(" ", ""))
                    {
                        result.Append(Dulces[random.Next(Dulces.Count)]);
                    }

                    // Un dulce por cada 3 años cumplidos hasta un máximo de 10 años por persona
                    int ageDulces = Math.Min(10, persona.Edad / 3);
                    for (int i = 0; i < ageDulces; i++)
                    {
                        result.Append(Dulces[random.Next(Dulces.Count)]);
                    }

                    // Dos dulces por cada 50 cm de altura hasta un máximo de 150 cm por persona
                    int heightDulces = (persona.Altura <= 150) ? (2 * (persona.Altura / 50)) : 6;
                    for (int i = 0; i < heightDulces; i++)
                    {
                        result.Append(Dulces[random.Next(Dulces.Count)]);
                    }
                }
            }
            
            return result.ToString();
        }
    }
}