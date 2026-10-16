using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaPOO.Interfaces;

namespace ClinicaPOO.Models
{
    public class Procedimento : IPrototipo<Procedimento>
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Valor { get; set; }

        public Procedimento(string nome, decimal valor)
        {
            Nome = nome;
            Valor = valor;
        }

        public Procedimento Clonar()
        {
            return (Procedimento)this.MemberwiseClone();
        }
    }
}