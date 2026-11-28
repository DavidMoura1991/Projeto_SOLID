using Projeto_SOLID.Controller;
using Projeto_SOLID.dados;
using Projeto_SOLID.Model;
using Projeto_SOLID.View;

IRepository<Hospede> repositorioHospedes = new ListaHospedes();
IRepository<Quarto> repositorioQuartos = new ListaQuartos();
IReservaRepository repositorioReservas = new ListaReservas();

var reservaController = new ReservaController(repositorioHospedes, repositorioQuartos, repositorioReservas, new ReservaView());
var hospedeController = new HospedeController(repositorioHospedes, new HospedeView(), new CadastroHospede(), reservaController.HospedeTemReserva);
var quartoController = new QuartoController(repositorioQuartos, new QuartoView(), new CadastroQuarto(), reservaController.QuartoTemReserva);
IMenuView menuHospedes = new MenuHospedesView();
IMenuView menuQuartos = new MenuQuartosView();
IMenuView menuReservas = new MenuReservasView();

bool executando = true;
while (executando)
{
    Console.WriteLine("\n========== SISTEMA DE HOTEL ==========");
    Console.WriteLine("1 - Gerenciar hóspedes\n2 - Gerenciar quartos\n3 - Gerenciar reservas\n0 - Sair");
    Console.Write("Opção: ");
    if (!int.TryParse(Console.ReadLine(), out int opcao)) { Console.WriteLine("Digite uma opção válida."); continue; }
    switch (opcao)
    {
        case 1: MenuHospedes(); break;
        case 2: MenuQuartos(); break;
        case 3: MenuReservas(); break;
        case 0: executando=false; Console.WriteLine("Sistema encerrado."); break;
        default: Console.WriteLine("Opção inválida."); break;
    }
}

void MenuHospedes()
{
    bool voltar=false; while(!voltar) switch(menuHospedes.ExibirMenu())
    { case 1:hospedeController.Cadastrar();break; case 2:hospedeController.Listar();break; case 3:hospedeController.BuscarEExibir();break; case 4:hospedeController.AtualizarSolicitado();break; case 5:hospedeController.RemoverSolicitado();break; case 0:voltar=true;break; default:Console.WriteLine("Opção inválida.");break; }
}
void MenuQuartos()
{
    bool voltar=false; while(!voltar) switch(menuQuartos.ExibirMenu())
    { case 1:quartoController.Cadastrar();break; case 2:quartoController.Listar();break; case 3:quartoController.BuscarEExibir();break; case 4:quartoController.AtualizarSolicitado();break; case 5:quartoController.RemoverSolicitado();break; case 0:voltar=true;break; default:Console.WriteLine("Opção inválida.");break; }
}
void MenuReservas()
{
    bool voltar=false; while(!voltar) switch(menuReservas.ExibirMenu())
    { case 1:reservaController.Cadastrar();break; case 2:reservaController.Listar();break; case 3:reservaController.Buscar();break; case 4:reservaController.Cancelar();break; case 5:reservaController.Remover();break; case 0:voltar=true;break; default:Console.WriteLine("Opção inválida.");break; }
}
