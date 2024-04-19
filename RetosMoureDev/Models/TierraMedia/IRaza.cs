namespace RetosMoureDev.Models.TierraMedia
{
    public interface IRaza
    {
        string Nombre { get; set; }
        int Valor { get; set; }
        bool EsMalvada { get; }
        string ToString();
    }
}