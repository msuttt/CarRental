using CarRental.Models;
using CarRental.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        List<Customer> customerList;
        public ActionResult Index()
        {
            using (var dbContext = new CarRentalContext())
            {
                customerList = dbContext.Customers.ToList();
            }
            return View(customerList);
        }
        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            //int Intisim;
            //string isim = customer.FirstName;
            //bool sayıMı = Int32.TryParse("isim", out Intisim);
            //if (sayıMı)
            //{
            //    TempData["msg"] = "Bu alana sayı giremezsiniz";
            //    return View();
            //}

            int firstName =0;
            int lastName = 0;
            int age = 0;

            bool intMi = int.TryParse(customer.FirstName, out firstName);
            bool sayıMi = int.TryParse(customer.LastName, out lastName);
            bool harfMi = int.TryParse(customer.Age.ToString(), out age);
            

           string kartNo=customer.CreditCardNumber;
           string telefon= customer.Phone;
           string tc= customer.TC;

            var db = new CarRentalContext();

           bool kartVarMı= db.Customers.Any(m => m.CreditCardNumber == kartNo);
           bool telVarMı= db.Customers.Any(m => m.Phone == telefon);
           bool tcVarMı= db.Customers.Any(m => m.TC == tc);

            if (!kartVarMı && !telVarMı && !tcVarMı)
            {
                if (intMi&&customer.FirstName!=string.Empty)
                {
                    TempData["errorMsg"] = "Bu alana sayı giremezsiniz";
                    return RedirectToAction("Create", "Customer");
                }
                else if (sayıMi&&customer.LastName!=string.Empty)
                {
                    TempData["errMsg"] = "Bu alana sayı giremezsiniz";
                    return RedirectToAction("Create", "Customer");
                }
                else if (harfMi&&customer.Age!=null)
                {
                    TempData["erMs"] = "Bu alana harf giremezsiniz";
                    return RedirectToAction("Create", "Customer");
                }
                else
                {
                    using (var dbContext = new CarRentalContext())
                    {
                      

                        dbContext.Customers.Add(customer);
                        dbContext.SaveChanges();
                    }
                }
               
            }

            else
            {
                TempData["errormsg"] = "Aynı TC,Telefon veya Kart Numarasına sahip bir kişi zaten var";
                return RedirectToAction("Create", "Customer");
            }
           
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                RedirectToAction("Index");
            }

            using (var dbContext = new CarRentalContext())
            {
                var customer = dbContext.Customers.Find(id.Value);
                return View(customer);
            }

        }
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            int firstName = 0;
            int lastName = 0;
            int age = 0;

            bool intMi = int.TryParse(customer.FirstName, out firstName);
            bool sayıMi = int.TryParse(customer.LastName, out lastName);
            bool harfMi = int.TryParse(customer.Age.ToString(), out age);


            if (intMi || sayıMi)
           {
                    TempData["errMsg"] = "Bu alana sayı giremezsiniz";
                    return RedirectToAction("Edit", "Customer");
           }
              
                else
          {

                if (harfMi)
                {
                    TempData["harf"] = "buraya harf giremezsiniz";
                    return RedirectToAction("Edit", "Customer");
                }

                else
                {
                    using (var dbContext = new CarRentalContext())
                    {
                       
                        var customerEntry = dbContext.Entry(customer);
                        customerEntry.State = EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                }
                   
          }                                          
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }

            using (var dbContext = new CarRentalContext())
            {
                var customer = dbContext
                    .Customers
                    .SingleOrDefault(c => c.Id == id.Value);

                return View(customer);
            }

        }
        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            using (var dbContext = new CarRentalContext())
            {
                var customerEntry = dbContext.Entry(customer);
                customerEntry.State = EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}