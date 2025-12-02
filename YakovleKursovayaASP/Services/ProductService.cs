using Microsoft.EntityFrameworkCore;
using YakovleKursovayaASP.Models;

namespace YakovleKursovayaASP.Services
{
    public class ProductService
    {
        private readonly KursachAspContext _context;

        public ProductService(KursachAspContext context)
        {
            _context = context;
        }
        public async Task<Product> GetAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<List<Product>> GetByFiltersAsync(Filters filters)
        {
            return await _context.Products
                .FromSqlInterpolated($@"
        SELECT *
        FROM Products
        WHERE (IFNULL({filters.Brand}, '') = '' OR Brand LIKE '%' || {filters.Brand} || '%')
        AND (IFNULL({filters.Thematics}, '') = '' OR Thematics LIKE '%' || {filters.Thematics} || '%')
        AND (IFNULL({filters.Genre}, '') = '' OR Genre LIKE '%' || {filters.Genre} || '%')").ToListAsync();
        }
    }
}
