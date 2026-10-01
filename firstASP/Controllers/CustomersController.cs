using Microsoft.AspNetCore.Mvc;
using firstASP.Data;
using firstASP.Models;

namespace firstASP.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CustomersController(ApplicationDbContext db)
        {
            _db = db;
        }

        // LIST - show all customers
        public IActionResult Index()
        {
            var customers = _db.Customers.ToList();
            return View(customers);
        }

        // ADD - show the form
        public IActionResult Create()
        {
            return View();
        }

        // ADD - save the new customer
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _db.Customers.Add(customer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // EDIT - show the edit form
        public IActionResult Edit(int id)
        {
            var customer = _db.Customers.Find(id);
            if (customer == null) return RedirectToAction("Index");
            return View(customer);
        }

        // EDIT - save the changes
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            _db.Customers.Update(customer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // DELETE - remove the customer
        public IActionResult Delete(int id)
        {
            var customer = _db.Customers.Find(id);
            if (customer != null)
            {
                _db.Customers.Remove(customer);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}