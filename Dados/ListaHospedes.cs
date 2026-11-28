using Projeto_SOLID.Model;

namespace Projeto_SOLID.dados;

public class ListaHospedes : IRepository<Hospede>
{
    private readonly List<Hospede> hospedes = new();

    public void Adicionar(Hospede novo) => hospedes.Add(novo);

    public List<Hospede> ListarTodos() => hospedes.ToList();

    public Hospede BuscarPorId(int id) =>
        hospedes.FirstOrDefault(h => h.Id == id)
        ?? throw new InvalidOperationException($"Nenhum hóspede com ID {id} foi encontrado.");

    public void Atualizar(Hospede entidade)
    {
        Hospede atual = BuscarPorId(entidade.Id);
        atual.Atualizar(entidade.Nome, entidade.CPF, entidade.Email, entidade.Telefone);
    }

    public void Remover(Hospede entidade) => hospedes.Remove(entidade);

    public void Remover(int id) => Remover(BuscarPorId(id));
}