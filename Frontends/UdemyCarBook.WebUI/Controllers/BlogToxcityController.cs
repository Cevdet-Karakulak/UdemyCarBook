using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.BlogDtos;
using UdemyCarBook.Dto.CommentDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class BlogToxcityController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BlogToxcityController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Yazarlarımızın Blogları";
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7124/api/Blogs/GetAllBlogsWithAuthorList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);

                foreach (var blog in values)
                {
                    var commentResponse = await client.GetAsync($"https://localhost:7124/api/Comments/CommentCountByBlog?id=" + blog.blogID);
                    var commentCountStr = await commentResponse.Content.ReadAsStringAsync();
                    blog.CommentCount = int.TryParse(commentCountStr, out var count) ? count : 0;
                }

                return View(values);
            }

            return View();
        }

        public async Task<IActionResult> BlogDetail(int id)
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Blog Detayı ve Yorumlar";
            ViewBag.blogid = id;

            var client = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync($"https://localhost:7124/api/Comments/CommentCountByBlog?id=" + id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.commentCount = jsonData2;

            return View();
        }

        [HttpPost]
        public async Task<JsonResult> CheckToxicity([FromBody] CreateCommentDto dto)
        {
            bool isToxic = false;

            using (var client = new HttpClient())
            {
                var apiKey = "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";
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

                var body = new { inputs = dto.Description };
                var json = JsonConvert.SerializeObject(body);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(
                    "https://api-inference.huggingface.co/models/unitary/toxic-bert", content);
                var respStr = await response.Content.ReadAsStringAsync();

                if (respStr.TrimStart().StartsWith("["))
                {
                    using var doc = System.Text.Json.JsonDocument.Parse(respStr);
                    var firstElement = doc.RootElement[0];

                    if (firstElement.ValueKind == System.Text.Json.JsonValueKind.Array)
                    {
                        foreach (var item in firstElement.EnumerateArray())
                        {
                            if (item.GetProperty("score").GetDouble() > 0.5)
                            {
                                isToxic = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (firstElement.GetProperty("score").GetDouble() > 0.5)
                            isToxic = true;
                    }
                }
            }

            return Json(new { isToxic });
        }

        [HttpPost]
        public async Task<JsonResult> AddComment([FromBody] CreateCommentDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(
                "https://localhost:7124/api/Comments/CreateCommentWithMediator", content);

            if (response.IsSuccessStatusCode)
                return Json(new { status = "Yorum başarıyla eklendi" });

            return Json(new { status = "Yorum eklenemedi" });
        }
    }
}
