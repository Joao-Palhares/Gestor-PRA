using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Models
{
    public class Turma
    {
        public int ID_Turma { get; set; }
        public int Ano_Escolaridade { get; set; }
        public int ID_Curso { get; set; }
        public int? Diretor_Turma { get; set; }
        public string Nome_Turma { get; set; }
    }
}
