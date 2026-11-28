using Projeto_SOLID.Model;

namespace Projeto_SOLID.View;

public class QuartoView : IQuartoView
{
    public void MostrarQuarto(Quarto q)
    {
        Console.WriteLine($"ID: {q.Id} | Número: {q.Numero} | Tipo: {q.Tipo}");
        Console.WriteLine($"Capacidade: {q.Capacidade} | Diária: {q.PrecoDiaria:C}");
        Console.WriteLine($"Descrição: {q.Descricao}");
        Console.WriteLine(new string('-', 55));
    }
}