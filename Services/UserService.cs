using Day01_UserCrud.Models;
using Day01_UserCrud.DTOs;

namespace Day01_UserCrud.Services
{
    public class UserService
    {
        private readonly List<User> _users = new();
        private int _nextId = 1;

        public List<User> GetAll() => _users;
        public User? Get(int id) => _users.FirstOrDefault(x => x.Id == id);
        public User Create(UserDto dto)
        {
            var user = new User
            {
                Id = _nextId++,
                Name = dto.Name,
                Email = dto.Email
            };
            _users.Add(user);
            return user;
        }
        public bool Update(int id, UserDto dto)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            if (user == null) return false;

            user.Name = dto.Name;
            user.Email = dto.Email;
            return true;
        }
        public bool Delete(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            if (user == null) return false;

            _users.Remove(user);
            return true;
        }
    }
}
