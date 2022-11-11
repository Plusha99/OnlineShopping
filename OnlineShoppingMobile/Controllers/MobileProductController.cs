using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingMobile.Data;
using OnlineShoppingMobile.Models;

namespace OnlineShoppingMobile.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MobileProductController : ControllerBase
    {
        private readonly DataContext _context;
        public MobileProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<MobileProduct>mobileProducts = _context.Mobiles.ToList();
            return Ok(mobileProducts);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            MobileProduct mobileProduct = _context.Mobiles.Find(id);
            return Ok(mobileProduct);
        }

        [HttpPost]
        public ActionResult Create(MobileProduct mobileProduct)
        {
            if(ModelState.IsValid)
            {
                _context.Add(mobileProduct);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public ActionResult Update(MobileProduct mobileProduct)
        {
            if(ModelState.IsValid)
            {
                _context.Update(mobileProduct);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            MobileProduct mobileProduct = _context.Mobiles.FirstOrDefault(x => x.Id == id);
            _context.Remove(mobileProduct);
            _context.SaveChanges();
            return Ok();
        }
    }
}