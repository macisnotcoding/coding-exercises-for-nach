namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea un programa que invierta el orden de una cadena de texto
    /// sin usar funciones propias del lenguaje que lo hagan de forma automática.
    /// - Si le pasamos "Hola mundo" nos retornaría "odnum aloH"
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Fácil
    /// </remarks>
    public static class Ejercicio0007
    {
        public static void Run()
        {
            ExecuteLogic("Hola mundo!");
        }

        private static void ExecuteLogic(string palabraAInvertir)
        {
            Console.WriteLine("La palabra original era {0}", palabraAInvertir);
            Console.WriteLine("Y su forma invertida es {0}", InvertirPalabra(palabraAInvertir));
        }

        private static string InvertirPalabra(string palabraAInvertir)
        {
            char[] palabraInvertida = new char[palabraAInvertir.Length];

            //Recorremos la palabra original de atras hacia adelante y la guardamos en la palabra invertida
            for (int i = 0; i < palabraInvertida.Length; i++)
            {
                palabraInvertida[i] = palabraAInvertir[palabraAInvertir.Length - (i + 1)];
            }

            return new(palabraInvertida);
        }
    }
}