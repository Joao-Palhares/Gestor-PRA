using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Models
{
    public class PrhPrincipal
    {
        public int id_principal { get; set; }
        public string ano_letivo { get; set; }
        public string turma { get; set; }
        public int numero_aluno { get; set; }
        public int id_aluno { get; set; }
        public string curso { get; set; }
        public string disciplina { get; set; }
        public int tempo_letivos_faltas { get; set; }
        public string modalidade_adotada { get; set; }
        public string outra_modalidade { get; set; }
        public string codigo_prhprincipal { get; set; }
        public int? id_prh { get; set; }
    }
}
