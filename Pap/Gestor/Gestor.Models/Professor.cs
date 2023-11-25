using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.Models
{
     public class Professor
    {
        public int Id_Professor { get; set; }
        public string Nome { get; set; }
        public DateTime data_nascimento { get; set; }
        public string dt { get; set; }
        public int Id_User { get; set; }
    }
}
