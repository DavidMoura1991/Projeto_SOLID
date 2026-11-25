using Projeto_SOLID.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.View
{
    internal class CadastroHospede : ICadastroView<Hospede>
    {
        public Hospede ObterDados()
        {
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine() ?? "";

            Console.WriteLine("CPF:");
            string cpf = Console.ReadLine() ?? "";

            Console.WriteLine("Email:");
            string email = Console.ReadLine() ?? "";

            Console.WriteLine("Telefone:");
            string telefone = Console.ReadLine() ?? "";

            return new Hospede(0, nome, cpf, email, telefone);
        }

        public void ExibirMensagem(string mensagem)
        {
            Console.WriteLine($"\n{mensagem}");
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
