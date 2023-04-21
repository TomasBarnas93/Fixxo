using Frontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
		private const string BaseUrl = "https://localhost:7105/api/Product?key=MySecretKey";

		public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _httpClient.GetFromJsonAsync<IEnumerable<ProductModel>>(BaseUrl);
		
			return View(products);

        }


    }
}