using Microsoft.EntityFrameworkCore;
using YakovleKursovayaASP.Models;

namespace YakovleKursovayaASP.Services
{
    public class UserService
    {
        private readonly KursachAspContext _context;

        public UserService(KursachAspContext context)
        {
            _context = context;
        }

        public async Task<User> GetAsync(LoginModel loginModel)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Login == loginModel.Login && u.Password == loginModel.Password);
        }

        public async Task InsertAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
