namespace RetosMoureDev.Models.Poligonos
{
    public class Cuadrado(double lado) : Poligono
    {
        private readonly double lado = lado;

        public double CalcularArea()
        {
            return Math.Pow(lado, 2);
        }
    }
}