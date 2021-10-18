using CMSG.BL.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using CMSG.BL.Helper;

namespace CMSG.Controllers
{
    public class UserController : Controller
    {
        // Loosly Coupled
        private readonly IEmployeeRep employee;
        private readonly IDepartmentRep department;

        // Dependency Injection
        public UserController(IEmployeeRep employee, IDepartmentRep department)
        {
            this.employee = employee;
            this.department = department;
        }
        public IActionResult IndexInterface()
        {
            var data = employee.Get();

            return View(data);
        }

        public IActionResult Details(int id)
        {
            var data = employee.GetById(id);
            var Dptdata = department.Get();

            ViewBag.DepartmentList = new SelectList(Dptdata, "Id", "DepartmentName", data.DepartmentId);

            return View(data);
        }

        //// ======================================================= mail

        //public IActionResult MailIndex()        // to create view contains from for emails
        //{
        //    return View();
        //}

        [HttpPost]                          // to recieve emails
        public IActionResult SendMail(string Title, string Message)
        {


            TempData["msg"] = MailHelper.sendMail(Title, Message);      //if mail sent successfully // TempData["msg"] to send from an action to another action view

            return RedirectToAction("Index");
        }
    }
}
