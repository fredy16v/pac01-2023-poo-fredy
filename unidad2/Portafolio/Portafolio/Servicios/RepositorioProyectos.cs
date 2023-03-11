using Portafolio.Interfaces;
using Portafolio.Models;

namespace Portafolio.Servicios
{
    public class RepositorioProyectos : IRepositorioProyectos
    {
        public List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>
            {
                new Proyecto
                {
                    Titulo = "La Prensa",
                    Descripcion = "Aplicacion de PLanilla realizado en ASP.Net Core",
                    ImagenUrl = "/images/pic-laprensa.png",
                    Link = "http://laprensa.hn"
                },
                new Proyecto
                {
                    Titulo = "Diunsa",
                    Descripcion = "E-Comere desarrollado en React",
                    ImagenUrl = "/images/pic-diunsa.png",
                    Link = "http://diunsa.hn"
                },
                new Proyecto
                {
                    Titulo = "JetStereo",
                    Descripcion = "Desarrollo de un sistema de cotizaciones Oneline en React",
                    ImagenUrl = "/images/pic-jetstereo.png",
                    Link = "http://diunsa.hn"
                },
                new Proyecto
                {
                    Titulo = "UNAH",
                    Descripcion = "Sistema de matricula en ASP.Net Core con base de datos Oracle",
                    ImagenUrl = "/images/pic-unah.png",
                    Link = "http://unah.hn.edu"
                },
            };
        }
    }
}
