using CarReview.Data;
using CarReview.Models;

namespace CarReview
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.CarOwners.Any())
            {
                var CarOwners = new List<CarOwner>()
                {
                    new CarOwner()
                    {
                        Car = new Car()
                        {
                            Name = "Audi",
                            ProductionDate = new DateTime(1903,1,1),
                            CarCategories = new List<CarCategory>()
                            {
                                new CarCategory { Category = new Category() { Name = "Electric"}}
                            },
                            Awards = new List<Award>()
                            {
                                new Award { Title="Grand Prix 1", 
                                AwardProvider = new AwardProvider(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Award { Title="Grand Prix 2",
                                AwardProvider = new AwardProvider(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Award { Title="Grand Prix 3",
                                AwardProvider = new AwardProvider(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Jack",
              
                            Country = new Country()
                            {
                                Name = "Poland"
                            }
                        }
                    },
                    new CarOwner()
                    {
                        Car = new Car()
                        {
                            Name = "Bmw",
                            ProductionDate = new DateTime(1903,1,1),
                            CarCategories = new List<CarCategory>()
                            {
                                new CarCategory { Category = new Category() { Name = "Fast"}}
                            },
                            Awards = new List<Award>()
                            {
                                new Award { Title= "Grand Prix 11",
                                AwardProvider = new AwardProvider(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Award { Title= "Grand Prix 22",
                                AwardProvider = new AwardProvider(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Award { Title= "Grand Prix 33", 
                                AwardProvider = new AwardProvider(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Harry",
                            Country = new Country()
                            {
                                Name = "Saffron City"
                            }
                        }
                    },
                    new CarOwner()
                    {
                        Car = new Car()
                        {
                            Name = "Ford",
                            ProductionDate = new DateTime(1903,1,1),
                            CarCategories = new List<CarCategory>()
                            {
                                new CarCategory { Category = new Category() { Name = "Heavy"}}
                            },
                            Awards = new List<Award>()
                            {
                                new Award { Title="Grand Prix 111",
                                AwardProvider = new AwardProvider(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Award { Title="Grand Prix 222",
                                AwardProvider = new AwardProvider(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Award { Title="Grand Prix 333",
                                AwardProvider = new AwardProvider(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Ash",
  
                            Country = new Country()
                            {
                                Name = "Usa"
                            }
                        }
                    }
                };
                dataContext.CarOwners.AddRange(CarOwners);
                dataContext.SaveChanges();
            }
        }
    }
}