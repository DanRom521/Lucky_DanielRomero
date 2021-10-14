using Lucky_DanielRomero.Data;
using Lucky_DanielRomero.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lucky_DanielRomero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomLucksController : ControllerBase
    {
        private readonly AppDbContext _context; 
        public RandomLucksController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        /*public async Task<ActionResult<Luck>> GetLucky()
        {
            var list = await _context.Lucky.LastAsync();
            var max = list.Count;
            var index = new Random().Next(0, 10);
            var modelo = list[index];
            if (modelo == null)
            {
                return NoContent();
            }
            return modelo;
        }*/
    }
}
