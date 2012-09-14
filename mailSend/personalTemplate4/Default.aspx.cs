using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

namespace personalTemplate4
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var fromAddress = new MailAddress("pdah@itu.dk", "Perry Dahl Christensen - itu");
            var toAddress = new MailAddress("perry.dahl.christensen@gmail.com", "Perry Dahl Christensen - gmail");
            var ReplyTo = new MailAddress("pdah@itu.dk", "Perry Dahl Christensen - itu");
            const string fromPassword = "";
            const string subject = "Subject";
            const string body = "Body";

            var smtp = new SmtpClient
            {
                Host = "smtpauth.itu.dk",
                Port = 465,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
            })
            {
                smtp.Send(message);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
