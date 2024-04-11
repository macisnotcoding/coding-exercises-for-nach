namespace RetosMoureDev.Models.Poligonos
{
    public class Triangulo(double @base, double altura) : Poligono
    {
        private readonly double b = @base;
        private readonly double h = altura;

        public double CalcularArea()
        {
            return (b * h) / 2;
        }
    }
}
