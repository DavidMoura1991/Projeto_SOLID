using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.Model
{
    internal class Quarto
    {
        public int Id { get; private set; }
        public int Numero { get; private set; }
        public string Tipo { get; private set; }
        public int Capacidade { get; private set; }
        public decimal PrecoDiaria { get; private set; }
        public string Descricao { get; private set; }

        public Quarto(int id, int numero, string tipo,
            int capacidade, decimal precoDiaria, string descricao)
        {
            Id = id;
            Atualizar(numero, tipo, capacidade,
                precoDiaria, descricao);
        }

        public void Atualizar(int numero, string tipo,
            int capacidade, decimal precoDiaria, string descricao)
        {
            if (numero <= 0)
                throw new ArgumentException("O número do quarto deve ser maior que zero.");

            if (string.IsNullOrWhiteSpace(tipo))
                throw new ArgumentException("O tipo do quarto é obrigatório.");

            if (capacidade <= 0)
                throw new ArgumentException("A capacidade deve ser maior que zero.");

            if (precoDiaria <= 0)
                throw new ArgumentException("O preço da diária deve ser maior que zero.");

            Numero = numero;
            Tipo = tipo;
            Capacidade = capacidade;
            PrecoDiaria = precoDiaria;
            Descricao = descricao;
        }

        public void AtualizarId(int id)
        {
            Id = id;
        }
    }
}
