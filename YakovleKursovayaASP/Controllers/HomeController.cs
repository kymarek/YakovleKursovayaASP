using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using YakovleKursovayaASP.Models;
using YakovleKursovayaASP.Services;

namespace YakovleKursovayaASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _productService;

        public HomeController(ILogger<HomeController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _productService.GetAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _productService.GetAsync(id);
            return View(result);
        }

        public async Task<IActionResult> GetByFilters(Filters filters)
        {
            var all = await _productService.GetAllAsync();

            var filtered = all.AsQueryable();

            if (!string.IsNullOrEmpty(filters.Name))
                filtered = filtered.Where(p => p.Name != null &&
                                     p.Name.Contains(filters.Name, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(filters.Brand))
                filtered = filtered.Where(p => p.Brand != null &&
                                       p.Brand.Contains(filters.Brand, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(filters.Genre))
                filtered = filtered.Where(p => p.Genre != null &&
                                       p.Genre.Contains(filters.Genre, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(filters.Thematics))
                filtered = filtered.Where(p => p.Thematics != null &&
                                       p.Thematics.Contains(filters.Thematics, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(filters.BindingType))
                filtered = filtered.Where(p => p.BindingType != null &&
                                       p.BindingType.Contains(filters.BindingType, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(filters.GameType))
                filtered = filtered.Where(p => p.GameType != null &&
                                               p.GameType.Contains(filters.GameType,
                                                   StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(filters.Series))
                filtered = filtered.Where(p => p.Series != null &&
                                       p.Series.Contains(filters.Series, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(filters.Subject))
                filtered = filtered.Where(p => p.Subject != null &&
                                               p.Subject.Contains(filters.Subject, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(filters.StudingType))
                filtered = filtered.Where(p => p.StudingType != null &&
                                               p.StudingType.Contains(filters.StudingType, StringComparison.OrdinalIgnoreCase));

            if (filters.ProductTypes != null)
                filtered = filtered.Where(p => p.ProductType != null &&
                                               p.ProductType == filters.ProductTypes);

            if (filters.WeightFrom != null && filters.WeightTo != null)
                filtered = filtered.Where(p => p.Weight != null &&
                                               p.Weight >= filters.WeightFrom && p.Weight <= filters.WeightTo);

            if (filters.PriceFrom != null && filters.PriceTo != null)
                filtered = filtered.Where(p => p.Price != null &&
                                               p.Price >= filters.PriceFrom && p.Price <= filters.PriceTo);

            if (filters.PagesFrom != null && filters.PagesTo != null)
                filtered = filtered.Where(p => p.Pages != null &&
                                               p.Pages >= filters.PagesFrom && p.Pages <= filters.PagesTo);

            if (filters.PlayersFrom != null && filters.PlayersTo != null)
                filtered = filtered.Where(p => p.PlayersCount != null &&
                                               p.PlayersCount >= filters.PlayersFrom && p.PlayersCount <= filters.PlayersTo);

            if (filters.ClassFrom != null && filters.ClassTo != null)
                filtered = filtered.Where(p => p.Class != null &&
                                               p.Class >= filters.ClassFrom && p.Class <= filters.ClassTo);

            var filteredProducts = filtered.ToList();

            if (!string.IsNullOrEmpty(filters.Sort))
                filteredProducts = filters.SortWay ? SortProducts(filteredProducts, filters.Sort, true) : SortProducts(filteredProducts, filters.Sort, false);

            var fieldsWithNonNullValues = typeof(Product)
                .GetProperties()
                .Where(p => filteredProducts.Any(prod => p.GetValue(prod) != null))
                .Select(p => p.Name)
                .ToList();

            var result = new GetByFiltersResult()
            {
                FilteredProducts = filteredProducts,
                FieldsWithNonNullValues = fieldsWithNonNullValues
            };

            return Ok(result);
        }

        public async Task<IActionResult> GetFilteredProducts(string filteredProductsString)
        {
            List<Product> filteredProducts = JsonConvert.DeserializeObject<List<Product>>(filteredProductsString);
            return PartialView("ProductList", filteredProducts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> GetBrands()
        {
            var result = await _productService.GetBrands();

            string html = $"<option value=\"\">-</option>";
            foreach (var item in result)
            {
                html += $"<option value=\"{item}\">{item}</option>";
            }
            return Ok(html);
        }

        public async Task<IActionResult> GetGenre()
        {
            var result = await _productService.GetGenre();

            string html = $"<option value=\"\">-</option>";
            foreach (var item in result)
            {
                html += $"<option value=\"{item}\">{item}</option>";
            }
            return Ok(html);
        }

        public async Task<IActionResult> GetGameType()
        {
            var result = await _productService.GetGameType();

            string html = $"<option value=\"\">-</option>";
            foreach (var item in result)
            {
                html += $"<option value=\"{item}\">{item}</option>";
            }
            return Ok(html);
        }

        public async Task<IActionResult> GetSubject()
        {
            var result = await _productService.GetSubject();

            string html = $"<option value=\"\">-</option>";
            foreach (var item in result)
            {
                html += $"<option value=\"{item}\">{item}</option>";
            }
            return Ok(html);
        }

        public async Task<IActionResult> GetStudingType()
        {
            var result = await _productService.GetStudingType();

            string html = $"<option value=\"\">-</option>";
            foreach (var item in result)
            {
                html += $"<option value=\"{item}\">{item}</option>";
            }
            return Ok(html);
        }

        public async Task<IActionResult> GetProductTypes()
        {
            var result = await _productService.GetProductTypes();

            string html = $"<option value=\"\">-</option>";
            foreach (var item in result)
            {
                html += $"<option value=\"{item.Id}\">{item.Name}</option>";
            }
            return Ok(html);
        }

        private List<Product> SortProducts(List<Product> products, string sortProperty, bool ascending = true)
        {
            if (products == null || !products.Any())
                return products;

            var sortDictionary = new Dictionary<string, Func<IEnumerable<Product>, IOrderedEnumerable<Product>>>
            {
                ["name"] = source => ascending ? source.OrderBy(p => p.Name) : source.OrderByDescending(p => p.Name),
                ["price"] = source => ascending ? source.OrderBy(p => p.Price) : source.OrderByDescending(p => p.Price),
                ["weight"] = source => ascending ? source.OrderBy(p => p.Weight) : source.OrderByDescending(p => p.Weight),
                ["brand"] = source => ascending ? source.OrderBy(p => p.Brand) : source.OrderByDescending(p => p.Brand),
                ["producttype"] = source => ascending ? source.OrderBy(p => p.ProductType) : source.OrderByDescending(p => p.ProductType),
                ["pages"] = source => ascending ? source.OrderBy(p => p.Pages) : source.OrderByDescending(p => p.Pages),
                ["playerscount"] = source => ascending ? source.OrderBy(p => p.PlayersCount) : source.OrderByDescending(p => p.PlayersCount),
                ["class"] = source => ascending ? source.OrderBy(p => p.Class) : source.OrderByDescending(p => p.Class),
                ["genre"] = source => ascending ? source.OrderBy(p => p.Genre) : source.OrderByDescending(p => p.Genre),
                ["series"] = source => ascending ? source.OrderBy(p => p.Series) : source.OrderByDescending(p => p.Series)
            };

            var sortKey = sortProperty?.ToLower();

            if (sortKey != null && sortDictionary.ContainsKey(sortKey))
            {
                return sortDictionary[sortKey](products).ToList();
            }

            // Сортировка по умолчанию
            return ascending ? products.OrderBy(p => p.Id).ToList() : products.OrderByDescending(p => p.Id).ToList();
        }
    }
}
