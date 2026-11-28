using Projeto_SOLID.dados;
using Projeto_SOLID.Model;
using Projeto_SOLID.View;

namespace Projeto_SOLID.Controller;

public class QuartoController
{
    private readonly IRepository<Quarto> repository;
    private readonly IQuartoView view;
    private readonly ICadastroView<Quarto> cadastroView;
    private readonly Func<int, bool>? possuiReserva;

    public QuartoController(IRepository<Quarto> repository, IQuartoView view,
                            ICadastroView<Quarto> cadastroView, Func<int, bool>? possuiReserva = null)
    {
        this.repository = repository;
        this.view = view;
        this.cadastroView = cadastroView;
        this.possuiReserva = possuiReserva;
    }

    public void Cadastrar()
    {
        try
        {
            Quarto quarto = cadastroView.ObterDados();
            if (repository.ListarTodos().Any(q => q.Numero == quarto.Numero))
                throw new InvalidOperationException("Já existe um quarto com esse número.");
            quarto.AtualizarId(ProximoId());
            repository.Adicionar(quarto);
            cadastroView.ExibirMensagem("Quarto cadastrado com sucesso!");
        }
        catch (Exception ex) { cadastroView.ExibirMensagem($"Não foi possível cadastrar: {ex.Message}"); }
    }

    private int ProximoId()
    {
        List<Quarto> lista = repository.ListarTodos();
        return lista.Count == 0 ? 1 : lista.Max(q => q.Id) + 1;
    }

    public void Listar()
    {
        List<Quarto> lista = repository.ListarTodos();
        if (lista.Count == 0) { Console.WriteLine("Nenhum quarto cadastrado."); return; }
        foreach (Quarto q in lista) view.MostrarQuarto(q);
    }

    public Quarto Buscar(int id) => repository.BuscarPorId(id);

    public void BuscarEExibir()
    {
        try
        {
            Console.Write("ID do quarto: ");
            int id = LerId();
            view.MostrarQuarto(Buscar(id));
        }
        catch (Exception ex) { Console.WriteLine($"Erro: {ex.Message}"); }
    }

    public void Atualizar(int id)
    {
        try
        {
            Quarto atual = Buscar(id);
            Console.WriteLine("Digite os novos dados:");
            Quarto dados = cadastroView.ObterDados();
            if (repository.ListarTodos().Any(q => q.Id != id && q.Numero == dados.Numero))
                throw new InvalidOperationException("Outro quarto já utiliza esse número.");
            atual.Atualizar(dados.Numero, dados.Tipo, dados.Capacidade, dados.PrecoDiaria, dados.Descricao);
            cadastroView.ExibirMensagem("Quarto atualizado com sucesso!");
        }
        catch (Exception ex) { cadastroView.ExibirMensagem($"Não foi possível atualizar: {ex.Message}"); }
    }

    public void AtualizarSolicitado()
    {
        Console.Write("ID do quarto que deseja atualizar: ");
        try { Atualizar(LerId()); }
        catch (Exception ex) { Console.WriteLine($"Erro: {ex.Message}"); }
    }

    public void Remover(int id)
    {
        try { if (possuiReserva?.Invoke(id) == true) throw new InvalidOperationException("Não é possível excluir: o quarto possui reservas ativas. Cancele-as primeiro."); repository.Remover(id); Console.WriteLine("Quarto removido."); }
        catch (Exception ex) { Console.WriteLine($"Não foi possível remover: {ex.Message}"); }
    }

    public void RemoverSolicitado()
    {
        Console.Write("ID do quarto que deseja remover: ");
        try { Remover(LerId()); }
        catch (Exception ex) { Console.WriteLine($"Erro: {ex.Message}"); }
    }

    private static int LerId()
    {
        if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            throw new ArgumentException("Informe um ID inteiro positivo.");
        return id;
    }
}