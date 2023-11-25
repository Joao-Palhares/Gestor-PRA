using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Models
{
    public class DescricaoAtividades
    {
        public int id_descriçao_atividade { get; set; }
        public string atividades { get; set; }
        public string local { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_final { get; set; }
        public int? id_prh { get; set; }
        public string cumprimento { get; set; }
        public string codigo_descricao { get; set; }
    }
}
