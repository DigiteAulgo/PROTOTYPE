using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaPOO.Interfaces;

namespace ClinicaPOO.Models
{
    public class PacoteExame : IPrototipo<PacoteExame>
    {
        public string NomePacote { get; set; } = string.Empty;
        public string OrientacoesJejum { get; set; } = string.Empty;
        public string NomePaciente { get; set; } = "NÃO ATRIBUÍDO";
        public List<Procedimento> Procedimentos { get; set; } = new();

        public PacoteExame(string nomePacote, string orientacoesJejum)
        {
            NomePacote = nomePacote;
            OrientacoesJejum = orientacoesJejum;
        }

        public void AdicionarProcedimento(Procedimento procedimento)
        {
            Procedimentos.Add(procedimento);
        }

        // Deep Copy usando MemberwiseClone + nova lista
        public PacoteExame Clonar()
        {
            PacoteExame pacoteClonado = (PacoteExame)this.MemberwiseClone();

            pacoteClonado.Procedimentos = new List<Procedimento>();

            foreach (Procedimento item in this.Procedimentos)
            {
                pacoteClonado.Procedimentos.Add(item.Clonar());
            }

            return pacoteClonado;
        }

        // Método apenas para demonstração do erro (Shallow Copy)
        public PacoteExame ClonarSuperficial()
        {
            PacoteExame pacoteRaso = (PacoteExame)this.MemberwiseClone();
            return pacoteRaso;
        }

        public void ExibirResumo()
        {
            Console.WriteLine($"\n[PACOTE]: {NomePacote} | Paciente: {NomePaciente}");
            Console.WriteLine($"  Orientação: {OrientacoesJejum}");
            Console.WriteLine("  Procedimentos inclusos:");

            decimal total = 0;
            foreach (var p in Procedimentos)
            {
                Console.WriteLine($"   - {p.Nome}: R$ {p.Valor:F2}");
                total += p.Valor;
            }
            Console.WriteLine($"  Total: R$ {total:F2}");
        }
    }
}