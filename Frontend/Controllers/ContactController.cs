using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Frontend.Controllers
{
	public class ContactController : Controller
	{
		private readonly HttpClient _httpClient;
		private const string BaseUrl = "https://localhost:7105/api/Contact/Send/?key=MySecretKey";

		public ContactController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}


		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Send(ContactModel model)
		{
			if (ModelState.IsValid)
			{
				var response = await _httpClient.PostAsJsonAsync(BaseUrl, model);

				if (response.IsSuccessStatusCode)
				{
					return RedirectToAction("Index");
				}
			}

			return RedirectToAction("Index","Home");
		}
	}
}

