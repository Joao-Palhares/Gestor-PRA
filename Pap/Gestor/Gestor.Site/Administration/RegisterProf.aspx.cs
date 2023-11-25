using Gestor.Models;
using Gestor.DataAccess.UserDA;
using Gestor.DataAccess.ProfessorDA;
using Gestor.DataAccess.DTDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gestor.DataAccess.TurmaDA;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Gestor.Site.Administration
{
    public partial class RegisterProf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!Session["role"].ToString().Equals("AD"))
                {
                    Response.Redirect("~/Home/Home.aspx");
                }
                else
                {
                    lbturma.Enabled = false;
                    lbturma.Visible = false;
                    ddlturmas.Enabled = false;
                    ddlturmas.Visible = false;
                    List<Turma> listaturmas = TurmaDAO.GetTurmasByDiretorturma();

                    ddlturmas.DataSource = listaturmas;
                    ddlturmas.DataValueField = "id_turma";
                    ddlturmas.DataTextField = "nome_turma";
                    ddlturmas.DataBind();
                }

            }

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
        protected void bregistar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (!Session["role"].ToString().Equals("AD"))
                {
                    Response.Redirect("~/Home/Home.aspx");
                }
                else
                {
                    if (cbdtsim.Checked || cbdtnao.Checked)
                    {
                        string username = tbusername.Text;
                        string pattern = null;
                        pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
                        string email = tbemail.Text;
                        User user2 = UserDAO.GetUserByusername(username);
                        User user3 = UserDAO.GetUserByEmail(email);

                        TurmaDT turmadt1 = TurmaDAO.GetTurmaByTurma(Convert.ToInt32(ddlturmas.SelectedValue));
                        string role;
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
                        else if (turmadt1 != null && cbdtsim.Checked)
                        {
                            lbmensagem.Text = "Esta turma já tem diretor de turma, tem a certeza que introduziu a turma correta?";
                        }
                        else
                        {

                            if (cbdtsim.Checked)
                            {
                                role = "DT";
                            }
                            else
                            {
                                role = "PR";
                            }
                            User user = new User()
                            {
                                Username = tbusername.Text,
                                Password = tbpassword.Text,
                                Email = tbemail.Text,
                                Role = role
                            };
                            int returnCode = UserDAO.RegisterUserProfessor(user);

                            User user1 = UserDAO.GetUserByEmail(user.Email);
                            string cbvalue;
                            if (cbdtsim.Checked)
                            {
                                cbvalue = "Sim";
                            }
                            else
                            {
                                cbvalue = "Não";
                            }



                            Professor professor = new Professor()
                            {
                                Nome = tbnomecompleto.Text,
                                data_nascimento = Convert.ToDateTime(tbdatanascimento.Text),
                                dt = cbvalue,
                                Id_User = user1.Id_User
                            };
                            int returnCode1 = ProfessorDAO.RegisterProfessor(professor);
                            Professor professor1 = ProfessorDAO.GetProfessorByUserID(user1.Id_User);
                            Turma turma1 = TurmaDAO.GetTurmaByID(Convert.ToInt32(ddlturmas.SelectedValue));
                            if (cbdtsim.Checked)
                            {

                                TurmaDT turmadt = new TurmaDT()
                                {
                                    id_professor = professor1.Id_Professor,
                                    id_turma = Convert.ToInt32(ddlturmas.SelectedValue)
                                };
                                int returnCode01 = TurmaDAO.RegisterTurmaDT(turmadt);

                                DT dt = new DT()
                                {
                                    nome = tbnomecompleto.Text,
                                    id_professor = professor1.Id_Professor
                                };
                                int returnCode02 = DTDAO.RegisterDT(dt);
                                Turma turma = new Turma()
                                {
                                    ID_Turma = turma1.ID_Turma,
                                    Ano_Escolaridade = turma1.Ano_Escolaridade,
                                    Diretor_Turma = professor1.Id_Professor,
                                    Nome_Turma = turma1.Nome_Turma,
                                    ID_Curso = turma1.ID_Curso
                                };
                                int returnCode03 = TurmaDAO.UpdateTurma(turma);
                            }


                            Send_Mail(tbemail.Text);
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
                                tbnomecompleto.Enabled = false;
                                tbdatanascimento.Enabled = false;
                                cbdtnao.Enabled = false;
                                cbdtsim.Enabled = false;

                                bregistar.Visible = false;
                                bcancelar.Visible = false;
                            }
                            Response.Write("<script>alert('Registo efetuado com sucesso com sucesso!');window.location='/Home/Home.aspx';</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Se o professor for diretor de turma assinale a opção sim caso contrario assinale a opção não!')</script>");
                    }
                }
            }
        }


        protected void bcancelar_Click(object sender, EventArgs e)
        {
            tbconfirm.Text = "";
            tbpassword.Text = "";
            tbusername.Text = "";
        }

        protected void cbdtsim_CheckedChanged(object sender, EventArgs e)
        {

            if (cbdtsim.Checked == true)
            {
                cbdtnao.Checked = false;
                lbturma.Enabled = true;
                lbturma.Visible = true;
                ddlturmas.Enabled = true;
                ddlturmas.Visible = true;
            }

        }

        protected void cbdtnao_CheckedChanged(object sender, EventArgs e)
        {
            if (cbdtnao.Checked == true)
            {
                cbdtsim.Checked = false;
                lbturma.Enabled = false;
                lbturma.Visible = false;
                ddlturmas.Enabled = false;
                ddlturmas.Visible = false;
            }
        }
    }
}