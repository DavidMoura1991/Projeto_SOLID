namespace Projeto_SOLID.Model;

public class Reserva
{
    private readonly List<int> quartosIds = new();
    public int Id { get; private set; }
    public int HospedeId { get; private set; }
    public DateTime DataEntrada { get; private set; }
    public DateTime DataSaida { get; private set; }
    public int QuantidadePessoas { get; private set; }
    public IReadOnlyList<int> QuartosIds => quartosIds.AsReadOnly();
    public bool Cancelada { get; private set; }

    public Reserva(int id, int hospedeId, DateTime entrada, DateTime saida, int quantidadePessoas, IEnumerable<int> quartos)
    {
        if (hospedeId <= 0) throw new ArgumentException("Selecione um hóspede válido.");
        if (entrada.Date < DateTime.Today) throw new ArgumentException("A entrada não pode ser anterior à data de hoje.");
        if (saida.Date <= entrada.Date) throw new ArgumentException("A saída deve ser posterior à entrada.");
        if (quantidadePessoas <= 0) throw new ArgumentException("A quantidade de pessoas deve ser positiva.");
        var ids = quartos?.Distinct().ToList() ?? new List<int>();
        if (ids.Count == 0 || ids.Any(x => x <= 0)) throw new ArgumentException("Selecione pelo menos um quarto válido.");
        Id=id; HospedeId=hospedeId; DataEntrada=entrada.Date; DataSaida=saida.Date;
        QuantidadePessoas=quantidadePessoas; quartosIds.AddRange(ids);
    }
    public int Diarias => (DataSaida.Date-DataEntrada.Date).Days;
    public bool Sobrepoe(DateTime entrada, DateTime saida) => !Cancelada && DataEntrada < saida.Date && entrada.Date < DataSaida;
    public void AtualizarId(int id) { if(id<=0) throw new ArgumentOutOfRangeException(nameof(id)); Id=id; }
    public void Cancelar() => Cancelada=true;
}
