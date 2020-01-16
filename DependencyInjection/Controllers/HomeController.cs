using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjection.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository productRepository;


        public HomeController(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        public IActionResult Index()
        {
            return View(productRepository.GetAll());
        }
        public IActionResult Get()
        {
            return View(productRepository.Get());
        }
    }
}