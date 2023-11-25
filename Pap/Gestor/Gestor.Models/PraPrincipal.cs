using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Models
{
    public class PraPrincipal
    {
        public int id_principal { get; set; }
        public int id_aluno { get; set; }
        public int idade { get; set; }
        public string ano_letivo { get; set; }
        public string turma { get; set; }
        public int numero_aluno { get; set; }
        public int? id_pra { get; set; }
        public string codepraprincipal { get; set; }
    }
}
