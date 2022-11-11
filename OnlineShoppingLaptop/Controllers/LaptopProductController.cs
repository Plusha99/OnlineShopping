using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingLaptop.Data;
using OnlineShoppingLaptop.Models;

namespace OnlineShoppingLaptop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LaptopProductController : ControllerBase
    {
        private readonly DataContext _context;
        public LaptopProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<LaptopProduct> laptopProduct = _context.Laptops.ToList();
            return Ok(laptopProduct);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            LaptopProduct laptopProduct = _context.Laptops.Find(id);
            return Ok(laptopProduct);
        }

        [HttpPost]
        public ActionResult Create(LaptopProduct laptopProduct)
        {
            if(ModelState.IsValid)
            {
                _context.Add(laptopProduct);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public ActionResult Update(LaptopProduct laptopProduct)
        {
            if(ModelState.IsValid)
            {
                _context.Update(laptopProduct);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            LaptopProduct laptopProduct = _context.Laptops.FirstOrDefault(x => x.Id == id);
            _context.Remove(laptopProduct);
            _context.SaveChanges();
            return Ok();
        }
    }
}