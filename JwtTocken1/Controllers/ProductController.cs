using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtTocken1.Model;
using JwtTocken1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JwtTocken1.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IproductService _iproduct;
        public ProductController(IproductService service)
        {
            _iproduct = service;
        }
        // GET: api/values
        [HttpGet]
        [Authorize(Roles ="user")]
        public IActionResult GetViewProducts()
        {
            return Ok( _iproduct.ViewProducts());
        }
        
        // POST api/values
        [HttpPost]
        [Authorize(Roles ="admin")]
        public IActionResult AddProducts(Products products)
        {
            return Ok(_iproduct.AddProducts(products));
        }

       
    }
}

