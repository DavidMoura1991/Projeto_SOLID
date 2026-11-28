using Projeto_SOLID.Model;
namespace Projeto_SOLID.dados;
public interface IReservaRepository
{
    void Adicionar(Reserva reserva);
    List<Reserva> ListarTodos();
    Reserva BuscarPorId(int id);
    void Remover(int id);
}
