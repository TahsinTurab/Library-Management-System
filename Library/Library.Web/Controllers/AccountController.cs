using Autofac;
using Library.Infrastructure.Entities;
using Library.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Serilog;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace Library.Web.Controllers
{
    public class AccountController : Controller
    {

        
        public async Task<IActionResult> Register()
        {
            return View();
        }

        


        public async Task<IActionResult> Login()
        {


            return View();
        }

    }  

}
