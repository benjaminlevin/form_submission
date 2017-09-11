using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using form_submission.Models;

namespace form_submission.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("/submit")]
        public IActionResult Submit(string FirstName, string LastName, string Age, string Email, string Password)
        {
            User NewUser = new User
            {
                FirstName = FirstName,
                LastName = LastName,
                Age = Age,
                Email = Email,
                Password = Password,
            };
            TryValidateModel(NewUser);
            if(ModelState.ErrorCount > 0)
            {
                return Json(ModelState.Values);
            }
            else if(ModelState.ErrorCount == 0)
            {
                return Json("Success");
            }
            else
            {
                Console.WriteLine("Unknown Error");
                return new EmptyResult();
            }
        }
    }
}
