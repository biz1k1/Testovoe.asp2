using Application.DTO;
using Microsoft.AspNetCore.Mvc;
using Web.Contracts;
using Web.Model.ViewModel;
using Web.Models;

namespace Web.Controllers
{
    public class RecordController: Controller
    {
        private readonly IRecordService _recordService;


        public RecordController(IRecordService recordService)
        {
            _recordService = recordService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRecords()
        {
            var records = await _recordService.GetAllRecords();
            return View("/Views/Home/Index.cshtml", records);
        }

		[HttpPost]
		public async Task<IActionResult> CreateRecord(RegistrationModel registrationModel)
        {
            try
            {
                var records = await _recordService.CreateRecord(registrationModel);
            }
            catch(Exception ex)
            {
				TempData["ErrorMessage"] = ex.Message;
			}
            return LocalRedirect("~/Home/Index");
		}
        
    }
}
