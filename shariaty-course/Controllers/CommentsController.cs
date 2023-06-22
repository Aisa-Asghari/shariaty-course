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

        // POST: api/Comments
        [HttpPost]
        public IActionResult AddComment([FromBody] Comment comment)
        {
            var addedComment = _commentService.AddComment(comment);
            return CreatedAtAction(nameof(GetComment), new { id = addedComment.Id }, addedComment);
        }

        // PUT: api/Comments/5
        [HttpPut("{id}")]
        public IActionResult UpdateComment(int id, [FromBody] Comment comment)
        {
            var updatedComment = _commentService.UpdateComment(id, comment);

            if (updatedComment == null)
            {
                return NotFound();
            }
            return Ok(updatedComment);
        }

        // DELETE: api/Comments/5        
        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            try
            {
                var deletingComment = _commentService.GetComment(id);
                _commentService.DeleteComment(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}