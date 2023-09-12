using Prueba_Tecnica.Models;

namespace Prueba_Tecnica.Data
{
    public class DataTecnicoRequest
    {
        public Tecnico tecnico { get; set; }
        public List<Elemento> elementos { get; set; }
    }
}
