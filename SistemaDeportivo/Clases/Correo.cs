using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace SistemaDeportivo.Clases
{
    public class Correo
    {
        private static string contra;
        MailMessage msg = new MailMessage();
        private string destinatario;
        private string asunto;
        private string mensaje;
        private string remitente_Email = "sistemasdeportivosrfm@gmail.com";
        private string remitente_Pass = "udkfpiqkqmfvqhzp";
        private string path;

        public string Contra { get => contra; set => contra = value; }

        public string Generar_Contraseña()
        {
            Random rd = new Random();
            string contraseña = Convert.ToChar(rd.Next(65, 90)).ToString() + Convert.ToChar(rd.Next(65, 90)).ToString();
            contraseña += Convert.ToChar(rd.Next(65, 90)) + Convert.ToChar(rd.Next(65, 90));
            contraseña += Convert.ToChar(rd.Next(65, 90)) + Convert.ToChar(rd.Next(65, 90)).ToString();
            contraseña += Convert.ToChar(rd.Next(65, 90));
            contraseña += rd.Next(0, 9);
            contraseña += Convert.ToChar(rd.Next(97, 122));
            return contraseña;
        }

        public Correo(string destinatario, string path)
        {
            this.path = path;
            this.destinatario = destinatario;
            this.asunto = "Haz hecho match";
            this.mensaje = "Alguien te hizo match, ve a tus notificaciones dentro de la página y revisa quien fue🐾";
        }

        private void Mensaje()
        {
            Attachment _attachment = new Attachment(path);
            msg.To.Add(new MailAddress(destinatario));
            msg.Subject = asunto;
            msg.SubjectEncoding = Encoding.UTF8;
            msg.Body = mensaje;
            msg.Attachments.Add(_attachment);
            msg.BodyEncoding = Encoding.UTF8;
            msg.From = new MailAddress(remitente_Email);
            msg.IsBodyHtml = false;
        }
        public string smtpCorreo()
        {
            try
            {
                Mensaje();

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

                client.UseDefaultCredentials = false;

                client.Credentials = new NetworkCredential(remitente_Email, remitente_Pass);
                client.EnableSsl = true;

                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(msg);
                return "Mensaje Enviado Correctamente";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
