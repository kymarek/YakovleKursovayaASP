using Microsoft.EntityFrameworkCore;
using YakovleKursovayaASP.Models;

namespace YakovleKursovayaASP.Services
{
    public class ArtisticBookService
    {
        private readonly KursachAspContext _context;

        public ArtisticBookService(KursachAspContext context)
        {
            _context = context;
        }
        public async Task<ArtisticBook> GetAsync(int id)
        {
            return await _context.ArtisticBooks.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ArtisticBookView> GetViewAsync(int id)
        {
            return await _context.ArtisticBookViews.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<ArtisticBook>> GetAllAsync()
        {
            return await _context.ArtisticBooks.ToListAsync();
        }

        public async Task<List<ArtisticBookView>> GetAllViewsAsync()
        {
            return await _context.ArtisticBookViews.ToListAsync();
        }
    }
}
