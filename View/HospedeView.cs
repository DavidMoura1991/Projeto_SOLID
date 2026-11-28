using Projeto_SOLID.Model;

namespace Projeto_SOLID.View;

public class HospedeView : IHospedeView
{
    public void MostrarHospede(Hospede h)
    {
        Console.WriteLine($"ID: {h.Id} | Nome: {h.Nome} | CPF: {h.CPF}");
        Console.WriteLine($"E-mail: {h.Email} | Telefone: {h.Telefone}");
        Console.WriteLine(new string('-', 55));
    }
}