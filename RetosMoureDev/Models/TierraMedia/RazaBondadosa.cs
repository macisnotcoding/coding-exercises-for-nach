namespace RetosMoureDev.Models.TierraMedia
{
    public abstract class RazaBondadosa(string nombre, int valor) : IRaza
    {
        public string Nombre { get; set; } = nombre;
        public int Valor { get; set; } = valor;

        public bool EsMalvada => false;

        public override string ToString()
        {
            return $"{Nombre} ({Valor}) [bueno]";
        }
    }

    public class Peloso() : RazaBondadosa("Peloso", 1) { }
    public class SurenoBueno() : RazaBondadosa("SurenoBueno", 2) { }
    public class Enano() : RazaBondadosa("Enano", 3) { }
    public class Numenoreano() : RazaBondadosa("Numenoreano", 4) { }
    public class Elfo() : RazaBondadosa("Elfo", 5) { }
}