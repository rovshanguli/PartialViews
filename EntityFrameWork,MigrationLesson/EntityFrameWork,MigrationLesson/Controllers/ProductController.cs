using EntityFrameWork_MigrationLesson.Data;
using EntityFrameWork_MigrationLesson.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameWork_MigrationLesson.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public  ProductController(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
        List<Product> products = await _context.Products
                .Include(m => m.Catagory)
                .Include(m => m.Images)
                .OrderByDescending(m => m.Id)
                .Take(8)
                .ToListAsync();
        return View(products);
        }
    }
}
