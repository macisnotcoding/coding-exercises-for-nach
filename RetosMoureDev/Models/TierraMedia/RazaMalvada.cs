namespace RetosMoureDev.Models.TierraMedia
{
    public abstract class RazaMalvada(string nombre, int valor) : IRaza
    {
        public string Nombre { get; set; } = nombre;
        public int Valor { get; set; } = valor;

        public bool EsMalvada => true;

        public override string ToString()
        {
            return $"{Nombre} ({Valor}) [malo]";
        }
    }

    public class SurenoMalo() : RazaMalvada("SurenoMalo", 2) { }
    public class Orco() : RazaMalvada("Orco", 2) { }
    public class Goblin() : RazaMalvada("Goblin", 2) { }
    public class Huargo() : RazaMalvada("Huargo", 3) { }
    public class Troll() : RazaMalvada("Troll", 5) { }
}