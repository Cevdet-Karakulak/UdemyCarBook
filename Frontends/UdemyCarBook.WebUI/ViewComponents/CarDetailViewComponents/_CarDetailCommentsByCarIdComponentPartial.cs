using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.CarFeatureDtos;
using UdemyCarBook.Dto.ReviewDtos;

namespace UdemyCarBook.WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailCommentsByCarIdComponentPartial:ViewComponent
	{
        private readonly IHttpClientFactory _httpClientFactory;
        public _CarDetailCommentsByCarIdComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.carid = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7124/api/Reviews?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultReviewByCarIdDto>>(jsonData);

                // Toplam review sayısı
                ViewBag.TotalReviews = values.Count;

                // Rating grupları
                ViewBag.ReviewStats = values
                    .GroupBy(x => x.RaytingValue)
                    .Select(g => new
                    {
                        Stars = g.Key,
                        Count = g.Count(),
                        Percent = (int)Math.Round((double)g.Count() / values.Count * 100)
                    })
                    .OrderByDescending(x => x.Stars)
                    .ToList();

                return View(values);
            }
            return View(new List<ResultReviewByCarIdDto>());
        }
    }
}
