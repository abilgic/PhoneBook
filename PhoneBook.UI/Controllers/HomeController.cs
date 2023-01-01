using Microsoft.AspNetCore.Mvc;
using PhoneBook.UI.Models;
using PhoneBook.UI.Services;
using System.Diagnostics;

namespace PhoneContact.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly PhoneBookService _phoneService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, PhoneBookService phoneContactService)
        {
            _logger = logger;
            _phoneService = phoneContactService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var contactList = new List<Contact>();
            contactList = await _phoneService.GetAsync();

            return View(contactList);

        }
        [HttpGet]
        public async Task<JsonResult> GetContact(string Id)
        {
            var contact = await _phoneService.GetAsync(Id);

            return Json(contact);
        }

        [HttpPost]
        public async Task<JsonResult> AddContact(Contact newContact)
        {
            await _phoneService.CreateAsync(newContact);

            return Json(true);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateContact(Contact updatedContact)
        {

            await _phoneService.UpdateAsync(updatedContact.Id, updatedContact);

            return Json(updatedContact.Id);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteContact(string Id)
        {

            await _phoneService.DeleteAsync(Id);

            return Json(true);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}