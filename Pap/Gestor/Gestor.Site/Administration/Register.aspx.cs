using Gestor.Models;
using Gestor.DataAccess.UserDA;
using Gestor.DataAccess.AlunoDA;
using Gestor.DataAccess.CursoDA;
using Gestor.DataAccess.TurmaDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using Gestor.DataAccess.ProfessorDA;
using System.Text.RegularExpressions;

namespace Gestor.Site.Administration
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["role"].ToString().Equals("DT"))
                {
                    int iduser = Convert.ToInt32(Session["id_user"]);
                    Professor professor = ProfessorDAO.GetProfessorByUserID(iduser);
                    TurmaDT turmadt = TurmaDAO.GetTurmaByDT(professor.Id_Professor);
                    Turma turma = TurmaDAO.GetTurmaByID(turmadt.id_turma);
                    tbturma.Text = Convert.ToString(turma.Nome_Turma);
                    Curso curso = CursoDAO.GetCursoByID(turma.ID_Curso);
                    tbcurso.Text = Convert.ToString(curso.Nome);
                }
                else
                {
                    Response.Redirect("~/Home/Home.aspx");
                }


            }
        }
        protected void bregistar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (Session["role"].ToString().Equals("DT"))
                {
                    int iduser = Convert.ToInt32(Session["id_user"]);
                    Professor professor = ProfessorDAO.GetProfessorByUserID(iduser);
                    TurmaDT turmadt = TurmaDAO.GetTurmaByDT(professor.Id_Professor);
                    Turma turma = TurmaDAO.GetTurmaByID(turmadt.id_turma);
                    tbturma.Text = Convert.ToString(turma.Nome_Turma);
                    Curso curso = CursoDAO.GetCursoByID(turma.ID_Curso);
                    tbcurso.Text = Convert.ToString(curso.Nome);
                    string username = tbusername.Text;
                    string pattern = null;
                    pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
                    string email = tbemail.Text;
                    int numero = Convert.ToInt32(tbnumero.Text);
                    int nprocesso = Convert.ToInt32(tbnprocesso.Text);
                    int i = 0, a;
                    while (nprocesso > 0)
                    {
                        a = nprocesso / 10;
                        nprocesso = a;
                        i++;
                    }

                    User user2 = UserDAO.GetUserByusername(username);
                    User user3 = UserDAO.GetUserByEmail(email);
                    Aluno aluno1 = AlunoDAO.GetAlunoByNumero(numero);
                    Aluno aluno2 = AlunoDAO.GetAlunoByProcesso(nprocesso);
                    if (user2 != null)
                    {
                        lbmensagem.Text = "O Username já existe!";
                    }
                    else if (!Regex.IsMatch(email, pattern))
                    {
                        lbmensagem.Text = "Introduza um email valido!";
                    }
                    else if (user3 != null)
                    {
                        lbmensagem.Text = "Este email já foi introduzido!";
                    }
                    else if (aluno2 != null)
                    {
                        lbmensagem.Text = "Já algum aluno introduziu este numero de processo! <br> Verifique se está correto!";
                    }
                    else if (aluno1 != null)
                    {
                        lbmensagem.Text = "Já algum aluno introduziu este numero! <br> Verifique se está correto!";
                    }
                    else if (i < 9 || i > 9)
                    {
                        lbmensagem.Text = "O numero de processo tem de ter no minimo 9 digitos!";
                    }
                    else
                    {
                        
                        User user = new User()
                        {
                            Username = tbusername.Text,
                            Password = tbpassword.Text,
                            Email = tbemail.Text,
                            Role = "AL"
                        };
                        int returnCode = UserDAO.RegisterUserAluno(user);

                        User user1 = UserDAO.GetUserByEmail(user.Email);

                        Aluno aluno = new Aluno()
                        {
                            n_processo = Convert.ToInt32(tbnprocesso.Text),
                            nome = tbnomecompleto.Text,
                            data_nascimento = Convert.ToDateTime(tbdatanascimento.Text),
                            Id_Curso = Convert.ToInt32(turma.ID_Curso),
                            Id_Turma = Convert.ToInt32(turmadt.id_turma),
                            numero = Convert.ToInt32(tbnumero.Text),
                            Id_User = user1.Id_User,
                            pra="false"
                        };
                        int returnCode1 = AlunoDAO.RegisterAluno(aluno);
                        //Send_Mail(tbemail.Text);
                        if (returnCode == -1 && returnCode1 == -1)
                        {
                            lbmensagem.ForeColor = System.Drawing.Color.Green;
                            lbmensagem.Text = "Registo falhado! <br />Contacte o administrador ou tente novamente...";
                        }
                        else
                        {
                            lbmensagem.ForeColor = System.Drawing.Color.Green;
                            lbmensagem.Text = "Registo efetuado com sucesso!";

                            tbusername.Enabled = false;
                            tbpassword.Enabled = false;
                            tbconfirm.Enabled = false;
                            tbemail.Enabled = false;

                            bregistar.Visible = false;
                            bcancelar.Visible = false;
                        }
                        Response.Write("<script>alert('Registo efetuado com sucesso com sucesso!');window.location='/Home/Home.aspx';</script>");
                    }

                }
                else
                {
                    Response.Redirect("~/Home/Home.aspx");
                }

            }
        }

        private void Send_Mail1(string email, string GUID)
        {
            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress("pgestplanosrecuperacao@gmail.com");
            mailMessage.To.Add(new MailAddress(email));
            mailMessage.Subject = "PGest -Planos Recuperação : Solicitação de Nova Password";

            mailMessage.Body = "Para verificar o email clique aqui: https://localhost:44359/PwdMgmt/SetNewPassword.aspx?guid=" + GUID;
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential("pgestplanosrecuperacao@gmail.com", "Pgestplanosrecuperacao1234");
            smtpClient.Send(mailMessage);
        }
        private void Send_Mail(string email)
        {
            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress("pgestplanosrecuperacao@gmail.com");
            mailMessage.To.Add(new MailAddress(email));
            mailMessage.Subject = "PGest - Planos Recuperação : Registos";

            mailMessage.Body = "Uma conta acabou de se registar com este email no PGest - Planos de Recuperação.<br />" +
                "Se foi você clique no seguinte link para confirmar a conta: " + " .<br />" +
                "Caso contrario ignore esta mensagem.";
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential("pgestplanosrecuperacao@gmail.com", "Pgestplanosrecuperacao1234");
            smtpClient.Send(mailMessage);
        }

        protected void bcancelar_Click(object sender, EventArgs e)
        {
            tbconfirm.Text = "";
            tbpassword.Text = "";
            tbusername.Text = "";
        }

    }
}