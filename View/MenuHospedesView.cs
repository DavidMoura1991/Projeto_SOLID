using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.View
{
    internal class MenuHospedesView : IMenuView
    {
        public int ExibirMenu()
        {
            Console.Clear();

            Console.WriteLine("===== GERENCIAMENTO DE HÓSPEDES =====");
            Console.WriteLine();
            Console.WriteLine("1 - Cadastrar hóspede");
            Console.WriteLine("2 - Listar hóspedes");
            Console.WriteLine("3 - Buscar hóspede");
            Console.WriteLine("4 - Atualizar hóspede");
            Console.WriteLine("5 - Excluir hóspede");
            Console.WriteLine("0 - Voltar");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out int opcao))
                return opcao;

            return -1;
        }
    }
}
