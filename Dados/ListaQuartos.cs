using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_SOLID.Model;

namespace Projeto_SOLID.Dados
{
    internal class ListaQuartos : IRepository<Quarto>
    {
        private readonly List<Quarto> quartos;

        public ListaQuartos()
        {
            quartos = new List<Quarto>();
        }

        public void Adicionar(Quarto quarto)
        {
            quartos.Add(quarto);
        }

        public List<Quarto> ListarTodos()
        {
            return quartos.ToList();
        }

        public Quarto BuscarPorId(int id)
        {
            return quartos.FirstOrDefault(q => q.Id == id);
        }

        public void Atualizar(Quarto entidade)
        {
            Quarto quarto = BuscarPorId(entidade.Id);

            if (quarto == null)
                throw new InvalidOperationException("Quarto não encontrado.");

            quarto.Atualizar(
                entidade.Numero,
                entidade.Tipo,
                entidade.Capacidade,
                entidade.PrecoDiaria,
                entidade.Descricao
            );
        }

        public void Remover(Quarto quarto)
        {
            quartos.Remove(quarto);
        }

        public void Remover(int id)
        {
            Quarto quarto = BuscarPorId(id);

            if (quarto == null)
                throw new InvalidOperationException("Quarto não encontrado.");

            Remover(quarto);
        }
    }
}
