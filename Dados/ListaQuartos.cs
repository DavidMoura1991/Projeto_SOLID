using Projeto_SOLID.Model;

namespace Projeto_SOLID.dados;

public class ListaQuartos : IRepository<Quarto>
{
    private readonly List<Quarto> quartos = new();

    public void Adicionar(Quarto novo) => quartos.Add(novo);

    public List<Quarto> ListarTodos() => quartos.ToList();

    public Quarto BuscarPorId(int id) =>
        quartos.FirstOrDefault(q => q.Id == id)
        ?? throw new InvalidOperationException($"Nenhum quarto com ID {id} foi encontrado.");

    public void Atualizar(Quarto entidade)
    {
        Quarto atual = BuscarPorId(entidade.Id);
        atual.Atualizar(entidade.Numero, entidade.Tipo, entidade.Capacidade,
                        entidade.PrecoDiaria, entidade.Descricao);
    }

    public void Remover(Quarto entidade) => quartos.Remove(entidade);

    public void Remover(int id) => Remover(BuscarPorId(id));
}