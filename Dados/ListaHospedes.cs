using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_SOLID.Model;

namespace Projeto_SOLID.Dados
{
    internal class ListaHospedes : IRepository<Hospede>
    {
        private readonly List<Hospede> hospedes;

        public ListaHospedes()
        {
            hospedes = new List<Hospede>();
        }

        public void Adicionar(Hospede hospede)
        {
            hospedes.Add(hospede);
        }

        public List<Hospede> ListarTodos()
        {
            return hospedes.ToList();
        }

        public Hospede BuscarPorId(int id)
        {
            return hospedes.FirstOrDefault(h => h.Id == id);
        }

        public void Atualizar(Hospede entidade)
        {
            Hospede hospede = BuscarPorId(entidade.Id);

            if (hospede == null)
                throw new InvalidOperationException("Hóspede não encontrado.");

            hospede.Atualizar(
                entidade.Nome,
                entidade.CPF,
                entidade.Email,
                entidade.Telefone
            );
        }

        public void Remover(Hospede hospede)
        {
            hospedes.Remove(hospede);
        }

        public void Remover(int id)
        {
            Hospede hospede = BuscarPorId(id);

            if (hospede == null)
                throw new InvalidOperationException("Hóspede não encontrado.");

            Remover(hospede);
        }
    }
}
