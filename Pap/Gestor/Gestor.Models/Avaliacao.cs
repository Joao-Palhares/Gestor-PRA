using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Models
{
    public class Avaliacao
    {
        public int id_avaliaçoes { get; set; }
        public string avaliaçao_atividade { get; set; }
        public string faltas_desconsideradas { get; set; }
        public string nome_aluno { get; set; }
        public DateTime? data_assinatura_aluno { get; set; }
        public string nome_professor { get; set; }
        public DateTime? data_assinatura_professor { get; set; }
        public string dt_assinatura { get; set; }
        public DateTime? data_assinatura_dt { get; set; }
        public string codigo_avaliacao { get; set; }
        public int id_prh { get; set; }
    }
}
