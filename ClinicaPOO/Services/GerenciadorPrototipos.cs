using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaPOO.Models;

namespace ClinicaPOO.Services
{
    public class GerenciadorPrototipos
    {
        private Dictionary<string, PacoteExame> _prototipos = new();
        public void CadastrarPrototipo(string chave, PacoteExame prototipo)
        {
            _prototipos[chave] = prototipo;
        }
        public PacoteExame? ObterClone(string chave)
        {
            if (_prototipos.TryGetValue(chave, out PacoteExame? modeloOriginal))
            {
                return modeloOriginal.Clonar();
            }

            return null;
        }
    }
}