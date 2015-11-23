using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
             return View();
        }

        public ActionResult Contact()
        {
             return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("kirstinwalsh0805@gmail.com"));
                message.From = new MailAddress(model.FromEmail);
                message.Subject = model.Subject;
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }
        public JsonResult GetData()
        {
            EmailFormModel efm = new EmailFormModel();
            efm.FromName = "Kirstin";
            efm.FromEmail = "kirstinwalsh0805@gmail.com";
            efm.Subject = "From Server";

            return Json(efm, JsonRequestBehavior.AllowGet);
        }
    }
}