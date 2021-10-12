using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _102180192_PhanTheTue.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _102180192_PhanTheTue.Controllers
{
    public class ComputerController : Controller
    {
        private readonly DataContext _db;
        public ComputerController(DataContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(string sortOrder, string searchName)
        {
            var listComputer = from s in _db.Computers select s;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["IDSortParm"] = sortOrder == "id" ? "id_desc" : "id";
            if (!String.IsNullOrEmpty(searchName))
            {
                listComputer = listComputer.Where(s => s.name.Contains(searchName));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    listComputer = listComputer.OrderByDescending(s => s.name);
                    break;
                case "name":
                    listComputer = listComputer.OrderBy(s => s.name);
                    break;
                case "id_desc":
                    listComputer = listComputer.OrderByDescending(s => s.id);
                    break;
                default:
                    listComputer = listComputer.OrderBy(s => s.id);
                    break;
            }
            return View(await listComputer.AsNoTracking().ToListAsync());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Computer obj)
        {
            _db.Computers.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Computers.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Computer obj)
        {
            if (ModelState.IsValid)
            {
                _db.Computers.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Computers.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Computers.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Computers.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}