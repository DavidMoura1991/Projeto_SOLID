using Projeto_SOLID.Model;
namespace Projeto_SOLID.dados;
public class ListaReservas : IReservaRepository
{
    private readonly List<Reserva> reservas = new();
    public void Adicionar(Reserva reserva)
    {
        if (reserva is null) throw new ArgumentNullException(nameof(reserva));
        if (reservas.Any(r => r.Id == reserva.Id)) throw new InvalidOperationException("ID de reserva duplicado.");
        reserva.AtualizarId(reservas.Count == 0 ? 1 : reservas.Max(r => r.Id)+1);
        reservas.Add(reserva);
    }
    public List<Reserva> ListarTodos() => reservas.ToList();
    public Reserva BuscarPorId(int id) => reservas.FirstOrDefault(r => r.Id == id) ?? throw new InvalidOperationException($"Reserva {id} não encontrada.");
    public void Remover(int id) => reservas.Remove(BuscarPorId(id));
}
