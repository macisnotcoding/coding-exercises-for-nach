namespace RetosMoureDev.Models.TrucoTrato
{
    public record TrucoTratoPersona(string Nombre, int Edad, int Altura)
    {
        public override string ToString()
        {
            return $"Nombre: {Nombre}, Edad: {Edad}, Altura: {Altura}";
        }
    }
}