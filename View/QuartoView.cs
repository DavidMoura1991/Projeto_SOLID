using Projeto_SOLID.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_SOLID.View
{
    internal class QuartoView : IQuartoView
    {
        public void MostrarQuarto(Quarto quarto)
        {
            Console.WriteLine(
                $"ID: {quarto.Id} | " +
                $"Número: {quarto.Numero} | " +
                $"Tipo: {quarto.Tipo} | " +
                $"Capacidade: {quarto.Capacidade} pessoas | " +
                $"Diária: {quarto.PrecoDiaria:C}"
            );
        }
    }
}
