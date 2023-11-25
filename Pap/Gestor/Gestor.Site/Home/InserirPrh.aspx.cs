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
using System.Net.Mail;

namespace Gestor.Site.Home
{
    public partial class InserirPrh : System.Web.UI.Page
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

                    List<Disciplina> listaDisciplinas = DisciplinaDAO.GetDisciplinaByTurma(turmadt.id_turma);

                    ddldisciplinas.DataSource = listaDisciplinas;
                    ddldisciplinas.DataValueField = "id_disciplina";
                    ddldisciplinas.DataTextField = "nome";
                    ddldisciplinas.DataBind();

                    Disciplina disciplina1 = DisciplinaDAO.GetDisciplinasByID(Convert.ToInt32(ddldisciplinas.SelectedValue));

                    List<Professor> listaProfessores = ProfessorDAO.GetListaProfessoresByDisciplina(disciplina1.id_disciplina);

                    ddlprofessores.DataSource = listaProfessores;
                    ddlprofessores.DataValueField = "id_professor";
                    ddlprofessores.DataTextField = "nome";
                    ddlprofessores.DataBind();

                    Aluno alunodados = AlunoDAO.GetAlunoByID(Convert.ToInt32(ddlalunos.SelectedValue));
                    Curso cursonome = CursoDAO.GetCursoByID(alunodados.Id_Curso);
                    tbcurso.Text = Convert.ToString(cursonome.Nome);
                    tbnaluno.Text = Convert.ToString(alunodados.numero);
                }
                else
                {
                    Response.Redirect("~/Home/Home.aspx");
                }

            }
        }

        private void Send_Mail(string email, string nome_aluno)
        {

            int hour = DateTime.Now.Hour;
            if (hour > 6 && hour < 12)
            {
                MailMessage mailMessage = new MailMessage();

                mailMessage.From = new MailAddress("pgestplanosrecuperacao@gmail.com");
                mailMessage.To.Add(new MailAddress(email));
                mailMessage.Subject = "PGest - Planos Recuperação : Detalhes das atividades a cumprir.";

                mailMessage.Body = "Bom dia " + nome_aluno + ".<br /> <br />" +
                "Devido ao excesso de faltas justificadas foi introduzido num (PRH)-Plano de Recuperação de Horas, <br>aguarde o tempo que for preciso para saber o que terá de fazer para concluir com êxito.";
                mailMessage.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("pgestplanosrecuperacao@gmail.com", "Pgestplanosrecuperacao1234");
                smtpClient.Send(mailMessage);
            }
            else if (hour >= 12 && hour < 19)
            {
                MailMessage mailMessage = new MailMessage();

                mailMessage.From = new MailAddress("pgestplanosrecuperacao@gmail.com");
                mailMessage.To.Add(new MailAddress(email));
                mailMessage.Subject = "PGest - Planos Recuperação : Detalhes das atividades a cumprir.";

                mailMessage.Body = "Boa tarde " + nome_aluno + ".<br /> <br />" +
                "Devido ao excesso de faltas justificadas foi introduzido num (PRH)-Plano de Recuperação de Horas, <br>aguarde o tempo que for preciso para saber o que terá de fazer para concluir com êxito.";
                mailMessage.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("pgestplanosrecuperacao@gmail.com", "Pgestplanosrecuperacao1234");
                smtpClient.Send(mailMessage);
            }
            else if (hour >= 19 && hour < 24 || hour >= 0 && hour <= 6)
            {
                MailMessage mailMessage = new MailMessage();

                mailMessage.From = new MailAddress("pgestplanosrecuperacao@gmail.com");
                mailMessage.To.Add(new MailAddress(email));
                mailMessage.Subject = "PGest - Planos Recuperação : Detalhes das atividades a cumprir.";

                mailMessage.Body = "Boa noite " + nome_aluno + ".<br /> <br />" +
                "Devido ao excesso de faltas justificadas foi introduzido num (PRH)-Plano de Recuperação de Horas, <br>aguarde o tempo que for preciso para saber o que terá de fazer para concluir com êxito.";
                mailMessage.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("pgestplanosrecuperacao@gmail.com", "Pgestplanosrecuperacao1234");
                smtpClient.Send(mailMessage);
            }

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
                Disciplina disciplina1 = DisciplinaDAO.GetDisciplinasByID(Convert.ToInt32(ddldisciplinas.SelectedValue));

                var codigo_prhprincipal1 = GenerateCoupon(45, new Random());
                string mod;
                mod = Convert.ToString(DBNull.Value);
                PrhPrincipal prhprincipal = new PrhPrincipal()
                {

                    ano_letivo = tbanoletivo.Text,
                    curso = tbcurso.Text,
                    disciplina = Convert.ToString(disciplina1.nome),
                    id_aluno = Convert.ToInt32(ddlalunos.Text),
                    numero_aluno = Convert.ToInt32(tbnaluno.Text),
                    turma = tbturma.Text,
                    tempo_letivos_faltas = Convert.ToInt32(tbntempos.Text),
                    modalidade_adotada = mod,
                    codigo_prhprincipal = codigo_prhprincipal1
                };
                int returnCode1 = PrhPrincipalDAO.InsertPrhPrincipal(prhprincipal);
                PrhPrincipal prhprincipal1 = PrhPrincipalDAO.GetPrhPrincipalByCode(prhprincipal.codigo_prhprincipal);

                DT dt = DTDAO.GetDTByProfessor1(professor.Id_Professor);
                var codigo_prh1 = GenerateCoupon(70, new Random());

                PrhPagina prhpagina = new PrhPagina()
                {
                    id_principal = prhprincipal1.id_principal,
                    codigo_prh = codigo_prh1,
                    id_professor = Convert.ToInt32(ddlprofessores.SelectedValue),
                    id_aluno = Convert.ToInt32(ddlalunos.SelectedValue),
                    id_dt = Convert.ToInt32(dt.id_dt),
                    id_turma = Convert.ToInt32(turmadt.id_turma),
                    estado="Incompleto",
                    progresso="Falta a modalidade e a descrição da atividade"
                };
                int returnCode30 = PrhDAO.InsertPrhPagina(prhpagina);

                PrhPagina prhpagina1 = PrhDAO.GetPrhByCode(prhpagina.codigo_prh);


                //########################################################
                //###  Prh Principal Updates                           ###
                //########################################################


                PrhPrincipal prhprincipal2 = new PrhPrincipal()
                {
                    ano_letivo = prhprincipal1.ano_letivo,
                    curso = prhprincipal1.curso,
                    disciplina = prhprincipal1.disciplina,
                    modalidade_adotada = prhprincipal1.modalidade_adotada,
                    id_aluno = prhprincipal1.id_aluno,
                    numero_aluno = prhprincipal1.numero_aluno,
                    outra_modalidade = prhprincipal1.outra_modalidade,
                    tempo_letivos_faltas = prhprincipal1.tempo_letivos_faltas,
                    turma = prhprincipal1.turma,
                    codigo_prhprincipal = prhprincipal1.codigo_prhprincipal,
                    id_principal = prhprincipal1.id_principal,
                    id_prh = prhpagina1.id_prh
                };
                int returnCode100 = PrhPrincipalDAO.UpdatePrhPrincipalByID(prhprincipal2);
                Aluno aluno = AlunoDAO.GetAlunoByID(prhpagina1.id_aluno);
                User user = UserDAO.GetUserByID(aluno.Id_User);
                Send_Mail(user.Email, aluno.nome);
                Response.Write("<script>alert('Preenchimento registado com sucesso!');window.location='/Home/Home.aspx';</script>");
            }

        }

        protected void bcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Home.aspx");
        }

        protected void ddlalunos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Aluno alunodados = AlunoDAO.GetAlunoByID(Convert.ToInt32(ddlalunos.SelectedValue));

            Curso cursonome = CursoDAO.GetCursoByID(alunodados.Id_Curso);

            tbcurso.Text = Convert.ToString(cursonome.Nome);
            tbnaluno.Text = Convert.ToString(alunodados.numero);
        }

        protected void ddlprofessores_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Disciplina> listaDisciplinas = DisciplinaDAO.GetDisciplinasByProfessor(Convert.ToInt32(ddlprofessores.SelectedValue));

            ddldisciplinas.DataSource = listaDisciplinas;
            ddldisciplinas.DataValueField = "id_disciplina";
            ddldisciplinas.DataTextField = "nome";
            ddldisciplinas.DataBind();
        }

        protected void ddldisciplinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Disciplina disciplina1 = DisciplinaDAO.GetDisciplinasByID(Convert.ToInt32(ddldisciplinas.SelectedValue));

            List<Professor> listaProfessores = ProfessorDAO.GetListaProfessoresByDisciplina(disciplina1.id_disciplina);

            ddlprofessores.DataSource = listaProfessores;
            ddlprofessores.DataValueField = "id_professor";
            ddlprofessores.DataTextField = "nome";
            ddlprofessores.DataBind();

        }
    }
}