using System.Text;

namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea una función que sea capaz de encriptar y desencriptar texto
    /// utilizando el algoritmo de encriptación de Karaca.
    /// Consiste en que para cada palabra:
    /// 1. Reversa la cadena de entrada: Comienzas por invertir la cadena original.Por ejemplo, si la entrada es "karaca", se convierte en "acarak".
    /// 2. Reemplazo de vocales: Cada vocal en la cadena invertida se reemplaza de acuerdo a una regla específica. Las vocales son reemplazadas de la siguiente manera:
    ///    - 'a' se convierte en '0'
    ///    - 'e' se convierte en '1'
    ///    - 'i' se convierte en '2'
    ///    - 'o' se convierte en '3'
    ///    - 'u' se convierte en '4'
    /// Siguiendo el ejemplo anterior, "acarak" se convierte en "0c0r0k".
    /// 3. Añadir "aca" al final de la cadena: Finalmente, se añade "aca" al final de la cadena resultante. Así, "0c0r0k" se convierte en "0c0r0kaca"
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Fácil
    /// </remarks>
    public static class Ejercicio0051
    {
        public static void Run()
        {
            ExecuteLogic("placa", false);
            ExecuteLogic("0c0lpaca", true);

            ExecuteLogic("Este es el penúltimo reto de programación del año", false);
            ExecuteLogic("1ts1aca s1aca l1aca 3m2tlún1paca 3t1raca 1daca nó2c0m0rg3rpaca l1daca 3ñ0aca", true);

            // El algoritmo no soporta estos casos
            ExecuteLogic("1", false);
            ExecuteLogic("1aca", true);
        }

        private static void ExecuteLogic(string texto, bool esKaraca)
        {
            if (esKaraca)
            {
                Console.WriteLine($"Desencriptando \"{texto}\" -> \"{DesencriptarKaraca(texto)}\"");
            }
            else
            {
                Console.WriteLine($"Encriptando \"{texto}\" -> \"{EncriptarKaraca(texto)}\"");
            }
        }

        private static string EncriptarKaraca(string texto)
        {
            StringBuilder resultado = new();
            List<string> palabras = texto.Split(" ").ToList();

            palabras.ForEach(x => resultado.Append(EncriptarPalabra(x)));

            return resultado.ToString().Trim();
        }

        private static string EncriptarPalabra(string palabra)
        {
            StringBuilder resultado = new();

            foreach (char letra in palabra.ToLowerInvariant().Reverse())
            {
                resultado.Append(letra switch
                {
                    'a' => '0',
                    'e' => '1',
                    'i' => '2',
                    'o' => '3',
                    'u' => '4',
                    _ => letra
                });
            }

            return resultado.Append("aca ").ToString();
        }

        private static string DesencriptarKaraca(string texto)
        {
            StringBuilder resultado = new();
            List<string> palabras = texto.Split(" ").ToList();

            palabras.ForEach(x => resultado.Append(DesencriptarPalabra(x)));

            return resultado.ToString().Trim();
        }

        private static string DesencriptarPalabra(string palabra)
        {
            StringBuilder resultado = new();

            foreach (char letra in palabra.Remove(palabra.Length - 3).ToLowerInvariant().Reverse())
            {
                resultado.Append(letra switch
                {
                    '0' => 'a',
                    '1' => 'e',
                    '2' => 'i',
                    '3' => 'o',
                    '4' => 'u',
                    _ => letra
                });
            }

            return resultado.Append(" ").ToString();
        }
    }
}