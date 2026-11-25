using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.View
{
    internal class MenuQuartosView : IMenuView
    {
        public int ExibirMenu()
        {
            Console.Clear();

            Console.WriteLine("===== GERENCIAMENTO DE QUARTOS =====");
            Console.WriteLine();
            Console.WriteLine("1 - Cadastrar quarto");
            Console.WriteLine("2 - Listar quartos");
            Console.WriteLine("3 - Buscar quarto");
            Console.WriteLine("4 - Atualizar quarto");
            Console.WriteLine("5 - Excluir quarto");
            Console.WriteLine("0 - Voltar");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out int opcao))
                return opcao;

            return -1;
        }
    }
}
