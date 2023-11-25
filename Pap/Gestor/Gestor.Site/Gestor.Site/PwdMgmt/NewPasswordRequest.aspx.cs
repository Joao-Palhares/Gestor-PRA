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
using Gestor.DataAccess.PasswordDA;
using System.Net.Mail;

namespace Gestor.Site.PwdMgmt
{
    public partial class NewPasswordRequest1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonSubmeterPedido_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                User user = UserDAO.GetUserByEmail(textBoxEmail.Text);

                if (user == null)
                {
                    labelMensagem.Text = "O email indicado não se encontra registado no sistema.";
                    labelMensagem.ForeColor = System.Drawing.Color.Red;
                    labelMensagem.Visible = true;
                }
                else
                {
                    string GUID = PasswordDAO.InsertNewPwdRequest(textBoxEmail.Text);
                    if (string.IsNullOrEmpty(GUID))
                    {
                        labelMensagem.Text = "Solicitação falhada. <br />Tente novamente ou contacte o administrador...";
                        labelMensagem.ForeColor = System.Drawing.Color.Red;
                        labelMensagem.Visible = true;
                    }
                    else
                    {
                        Send_Mail(textBoxEmail.Text, GUID);

                        labelMensagem.Text = "Foi enviado para o email indicado um link para a definição de uma nova senha.";
                        labelMensagem.ForeColor = System.Drawing.Color.Green;
                        labelMensagem.Visible = true;

                        textBoxEmail.Enabled = false;
                        buttonSubmeterPedido.Visible = false;
                        buttonCancelar.Visible = false;
                    }
                    hyperLinkLogin.Visible = true;
                }
            }
        }

        private void Send_Mail(string email, string GUID)
        {
            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress("pgestplanosrecuperacao@gmail.com");
            mailMessage.To.Add(new MailAddress(email));
            mailMessage.Subject = "PGest -Planos Recuperação : Solicitação de Nova Password";

            mailMessage.Body = "Para efetivar o pedido de nova password clique aqui: https://localhost:44359/PwdMgmt/SetNewPassword.aspx?guid=" + GUID;
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential("pgestplanosrecuperacao@gmail.com", "Pgestplanosrecuperacao1234");
            smtpClient.Send(mailMessage);
        }

        protected void buttonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Authentication/Login.aspx");
        }
    }
}