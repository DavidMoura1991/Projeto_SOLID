using Projeto_SOLID.dados;
using Projeto_SOLID.Model;
using Projeto_SOLID.View;

namespace Projeto_SOLID.Controller;

public class HospedeController
{
    private readonly IRepository<Hospede> repository;
    private readonly IHospedeView view;
    private readonly ICadastroView<Hospede> cadastroView;
    private readonly Func<int, bool>? possuiReserva;

    public HospedeController(IRepository<Hospede> repository, IHospedeView view,
                             ICadastroView<Hospede> cadastroView, Func<int, bool>? possuiReserva = null)
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
            Hospede hospede = cadastroView.ObterDados();
            if (repository.ListarTodos().Any(h => h.CPF.Equals(hospede.CPF, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("Já existe um hóspede cadastrado com esse CPF.");

            hospede.AtualizarId(ProximoId());
            repository.Adicionar(hospede);
            cadastroView.ExibirMensagem("Hóspede cadastrado com sucesso!");
        }
        catch (Exception ex) { cadastroView.ExibirMensagem($"Não foi possível cadastrar: {ex.Message}"); }
    }

    private int ProximoId()
    {
        List<Hospede> lista = repository.ListarTodos();
        return lista.Count == 0 ? 1 : lista.Max(h => h.Id) + 1;
    }

    public void Listar()
    {
        List<Hospede> lista = repository.ListarTodos();
        if (lista.Count == 0) { Console.WriteLine("Nenhum hóspede cadastrado."); return; }
        foreach (Hospede h in lista) view.MostrarHospede(h);
    }

    public Hospede Buscar(int id) => repository.BuscarPorId(id);

    public void BuscarEExibir()
    {
        try
        {
            Console.Write("ID do hóspede: ");
            int id = LerId();
            view.MostrarHospede(Buscar(id));
        }
        catch (Exception ex) { Console.WriteLine($"Erro: {ex.Message}"); }
    }

    public void Atualizar(int id)
    {
        try
        {
            Hospede atual = Buscar(id);
            Console.WriteLine("Digite os novos dados:");
            Hospede dados = cadastroView.ObterDados();
            bool cpfDuplicado = repository.ListarTodos()
                .Any(h => h.Id != id && h.CPF.Equals(dados.CPF, StringComparison.OrdinalIgnoreCase));
            if (cpfDuplicado) throw new InvalidOperationException("Outro hóspede já utiliza esse CPF.");
            atual.Atualizar(dados.Nome, dados.CPF, dados.Email, dados.Telefone);
            cadastroView.ExibirMensagem("Hóspede atualizado com sucesso!");
        }
        catch (Exception ex) { cadastroView.ExibirMensagem($"Não foi possível atualizar: {ex.Message}"); }
    }

    public void AtualizarSolicitado()
    {
        Console.Write("ID do hóspede que deseja atualizar: ");
        try { Atualizar(LerId()); }
        catch (Exception ex) { Console.WriteLine($"Erro: {ex.Message}"); }
    }

    public void Remover(int id)
    {
        try
        {
            if (possuiReserva?.Invoke(id) == true)
                throw new InvalidOperationException("Não é possível excluir: o hóspede possui reservas ativas. Cancele-as primeiro.");

            repository.Remover(id);
            Console.WriteLine("Hóspede removido.");
        }
        catch (Exception ex) { Console.WriteLine($"Não foi possível remover: {ex.Message}"); }
    }

    public void RemoverSolicitado()
    {
        Console.Write("ID do hóspede que deseja remover: ");
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