using Frontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
	public class ProductController : Controller
	{
		private readonly HttpClient _httpClient;
		private const string BaseUrl = "https://localhost:7105/api/Product";

		public ProductController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IActionResult> Index()
		{
			var result = await _httpClient.GetFromJsonAsync<IEnumerable<ProductModel>>($"{BaseUrl}?key=MySecretKey");
			return View(result);
		}

		public async Task<IActionResult> Search(string searchTerm)
		{
			if (string.IsNullOrEmpty(searchTerm))
			{
				return View(new List<ProductModel>());
			}

			var result = await _httpClient.GetFromJsonAsync<IEnumerable<ProductModel>>($"{BaseUrl}/search/{searchTerm}?key=MySecretKey");
			return View(result);
		}

		public async Task<IActionResult> Details(int id)
		{
			var result = await _httpClient.GetFromJsonAsync<ProductModel>($"{BaseUrl}/details/{id}?key=MySecretKey");
			return View(result);
		}
	}
}
