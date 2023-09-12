
using Prueba_Tecnica.Models;

namespace Prueba_Tecnica.Services
{
    public class ElementoService: IElementoServices
    {
        ProgramContext context;

        public ElementoService(ProgramContext dbcontext)
        {
            context = dbcontext;
        }
        public IEnumerable<Elemento> GetElement()
        {
            return context.Elemento;
        }
        public async Task AddNewElement(Elemento elemento)
        {
            context.Add(elemento);
            await context.SaveChangesAsync();
        }

        public async Task UpdateElement(string codigo, Elemento elemento)
        {
            var elementoActual = context.Tecnico.Find(codigo);
            if (elementoActual != null)
            {
                elementoActual.Nombre = elemento.Nombre;

                await context.SaveChangesAsync();
            }
        }
        public async Task DeleteElement(string codigo)
        {
            var tecnicoActual = context.Tecnico.Find(codigo);
            if (tecnicoActual != null)
            {
                context.Remove(tecnicoActual);
                await context.SaveChangesAsync();
            }
        }
    }
}

public interface IElementoServices
{
    IEnumerable<Elemento> GetElement();
    Task AddNewElement(Elemento elemento);
    Task UpdateElement(string codigo, Elemento elemento);
    Task DeleteElement(string codigo);
}
