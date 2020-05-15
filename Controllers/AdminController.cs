using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ghardailo.Data;
using Ghardailo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ghardailo.Controllers
{
    public class AdminController : Controller
    {
    
            private ApplicationDbContext db;

            private readonly ILogger<AdminController> _logger;

        public AdminController(ApplicationDbContext _db, ILogger<AdminController> logger)
        {
            _logger = logger;
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([FromForm]Admin_Login login,manager manager)
        {
            if (login.admin)
            {
                if (db.Admin_Login.Where(b => b.userName == login.userName && b.password == login.password).FirstOrDefault() == null)
                {
                    return View();

                }
                else
                {
                    return View("~/Views/Home/Index.cshtml");
                }
            }
            else
            {
                login.userName = manager.userName;
               
                login.password = manager.userPassword;
                if (db.managers .Where(c => c.userName == manager.userName && c.userPassword == manager.userPassword).FirstOrDefault() == null)
                {

                    return View();

                }
                else
                {

                    return View("~/Views/Home/Index.cshtml");
                }
            }

        }
    }
}