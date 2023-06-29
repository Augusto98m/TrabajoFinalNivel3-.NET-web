using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EmailService
    {
        private MailMessage mail;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("programmingtestam@gmail.com", "enat cfat bjwu aumn");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void armarCorreo(string emailDestino, string asunto) //string cuerpo)
        {
            mail = new MailMessage("programmingtestam@gmail.com", emailDestino);
            mail.From = new MailAddress("noresponder@testAugusto.com");
            //mail.To.Add(emailDestino);
            mail.Subject = asunto;
            mail.IsBodyHtml = true;
            //mail.Body = cuerpo;
            mail.Body = "<h1>¡¡¡ Te saludamos desde <strong style=\"color:blue\">Smart</strong>" +
                "<strong style=\"color:#00ff21\"> Tech</strong> !!!</h1> " +
                "<br/> <h4>Esperamos que encuentres en nuestra web, todo lo que busques relacionado a la tecnología.</h4> " +
                "<h2>Aprovechamos a decirte que en tu primera compra usando el código SMART! tenés un 10% de descuento!!! </h2>";
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
