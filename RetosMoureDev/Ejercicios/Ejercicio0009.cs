namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea un programa que se encargue de transformar un número
    /// decimal natural(decimal como numero en base 10, no un decimal de c#) a binario sin utilizar funciones propias del lenguaje que lo hagan directamente.
    /// 
    /// (Un numero natural es un numero entero no negativo: 0,1,2,3,4,5,...)
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Fácil <br/>
    /// <a href="https://www.cuemath.com/numbers/decimal-to-binary/">Explicacion de la conversion a Binario</a>
    /// </remarks>
    public static class Ejercicio0009
    {
        public static void Run()
        {
            ExecuteLogic(10);
        }

        private static void ExecuteLogic(uint numero)
        {
            Console.WriteLine($"El numero natural {numero} en base 10 es el {ObtenerBinario(numero)} en binario");
        }

        private static string ObtenerBinario(uint numero)
        {
            //Si el numero es 0, su representacion en binario es 0
            if (numero == 0)
                return "0";

            //Usamos un string para guardar el numero binario
            //Empezamos con un string vacio y vamos añadiendo los restos de la division del numero entre 2
            //Esto se hace de atras hacia adelante, por lo que al final invertimos el string para tener el numero binario correcto
            //Por ejemplo, si el numero es 4, el bucle se ejecutaria 3 veces (4/2 = 2 resto 0, 2/2 = 1 resto 0, 1/2 = 0 resto 1)
            //Y el string seria "001"
            //Al invertirlo, obtenemos el numero binario correcto "100"
            string binario = string.Empty;
            while (numero > 0)
            {
                uint resto = numero % 2;
                binario = resto + binario;
                numero /= 2;
            }

            return binario;
        }
    }
}