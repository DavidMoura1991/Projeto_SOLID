namespace Projeto_SOLID.View;

public class MenuHospedesView : IMenuView
{
    public int ExibirMenu()
    {
        Console.WriteLine("\n===== GERENCIAR HÓSPEDES =====");
        Console.WriteLine("1 - Cadastrar hóspede");
        Console.WriteLine("2 - Listar hóspedes");
        Console.WriteLine("3 - Buscar hóspede por ID");
        Console.WriteLine("4 - Atualizar hóspede");
        Console.WriteLine("5 - Remover hóspede");
        Console.WriteLine("0 - Voltar");
        Console.Write("Opção: ");
        return int.TryParse(Console.ReadLine(), out int opcao) ? opcao : -1;
    }
}