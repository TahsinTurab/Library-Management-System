using Autofac;
using Library.Web.Areas.App.Models.Books;
using Library.Web.Areas.App.Models.Students;
using Library.Web.Codes;
using Library.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Text.Json;

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
    }


}
