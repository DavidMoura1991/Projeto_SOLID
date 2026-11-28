namespace Projeto_SOLID.View;
public class MenuReservasView : IMenuView
{
    public int ExibirMenu()
    {
        Console.WriteLine("\n========== RESERVAS ==========");
        Console.WriteLine("1 - Cadastrar reserva\n2 - Listar reservas\n3 - Consultar reserva por ID\n4 - Cancelar reserva\n5 - Excluir reserva\n0 - Voltar");
        Console.Write("Opção: ");
        return int.TryParse(Console.ReadLine(),out int op)?op:-1;
    }
}
