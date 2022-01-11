using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _062_Mansoor_Crud.Models;

using Microsoft.EntityFrameworkCore;
namespace _062_Mansoor_Crud.Controllers
{
    public class OrderController : Controller
    {
        private readonly StoreDB _db;
        public OrderController(StoreDB db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var displaydata = _db.order_table.ToList();
            return View(displaydata);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Orderclass ord)
        {
            if (ModelState.IsValid)
            {
                _db.Add(ord);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");

            }

            return View(ord);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var getorderdetails = await _db.order_table.FindAsync(id);
            return View(getorderdetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Orderclass ord)
        {
            if (ModelState.IsValid)
            {
                _db.Update(ord);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");

            }

            return View(ord);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var getorderdetails = await _db.order_table.FindAsync(id);
            return View(getorderdetails);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var getorderdetails = await _db.order_table.FindAsync(id);
            return View(getorderdetails);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            var getorderdetails = await _db.order_table.FindAsync(id);
            _db.order_table.Remove(getorderdetails);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");

        }

    }
}
