namespace shariaty_course.Models
{
    public class UserService : IUserService
    {
        private readonly List<User> _users = new List<User>
        {
            new User{
                Id=1,
                Username="ice_asghari",
                Password="4171",
                Email="aisaasghari@gmail.com",
                IsAdmin=true,
            },
            new User{
                Id=2,
                Username="test",
                Password="4171",
                Email="test@gmail.com",
                IsAdmin=true,
            },
        };

        public User AddUser(User user)
        {
            user.Id = _users.Select(comment => comment.Id).DefaultIfEmpty(0).Max() + 1;
            user.IsAdmin = true;

            _users.Add(user);
            return user;
        }

        User IUserService.GetUser(int id)
        {
            return _users.FirstOrDefault(user => user.Id == id);
        }
    }
}
