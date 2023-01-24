using Autofac;
using Library.Web.Areas.App.Models.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Text.Json;

namespace Library.Web.Areas.App.Controllers
{
    [Area("App")]
    public class NoteController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly ILifetimeScope _scope;

        public NoteController(ILogger<BookController> logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var model = _scope.Resolve<BookCreateModel>();
            return View(model);
        }

        //[HttpPost, ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(BookCreateModel model)
        //{
            
        //}
    }


}
