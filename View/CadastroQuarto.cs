using Projeto_SOLID.Model;
using System.Globalization;

namespace Projeto_SOLID.View;

public class CadastroQuarto : ICadastroView<Quarto>
{
    public Quarto ObterDados()
    {
        int numero = LerInt("Número do quarto: ");
        Console.Write("Tipo (simples, duplo, suíte etc.): ");
        string tipo = Console.ReadLine() ?? "";
        int capacidade = LerInt("Capacidade: ");
        decimal preco = LerDecimal("Preço da diária: ");
        Console.Write("Descrição: ");
        string descricao = Console.ReadLine() ?? "";
        return new Quarto(0, numero, tipo, capacidade, preco, descricao);
    }

    private static int LerInt(string rotulo)
    {
        Console.Write(rotulo);
        if (!int.TryParse(Console.ReadLine(), out int valor))
            throw new ArgumentException("Digite um número inteiro válido.");
        return valor;
    }

    private static decimal LerDecimal(string rotulo)
    {
        Console.Write(rotulo);
        string entrada = (Console.ReadLine() ?? "").Trim().Replace(',', '.');
        if (!decimal.TryParse(entrada, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal valor))
            throw new ArgumentException("Digite um preço válido. Exemplo: 150,00.");
        return valor;
    }

    public void ExibirMensagem(string mensagem) => Console.WriteLine(mensagem);
}