using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Models
{
    public class Notificacoes
    {
        public int id_notificaçoes { get; set; }
        public string assinatura_enc { get; set; }
        public DateTime? data_assinatura_enc { get; set; }
        public string assinatura_dt { get; set; }
        public DateTime? data_assinatura_dt { get; set; }
        public string assinatura_pt { get; set; }
        public DateTime? data_assinatura_pt { get; set; }
        public DateTime? data_assinatura_cpcj { get; set; }
        public int? id_pra { get; set; }
        public string codenotificaçoes { get; set; }
    }
}