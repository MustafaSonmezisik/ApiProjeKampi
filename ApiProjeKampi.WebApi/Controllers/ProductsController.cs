using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        private readonly ApiContext _context;

        public ProductsController(IValidator<Product> validator, ApiContext context)
        {
            _validator = validator;
            _context = context;
        }

        [HttpGet]
        public IActionResult ProductList (){
            var values = _context.Products.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product )
        {
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
            }
            else
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok(new { message = "Ürün başarıyla eklendi.", data= product });
            }         

        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _context.Products.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                _context.Products.Remove(value);
                _context.SaveChanges();
                return Ok(new { message = "Ürün başarıyla silindi.", data = value });
            }
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _context.Products.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(value);
            }
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
           var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
            }
            else
            {
               
                  _context.Products.Update(product);
                    _context.SaveChanges();
                    return Ok( "Ürün başarıyla güncellendi.");
            }
        }



    }
}