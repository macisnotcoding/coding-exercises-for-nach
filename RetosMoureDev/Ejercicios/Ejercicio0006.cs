using System.Drawing;

namespace RetosMoureDev.Ejercicios
{
    /// <summary>
    /// Crea un programa que se encargue de calcular el aspect ratio de una
    /// imagen a partir de una url.
    /// - Url de ejemplo:
    ///   https://raw.githubusercontent.com/mouredevmouredev/master/mouredev_github_profile.png
    /// - Por ratio hacemos referencia por ejemplo a los "16:9" de una
    ///   imagen de 1920*1080px.
    /// </summary>
    /// <remarks>
    /// Dificultad: Difícil
    /// </remarks>
    public class Ejercicio0006
    {
        public static void Run()
        {
            string urlImagen = "https://i.pinimg.com/originals/8e/51/30/8e51302d51089d0f234dc16314c4e5b6.jpg";
            RunAsync(urlImagen).Wait(); // Espera a que RunAsync finalice para continuar con el programa principal
        }

        public static async Task RunAsync(string urlImagen)
        {
            await ExecuteLogic(urlImagen);
        }

        private static async Task ExecuteLogic(string urlImagen)
        {
            try
            {
                Console.WriteLine($"Imagen a analizar alojada en {urlImagen}");
                var ratio = await GetImageAspectRatio(urlImagen);
                Console.WriteLine($"El aspect ratio de la imagen es: {ratio}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static async Task<string> GetImageAspectRatio(string urlImagen)
        {
            //Usamos HttpClient para descargar la imagen y poder obtener su ancho y alto
            using (var client = new HttpClient())
            {
                //Descargamos la imagen
                var response = await client.GetAsync(urlImagen);
                response.EnsureSuccessStatusCode();

                //Leemos la imagen como un stream
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    #region Windows only
                    var imagen = Image.FromStream(stream);
                    int ancho = imagen.Width;
                    int alto = imagen.Height;

                    //Ahora que tenemos el ancho y alto de la imagen (1920x1080px por ejemplo) calculamos el maximo comun divisor (MCD) de ambos
                    //y dividimos cada proporcion por este para sacar el ratio
                    //Por ejemplo, si el MCD de 1920 y 1080 es 120, el aspect ratio de la imagen es 16:9
                    int mcd = MCD(ancho, alto);


                    return $"{ancho / mcd}:{alto / mcd}";
                    #endregion

                    #region Linux/macOS
                    // NOTE: If you're using Linux/macOS uncomment this section and comment the windows section
                    /*
                    using(var imagen = await SixLabors.ImageSharp.Image.LoadAsync(stream))
                    {
                        int ancho = imagen.Width;
                        int alto = imagen.Height;
                    
                        int mcd = MCD(ancho, alto);
                    
                        return $"{ancho / mcd}:{alto / mcd}";
                    }
                    */
                    #endregion
                }
            }
        }

        /// <summary>
        /// Calcula el MCD de dos enteros utilizando el metodo del algoritmo de Euclides
        /// </summary>
        /// 
        /// <remarks>
        /// <a href="https://es.wikipedia.org/wiki/Algoritmo_de_Euclides">Explicacion del algoritmo de Euclides</a>
        /// </remarks>
        private static int MCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }
    }
}