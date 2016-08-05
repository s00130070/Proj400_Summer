using Proj400.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace Proj400.Models
{
    public class EmailOrder : IOrderProcessor
    {
        public class EmailSettings
        {
            public string MailToAddress = "Proj400summer@outlook.com";
            public string MailFromAddress = "Proj400summer@outlook.com";
            public bool UseSsl = true;
            public string Username = "Proj400summer@outlook.com";
            public string Password = "Abc1234!";
            public string ServerName = "Proj400summer@outlook.com";
            public int ServerPort = 587;
            public bool WriteAsFile = false;
            public string FileLocation = @"c:\Proj400_emails";
        }




        private EmailSettings emailSettings;
        public EmailOrder(EmailSettings settings)
        {
            emailSettings = settings;
        }
        public void ProcessOrder(Cart cart, OrderInfo orderInfo)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);

                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod
                    = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation =
                    emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }
                StringBuilder body = new StringBuilder()
                .AppendLine("A new order has been submitted")
                .AppendLine("---")
                .AppendLine("Items:");
                foreach (var line in cart.Rows)
                {
                    var subtotal = line.Product.product_Price * line.product_Quantity;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c}",
                    line.product_Quantity,
                    line.Product.product_Name,
                    subtotal);
                    body.AppendFormat("Total order value: {0:c}",
                    cart.ComputeToatalValue())
                    .AppendLine("-----------------------")
                    .AppendLine("Ship to:")
                    .AppendLine(orderInfo.shipping_ShipName)
                    .AppendLine(orderInfo.shipping_Line1)
                    .AppendLine(orderInfo.shipping_Line2 ?? "")
                    .AppendLine(orderInfo.shipping_Line3 ?? "")
                    .AppendLine(orderInfo.shipping_City)
                    .AppendLine(orderInfo.shipping_State ?? "")
                    .AppendLine(orderInfo.shipping_Country)
                    .AppendLine(orderInfo.shipping_Postcode)
                    .AppendLine("-----------------------")
                    .AppendFormat("Gift wrap: {0}", orderInfo.shiping_Wrapped ? "Yes" : "No");
                    MailMessage mailMessage = new MailMessage(
                    emailSettings.MailFromAddress, //From
                    emailSettings.MailToAddress, // To
                    "New order submitted!", //Subject
                    body.ToString()); //Body
                    if (emailSettings.WriteAsFile)
                    {
                        mailMessage.BodyEncoding = Encoding.ASCII;
                    }
                    smtpClient.Send(mailMessage);
                }
            }
        }

    }
}



