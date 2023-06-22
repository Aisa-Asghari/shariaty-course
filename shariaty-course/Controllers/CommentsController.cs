using Microsoft.AspNetCore.Mvc;
using shariaty_course.Models;

namespace shariaty_course.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // GET: api/Comments
        [HttpGet]
        public IActionResult GetComments()
        {
            var comments = _commentService.GetComments();
            return Ok(comments);
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var comment = _commentService.GetComment(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }
    }
}