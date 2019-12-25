namespace CarRental.Migrations
{
    using CarRental.Models.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarRental.Models.CarRentalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CarRental.Models.CarRentalContext context)
        {
            var color01 = new Color()
            {
               
                CarColor = "Red"
            };
            var color02 = new Color()
            {
                
                CarColor = "Green"
            };
            var color03 = new Color()
            {
               
                CarColor = "Blue"
            };
            var color04 = new Color()
            {
               
                CarColor = "Yellow"
            };
            var color05 = new Color()
            {
               
                CarColor = "Black"
            };
            var color06 = new Color()
            {
                
                CarColor = "Brown"
            };
            var color07 = new Color()
            {
               
                CarColor = "White"
            };
            var color08 = new Color()
            {
              
                CarColor = "DarkBlue"
            };
            var color09 = new Color()
            {
               
                CarColor = "Aqua"
            };
            var color10 = new Color()
            {
               
                CarColor = "DarkRed"
            };

            var brand01 = new Brand()
            {
                BrandName = "Seat"
            };
            var brand02 = new Brand()
            {
                BrandName = "Toyota"
            };
            var brand03 = new Brand()
            {
                BrandName = "Opel"
            };
            var brand04 = new Brand()
            {
                BrandName = "Wolkswagen"
            };
            var brand05 = new Brand()
            {
                BrandName = "Peugeot"
            };
            var brand06 = new Brand()
            {
                BrandName = "Nissan"
            };
            var brand07 = new Brand()
            {
                BrandName = "Audi"
            };
            var brand08 = new Brand()
            {
                BrandName = "BMW"
            };
            var brand09 = new Brand()
            {
                BrandName = "Alfa Romeo"
            };
            var brand10 = new Brand()
            {
                BrandName = "Dacia"
            };
            var brand11 = new Brand()
            {
                BrandName = "Fiat"
            };
            var brand12 = new Brand()
            {
                BrandName = "Ford"
            };
            var brand13 = new Brand()
            {
                BrandName = "Hyundai"
            };
            var brand14 = new Brand()
            {
                BrandName = "Honda"
            };
            var brand15 = new Brand()
            {
                BrandName = "Mazda"
            };
            var brand16 = new Brand()
            {
                BrandName = "Skoda"
            };
            var brand17 = new Brand()
            {
                BrandName = "Renault"
            };
            var brand18 = new Brand()
            {
                BrandName = "Tofaþ"
            };
            var brand19 = new Brand()
            {
                BrandName = "Volvo"
            };

            var model01 = new ModelOfBrand()
            {
                BrandId = 11,
                Model = "Toledo"
            };

            var model02 = new ModelOfBrand()
            {
                BrandId = 11,
                Model = "Ateca"
            };

            var model03 = new ModelOfBrand()
            {
                BrandId = 11,
                Model = "Leon"
            };
            var model04= new ModelOfBrand()
            {
                BrandId = 11,
                Model = "Ibiza"
            };
            var model05 = new ModelOfBrand()
            {
                BrandId = 12,
                Model = "Corolla"
            };
            var model06 = new ModelOfBrand()
            {
                BrandId = 12,
                Model = "Camry"
            };
            var model07 = new ModelOfBrand()
            {
                BrandId = 12,
                Model = "Auris"
            };
            var model08 = new ModelOfBrand()
            {
                BrandId = 12,
                Model = "C-HR"
            };
            var model09 = new ModelOfBrand()
            {
                BrandId = 12,
                Model = "Yaris"
            };
            var model10 = new ModelOfBrand()
            {
                BrandId = 13,
                Model = "Meriva"
            };
            var model11 = new ModelOfBrand()
            {
                BrandId = 13,
                Model = "Corsa"
            };
            var model12 = new ModelOfBrand()
            {
                BrandId = 13,
                Model = "Astra"
            };
            var model13 = new ModelOfBrand()
            {
                BrandId = 13,
                Model = "Insignia"
            };
            var model14 = new ModelOfBrand()
            {
                BrandId = 13,
                Model = "Mokka"
            };
            var model15 = new ModelOfBrand()
            {
                BrandId = 14,
                Model = "Passat"
            };
            var model16 = new ModelOfBrand()
            {
                BrandId = 14,
                Model = "Polo"
            };
            var model17 = new ModelOfBrand()
            {
                BrandId = 14,
                Model = "Golf"
            };
            var model18 = new ModelOfBrand()
            {
                BrandId = 14,
                Model = "Arteon"
            };
            var model19 = new ModelOfBrand()
            {
                BrandId = 15,
                Model = "208"
            };
            var model20 = new ModelOfBrand()
            {
                BrandId = 15,
                Model = "301"
            };
            var model21 = new ModelOfBrand()
            {
                BrandId = 15,
                Model = "308"
            };
            var model22 = new ModelOfBrand()
            {
                BrandId = 16,
                Model = "Juke"
            };
            var model23 = new ModelOfBrand()
            {
                BrandId = 16,
                Model = "Micra"
            };
            var model24 = new ModelOfBrand()
            {
                BrandId = 16,
                Model = "Qashqai"
            };

            var model25 = new ModelOfBrand()
            {
                BrandId = 17,
                Model = "A3"
            };
            var model26 = new ModelOfBrand()
            {
                BrandId = 17,
                Model = "A4"
            };
            var model27 = new ModelOfBrand()
            {
                BrandId = 17,
                Model = "A5"
            };
            var model28 = new ModelOfBrand()
            {
                BrandId = 17,
                Model = "A6"
            };
            var model29 = new ModelOfBrand()
            {
                BrandId = 18,
                Model = "1 serisi"
            };
            var model30 = new ModelOfBrand()
            {
                BrandId = 18,
                Model = "2 serisi"
            };
            var model31 = new ModelOfBrand()
            {
                BrandId = 18,
                Model = "3 serisi"
            };
            var model32 = new ModelOfBrand()
            {
                BrandId = 18,
                Model = "4 serisi"
            };
            var model33 = new ModelOfBrand()
            {
                BrandId = 18,
                Model = "5 serisi"
            };
            var model34 = new ModelOfBrand()
            {
                BrandId = 19,
                Model = "Giulietta"
            };
            var model35 = new ModelOfBrand()
            {
                BrandId = 19,
                Model = "Giulia"
            };
            var model36 = new ModelOfBrand()
            {
                BrandId = 20,
                Model = "Duster"
            };
            var model37 = new ModelOfBrand()
            {
                BrandId = 20,
                Model = "Sandero"
            };
            var model38 = new ModelOfBrand()
            {
                BrandId = 21,
                Model = "Egea"
            };
            var model39 = new ModelOfBrand()
            {
                BrandId = 21,
                Model = "500"
            };
            var model40 = new ModelOfBrand()
            {
                BrandId = 22,
                Model = "Fiesta"
            };
            var model41 = new ModelOfBrand()
            {
                BrandId = 22,
                Model = "Focus"
            };
            var model42 = new ModelOfBrand()
            {
                BrandId = 22,
                Model = "Mondeo"
            };
            var model43 = new ModelOfBrand()
            {
                BrandId = 22,
                Model = "Kuga"
            };
            var model44 = new ModelOfBrand()
            {
                BrandId = 23,
                Model = "i10"
            };
            var model45 = new ModelOfBrand()
            {
                BrandId = 23,
                Model = "i20"
            };
            var model46 = new ModelOfBrand()
            {
                BrandId = 23,
                Model = "i30"
            };
            var model47 = new ModelOfBrand()
            {
                BrandId = 23,
                Model = "Accent"
            };
            var model48 = new ModelOfBrand()
            {
                BrandId = 24,
                Model = "CR-V"
            };
            var model49 = new ModelOfBrand()
            {
                BrandId = 24,
                Model = "HR-V"
            };
            var model50 = new ModelOfBrand()
            {
                BrandId = 24,
                Model = "Cývýc"
            };
            var model51 = new ModelOfBrand()
            {
                BrandId = 25,
                Model = "Mazda6"
            };
            var model52 = new ModelOfBrand()
            {
                BrandId = 25,
                Model = "CX-5"
            };
            var model53 = new ModelOfBrand()
            {
                BrandId = 26,
                Model = "Fabia"
            };
            var model54 = new ModelOfBrand()
            {
                BrandId = 26,
                Model = "Rapid"
            };
            var model55 = new ModelOfBrand()
            {
                BrandId = 26,
                Model = "Octavia"
            };
            var model56 = new ModelOfBrand()
            {
                BrandId = 26,
                Model = "kodiaq"
            };
            var model57 = new ModelOfBrand()
            {
                BrandId = 27,
                Model = "Clio"
            };
            var model58 = new ModelOfBrand()
            {
                BrandId = 27,
                Model = "Capture"
            };
            var model59 = new ModelOfBrand()
            {
                BrandId = 27,
                Model = "Kadjar"
            };
            var model60 = new ModelOfBrand()
            {
                BrandId = 28,
                Model = "Þahin"
            };
            var model61 = new ModelOfBrand()
            {
                BrandId = 28,
                Model = "Kartal"
            };
            var model62 = new ModelOfBrand()
            {
                BrandId = 28,
                Model = "Doðan"
            };
            var model63 = new ModelOfBrand()
            {
                BrandId = 29,
                Model = "V40"
            };
            var model64 = new ModelOfBrand()
            {
                BrandId = 29,
                Model = "S60"
            };
            var model65 = new ModelOfBrand()
            {
                BrandId = 29,
                Model = "S40"
            };
            context.Colors.AddOrUpdate(color01, color02, color03, color04, color05, color06, color07, color08, color09, color10);          
            context.Brands.AddOrUpdate(brand01, brand02, brand03, brand04, brand05, brand06, brand07, brand08, brand09, brand10, brand11, brand12, brand13, brand14, brand15, brand16, brand17, brand18, brand19);
            context.ModelOfBrands.AddOrUpdate(model01, model02, model03, model04, model05, model06, model07, model08, model09, model10, model11, model12, model13, model14, model15, model16, model17, model18, model19, model20, model21, model22, model23, model24, model25, model26, model27, model28, model29, model30, model31, model32, model33, model34, model35, model36, model37, model38, model39, model40, model41, model42, model43, model44, model45, model46, model47, model48, model49, model50, model51, model52, model53, model54, model55, model56, model57, model58, model59, model60, model61, model62, model63, model64, model65);
           
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
