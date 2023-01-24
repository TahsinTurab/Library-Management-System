using Autofac;
using Library.Infrastructure.Exceptions;
using Library.Web.Areas.App.Models.Books;
using Library.Web.Codes;
using Library.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Org.BouncyCastle.Asn1.Ocsp;
using System.ComponentModel;
using System.Text.Json;

namespace Library.Web.Areas.App.Controllers
{
    [Area("App")]
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly ILifetimeScope _scope;

        public BookController(ILogger<BookController> logger, ILifetimeScope scope)
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

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookCreateModel model)
        {
            if (ModelState.IsValid)
            {
                model.BookTitle = model.BookTitle.ToLower();
                model.ResolveDependency(_scope);
                try
                {
                    var bookGuid = await model.CreateAsync();
                    if (bookGuid == null)
                    {
                        return View(model);
                    }
                    else
                    {
                        TempData["BookID"] = bookGuid;
                        TempData["BookTitle"] = model.BookTitle;
                        TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                        {
                            Message = "Successfully Added Book - " + model.BookTitle,
                            Type = ResponseTypes.Success
                        });
                    }
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

            return RedirectToAction(nameof(BookDetails));
        }

        public IActionResult BookDetails()
        {
            var model = _scope.Resolve<BookDetailsCreateModel>();
            if (TempData.Peek("BookTitle") == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                model.BookTitle = (string)TempData.Peek("BookTitle");
                return View(model);
            }
        }
    }


}
