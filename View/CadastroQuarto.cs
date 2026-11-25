using Projeto_SOLID.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.View
{
    internal class CadastroQuarto : ICadastroView<Quarto>
    {
        public Quarto ObterDados()
        {
            Console.WriteLine("Número do quarto:");
            int numero = int.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Tipo (Simples, Duplo, Suíte):");
            string tipo = Console.ReadLine() ?? "";

            Console.WriteLine("Capacidade:");
            int capacidade = int.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Preço da diária:");
            decimal preco = decimal.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Descrição:");
            string descricao = Console.ReadLine() ?? "";

            return new Quarto(
                0, numero, tipo, capacidade, preco, descricao
            );
        }

        public void ExibirMensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
