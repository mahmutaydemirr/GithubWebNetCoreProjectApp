using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNetCoreProjectApp.Data;
using WebNetCoreProjectApp.Models;
using WebNetCoreProjectApp.Services;

namespace WebNetCoreProjectApp.Controllers
{
    public class WebSitePasswordController : Controller
    {
        private readonly ProjectContext _db;
        private readonly IPasswordGenerator _passwordGenerator;

        public WebSitePasswordController(ProjectContext db, IPasswordGenerator passwordGenerator)
        {
            _db = db;
            _passwordGenerator = passwordGenerator;
        }

        public IActionResult List(string orderBy = "desc")
        {
            List<WebSitePassword> list = new List<WebSitePassword>();

            switch (orderBy)
            {
                case "desc":
                    list = _db.WebSitePasswords.Include(x => x.PasswordHistories).OrderByDescending(x => x.CopyCount).ToList();
                    break;
                case "asc":
                    list = _db.WebSitePasswords.Include(x => x.PasswordHistories).OrderBy(x => x.CopyCount).ToList();
                    break;
                default:
                    list = _db.WebSitePasswords.Include(x => x.PasswordHistories).OrderByDescending(x => x.CopyCount).ToList();
                    break;
            }

            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(WebSitePassword sitePassword)
        {
            _db.WebSitePasswords.Add(sitePassword);
            int result = _db.SaveChanges();
            if (result > 0)
            {
                ViewBag.Message = "kayıt Başarılı";
            }
            else
            {
                ViewBag.Message = "Tekrar Deneyiniz";
            }
            return View(sitePassword);
        }

        [HttpPost]
        public JsonResult GeneratePassword(GeneratePasswordViewModel model)
        {
            string password = _passwordGenerator.GeneratePassword(model.PasswordLength, model.UpperCaseCharLength, model.LowerCaseCharLength, model.SpecialCharLength, model.NumericCharLength);

            return Json(password);
        }

        [HttpPost]
        public JsonResult IncreaseCopyCount([FromBody] string id)
        {
            var data = _db.WebSitePasswords.Find(id);
            data.IncreaseCopyCount();
            _db.SaveChanges();
            return Json("Ok");
        }

        [HttpPost]
        public JsonResult SaveNewPassword([FromBody] string id)
        {
            string password = _passwordGenerator.GeneratePassword(12, 3, 3, 3, 3);

            var data = _db.WebSitePasswords.Find(id);

            _db.WebSitePasswordHistories.Add(new WebSitePasswordHistory
            {
                WebSitePasswordId = data.Id,
                ExpiredDate = DateTime.Now,
                Password = data.Password

            });

            data.Password = password;

            int result = _db.SaveChanges();


            return Json(password);
        }
        
        [HttpPost]
        public JsonResult Remove([FromBody] string id)
        {
            var data = _db.WebSitePasswords.Find(id);
            _db.WebSitePasswords.Remove(data);
            _db.SaveChanges();

            return Json("Ok");
        }

        [HttpPost]
        public JsonResult ChangeUserName([FromBody] ChangeUserNameInputModel model)
        {
            try
            {
                var dbData = _db.WebSitePasswords.Find(model.Id);
                dbData.ChangeUserName(model.UserName);
                _db.SaveChanges();

                return Json("UserName Güncellendi");
            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }
        }
        

    }
}
