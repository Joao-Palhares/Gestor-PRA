using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Models
{
    public class DM2
    {
        public int id_dm { get; set; }
        public int disciplina_modulo { get; set; }
        public int faltas_excesso { get; set; }
        public string assinatura_professor_disciplina { get; set; }
        public DateTime? data_assinatura { get; set; }
        public string avaliaçao { get; set; }
        public string retido { get; set; }
        public int? id_pra { get; set; }
        public string dmcode { get; set; }
        public int id_professor { get; set; }
    }
}
