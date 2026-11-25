using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.Model
{
    internal class Hospede
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }

        public Hospede(int id, string nome, string cpf,
            string email, string telefone)
        {
            Id = id;
            Atualizar(nome, cpf, email, telefone);
        }

        public void Atualizar(string nome, string cpf,
            string email, string telefone)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome é obrigatório.");

            if (string.IsNullOrWhiteSpace(cpf))
                throw new ArgumentException("O CPF é obrigatório.");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("O email é obrigatório.");

            if (string.IsNullOrWhiteSpace(telefone))
                throw new ArgumentException("O telefone é obrigatório.");

            Nome = nome;
            CPF = cpf;
            Email = email;
            Telefone = telefone;
        }

        public void AtualizarId(int id)
        {
            Id = id;
        }
    }
}
