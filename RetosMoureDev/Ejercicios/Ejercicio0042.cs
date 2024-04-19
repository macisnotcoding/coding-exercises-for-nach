namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea una función que calcule el valor del parámetro perdido
    /// correspondiente a la ley de Ohm.
    /// - Enviaremos a la función 2 de los 3 parámetros (V, R, I), y retornará
    ///   el valor del tercero (redondeado a 2 decimales).
    /// - Si los parámetros son incorrectos o insuficientes, la función retornará
    ///   la cadena de texto "Invalid values".
    /// </summary>
    /// <remarks>
    /// 
    /// Dificultad: Facil
    /// </remarks>
    public static class Ejercicio0042
    {
        public static void Run()
        {
            // Ejecutar la lógica del ejercicio
            ExecuteLogic();
            ExecuteLogic(5);
            ExecuteLogic(5, 4);
            ExecuteLogic(5, null, 4);
            ExecuteLogic(null, 5, 4);
            ExecuteLogic(5.125, 4);
            ExecuteLogic(5, null, 4.125);
            ExecuteLogic(null, 5, 4.125);
            ExecuteLogic(5, 0);
            ExecuteLogic(5, null, 0);
            ExecuteLogic(null, 5, 0);
            ExecuteLogic(5, 4, 3);
        }

        //Recibo VRI en lugar de VIR por reutilizar los casos de prueba, pero de toda la vida es VIR, ay este @MoureDev...espabila niño! jaja
        private static void ExecuteLogic(double? V = null, double? R = null, double? I = null)
        {
            Console.WriteLine("Input: V={0} R={1} I={2}",
                V?.ToString() ?? "null",
                R?.ToString() ?? "null",
                I?.ToString() ?? "null"
            );
            Console.WriteLine(CalcularValorParametroPerdidoOhm(V, R, I));
        }

        private static string CalcularValorParametroPerdidoOhm(double? V, double? R, double? I)
        {
            if(V.HasValue && R.HasValue && !I.HasValue)
            { 
                return $"El valor Perdido era I={Math.Round(V.Value / R.Value, 2)}";
            }
            else if (V.HasValue && !R.HasValue && I.HasValue)
            {
                return $"El valor Perdido era R={Math.Round(V.Value / I.Value, 2)}";
            }
            else if (!V.HasValue && R.HasValue && I.HasValue)
            {
                return $"El valor Perdido era V={Math.Round(I.Value * R.Value, 2)}";
            }

            return "Invalid values";
        }
    }
}