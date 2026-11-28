namespace Projeto_SOLID.Model;

public class Hospede
{
    public int Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string CPF { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Telefone { get; private set; } = string.Empty;

    public Hospede(int id, string nome, string cpf, string email, string telefone)
    {
        Id = id;
        Atualizar(nome, cpf, email, telefone);
    }

    public void Atualizar(string nome, string cpf, string email, string telefone)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome deve ser preenchido.");
        if (string.IsNullOrWhiteSpace(cpf))
            throw new ArgumentException("O CPF deve ser preenchido.");
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("O e-mail deve ser preenchido.");
        if (string.IsNullOrWhiteSpace(telefone))
            throw new ArgumentException("O telefone deve ser preenchido.");

        Nome = nome.Trim();
        CPF = cpf.Trim();
        Email = email.Trim();
        Telefone = telefone.Trim();
    }

    public void AtualizarId(int id)
    {
        if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "O ID deve ser positivo.");
        Id = id;
    }
}