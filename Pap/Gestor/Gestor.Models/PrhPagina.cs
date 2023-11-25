using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Models
{
    public class PrhPagina
    {
        public int id_prh { get; set; }
        public int id_principal { get; set; }
        public int? id_descricao_atividade { get; set; }
        public int? id_avaliaçoes { get; set; }
        public string codigo_prh { get; set; }
        public int id_professor { get; set; }
        public int id_turma { get; set; }
        public int id_aluno { get; set; }
        public int id_dt { get; set; }
        public string estado { get; set; }
        public string progresso { get; set; }
    }
}
