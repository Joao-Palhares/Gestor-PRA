using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Models
{
    public class Decisao
    {
        public int id_decisao { get; set; }
        public DateTime? data_eadpf { get; set; }
        public DateTime data_conselho { get; set; }
        public string consequencia { get; set; }
        public string medidas_c_s { get; set; }
        public string assinatura_diretor { get; set; }
        public DateTime? data_assinatura_diretor { get; set; }
        public string decisao_code { get; set; }
        public int? id_pra { get; set; }
    }
}
