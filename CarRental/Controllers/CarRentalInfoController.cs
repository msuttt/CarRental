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
    public class CarRentalInfoController : Controller
    {
        // GET: CarRentalInfo
        List<CarRentalInfo> carRentInfo;
        public ActionResult Index()
        {
            using (var dbContext = new CarRentalContext())
            {
                List<CarRentalInfo> carRentEnd = dbContext.CarRentalInfos.Where(m => m.EndDate < DateTime.Today).ToList();
                List<CarRentalInfo> carRentCancel= dbContext.CarRentalInfos.Where(m => m.Cancel < DateTime.Today).ToList();

                bool cancelTarihi=dbContext.CarRentalInfos.Any(m => m.Cancel == null);
                if (!cancelTarihi)
                {
                    for (int i = 0; i < carRentCancel.Capacity; i++)
                    {
                        dbContext.CarRentalInfos.Remove(carRentCancel[i]);
                        dbContext.SaveChanges();
                    }
                }

                bool endTarihi = dbContext.CarRentalInfos.Any(m => m.EndDate == null);
                if (!endTarihi)
                {
                    for (int j = 0; j < carRentEnd.Capacity; j++)
                    {

                        dbContext.CarRentalInfos.Remove(carRentEnd[j]);
                        dbContext.SaveChanges();
                    }
                }
                carRentInfo = dbContext.CarRentalInfos.ToList();
               
            }
            return View(carRentInfo);
        }
        [HttpGet]
        public ActionResult Create()
        {
            using(var dbContext=new CarRentalContext())
            {
                var allCar = dbContext.Cars.ToList();
                var allCustomer = dbContext.Customers.ToList();
                //var allBrand = dbContext.Brands.ToList();
               

                ViewBag.AllCar = allCar;
                //ViewBag.AllBrand = allBrand;
                ViewBag.AllCustomer = allCustomer;
               

            
                ViewBag.carSelectList = new SelectList(allCar, "Id", "Plate",1);
                //ViewBag.brandNameSelectList = new SelectList(allBrand, "Id", "BrandName");
                //ViewBag.brandModelSelectList = new SelectList(allBrand, "Id", "Model");
                ViewBag.customerSelectList = new SelectList(allCustomer, "Id", "FullName");

                return View();
            }
        }
        [HttpPost]
        public ActionResult Create(CarRentalInfo carRentInfo)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            using (var dbcontext = new CarRentalContext())
            {                            
                int id = carRentInfo.CarId;

                bool var=dbcontext.CarRentalInfos.Any(m => m.CarId==id);
                DateTime start = carRentInfo.StartingDate;
                DateTime end = carRentInfo.EndDate;
                
                if (var)
                {
                   DateTime availableEndDate= dbcontext.CarRentalInfos.SingleOrDefault(m => m.CarId == id).EndDate;
                    DateTime? availableCancel= dbcontext.CarRentalInfos.SingleOrDefault(m => m.CarId == id).Cancel;

                    if ((start <= availableEndDate || end <= availableEndDate)||(start<=availableCancel||end<=availableCancel))
                    {
                        TempData["msg"] = "Bu araba zaten kiralanmış";
                        return RedirectToAction("Create", "CarRentalInfo");
                    }
                  
                }
                
                int custId = carRentInfo.CustomerId;
               bool varMi=dbcontext.Customers.FirstOrDefault(m => m.Id == custId).Licence;
                if (varMi)
                {
                    dbcontext.CarRentalInfos.Add(carRentInfo);
                    dbcontext.SaveChanges();
                }
                else
                {
                    TempData["Message"] = "Ehliyeti olmayan araba kiralayamaz";
                    return RedirectToAction("Create", "CarRentalInfo");
                }
               
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            using(var db =new CarRentalContext())
            {
                var allCar = db.Cars.ToList();
                var allCustomer = db.Customers.ToList();
                //var allBrand = db.Brands.ToList();


                ViewBag.AllCar = allCar;
                //ViewBag.AllBrand = allBrand;
                ViewBag.AllCustomer = allCustomer;



                ViewBag.carSelectList = new SelectList(allCar, "Id", "Plate");
                //ViewBag.brandNameSelectList = new SelectList(allBrand, "Id", "BrandName");
                //ViewBag.brandModelSelectList = new SelectList(allBrand, "Id", "Model");
                ViewBag.customerSelectList = new SelectList(allCustomer, "Id", "FullName");
            }
          

            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }

            using (var dbContext = new CarRentalContext())
            {
                var carRentInfo = dbContext.CarRentalInfos.Find(id.Value);
                return View(carRentInfo);
            }

        }
        [HttpPost]
        public ActionResult Edit(CarRentalInfo carRentInfo)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            using (var dbContext = new CarRentalContext())
            {
                int id = carRentInfo.CarId;

                bool var = dbContext.CarRentalInfos.Any(m => m.CarId == id);
                DateTime start = carRentInfo.StartingDate;
                DateTime end = carRentInfo.EndDate;

                if (var)
                {
                    DateTime availableEndDate = dbContext.CarRentalInfos.SingleOrDefault(m => m.CarId == id).EndDate;
                    DateTime? availableCancel = dbContext.CarRentalInfos.SingleOrDefault(m => m.CarId == id).Cancel;

                    if ((start <= availableEndDate && end <= availableEndDate) || (start <= availableCancel && end <= availableCancel))
                    {
                        TempData["msg"] = "Bu araba zaten kiralanmış";
                        return RedirectToAction("Create", "CarRentalInfo");
                    }

                    var carEntry = dbContext.Entry(carRentInfo);
                    carEntry.State = EntityState.Modified;
                    dbContext.SaveChanges();
                }

                int custId = carRentInfo.CustomerId;
                bool varMi = dbContext.Customers.FirstOrDefault(m => m.Id == custId).Licence;
                if (varMi)
                {
                    var carEntry = dbContext.Entry(carRentInfo);
                    carEntry.State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
                else
                {
                    TempData["Message"] = "Ehliyeti olmayan araba kiralayamaz";
                    return RedirectToAction("Create", "CarRentalInfo");
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
                var carRentInfo = dbContext
                    .CarRentalInfos
                    .SingleOrDefault(c => c.Id == id.Value);

                return View(carRentInfo);
            }

        }
        [HttpPost]
        public ActionResult Delete(CarRentalInfo carRentInfo)
        {
            using (var dbContext = new CarRentalContext())
            {
               
                

                var carEntry = dbContext.Entry(carRentInfo);
                carEntry.State = EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}