namespace shariaty_course.Models
{
    public interface IUserService
    {
        User GetUser(int id);
        User AddUser(User user);
    }
}
