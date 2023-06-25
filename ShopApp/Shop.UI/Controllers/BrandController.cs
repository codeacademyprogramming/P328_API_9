using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Shop.UI.Filters;
using Shop.UI.Models;

namespace Shop.UI.Controllers
{
    [ServiceFilter(typeof(AuthFilter))]
    public class BrandController : Controller
    {
        private HttpClient _client;
        public BrandController()
        {
            _client = new HttpClient();

        }
        public async Task<IActionResult> Index()
        {
            var token = Request.Cookies["auth_token"];
            _client.DefaultRequestHeaders.Add(HeaderNames.Authorization, token);

            using (var response = await _client.GetAsync("https://localhost:7171/api/Brands/all"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<BrandGetAllItemResponse>>(content);

                    return View(data);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    return RedirectToAction("login", "account");
            }
            return View("error");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BrandCreateRequest brand)
        {
            var token = Request.Cookies["auth_token"];
            _client.DefaultRequestHeaders.Add(HeaderNames.Authorization, token);

            if (!ModelState.IsValid) return View();

            StringContent content = new StringContent(JsonConvert.SerializeObject(brand), System.Text.Encoding.UTF8, "application/json");
            using (var response = await _client.PostAsync("https://localhost:7171/api/Brands", content))
            {
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var error = JsonConvert.DeserializeObject<ErrorResponseModel>(responseContent);

                    foreach (var item in error.Errors)
                        ModelState.AddModelError(item.Key, item.Message);

                    return View();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    return RedirectToAction("login", "account");
            }

            return View("error");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var token = Request.Cookies["auth_token"];
            _client.DefaultRequestHeaders.Add(HeaderNames.Authorization, token);

            using (var response = await _client.GetAsync($"https://localhost:7171/api/Brands/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<BrandGetResponse>(responseContent);
                    var vm = new BrandUpdateRequest { Name = data.Name };

                    return View(vm);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    return RedirectToAction("login", "account");
            }
            return View("error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BrandUpdateRequest brand)
        {
            if (!ModelState.IsValid) return View();

            StringContent content = new StringContent(JsonConvert.SerializeObject(brand), System.Text.Encoding.UTF8, "application/json");

            var token = Request.Cookies["auth_token"];
            _client.DefaultRequestHeaders.Add(HeaderNames.Authorization, token);
            using (var response = await _client.PutAsync($"https://localhost:7171/api/Brands/{id}", content))
            {
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var error = JsonConvert.DeserializeObject<ErrorResponseModel>(responseContent);

                    foreach (var item in error.Errors)
                        ModelState.AddModelError(item.Key, item.Message);

                    return View();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    return RedirectToAction("login", "account");
            }
            return View("error");
        }


        public async Task<IActionResult> Delete(int id)
        {
            var token = Request.Cookies["auth_token"];
            _client.DefaultRequestHeaders.Add(HeaderNames.Authorization, token);
            using (var response = await _client.DeleteAsync($"https://localhost:7171/api/Brands/{id}"))
            {
                if (response.IsSuccessStatusCode)
                    return Ok();
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    return Unauthorized();
            }
            return NotFound();
        }
    }
}
