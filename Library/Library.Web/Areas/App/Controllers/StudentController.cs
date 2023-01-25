using Autofac;
using Library.Infrastructure.Exceptions;
using Library.Web.Areas.App.Models.Books;
using Library.Web.Areas.App.Models.Students;
using Library.Web.Codes;
using Library.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Org.BouncyCastle.Ocsp;
using System.Text.Json;
using static System.Formats.Asn1.AsnWriter;

namespace Library.Web.Areas.App.Controllers
{
    [Area("App")]
    public class StudentController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly ILifetimeScope _scope;

        public StudentController(ILogger<BookController> logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetStudentData(string status)
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<StudentListModel>();
            bool.TryParse(status, out bool stat);
            return Json(model.GetPagedUsers(dataTableModel, stat));
        }

        public async Task<IActionResult> Remove(Guid studentId)
        {
            var model = _scope.Resolve<StudentListModel>();
            await model.RemoveStudent(studentId);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ApproveAsync(Guid studentId)
        {
            var aproveModel = _scope.Resolve<StudentApproveModel>();

            await aproveModel.StudentApprove(studentId, true);

            TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
            {
                Message = "Student Approved",
                Type = ResponseTypes.Success
            });
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            var model = _scope.Resolve<StudentCreateModel>();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentCreateModel model)
        {
            if (ModelState.IsValid)
            {
                model.Email = model.Email.ToLower();
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
                        TempData["Name"] = model.Name;
                        TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                        {
                            Message = "Successfully Added Student - " + model.Name,
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
                        Message = "There was a problem in Adding Student.",
                        Type = ResponseTypes.Danger
                    });
                    return View(model);
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }

    

}
