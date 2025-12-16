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

        public async Task<List<string>> GetBrands()
        {
            return await _context.Products
                .Where(p => p.Brand != null)
                .Select(p => p.Brand)
                .Distinct()
                .ToListAsync(); ;
        }

        public async Task<List<string>> GetGenre()
        {
            return await _context.Products
                .Where(p => p.Genre != null)
                .Select(p => p.Genre)
                .Distinct()
                .ToListAsync(); ;
        }

        public async Task<List<string>> GetGameType()
        {
            return await _context.Products
                .Where(p => p.GameType != null)
                .Select(p => p.GameType)
                .Distinct()
                .ToListAsync(); ;
        }

        public async Task<List<string>> GetSubject()
        {
            return await _context.Products
                .Where(p => p.Subject != null)
                .Select(p => p.Subject)
                .Distinct()
                .ToListAsync(); ;
        }
        
        public async Task<List<string>> GetStudingType()
        {
            return await _context.Products
                .Where(p => p.StudingType != null)
                .Select(p => p.StudingType)
                .Distinct()
                .ToListAsync(); ;
        }

        public async Task<List<ProductType>> GetProductTypes()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<List<Product>> GetByFiltersAsync(Filters filters)
        {
            return await _context.Products
                .FromSqlInterpolated($@"
        SELECT *
        FROM Products
        WHERE (IFNULL({filters.Brand}, '') = '' OR Brand LIKE '%' || {filters.Brand} || '%')
        AND (IFNULL({filters.Thematics}, '') = '' OR Thematics LIKE '%' || {filters.Thematics} || '%')
        AND (IFNULL({filters.Name}, '') = '' OR Name LIKE '%' || {filters.Name} || '%')
        AND (IFNULL({filters.Series}, '') = '' OR Series LIKE '%' || {filters.Series} || '%')
        AND (IFNULL({filters.Genre}, '') = '' OR Genre LIKE '%' || {filters.Genre} || '%')").ToListAsync();
        }
    }
}
