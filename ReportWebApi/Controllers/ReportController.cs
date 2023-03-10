using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportWebApi.Services;

namespace ReportWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : Controller
    {
        private readonly IMessageProducer _messagePublisher;
        private readonly ReportService _reportService;

        public ReportController(ReportService reportService, IMessageProducer messagePublisher)
        {
            _reportService = reportService;
            _messagePublisher = messagePublisher;
        }
        // GET: ReportController
        [HttpGet("GetReport")]
        public async Task<JsonResult> GetReport()
        {
            var result = await _reportService.GetAsync();
            var rlist = result.Select(s => new
            {
                Location = s.Location,
                ContactNumber = result.Where(l => l.Location == s.Location).Count(),
                PhoneCount = result.Where(l => l.Location == s.Location && s.PhoneNumber != null).Count(),
            }).ToList().OrderBy(o => o.ContactNumber);

            // _messagePublisher.SendMessage(rlist); 

            return Json(rlist);

        }

    }
}
