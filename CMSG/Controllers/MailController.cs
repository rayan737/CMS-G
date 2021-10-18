using CMSG.BL.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace CMSG.Controllers
{
    public class MailController : Controller
    {
        public IActionResult Index()        // to create view contains from for emails
        {
            return View();
        }
        [HttpPost]                          // to recieve emails
        public IActionResult SendMail(string Title, string Message)
        {


            TempData["msg"] = MailHelper.sendMail(Title, Message);      //if mail sent successfully // TempData["msg"] to send from an action to another action view

            return RedirectToAction("Index");
        }

        public IActionResult MailBox()                         // to recieve in db
        {
            return View();
        }
    }
}
