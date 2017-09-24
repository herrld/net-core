using CorseFromGround.DataAccess;
using CorseFromGround.Services;
using CorseFromGround.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorseFromGround.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService mailService;
        private IConfigurationRoot config;
        private IWorldRepository repo;
        private ILogger<AppController> logger;

        public AppController(IMailService mailService, IConfigurationRoot config, IWorldRepository repo,
            ILogger<AppController> logger)
        {
            this.mailService = mailService;
            this.config = config;
            this.repo = repo;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Trips()
        {
            try
            {
                return View(this.repo.GetAllTrips().ToList());
            }
            catch (Exception ex)
            {

                logger.LogError($"Failed query: {ex.ToString()}");
                return Redirect("/error");
            }
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if(model.Email.Contains("aol"))
            {
                ModelState.AddModelError("Email", " field AOL sucks");
                ModelState.AddModelError("", "Model level AOL Sucks");
            }
            if(ModelState.IsValid)
            {
                this.mailService.SendMail(this.config["MailSettings:ToAddress"], model.Email, "from the world", model.Message);
                ModelState.Clear();
                ViewBag.UserMessage = "Message Sent";
            }
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
