using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Models
{
    public class Medidas
    {
        public int id_medidas { get; set; }
        public DateTime periodo_inicio { get; set; }
        public DateTime periodo_fim { get; set; }
        public string medida { get; set; }
        public string cumprimento { get; set; }
        public DateTime? data_cumprimento { get; set; }
        public string dever_incumprimento { get; set; }
        public DateTime? data_incumprimento { get; set; }
        public string faltas_desconsideradas { get; set; }
        public string codemedidas { get; set; }
        public int? id_pra { get; set; }
    }
}
