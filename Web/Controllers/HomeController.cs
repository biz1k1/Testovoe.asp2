using Infrastracture.Data;
using Infrastracture.Persistence.RecordPersistence.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Contracts;
using Web.Model.ViewModel;
using Web.Services;



namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRecordService _recordService;


        public HomeController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("GetAllRecords","Record");

		}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
