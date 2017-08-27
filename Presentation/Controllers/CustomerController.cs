using Domain.Entieties;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecruitmentTask.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository repository;

        public CustomerController(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            var customersList = repository.GetAll().ToList();
            return View(customersList);
        }

        public ActionResult Details(int? id)
        {
            var customer = repository.Get(x => x.Id == id);
            if (customer == null)
            {
                return RedirectToAction("Error");
            }
            return View(customer);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(customer);
                repository.SaveChanges();
                return RedirectToAction("Index");

            }
            else
                return View(customer);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var customer = repository.Get(x => x.Id == id);
            if (customer == null)
            {
                return RedirectToAction("Error");
            }
            else
                return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.Update(customer);
                    repository.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                    return View(customer);
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try Again");
            }

            return View(customer);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var customer = repository.Get(x => x.Id == id);
            if (customer == null)
                return RedirectToAction("Error");
            else
                return View(customer);

        }

        [HttpPost]
        public ActionResult Delete(int id, string confirmButton)
        {
            var customer = repository.Get(x => x.Id == id);
            repository.Delete(customer);
            repository.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Error()
        {
            ViewBag.Message = "Something went wrong. Please try again later.";
            return View();
        }

    }
}