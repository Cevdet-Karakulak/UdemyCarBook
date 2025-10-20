using MediatR;
using System;

namespace UdemyCarBook.Application.Features.Mediator.Commands.CommentCommands
{
    public class CreateCommentCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; } // nullable yaptık
        public int BlogID { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string CommentStatus { get; set; }
    }
}