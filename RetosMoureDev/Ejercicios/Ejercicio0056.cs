using System.Text;

namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Escribe un programa que sea capaz de generar contraseñas de forma aleatoria.
    /// Podrás configurar generar contraseñas con los siguientes parámetros:
    /// - Longitud: Entre 8 y 16.
    /// - Con o sin letras mayúsculas.
    /// - Con o sin números.
    /// - Con o sin símbolos.
    /// (Pudiendo combinar todos estos parámetros entre ellos)
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Medio
    /// </remarks>
    public static class Ejercicio0056
    {
        public static void Run()
        {
            ExecuteLogic();
            ExecuteLogic(16);
            ExecuteLogic(1);
            ExecuteLogic(22);
            ExecuteLogic(12, conMayusculas: true);
            ExecuteLogic(12, conMayusculas: true, conNumeros: true);
            ExecuteLogic(12, conMayusculas: true, conNumeros: true, conSimbolos: true);
            ExecuteLogic(12, conMayusculas: true, conSimbolos: true);
        }

        private static void ExecuteLogic(int longitud = 8, bool conMayusculas = false, bool conNumeros = false, bool conSimbolos = false)
        {
            Console.WriteLine("Has pedido una contraseña con longitud {0}, {1} mayusculas, {2} numeros y {3} simbolos",
                longitud,
                conMayusculas ? "con" : "sin",
                conNumeros ? "con" : "sin",
                conSimbolos ? "con" : "sin"
            );
            Console.WriteLine($"Aqui la tienes, guardala bien: {GenerarPassword(longitud, conMayusculas, conNumeros, conSimbolos)}");
        }

        // Vamos a añadir un set de caracteres ASCII segun su valor decimal https://www.ascii-code.com/
        private static string GenerarPassword(int longitud = 8, bool conMayusculas = false, bool conNumeros = false, bool conSimbolos = false)
        {
            StringBuilder password = new();
            Random random = new Random();
            longitud = longitud < 8 ? 8 : (longitud > 16 ? 16 : longitud);
            List<int> setCaracteres = Enumerable.Range(97, 26).ToList();

            if (conMayusculas)
                setCaracteres.AddRange(Enumerable.Range(65, 26));

            if (conNumeros)
                setCaracteres.AddRange(Enumerable.Range(48, 10));

            if (conSimbolos)
            {
                setCaracteres.AddRange(Enumerable.Range(33, 15));
                setCaracteres.AddRange(Enumerable.Range(58, 7));
                setCaracteres.AddRange(Enumerable.Range(91, 6));
            }

            while (password.Length < longitud)
            {
                password.Append(
                    Convert.ToChar(
                        setCaracteres[random.Next(setCaracteres.Count)]
                    )
                );
            }
            
            return password.ToString();
        }
    }
}