using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CMSG.BL.Helper
{
    public static class MailHelper
    {
        public static string sendMail(string Title, string Message)
        {
            try
            {

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

                smtp.EnableSsl = true;

                smtp.Credentials = new NetworkCredential("abdelrahmanrayan2021@gmail.com", "654321@1");  //NetworkCredential = class understand uname and pass 
                                                                                                //instead of request mail and pass from visitors , we recieve their message in mail

                smtp.Send("abdelrahmanrayan2021@gmail.com", "rayan737@hotmail.com", Title, Message);  //could be replaced by commented instanse and options

                return "Mail Sent Successfully";

                //MailMessage m = new MailMessage();

                //m.From = "";
                //m.To = "";
                //m.Subject = "";
                //m.Body = "";
                //m.CC = "";
                //m.Attachments = "";

            }
            catch (Exception ex)
            {
                return "Mail Faild";
            }
        }
    }
}
