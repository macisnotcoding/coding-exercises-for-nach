using RetosMoureDev.View;
using System.Reflection;

while (true)
{
    Console.Title = "RetosMoureDev by macisnotcoding - https://github.com/macisnotcoding";
    Console.Clear();

    ConsoleUI.PrintWelcomeMessage();
    var input = ConsoleUI.ExerciseInput();

    if (input?.ToLower() == "exit")
    {
        break;
    }

    if (int.TryParse(input, out int ejercicioNum) && ejercicioNum > 0 && ejercicioNum <= 101)
    {

        string className = $"RetosMoureDev.Ejercicios.Ejercicio{ejercicioNum:D4}";
        Type? type = Type.GetType(className);

        if (type != null)
        {
            MethodInfo? method = type.GetMethod("Run", BindingFlags.Public | BindingFlags.Static);
            if (method != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                
                ConsoleUI.PrintSeparator();

                method.Invoke(null, null);

                ConsoleUI.PrintSeparator();

                Console.ResetColor();
            }
            else
            {
                ConsoleUI.PrintError("Método 'Run' no encontrado.");
            }
        }
        else
        {
            ConsoleUI.PrintError("Ejercicio aún no disponible =)");
        }
    }
    else
    {
        ConsoleUI.PrintError("Entrada inválida. Introduce un número entre 1 y 101.");
    }

    ConsoleUI.PrintEndOfMenu();
}