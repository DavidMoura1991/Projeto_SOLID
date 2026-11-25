using Projeto_SOLID.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.View
{
    internal class HospedeView : IHospedeView
    {
        public void MostrarHospede(Hospede hospede)
        {
            Console.WriteLine(
                $"ID: {hospede.Id} | " +
                $"Nome: {hospede.Nome} | " +
                $"CPF: {hospede.CPF} | " +
                $"Email: {hospede.Email} | " +
                $"Telefone: {hospede.Telefone}"
            );
        }
    }
}
