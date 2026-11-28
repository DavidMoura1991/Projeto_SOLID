using Projeto_SOLID.dados;
using Projeto_SOLID.Model;
using Projeto_SOLID.View;
namespace Projeto_SOLID.Controller;
public class ReservaController
{
    private readonly IRepository<Hospede> hospedes;
    private readonly IRepository<Quarto> quartos;
    private readonly IReservaRepository reservas;
    private readonly IReservaView view;
    public ReservaController(IRepository<Hospede> hospedes, IRepository<Quarto> quartos, IReservaRepository reservas, IReservaView view)
    { this.hospedes=hospedes; this.quartos=quartos; this.reservas=reservas; this.view=view; }

    public void Cadastrar()
    {
        try
        {
            Console.WriteLine("\n--- Nova reserva ---");
            if (!hospedes.ListarTodos().Any()) throw new InvalidOperationException("Cadastre um hóspede antes de reservar.");
            if (!quartos.ListarTodos().Any()) throw new InvalidOperationException("Cadastre pelo menos um quarto antes de reservar.");
            Console.WriteLine("Hóspedes:"); foreach(var h in hospedes.ListarTodos()) Console.WriteLine($"{h.Id} - {h.Nome}");
            int hospedeId=LerInt("ID do hóspede: "); var hospede=hospedes.BuscarPorId(hospedeId);
            int pessoas=LerInt("Quantidade de pessoas: ");
            DateTime entrada=LerData("Data de entrada (dd/MM/aaaa): ");
            DateTime saida=LerData("Data de saída (dd/MM/aaaa): ");
            Console.WriteLine("Quartos disponíveis no cadastro:"); foreach(var q in quartos.ListarTodos()) Console.WriteLine($"ID {q.Id} | Nº {q.Numero} | {q.Tipo} | capacidade {q.Capacidade} | {q.PrecoDiaria:C2}/diária");
            Console.Write("IDs dos quartos separados por vírgula: ");
            var ids=(Console.ReadLine()??"").Split(',',StringSplitOptions.RemoveEmptyEntries|StringSplitOptions.TrimEntries).Select(x=>int.TryParse(x,out int id)?id:0).ToList();
            var selecionados=ids.Select(quartos.BuscarPorId).ToList();
            if(selecionados.Sum(q=>q.Capacidade)<pessoas) throw new InvalidOperationException("A capacidade total dos quartos escolhidos é insuficiente.");
            var nova=new Reserva(0,hospedeId,entrada,saida,pessoas,ids);
            foreach(var existente in reservas.ListarTodos().Where(r=>!r.Cancelada && r.Sobrepoe(entrada,saida)))
                if(existente.QuartosIds.Intersect(ids).Any()) throw new InvalidOperationException($"Conflito: um dos quartos já está reservado no período pela reserva {existente.Id}.");
            reservas.Adicionar(nova);
            Console.WriteLine("Reserva cadastrada com sucesso!"); Exibir(nova);
        }
        catch(Exception ex){Console.WriteLine($"Não foi possível cadastrar a reserva: {ex.Message}");}
    }
    public void Listar()
    { var lista=reservas.ListarTodos(); if(!lista.Any()){Console.WriteLine("Nenhuma reserva cadastrada.");return;} foreach(var r in lista) Exibir(r); }
    public void Buscar()
    { try{var r=reservas.BuscarPorId(LerInt("ID da reserva: "));Exibir(r);}catch(Exception ex){Console.WriteLine(ex.Message);} }
    public void Cancelar()
    { try{var r=reservas.BuscarPorId(LerInt("ID da reserva para cancelar: "));if(r.Cancelada) throw new InvalidOperationException("Essa reserva já está cancelada.");r.Cancelar();Console.WriteLine("Reserva cancelada. Os quartos foram liberados para esse período.");}catch(Exception ex){Console.WriteLine(ex.Message);} }
    public void Remover()
    { try{reservas.Remover(LerInt("ID da reserva para excluir: "));Console.WriteLine("Reserva excluída.");}catch(Exception ex){Console.WriteLine(ex.Message);} }
    public bool HospedeTemReserva(int id)=>reservas.ListarTodos().Any(r=>r.HospedeId==id);
    public bool QuartoTemReserva(int id)=>reservas.ListarTodos().Any(r=>r.QuartosIds.Contains(id));
    private void Exibir(Reserva r)
    { var h=hospedes.BuscarPorId(r.HospedeId); var qs=r.QuartosIds.Select(quartos.BuscarPorId); view.MostrarReserva(r,h,qs); }
    private static int LerInt(string msg){Console.Write(msg);if(!int.TryParse(Console.ReadLine(),out int n)||n<=0)throw new ArgumentException("Informe um número inteiro positivo.");return n;}
    private static DateTime LerData(string msg){Console.Write(msg);if(!DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",System.Globalization.CultureInfo.GetCultureInfo("pt-BR"),System.Globalization.DateTimeStyles.None,out var d))throw new ArgumentException("Data inválida. Use dd/MM/aaaa.");return d;}
}
