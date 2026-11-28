namespace Projeto_SOLID.dados;

public interface IRepository<T>
{
    void Adicionar(T novo);
    List<T> ListarTodos();
    T BuscarPorId(int id);
    void Atualizar(T entidade);
    void Remover(T entidade);
    void Remover(int id);
}