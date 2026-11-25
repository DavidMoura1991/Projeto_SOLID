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
    internal class HospedeController
    {
        private readonly IRepository<Hospede> repository;
        private readonly IHospedeView view;
        private readonly ICadastroView<Hospede> cadastroView;

        public HospedeController(
            IRepository<Hospede> repository,
            IHospedeView view,
            ICadastroView<Hospede> cadastroView)
        {
            this.repository = repository;
            this.view = view;
            this.cadastroView = cadastroView;
        }

        public void Cadastrar()
        {
            try
            {
                Hospede hospede = cadastroView.ObterDados();

                bool cpfExiste = repository.ListarTodos()
                    .Any(h => h.CPF == hospede.CPF);

                if (cpfExiste)
                {
                    cadastroView.ExibirMensagem(
                        "Já existe um hóspede cadastrado com esse CPF."
                    );
                    return;
                }

                List<Hospede> hospedes = repository.ListarTodos();

                int id = 1;

                if (hospedes.Count > 0)
                    id = hospedes.Max(h => h.Id) + 1;

                hospede.AtualizarId(id);

                repository.Adicionar(hospede);

                cadastroView.ExibirMensagem(
                    "Hóspede cadastrado com sucesso!"
                );
            }
            catch (Exception ex)
            {
                cadastroView.ExibirMensagem(
                    "Erro ao cadastrar hóspede: " + ex.Message
                );
            }
        }

        public void Listar()
        {
            List<Hospede> hospedes = repository.ListarTodos();

            Console.WriteLine("===== LISTA DE HÓSPEDES =====");

            if (hospedes.Count == 0)
            {
                Console.WriteLine("Nenhum hóspede cadastrado.");
                return;
            }

            foreach (Hospede hospede in hospedes)
            {
                view.MostrarHospede(hospede);
            }
        }

        public Hospede Buscar(int id)
        {
            return repository.BuscarPorId(id);
        }

        public void BuscarEExibir(int id)
        {
            Hospede hospede = Buscar(id);

            if (hospede == null)
            {
                Console.WriteLine("Hóspede não encontrado.");
                return;
            }

            view.MostrarHospede(hospede);
        }

        public void Atualizar(int id)
        {
            try
            {
                Hospede hospedeExistente = Buscar(id);

                if (hospedeExistente == null)
                {
                    cadastroView.ExibirMensagem(
                        "Hóspede não encontrado."
                    );
                    return;
                }

                Console.WriteLine("Digite os novos dados do hóspede:");

                Hospede novosDados = cadastroView.ObterDados();

                bool cpfDuplicado = repository.ListarTodos()
                    .Any(h => h.CPF == novosDados.CPF && h.Id != id);

                if (cpfDuplicado)
                {
                    cadastroView.ExibirMensagem(
                        "Esse CPF já pertence a outro hóspede."
                    );
                    return;
                }

                hospedeExistente.Atualizar(
                    novosDados.Nome,
                    novosDados.CPF,
                    novosDados.Email,
                    novosDados.Telefone
                );

                repository.Atualizar(hospedeExistente);

                cadastroView.ExibirMensagem(
                    "Hóspede atualizado com sucesso!"
                );
            }
            catch (Exception ex)
            {
                cadastroView.ExibirMensagem(
                    "Erro ao atualizar hóspede: " + ex.Message
                );
            }
        }

        public void Remover(int id)
        {
            try
            {
                Hospede hospede = Buscar(id);

                if (hospede == null)
                {
                    cadastroView.ExibirMensagem(
                        "Hóspede não encontrado."
                    );
                    return;
                }

                repository.Remover(id);

                cadastroView.ExibirMensagem(
                    "Hóspede removido com sucesso!"
                );
            }
            catch (Exception ex)
            {
                cadastroView.ExibirMensagem(
                    "Erro ao remover hóspede: " + ex.Message
                );
            }
        }
    }
}
