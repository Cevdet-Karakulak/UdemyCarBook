using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using UdemyCarBook.Dto.DashboardDtos;

namespace UdemyCarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardChart2ComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardChart2ComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7124/api/Brands/BrandCarCounts"); // tüm markalar
            List<BrandCarCountDto> allBrandCounts = new List<BrandCarCountDto>();

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                allBrandCounts = JsonConvert.DeserializeObject<List<BrandCarCountDto>>(jsonData);
            }

            // Grafik için sadece Top7
            var top7BrandCounts = allBrandCounts.OrderByDescending(b => b.CarCount).Take(7).ToList();

            // View’a hem Top7 hem toplam bilgilerini gönder
            var model = new Tuple<List<BrandCarCountDto>, int, int>(
                top7BrandCounts,
                allBrandCounts.Sum(b => b.CarCount), // toplam araç sayısı
                allBrandCounts.Count()               // toplam marka sayısı
            );

            return View(model);
        }
    }
}