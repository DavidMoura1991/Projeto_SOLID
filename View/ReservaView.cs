using Projeto_SOLID.Model;
namespace Projeto_SOLID.View;
public class ReservaView : IReservaView
{
    public void MostrarReserva(Reserva r, Hospede h, IEnumerable<Quarto> quartos)
    {
        var lista=quartos.ToList();
        decimal total=lista.Sum(q=>q.PrecoDiaria)*r.Diarias;
        Console.WriteLine($"\nReserva #{r.Id} | {(r.Cancelada ? "CANCELADA" : "ATIVA")}\nHóspede: {h.Nome} (ID {h.Id})\nPeríodo: {r.DataEntrada:dd/MM/yyyy} até {r.DataSaida:dd/MM/yyyy} ({r.Diarias} diária(s))\nPessoas: {r.QuantidadePessoas}\nQuartos: {string.Join(", ",lista.Select(q=>$"{q.Numero} (ID {q.Id})"))}\nTotal estimado: {total:C2}");
    }
}
