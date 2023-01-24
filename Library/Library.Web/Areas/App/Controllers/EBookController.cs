using Autofac;
using Library.Infrastructure.Exceptions;
using Library.Web.Areas.App.Models.Books;
using Library.Web.Codes;
using Library.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Text.Json;

namespace Library.Web.Areas.App.Controllers
{
    [Area("App")]
    public class EBookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly ILifetimeScope _scope;

        public EBookController(ILogger<BookController> logger, ILifetimeScope scope)
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
            var model = _scope.Resolve<EBookCreateModel>();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EBookCreateModel model)
        {
            if (ModelState.IsValid)
            {
                model.BookTitle = model.BookTitle.ToLower();
                model.ResolveDependency(_scope);
                try
                {
                    await model.CreateAsync();
                    
                    TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    {
                        Message = "Successfully Added Book - " + model.BookTitle,
                        Type = ResponseTypes.Success
                    });
                    
                }
                catch (DuplicateException ioe)
                {
                    _logger.LogError(ioe, ioe.Message);
                    ModelState.AddModelError("", ioe.Message);
                    TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    {
                        Message = ioe.Message,
                        Type = ResponseTypes.Danger
                    });
                    return View(model);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    {
                        Message = "There was a problem in Adding Book.",
                        Type = ResponseTypes.Danger
                    });
                    return View(model);
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }


}
