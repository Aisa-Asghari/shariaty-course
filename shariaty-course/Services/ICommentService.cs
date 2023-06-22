namespace shariaty_course.Models
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetComments();
        Comment GetComment(int id);
    }
}
