using Gestor.Models;
using Gestor.DataAccess.UserDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Gestor.Site.Administration
{
    public partial class RegisterAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Session["role"].ToString().Equals("AD"))
            {
                Response.Redirect("~/Home/Home.aspx");
            }
        }
        protected void bregistar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string username = tbusername.Text;
                string pattern = null;
                pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
                string email = tbemail.Text;
                User user2 = UserDAO.GetUserByusername(username);
                User user3 = UserDAO.GetUserByEmail(email);
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
                else
                {
                    User user = new User()
                    {
                        Username = tbusername.Text,
                        Password = tbpassword.Text,
                        Email = tbemail.Text,
                        Role = "AD"
                    };

                    int returnCode = UserDAO.RegisterAdmin(user);
                    Send_Mail(tbemail.Text);
                    if (returnCode == -1)
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