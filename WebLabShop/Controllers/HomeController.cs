using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using WebLabShop.DbContexts;
using WebLabShop.Interfaces;
using WebLabShop.Mocks;
using WebLabShop.Models;
using WebLabShop.Repository;

namespace WebLabShop.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> allProducts;
        IRepository<Brands> allBrands;
        IRepository<City> allCities;
        IRepository<Order> allOrders;
        IRepository<OrderedProduct> allOrderedProduct;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(WebDbContexts contexts, IHttpContextAccessor httpContextAccessor)
        {
            allProducts = new ProductRepository(contexts);
            allBrands = new BrandRepository(contexts);
            allCities = new CityRepository(contexts);
            allOrderedProduct = new OrderedProductRepository(contexts);
            allOrders = new OrderRepository(contexts);
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            ViewBag.BrandList = allBrands.GetObjList().ToList();
            ViewBag.CitiesList = allCities.GetObjList().ToList();


            return View(allProducts.GetObjList().ToList());
        }

        [HttpGet]
        public IActionResult Sort(string sort, string filter)
        {
            List<Product> sorted;
            if (!String.IsNullOrEmpty(filter))
                sorted = allProducts.GetObjList(filter).ToList();
            else
                sorted = allProducts.GetObjList().ToList();
            switch (sort)
            {
                case "По возрастанию":
                    return PartialView("_Products", sorted.OrderBy(sorted => sorted.Price));
                case "По убыванию":
                    return PartialView("_Products", sorted.OrderByDescending(sorted => sorted.Price));
                default:
                    return PartialView("_Products", sorted);
            }
        }
        [HttpPost]
        public JsonResult AddToBasket(int id)
        {
            int result = id;
            List<OrderedProduct> orderedProducts = _httpContextAccessor.HttpContext.Session.Get<List<OrderedProduct>>("list") != null ? _httpContextAccessor.HttpContext.Session.Get<List<OrderedProduct>>("list") : new List<OrderedProduct>();
            orderedProducts.Add(new OrderedProduct { ProductId = id, Count = 1 });
            int basketCount = orderedProducts.Count;

            long totalPrice = 0;
            foreach (OrderedProduct ordered in orderedProducts)
            {
                totalPrice += allProducts.GetObj(ordered.ProductId).Price * ordered.Count;
            }

            _httpContextAccessor.HttpContext.Session.Set<List<OrderedProduct>>("list", orderedProducts);

            _httpContextAccessor.HttpContext.Session.SetString("totalPrice", totalPrice.ToString());
            _httpContextAccessor.HttpContext.Session.SetString("basketCount", basketCount.ToString());
            return Json(basketCount);
        }

        [HttpPost]
        public JsonResult ChangeCntr(int id, string change)
        {
            List<OrderedProduct> orderedProducts = _httpContextAccessor.HttpContext.Session.Get<List<OrderedProduct>>("list");
            if (change == "plus")
            {
                orderedProducts.Find(p => p.ProductId == id).Count++;
            }
            else if (change == "minus")
            {
                if (orderedProducts.Find(p => p.ProductId == id).Count != 1)
                {
                    orderedProducts.Find(p => p.ProductId == id).Count--;
                }
            }

            long totalPrice = 0;
            foreach (OrderedProduct ordered in orderedProducts)
            {
                totalPrice += allProducts.GetObj(ordered.ProductId).Price * ordered.Count;
            }

            _httpContextAccessor.HttpContext.Session.Set<List<OrderedProduct>>("list", orderedProducts);
            var package = new CounterBasketPackage
            {
                Count = orderedProducts.Find(p => p.ProductId == id).Count,
                Price = allProducts.GetObj(orderedProducts.Find(p => p.ProductId == id).ProductId).Price * orderedProducts.Find(p => p.ProductId == id).Count,
                TotalPrice = totalPrice
            };
            _httpContextAccessor.HttpContext.Session.SetString("totalPrice", totalPrice.ToString());
            return Json(package);
        }

        [HttpPost]
        public ActionResult FinishOrder()
        {
            List<OrderedProduct> orderedProducts = _httpContextAccessor.HttpContext.Session.Get<List<OrderedProduct>>("list");
            string var = HttpContext.Request.Cookies["city"];
            int i = 0;
            Order order = new Order { City = HttpContext.Request.Cookies["city"], Date = DateTime.Now, OrderedProducts = orderedProducts.ToList() };
            allOrders.Add(order);
            return Json("");
        }

        public ActionResult Basket()
        {
            ViewBag.CitiesList = allCities.GetObjList().ToList();
            var model = _httpContextAccessor.HttpContext.Session.Get<List<OrderedProduct>>("list");
            if (model != null) 
            foreach (OrderedProduct ordered in model)
            {
                ordered.Product = allProducts.GetObj(ordered.ProductId);
            }
            return View(model);
        }
        public IActionResult Orders()
        {
            ViewBag.CitiesList = allCities.GetObjList().ToList();

            return View(allOrders.GetObjList().ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
