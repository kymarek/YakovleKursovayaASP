using Microsoft.EntityFrameworkCore;
using YakovleKursovayaASP.Models;

namespace YakovleKursovayaASP.Services
{
    public class StudingBookService
    {
        private readonly KursachAspContext _context;

        public StudingBookService(KursachAspContext context)
        {
            _context = context;
        }

        public async Task<StudingBook> GetAsync(int id)
        {
            return await _context.StudingBooks.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<StudingBookView> GetViewAsync(int id)
        {
            return await _context.StudingBookViews.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<StudingBook>> GetAllAsync()
        {
            return await _context.StudingBooks.ToListAsync();
        }

        public async Task<List<StudingBookView>> GetAllViewsAsync()
        {
            return await _context.StudingBookViews.ToListAsync();
        }
    }
}
