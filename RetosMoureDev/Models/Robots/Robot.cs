namespace RetosMoureDev.Models.Robots
{
    public class Robot()
    {
        public (int x, int y) Coordenadas { get; set; } = (0,0);
        public RobotDireccion DireccionActual { get; set; } = RobotDireccion.Arriba;

        public void Mover(int pasos)
        {
            if (DireccionActual == RobotDireccion.Arriba)
            {
                Coordenadas = (Coordenadas.x, Coordenadas.y + pasos);
                DireccionActual = RobotDireccion.Izquierda;
            }
            else if (DireccionActual == RobotDireccion.Izquierda)
            {
                Coordenadas = (Coordenadas.x - pasos, Coordenadas.y);
                DireccionActual = RobotDireccion.Abajo;
            }
            else if (DireccionActual == RobotDireccion.Abajo)
            {
                Coordenadas = (Coordenadas.x, Coordenadas.y - pasos);
                DireccionActual = RobotDireccion.Derecha;
            }
            else if (DireccionActual == RobotDireccion.Derecha)
            {
                Coordenadas = (Coordenadas.x + pasos, Coordenadas.y);
                DireccionActual = RobotDireccion.Arriba;
            }
        }
    }
}