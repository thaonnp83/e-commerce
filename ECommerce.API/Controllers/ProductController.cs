﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.API.Contexts;
using ECommerce.API.Domain;
using ECommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ECommerceContext _dbContext;

        public ProductController(ECommerceContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public IActionResult GetProductAsync(int id)
        {
            return Ok(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAsync(ProductViewModel productViewModel)
        {
            var newProduct = new Product
                {
                Name = productViewModel.Name,
                Description = productViewModel.Description,
                CategoryId = productViewModel.CategoryId,
                BrandId = productViewModel.BrandId,
                Price = productViewModel.Price,
                ThumbnailUrl = productViewModel.ThumbnailUrl
                };

            await _dbContext.Products.AddAsync(newProduct);
            await _dbContext.SaveChangesAsync();

            return Created($"/api/product/{newProduct.Id}", newProduct);
        }
    }
}
