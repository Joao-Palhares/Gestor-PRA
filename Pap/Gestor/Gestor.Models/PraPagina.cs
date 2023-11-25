using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Models
{
    public class PraPagina
    {
        public int id_pra { get; set; }
        public int id_principal { get; set; }
        public int? id_medidas { get; set; }
        public int? id_notificaçoes { get; set; }
        public int? id_decisao { get; set; }
        public string codigo_pra { get; set; }
        public int id_turma { get; set; }
        public int id_aluno { get; set; }
        public int id_dt { get; set; }
        public string estado { get; set; }
        public string progresso { get; set; }
        public int? id_professor1 { get; set; }
        public int? id_professor2 { get; set; }
        public int? id_professor3 { get; set; }
        public int? id_professor4 { get; set; }
        public int? id_professor5 { get; set; }
        public int? ndisciplinas { get; set; }
        public int? id_dm1{ get; set; }
        public int? id_dm2 { get; set; }
        public int? id_dm3 { get; set; }
        public int? id_dm4 { get; set; }
        public int? id_dm5 { get; set; }
    }
}
