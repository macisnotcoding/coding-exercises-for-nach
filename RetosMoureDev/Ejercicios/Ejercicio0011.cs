namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea un programa que comprueba si los paréntesis, llaves y corchetes
    /// de una expresión están equilibrados.
    /// - Equilibrado significa que estos delimitadores se abren y cierran
    ///   en orden y de forma correcta.
    /// - Paréntesis, llaves y corchetes son igual de prioritarios.
    ///   No hay uno más importante que otro.
    /// - Expresión balanceada: { [ a * ( c + d ) ] - 5 }
    /// - Expresión no balanceada: { a * ( c + d ) ] - 5 }
    /// </summary>
    /// 
    /// <remarks>
    /// Dificultad: Medio
    /// </remarks>
    public static class Ejercicio0011
    {
        public static void Run()
        {
            ExecuteLogic("{a + b [c] * (2x2)}}}}");
            ExecuteLogic("{ [ a * ( c + d ) ] - 5 }");
            ExecuteLogic("{ a * ( c + d ) ] - 5 }");
            ExecuteLogic("{a^4 + (((ax4)}");
            ExecuteLogic("{ ] a * ( c + d ) + ( 2 - 3 )[ - 5 }");
            ExecuteLogic("{{{{{{(}}}}}}");
            ExecuteLogic("(a");
            ExecuteLogic("([{aaa}])");
        }

        private static void ExecuteLogic(string expresion)
        {
            if (EsExpresionBalanceada(expresion))
            {
                Console.WriteLine($"La expresion \'{expresion}' esta balanceada");
            }
            else
            {
                Console.WriteLine($"La expresion \'{expresion}' NO esta balanceada");
            }
        }

        private static bool EsExpresionBalanceada(string expresion)
        {
            Dictionary<char, char> simbolos = new Dictionary<char, char>
            {
                {'{', '}'},
                {'[', ']'},
                {'(', ')'}
            };

            //Usamos un stack para guardar los delimitadores que se abren
            //Cuando encontramos uno que se cierra, lo sacamos del stack
            //Si al final del recorrido del string, el stack esta vacio, la expresion esta balanceada
            //Si no, no lo esta
            Stack<char> delimitadoresAbiertos = new Stack<char>();

            foreach (char caracter in expresion)
            {
                //Si el caracter es un delimitador que se abre, lo metemos en el stack
                if (simbolos.ContainsKey(caracter))
                {
                    delimitadoresAbiertos.Push(caracter);
                }//Si el caracter es un delimitador que se cierra, comprobamos que el ultimo delimitador que se abrio sea el que se cierra
                else if (simbolos.ContainsValue(caracter))
                {
                    //Si no hay delimitadores abiertos o el ultimo delimitador abierto no es el que se cierra, la expresion no esta balanceada
                    if (delimitadoresAbiertos.Count == 0 || caracter != simbolos[delimitadoresAbiertos.Pop()])
                    {
                        return false;
                    }
                }
            }

            //Si al final del recorrido del string, el stack esta vacio, la expresion esta balanceada
            return delimitadoresAbiertos.Count == 0;
        }
    }
}