using FoodBasket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FoodBasket.Controllers
{
    public class AdminController : Controller
    {
        private readonly FoodBasketContext _foodBasketContext;
        private AdminController() { }
        public AdminController(FoodBasketContext foodBasketContext)
        {
            _foodBasketContext = foodBasketContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }

        public IActionResult Suppliers()
        {
            return View();
        }

        public IActionResult AddCountry()
        {
            var currencyList = _foodBasketContext.Currencies
                .Where(x => (bool)x.IsActive)
                .Select(x => new SelectListItem
                {
                    Value = x.CurrencyId.ToString(),
                    Text = x.CurrencyName // assuming CurrencyName is the display field
                })
                .ToList();
            ViewBag.CurrencyId = currencyList;
            return View();
        }

        [HttpPost]
        public IActionResult AddCountry(Country country)
        {
            _foodBasketContext.Add(country);
            _foodBasketContext.SaveChanges();
            return RedirectToAction("CountryList");
        }

        public IActionResult EditCountry(int id)
        {
            Country country = GetCountry(id);
            return View(country);
        }

        public IActionResult DeleteCountry(int id)
        {
            Country country = GetCountry(id);
            return View(country);
        }

        [HttpPost]
        public IActionResult DeleteCountry(Country country)
        {
            country = GetCountry(country.CountryId);
            country.IsActive = false;
            _foodBasketContext.Update(country);
            _foodBasketContext.SaveChanges();
            return RedirectToAction("CountryList");
        }

        public IActionResult CountryList()
        {
            List<Country> countryList = _foodBasketContext.Countries
                .Where(x => (bool)x.IsActive)
                .Include(x => x.Currency)
                .ToList();
            return View(countryList);
        }

        public IActionResult CountryDetails(int id)
        {
            Country country = GetCountry(id);
            return View(country);
        }

        public IActionResult AddCurrency()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCurrency(Currency currency)
        {
            _foodBasketContext.Add(currency);
            _foodBasketContext.SaveChanges();
            return RedirectToAction("CurrencyList");
        }

        private Currency GetCurrency(int id)
        {
            Currency currency = _foodBasketContext.Currencies.Where(x => x.CurrencyId.Equals(id)).FirstOrDefault();
            return currency;
        }

        private Country GetCountry(int id)
        {
            Country country = _foodBasketContext.Countries
                .Where(x => x.CountryId.Equals(id))
                .Include(x => x.Currency)
                .FirstOrDefault();
            return country;
        }

        public IActionResult EditCurrency(int id)
        {
            Currency currency = GetCurrency(id);
            return View(currency);
        }

        [HttpPost]
        public IActionResult EditCurrency(Currency currency)
        {
            _foodBasketContext.Update(currency);
            _foodBasketContext.SaveChanges();
            return RedirectToAction("CurrencyList");
        }

        public IActionResult DeleteCurrency(int id)
        {
            Currency currency = GetCurrency(id);
            return View(currency);
        }

        [HttpPost]
        public IActionResult DeleteCurrency(Currency currency)
        {
            currency = GetCurrency(currency.CurrencyId);
            currency.IsActive = false;
            _foodBasketContext.Update(currency);
            _foodBasketContext.SaveChanges();
            return RedirectToAction("CurrencyList");
        }

        public IActionResult CurrencyList()
        {
            List<Currency> currencies = _foodBasketContext.Currencies.Where(x=> (bool)x.IsActive).ToList();
            return View(currencies);
        }

        public IActionResult CurrencyDetails(int id)
        {
            Currency currency = GetCurrency(id);
            return View(currency);
        }

        public IActionResult ProductType()
        {
            return View();
        }
    }
}