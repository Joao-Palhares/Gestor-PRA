using Gestor.Models;
using Gestor.DataAccess.UserDA;
using Gestor.DataAccess.AlunoDA;
using Gestor.DataAccess.CursoDA;
using Gestor.DataAccess.TurmaDA;
using Gestor.DataAccess.DTDA;
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
    public partial class InserirPra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["role"].ToString().Equals("DT"))
                {
                    tbmod.Enabled = false; tbmod.Visible = false;
                    int iduser = Convert.ToInt32(Session["id_user"]);
                    Professor professor = ProfessorDAO.GetProfessorByUserID(iduser);
                    TurmaDT turmadt = TurmaDAO.GetTurmaByDT(professor.Id_Professor);
                    Turma turma = TurmaDAO.GetTurmaByID(turmadt.id_turma);
                    tbturma.Text = Convert.ToString(turma.Nome_Turma);

                    List<Aluno> listaAlunos = AlunoDAO.GetAlunoByTurma(turmadt.id_turma);

                    ddlalunos.DataSource = listaAlunos;
                    ddlalunos.DataValueField = "id_aluno";
                    ddlalunos.DataTextField = "nome";
                    ddlalunos.DataBind();

                    Aluno alunodados = AlunoDAO.GetAlunoByID(Convert.ToInt32(ddlalunos.SelectedValue));
                    tbnaluno.Text = Convert.ToString(alunodados.numero);
                    DateTime datanasc=Convert.ToDateTime(alunodados.data_nascimento.ToString("yyyy-MM-dd"));
                    int ola = GetAge(datanasc);
                    tbidade.Text = Convert.ToString(ola);
                }
                else
                {
                    Response.Redirect("~/Home/Home.aspx");
                }
            }
        }
        public static int GetAge(DateTime birthDate)
        {
            DateTime n = DateTime.Now; // To avoid a race condition around midnight
            int age = n.Year - birthDate.Year;

            if (n.Month < birthDate.Month || (n.Month == birthDate.Month && n.Day < birthDate.Day))
                age--;

            return age;
        }

        public static string GenerateCoupon(int length, Random random)
        {
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }

        protected void binserir_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int iduser = Convert.ToInt32(Session["id_user"]);
                Professor professor = ProfessorDAO.GetProfessorByUserID(iduser);
                TurmaDT turmadt = TurmaDAO.GetTurmaByDT(professor.Id_Professor);
                Turma turma = TurmaDAO.GetTurmaByID(turmadt.id_turma);
                tbturma.Text = Convert.ToString(turma.Nome_Turma);

                var codigo_praprincipal1 = GenerateCoupon(70, new Random());
                PraPrincipal praprincipal = new PraPrincipal()
                {
                    idade = Convert.ToInt32(tbidade.Text),
                    ano_letivo = tbanoletivo.Text,
                    id_aluno = Convert.ToInt32(ddlalunos.Text),
                    numero_aluno = Convert.ToInt32(tbnaluno.Text),
                    turma = tbturma.Text,
                    codepraprincipal = codigo_praprincipal1
                };
                int returnCode1 = PraPrincipalDAO.InsertPrincipal(praprincipal);
                PraPrincipal praprincipal1 = PraPrincipalDAO.GetPraPrincipalByCode(praprincipal.codepraprincipal);

                DT dt = DTDAO.GetDTByProfessor1(professor.Id_Professor);
                var codigo_pra1 = GenerateCoupon(20, new Random());

                PraPagina prapagina = new PraPagina()
                {
                    id_principal = praprincipal1.id_principal,
                    codigo_pra = codigo_pra1,
                    id_aluno = Convert.ToInt32(ddlalunos.SelectedValue),
                    id_dt = Convert.ToInt32(dt.id_dt),
                    id_turma = Convert.ToInt32(turmadt.id_turma),
                    estado = "Incompleto",
                    progresso = "Falta a introdução de disciplinas e modulos"
                };
                int returnCode30 = PraDAO.InsertPra(prapagina);

                PraPagina prapagina1 = PraDAO.GetPraByCode(codigo_pra1);

                PraPrincipal praprincipal2 = new PraPrincipal()
                {
                    id_principal=praprincipal1.id_principal,
                    idade = Convert.ToInt32(tbidade.Text),
                    ano_letivo = tbanoletivo.Text,
                    id_aluno = Convert.ToInt32(ddlalunos.Text),
                    numero_aluno = Convert.ToInt32(tbnaluno.Text),
                    turma = tbturma.Text,
                    codepraprincipal = codigo_praprincipal1,
                    id_pra=prapagina1.id_pra
                };
                int returnCode100 = PraPrincipalDAO.UpdatePraPrincipalByID(praprincipal2);

                Response.Write("<script>alert('Preenchimento registado com sucesso!');window.location='/Home/Home.aspx';</script>");
            }
        }

        protected void bcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Home.aspx");
        }

        protected void ddlalunos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iduser = Convert.ToInt32(Session["id_user"]);
            Professor professor = ProfessorDAO.GetProfessorByUserID(iduser);
            TurmaDT turmadt = TurmaDAO.GetTurmaByDT(professor.Id_Professor);
            Turma turma = TurmaDAO.GetTurmaByID(turmadt.id_turma);
            tbturma.Text = Convert.ToString(turma.Nome_Turma);
            Aluno alunodados = AlunoDAO.GetAlunoByID(Convert.ToInt32(ddlalunos.SelectedValue));
            tbnaluno.Text = Convert.ToString(alunodados.numero);
            DateTime datanasc = Convert.ToDateTime(alunodados.data_nascimento.ToString("yyyy-MM-dd"));
            int ola = GetAge(datanasc);
            tbidade.Text = Convert.ToString(ola);
        }
    }
}