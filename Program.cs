using Projeto_SOLID.Controller;
using Projeto_SOLID.Dados;
using Projeto_SOLID.Model;
using Projeto_SOLID.View;

namespace ProjetoSOLID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Repositórios
            IRepository<Hospede> hospedeRepository =
                new ListaHospedes();

            IRepository<Quarto> quartoRepository =
                new ListaQuartos();

            // Views
            IHospedeView hospedeView =
                new HospedeView();

            IQuartoView quartoView =
                new QuartoView();

            ICadastroView<Hospede> cadastroHospede =
                new CadastroHospede();

            ICadastroView<Quarto> cadastroQuarto =
                new CadastroQuarto();

            IMenuView menuHospedes =
                new MenuHospedesView();

            IMenuView menuQuartos =
                new MenuQuartosView();

            // Controllers
            HospedeController hospedeController =
                new HospedeController(
                    hospedeRepository,
                    hospedeView,
                    cadastroHospede
                );

            QuartoController quartoController =
                new QuartoController(
                    quartoRepository,
                    quartoView,
                    cadastroQuarto
                );

            int opcao;

            do
            {
                Console.Clear();

                Console.WriteLine("========== HOTEL ==========");
                Console.WriteLine();
                Console.WriteLine("1 - Gerenciar hóspedes");
                Console.WriteLine("2 - Gerenciar quartos");
                Console.WriteLine("3 - Reservas (integração futura)");
                Console.WriteLine("0 - Sair");
                Console.WriteLine();
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                    opcao = -1;

                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        MenuHospedes(
                            hospedeController,
                            menuHospedes
                        );
                        break;

                    case 2:
                        MenuQuartos(
                            quartoController,
                            menuQuartos
                        );
                        break;

                    case 3:
                        Console.WriteLine(
                            "O módulo de reservas será integrado posteriormente."
                        );
                        Console.ReadLine();
                        break;

                    case 0:
                        Console.WriteLine("Encerrando o sistema...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        Console.ReadLine();
                        break;
                }

            } while (opcao != 0);
        }

        static void MenuHospedes(
            HospedeController controller,
            IMenuView menu)
        {
            int opcao;

            do
            {
                opcao = menu.ExibirMenu();

                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        controller.Cadastrar();
                        break;

                    case 2:
                        Console.Clear();
                        controller.Listar();
                        Console.WriteLine("\nPressione ENTER para continuar...");
                        Console.ReadLine();
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("Informe o ID do hóspede: ");

                        if (int.TryParse(Console.ReadLine(), out int idBusca))
                            controller.BuscarEExibir(idBusca);
                        else
                            Console.WriteLine("ID inválido.");

                        Console.WriteLine("\nPressione ENTER para continuar...");
                        Console.ReadLine();
                        break;

                    case 4:
                        Console.Clear();
                        Console.Write("Informe o ID do hóspede: ");

                        if (int.TryParse(Console.ReadLine(), out int idAtualizar))
                            controller.Atualizar(idAtualizar);
                        else
                            Console.WriteLine("ID inválido.");

                        break;

                    case 5:
                        Console.Clear();
                        Console.Write("Informe o ID do hóspede: ");

                        if (int.TryParse(Console.ReadLine(), out int idExcluir))
                            controller.Remover(idExcluir);
                        else
                            Console.WriteLine("ID inválido.");

                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        Console.ReadLine();
                        break;
                }

            } while (opcao != 0);
        }

        static void MenuQuartos(
            QuartoController controller,
            IMenuView menu)
        {
            int opcao;

            do
            {
                opcao = menu.ExibirMenu();

                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        controller.Cadastrar();
                        break;

                    case 2:
                        Console.Clear();
                        controller.Listar();
                        Console.WriteLine("\nPressione ENTER para continuar...");
                        Console.ReadLine();
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("Informe o ID do quarto: ");

                        if (int.TryParse(Console.ReadLine(), out int idBusca))
                            controller.BuscarEExibir(idBusca);
                        else
                            Console.WriteLine("ID inválido.");

                        Console.WriteLine("\nPressione ENTER para continuar...");
                        Console.ReadLine();
                        break;

                    case 4:
                        Console.Clear();
                        Console.Write("Informe o ID do quarto: ");

                        if (int.TryParse(Console.ReadLine(), out int idAtualizar))
                            controller.Atualizar(idAtualizar);
                        else
                            Console.WriteLine("ID inválido.");

                        break;

                    case 5:
                        Console.Clear();
                        Console.Write("Informe o ID do quarto: ");

                        if (int.TryParse(Console.ReadLine(), out int idExcluir))
                            controller.Remover(idExcluir);
                        else
                            Console.WriteLine("ID inválido.");

                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        Console.ReadLine();
                        break;
                }

            } while (opcao != 0);
        }
    }
}