using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Models
{
    public class Modulo
    {
        public int id_modulo { get; set; }
        public int tempos_letivos { get; set; }
        public string nome { get; set; }
        public int id_disciplina { get; set; }
    }
}
