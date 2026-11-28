namespace Projeto_SOLID.View;

public interface ICadastroView<T>
{
    T ObterDados();
    void ExibirMensagem(string mensagem);
}