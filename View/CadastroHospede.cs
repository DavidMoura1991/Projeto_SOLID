using Projeto_SOLID.Model;

namespace Projeto_SOLID.View;

public class CadastroHospede : ICadastroView<Hospede>
{
    public Hospede ObterDados()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine() ?? "";
        Console.Write("CPF: ");
        string cpf = Console.ReadLine() ?? "";
        Console.Write("E-mail: ");
        string email = Console.ReadLine() ?? "";
        Console.Write("Telefone: ");
        string telefone = Console.ReadLine() ?? "";
        return new Hospede(0, nome, cpf, email, telefone);
    }

    public void ExibirMensagem(string mensagem) => Console.WriteLine(mensagem);
}