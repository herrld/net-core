using HomePage.Services;
using HomePage.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePage.Controllers.Web
{
    [Authorize]
    public class AppController : Controller
    {
        private IConfigurationRoot config;
        private IMailService mailService;

        public AppController(IMailService mailService, IConfigurationRoot config)
        {
            this.config = config;
            this.mailService = mailService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (model.Email.Contains("aol.com")) ModelState.AddModelError("Email", "AOL Sucks");
            if (ModelState.IsValid)
            {
                this.mailService.SendMail(this.config["MailSettings:ToAddress"], model.Email, "from home page", model.Message);
                ModelState.Clear();
            }
            
            return View(); 
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
