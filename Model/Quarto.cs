namespace Projeto_SOLID.Model;

public class Quarto
{
    public int Id { get; private set; }
    public int Numero { get; private set; }
    public string Tipo { get; private set; } = string.Empty;
    public int Capacidade { get; private set; }
    public decimal PrecoDiaria { get; private set; }
    public string Descricao { get; private set; } = string.Empty;

    public Quarto(int id, int numero, string tipo, int capacidade, decimal precoDiaria, string descricao)
    {
        Id = id;
        Atualizar(numero, tipo, capacidade, precoDiaria, descricao);
    }

    public void Atualizar(int numero, string tipo, int capacidade, decimal precoDiaria, string descricao)
    {
        if (numero <= 0) throw new ArgumentException("O número do quarto deve ser positivo.");
        if (string.IsNullOrWhiteSpace(tipo)) throw new ArgumentException("O tipo deve ser preenchido.");
        if (capacidade <= 0) throw new ArgumentException("A capacidade deve ser maior que zero.");
        if (precoDiaria <= 0) throw new ArgumentException("O preço da diária deve ser maior que zero.");

        Numero = numero;
        Tipo = tipo.Trim();
        Capacidade = capacidade;
        PrecoDiaria = precoDiaria;
        Descricao = descricao?.Trim() ?? "";
    }

    public void AtualizarId(int id)
    {
        if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "O ID deve ser positivo.");
        Id = id;
    }
}