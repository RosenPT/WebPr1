using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Submit(string userInput)
        {
            if (int.TryParse(userInput, out int input))
            {
                var apiUrl = "http://api:5001/api/input";  // Docker service name 'api'
                var content = new StringContent(input.ToString(), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);

                if (response.StatusCode == (System.Net.HttpStatusCode)203)
                {
                    ViewBag.Message = "Received 203 from API";
                }
                else
                {
                    ViewBag.Message = $"Received response: {response.ReasonPhrase}";
                }
            }
            else
            {
                ViewBag.Message = "Invalid input";
            }

            return View("Result");
        }
    }
}