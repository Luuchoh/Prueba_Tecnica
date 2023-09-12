using Prueba_Tecnica.Models;

namespace Prueba_Tecnica.Services
{
    public class SucursalService: ISucursalService
    {
        ProgramContext context;

        public SucursalService(ProgramContext dbcontext)
        {
            context = dbcontext;
        }
        public IEnumerable<Sucursal> GetBranchOffice()
        {
            return context.Sucursal;
        }
        public async Task AddNewBranchOffice(Sucursal sucursal)
        {
            context.Add(sucursal);
            await context.SaveChangesAsync();
        }

        public async Task UpdateBranchOffice(string codigo, Sucursal sucursal)
        {
            var sucursalActual = context.Sucursal.Find(codigo);
            if (sucursalActual != null)
            {
                sucursalActual.Nombre = sucursal.Nombre;

                await context.SaveChangesAsync();
            }
        }
        public async Task DeleteBranchOffice(string codigo)
        {
            var sucursalActual = context.Sucursal.Find(codigo);
            if (sucursalActual != null)
            {
                context.Remove(sucursalActual);
                await context.SaveChangesAsync();
            }
        }
    }
}

public interface ISucursalService
{
    IEnumerable<Sucursal> GetBranchOffice();
    Task AddNewBranchOffice(Sucursal sucursal);
    Task UpdateBranchOffice(string codigo, Sucursal sucursal);
    Task DeleteBranchOffice(string codigo);
}
