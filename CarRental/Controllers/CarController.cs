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
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            List<Car> CarList;
            using (var dbcontext = new CarRentalContext())
            {
                CarList = dbcontext.Cars.ToList();

                var allBrands = dbcontext.Brands.ToList();

                ViewBag.AllBrands = allBrands;
                ViewBag.brandSelectList = new SelectList(allBrands, "Id", "BrandName");
                ViewBag.brandModelList = new SelectList(allBrands, "Id", "Model");

            }
            return View(CarList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            using(var dbContext=new CarRentalContext())
            {
                
                var allModels = dbContext.ModelOfBrands.ToList();
                var allColor = dbContext.Colors.ToList();

                var FuelTypelist = new List<SelectListItem>
               {
                new SelectListItem
                {Text="Benzin",Value="Benzin" ,Selected=true},
                new SelectListItem
                { Text="LPG",Value="LPG"},
                new SelectListItem
                {Text="Dizel",Value="Dizel" },
               };

                var EngineCap = new List<SelectListItem>
                    {
                    new SelectListItem
                    {Text="1.2",Value="1.2" ,Selected=true},
                    new SelectListItem
                    { Text="1.4",Value="1.4"},
                    new SelectListItem
                    {Text="1.6",Value="1.6" },
                    new SelectListItem
                    {Text="1.8",Value="1.8"},
                    new SelectListItem
                    { Text="2.0",Value="2.0"},
                    new SelectListItem
                    {Text="2.2",Value="2.2" },
                    };

                var EnginePow = new List<SelectListItem>
                    {
                    new SelectListItem
                    {Text="90",Value="90" ,Selected=true},
                    new SelectListItem
                    { Text="95",Value="95"},
                    new SelectListItem
                    {Text="100",Value="100" },
                    new SelectListItem
                    {Text="105",Value="105"},
                    new SelectListItem
                    { Text="110",Value="110"},
                    new SelectListItem
                    {Text="120",Value="120" },
                    };
                ViewBag.AllModels = allModels;
                ViewBag.AllColor = allColor;
                
                ViewBag.modelSelectList = new SelectList(allModels, "Id", "Model");
                ViewBag.colorSelectList = new SelectList(allColor, "Id", "CarColor");
                
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(Car car)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            decimal hirePrice = 0;
                    
            bool decimalMi= decimal.TryParse(car.HirePrice, out hirePrice);         

            string Plaka = car.Plate;
                            
            var db = new CarRentalContext();
            bool plakaVarMı=db.Cars.Any(m => m.Plate == Plaka);
            db.Dispose();

            if (!plakaVarMı)
            {                                                
                    if (decimalMi)
                    {
                    //string[] array = new string[7];
                    //int a = 0;
                    //for (int i = 0; i < array.Length; i++)
                    //{
                    //    array[i] = Plaka[i].ToString();

                    //}
                    //if (int.TryParse(array[0], out a) && int.TryParse(array[1], out a) && !int.TryParse(array[2], out a) && !int.TryParse(array[3], out a) && int.TryParse(array[4], out a) && int.TryParse(array[5], out a) && int.TryParse(array[6], out a) && int.TryParse(array[7], out a))
                    //{
                                                       
                        using (var dbcontext = new CarRentalContext())
                        {

                            dbcontext.Cars.Add(car);
                            dbcontext.SaveChanges();
                        }
                    
                 
                        //}
                        //else
                        //{
                        //    TempData["plakaFormat"] = "Plaka formatı yanlış girildi.Örnek format 11aa2222";
                        //    return RedirectToAction("Create", "Car");
                        //}                      
                    }
                    else if(!decimalMi)
                    {
                        TempData["ms"] = "Bu alana harf giremezsiniz";
                        return RedirectToAction("Create", "Car");

                    }                                           
              
            }//aynı plaka varsa hata verir
            else
            {
                TempData["plaka"] = "Aynı plakaya sahip araba zaten var";
                return RedirectToAction("Create", "Car");
            }
                      
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }                

            using (var dbContext = new CarRentalContext())
            {
                var allModels = dbContext.ModelOfBrands.ToList();
                var allColors = dbContext.Colors.ToList();

                ViewBag.AllModels = allModels;
                ViewBag.AllColors = allColors;

                ViewBag.modelSelectList = new SelectList(allModels, "Id", "Model");
                ViewBag.colorSelectList = new SelectList(allColors, "Id", "CarColor");

                var car = dbContext.Cars.Find(id.Value);
                return View(car);
            }

        }
        [HttpPost]
        public ActionResult Edit(Car car)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            decimal hirePrice = 0;

            bool decimalMi = decimal.TryParse(car.HirePrice, out hirePrice);
                     
                if (decimalMi)
                {
                    using (var dbContext = new CarRentalContext())
                    {
                        
                        var carEntry = dbContext.Entry(car);
                        carEntry.State = EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                }
                else if(!decimalMi)
                {
                    TempData["ms"] = "Bu alana harf giremezsiniz";
                    return RedirectToAction("Edit", "Car");
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
                var car = dbContext
                    .Cars
                    .SingleOrDefault(c => c.Id == id.Value);

                return View(car);
            }

        }
        [HttpPost]
        public ActionResult Delete(Car car)
        {
            using (var dbContext = new CarRentalContext())
            {
                var carEntry = dbContext.Entry(car);
                carEntry.State = EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}