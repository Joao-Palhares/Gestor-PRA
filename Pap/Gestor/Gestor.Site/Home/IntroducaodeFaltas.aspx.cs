using Gestor.Models;
using Gestor.DataAccess.UserDA;
using Gestor.DataAccess.AlunoDA;
using Gestor.DataAccess.CursoDA;
using Gestor.DataAccess.TurmaDA;
using Gestor.DataAccess.Prh.PrhPrincipalDA;
using Gestor.DataAccess.Prh.DescriçãoAtividadesDA;
using Gestor.DataAccess.Prh.AvaliacaoDA;
using Gestor.DataAccess.Pra.PraDA;
using Gestor.DataAccess.Pra.DecisaoDA;
using Gestor.DataAccess.Pra.DMDA;
using Gestor.DataAccess.Pra.MedidasDA;
using Gestor.DataAccess.Pra.NotificacoesDA;
using Gestor.DataAccess.Pra.PraPrincipalDA;
using Gestor.DataAccess.Pra.PRADMLIGACAODA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Gestor.DataAccess.DisciplinaDAO;
using Gestor.DataAccess.ModuloDA;
using Gestor.DataAccess.Prh.PrhDA;
using Gestor.DataAccess.ProfessorDA;

namespace Gestor.Site.Home
{
    public partial class IntroducaodeFaltas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int iduser = Convert.ToInt32(Session["id_user"]);
            Professor professor = ProfessorDAO.GetProfessorByUserID(iduser);

            List<Turma> listaturmas = TurmaDAO.GetTurmaByProfessor(professor.Id_Professor);

            ddlturmas.DataSource = listaturmas;
            ddlturmas.DataValueField = "id_turma";
            ddlturmas.DataTextField = "nome_turma";
            ddlturmas.DataBind();

            List<Disciplina> listaDisciplinas = DisciplinaDAO.GetDisciplinasByProfessor(professor.Id_Professor);

            ddldisciplinas.DataSource = listaDisciplinas;
            ddldisciplinas.DataValueField = "id_disciplina";
            ddldisciplinas.DataTextField = "nome";
            ddldisciplinas.DataBind();
            
            List<Aluno> listaAlunos = AlunoDAO.GetAlunoByTurma(Convert.ToInt32(ddlturmas.SelectedValue));

            ddlalunos.DataSource = listaAlunos;
            ddlalunos.DataValueField = "id_aluno";
            ddlalunos.DataTextField = "nome";
            ddlalunos.DataBind();

            
        }

        protected void ddlturmas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddldisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlalunos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}