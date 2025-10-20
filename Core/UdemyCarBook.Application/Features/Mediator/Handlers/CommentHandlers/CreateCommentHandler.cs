using MediatR;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.CommentCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly IRepository<Comment> _repository;

        public CreateCommentHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            bool isToxic = false;

            using (var client = new HttpClient())
            {
                var apiKey = "YOUR_API_KEY;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                var toxicRequestBody = new { inputs = request.Description };
                var toxicJson = JsonSerializer.Serialize(toxicRequestBody);
                var toxicContent = new StringContent(toxicJson, Encoding.UTF8, "application/json");

                var toxicResponse = await client.PostAsync(
                    "https://api-inference.huggingface.co/models/unitary/toxic-bert", toxicContent);

                var toxicResponseString = await toxicResponse.Content.ReadAsStringAsync();

                if (toxicResponseString.TrimStart().StartsWith("["))
                {
                    using var doc = JsonDocument.Parse(toxicResponseString);
                    var firstElement = doc.RootElement[0];

                    if (firstElement.ValueKind == JsonValueKind.Array)
                    {
                        foreach (var item in firstElement.EnumerateArray())
                        {
                            double score = item.GetProperty("score").GetDouble();
                            if (score > 0.5)
                            {
                                isToxic = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        double score = firstElement.GetProperty("score").GetDouble();
                        if (score > 0.5)
                            isToxic = true;
                    }
                }
            }

            if (isToxic)
            {
                throw new Exception("Yorum toksik olarak değerlendirildi ve kaydedilmedi.");
            }

            await _repository.CreateAsync(new Comment
            {
                Name = request.Name,
                Email = request.Email,
                BlogID = request.BlogID,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                CreatedDate = request.CreatedDate ?? DateTime.Now, 
                CommentStatus = "Onaylandı"
            });

            return Unit.Value; // Task<Unit> dönmek için
        }
    }
}
