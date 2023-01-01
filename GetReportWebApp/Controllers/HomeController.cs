using GetReportWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace GetReportWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()

        {
            return View();
        }
        [HttpGet]
        public JsonResult GetReport()
        {
            using var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("http://localhost:5257/");

            var result = httpClient.GetAsync("Report/GetReport").Result;

            var jsonString = result.Content.ReadAsStringAsync().Result;

            var products = JsonSerializer.Deserialize<List<ReportModel>>(jsonString);

            return Json(products);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}