using NihonItarareApi.Context;
using NihonItarareApi.Models;

namespace NihonItarareApi.Repository.Mesas
{
    public class MesaRepository : IMesaRepository
    {
        private readonly AppDbContext _context;

        public MesaRepository(AppDbContext context)
        {
            _context = context; 
        }

        public Mesa? ObterMesaPorId(int id)
        {
            try
            {
                return _context.Mesa
                    .FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Mesa> ObterMesas()
        {
            try
            {
                return _context.Mesa.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Mesa? InserirMesa(Mesa mesa)
        {
            try
            {
                _context.Mesa.Add(mesa);
                _context.SaveChanges();
                return mesa;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool AlterarMesa(Mesa mesa)
        {
            try
            {
                _context.Mesa.Update(mesa);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeletarMesa(int id)
        {
            try
            {
                var atual = ObterMesaPorId(id);
                if (atual != null)
                {
                    _context.Mesa.Remove(atual);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
