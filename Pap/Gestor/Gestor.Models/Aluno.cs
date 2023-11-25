using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Models
{
    public class Aluno
    {
        public int Id_Aluno { get; set; }
        public int n_processo { get; set; }
        public string nome { get; set; }
        public DateTime data_nascimento { get; set; }
        public int Id_Curso { get; set; }
        public int Id_Turma { get; set; }
        public int numero { get; set; }
        public int Id_User { get; set; }
        public string pra { get; set; }
    }
}
