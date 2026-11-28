namespace Projeto_SOLID.View;

public class MenuQuartosView : IMenuView
{
    public int ExibirMenu()
    {
        Console.WriteLine("\n===== GERENCIAR QUARTOS =====");
        Console.WriteLine("1 - Cadastrar quarto");
        Console.WriteLine("2 - Listar quartos");
        Console.WriteLine("3 - Buscar quarto por ID");
        Console.WriteLine("4 - Atualizar quarto");
        Console.WriteLine("5 - Remover quarto");
        Console.WriteLine("0 - Voltar");
        Console.Write("Opção: ");
        return int.TryParse(Console.ReadLine(), out int opcao) ? opcao : -1;
    }
}