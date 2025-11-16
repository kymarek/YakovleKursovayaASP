using Microsoft.EntityFrameworkCore;
using YakovleKursovayaASP.Models;

namespace YakovleKursovayaASP.Services
{
    public class BoardGameService
    {
        private readonly KursachAspContext _context;

        public BoardGameService(KursachAspContext context)
        {
            _context = context;
        }

        public async Task<BoardGame> GetAsync(int id)
        {
            return await _context.BoardGames.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<BordGameView> GetViewAsync(int id)
        {
            return await _context.BordGameViews.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<BoardGame>> GetAllAsync()
        {
            return await _context.BoardGames.ToListAsync();
        }

        public async Task<List<BordGameView>> GetAllViewsAsync()
        {
            return await _context.BordGameViews.ToListAsync();
        }
    }
}
