using Projeto_SOLID.Dados;
using Projeto_SOLID.Model;
using Projeto_SOLID.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.Controller
{
    internal class QuartoController
    {
        private readonly IRepository<Quarto> repository;
        private readonly IQuartoView view;
        private readonly ICadastroView<Quarto> cadastroView;

        public QuartoController(
            IRepository<Quarto> repository,
            IQuartoView view,
            ICadastroView<Quarto> cadastroView)
        {
            this.repository = repository;
            this.view = view;
            this.cadastroView = cadastroView;
        }

        public void Cadastrar()
        {
            try
            {
                Quarto quarto = cadastroView.ObterDados();

                bool numeroExiste = repository.ListarTodos()
                    .Any(q => q.Numero == quarto.Numero);

                if (numeroExiste)
                {
                    cadastroView.ExibirMensagem(
                        "Já existe um quarto com esse número."
                    );
                    return;
                }

                List<Quarto> quartos = repository.ListarTodos();

                int id = 1;

                if (quartos.Count > 0)
                    id = quartos.Max(q => q.Id) + 1;

                quarto.AtualizarId(id);

                repository.Adicionar(quarto);

                cadastroView.ExibirMensagem(
                    "Quarto cadastrado com sucesso!"
                );
            }
            catch (Exception ex)
            {
                cadastroView.ExibirMensagem(
                    "Erro ao cadastrar quarto: " + ex.Message
                );
            }
        }

        public void Listar()
        {
            List<Quarto> quartos = repository.ListarTodos();

            Console.WriteLine("===== LISTA DE QUARTOS =====");

            if (quartos.Count == 0)
            {
                Console.WriteLine("Nenhum quarto cadastrado.");
                return;
            }

            foreach (Quarto quarto in quartos)
            {
                view.MostrarQuarto(quarto);
            }
        }

        public Quarto Buscar(int id)
        {
            return repository.BuscarPorId(id);
        }

        public void BuscarEExibir(int id)
        {
            Quarto quarto = Buscar(id);

            if (quarto == null)
            {
                Console.WriteLine("Quarto não encontrado.");
                return;
            }

            view.MostrarQuarto(quarto);
        }

        public void Atualizar(int id)
        {
            try
            {
                Quarto quartoExistente = Buscar(id);

                if (quartoExistente == null)
                {
                    cadastroView.ExibirMensagem(
                        "Quarto não encontrado."
                    );
                    return;
                }

                Console.WriteLine("Digite os novos dados do quarto:");

                Quarto novosDados = cadastroView.ObterDados();

                bool numeroDuplicado = repository.ListarTodos()
                    .Any(q => q.Numero == novosDados.Numero && q.Id != id);

                if (numeroDuplicado)
                {
                    cadastroView.ExibirMensagem(
                        "Já existe outro quarto com esse número."
                    );
                    return;
                }

                quartoExistente.Atualizar(
                    novosDados.Numero,
                    novosDados.Tipo,
                    novosDados.Capacidade,
                    novosDados.PrecoDiaria,
                    novosDados.Descricao
                );

                repository.Atualizar(quartoExistente);

                cadastroView.ExibirMensagem(
                    "Quarto atualizado com sucesso!"
                );
            }
            catch (Exception ex)
            {
                cadastroView.ExibirMensagem(
                    "Erro ao atualizar quarto: " + ex.Message
                );
            }
        }

        public void Remover(int id)
        {
            try
            {
                Quarto quarto = Buscar(id);

                if (quarto == null)
                {
                    cadastroView.ExibirMensagem(
                        "Quarto não encontrado."
                    );
                    return;
                }

                repository.Remover(id);

                cadastroView.ExibirMensagem(
                    "Quarto removido com sucesso!"
                );
            }
            catch (Exception ex)
            {
                cadastroView.ExibirMensagem(
                    "Erro ao remover quarto: " + ex.Message
                );
            }
        }
    }
}
