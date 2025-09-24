using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.BlogDtos;
using UdemyCarBook.Dto.CategoryDtos;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsCategoryComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _BlogDetailsCategoryComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            // Kategorileri al
            var responseCategory = await client.GetAsync("https://localhost:7124/api/Categories");
            var jsonCategory = await responseCategory.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonCategory);

            // Tüm blogları al
            var responseBlog = await client.GetAsync("https://localhost:7124/api/Blogs/GetAllBlogsWithAuthorList");
            var jsonBlog = await responseBlog.Content.ReadAsStringAsync();
            var blogs = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonBlog);

            // Kategoriye göre blog sayısını hesapla
            foreach (var cat in categories)
            {
                cat.BlogCount = blogs.Count(b => b.categoryID == cat.CategoryId);
            }

            return View(categories);
        }
    }
}
