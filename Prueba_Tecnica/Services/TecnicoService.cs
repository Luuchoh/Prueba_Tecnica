using Prueba_Tecnica.Models;

namespace Prueba_Tecnica.Services
{
    public class TecnicoService: ITecnicoService
    {
        ProgramContext context;

        public TecnicoService(ProgramContext dbcontext)
        {
            context = dbcontext;
        }
        public IEnumerable<Tecnico> GetAllTechnicians()
        {
            return context.Tecnico;
        }
        public Tecnico GetTechnician(string id)
        {
            return context.Tecnico.Find(id);
        }
        public async Task AddNewTechnician(Tecnico tecnico, List<Elemento> elementos)
        {
            if (elementos.Count > 0 && elementos.Count < 11)
            {
                foreach(var elemento in elementos)
                {
                    var estaElementoRegistrado = context.ElementosPorTecnico.Find(elemento);
                    if (estaElementoRegistrado == null)
                    {
                        ElementosPorTecnico elementosPorTecnico = new ElementosPorTecnico
                        {
                            CodigoTecnico = tecnico.Codigo,
                            CodigoElemento = elemento.Codigo,
                        };
                        context.ElementosPorTecnico.Add(elementosPorTecnico);
                        context.Add(tecnico);
                        await context.SaveChangesAsync();
                    } else
                    {
                        var elementoRegistrado = context.Elemento.Find(elemento);
                        throw new Exception($"El elemento {elementoRegistrado.Nombre} ya se encuentra en uso");
                    }
                }
                
            } else
            {
                throw new Exception("El tecnico debe tener minimo 1 elemento y maximo 10");
            }
            
        }

        public async Task UpdateTechnician(string id, Tecnico tecnico, List<Elemento> elementos)
        {
            if (elementos.Count > 0 && elementos.Count < 11)
            {
                var tecnicoActual = context.Tecnico.Find(id);
                if (tecnicoActual != null)
                {
                    tecnicoActual.Nombre = tecnico.Nombre;
                    tecnicoActual.SueldoBase = tecnico.SueldoBase;

                    await context.SaveChangesAsync();
                }
            }
            else
            {
                throw new Exception("El tecnico debe tener minimo 1 elemento y maximo 10");
            }
            
        }
        public async Task DeleteTechnician(string id)
        {
            var tecnicoActual = context.Tecnico.Find(id);
            if (tecnicoActual != null)
            {
                context.Remove(tecnicoActual);
                await context.SaveChangesAsync();
            }
        }
    }

    public interface ITecnicoService
    {
        IEnumerable<Tecnico> GetAllTechnicians();
        Tecnico GetTechnician(string id);
        Task AddNewTechnician(Tecnico tecnico, List<Elemento> elementos);
        Task UpdateTechnician(string id, Tecnico tecnico, List<Elemento> elementos);
        Task DeleteTechnician(string id);

    }
}
